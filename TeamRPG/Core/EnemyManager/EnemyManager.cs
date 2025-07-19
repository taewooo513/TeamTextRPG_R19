using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Enemy;

namespace TeamRPG.Core.EnemyManager
{
    public enum eEnemyNum
    {
        // 숲
        eWolf,
        eWildBoar,
        eCentaur,
        eBandit,

        // 황야
        eGoblin,
        eOgre,
        eTroll,

        // 묘지
        eSkeleton,
        eZombie,
        eLich,
        eLich2,

        // 마계
        eImp,
        eSuccubus,
        eArchdemon,

        // 공용
        eSlime,
        eGolem,
        eMimic,

        // 보스
        eBoss,

        // 인카운터
        // eSwordsman
    }

    public enum eEnvironmentType
    {
        eWilderness,
        eDevildom,
        eForest,
        eCemetery,
        eNone
    }

    public class EnemyManager : Singleton<EnemyManager>
    {
        List<(Enemy, eEnemyNum)> initialEnemies = new(); // GameScene이 시작되면 생성할 적들
        List<Enemy> enemies;

        Dictionary<eEnvironmentType, List<eEnemyNum>> environmentEnemyDictionary = new()
        {
            { eEnvironmentType.eWilderness, new List<eEnemyNum> { eEnemyNum.eGoblin, eEnemyNum.eOgre, eEnemyNum.eTroll } },
            { eEnvironmentType.eDevildom, new List<eEnemyNum> { eEnemyNum.eImp, eEnemyNum.eSuccubus, eEnemyNum.eArchdemon } },
            { eEnvironmentType.eForest, new List<eEnemyNum> { eEnemyNum.eWolf, eEnemyNum.eWildBoar, eEnemyNum.eCentaur, eEnemyNum.eBandit } },
            { eEnvironmentType.eCemetery, new List<eEnemyNum> { eEnemyNum.eSkeleton, eEnemyNum.eZombie, eEnemyNum.eLich, eEnemyNum.eLich2 } },
            { eEnvironmentType.eNone, new List<eEnemyNum>() { eEnemyNum.eSlime, eEnemyNum.eGolem, eEnemyNum.eMimic } }
        };

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }
        public eEnemyNum GetRegionWeightedEnemy(eEnvironmentType envType, int regionRate = 80)
        {
            Random random = new();
            int roll = random.Next(0, 100); // 0~99

            // 전체 몬스터 리스트
            List<eEnemyNum> allMonsters = Enum.GetValues<eEnemyNum>().ToList();

            // 특정 지역 몬스터 제거 (예: eNone 지역 몬스터 제거)
            if (environmentEnemyDictionary.ContainsKey(eEnvironmentType.eNone))
            {
                var excluded = environmentEnemyDictionary[eEnvironmentType.eNone];
                allMonsters.RemoveAll(e => excluded.Contains(e));
            }

            // 일반적인 지역 가중치 처리
            bool useRegion = roll < regionRate;

            List<eEnemyNum> candidateList;

            if (useRegion && environmentEnemyDictionary.ContainsKey(envType))
            {
                candidateList = environmentEnemyDictionary[envType].ToList();
            }
            else
            {
                // 해당 지역 몬스터를 제외한 전체 리스트
                var region = environmentEnemyDictionary.ContainsKey(envType)
                    ? environmentEnemyDictionary[envType].ToHashSet()
                    : new();

                candidateList = allMonsters
                    .Where(e => !region.Contains(e))
                    .ToList();
            }

            if (candidateList.Count == 0)
                return allMonsters[random.Next(allMonsters.Count)];

            return candidateList[random.Next(candidateList.Count)];
        }

        public eEnvironmentType CurrentEnvironmentType()
        {
            eEnvironmentType environmentType = PlayerManager.GetInstance().environment switch
            {
                "ForestScene" => eEnvironmentType.eForest,
                "WildernessScene" => eEnvironmentType.eWilderness,
                "DevildomScene" => eEnvironmentType.eDevildom,
                "CemeteryScene" => eEnvironmentType.eCemetery,
                _ => eEnvironmentType.eNone,
            };

            return environmentType;
        }

        public void InitInitialEnemy(eEnvironmentType environmentType)
        {
            if (!environmentEnemyDictionary.ContainsKey(environmentType)) return;

            /*
            // 환경 몬스터 추가
            List<eEnemyNum> enemyList = environmentEnemyDictionary[environmentType];

            // 공용 몬스터 종류 추가
            if (environmentType != eEnvironmentType.eNone && environmentEnemyDictionary.ContainsKey(eEnvironmentType.eNone))
                enemyList.AddRange(environmentEnemyDictionary[eEnvironmentType.eNone]);

            if (enemyList.Count == 0) return;
            // 랜덤으로 환경에 맞는 몬스터 선택
            Random random = new Random();
            int randomIndex = random.Next(enemyList.Count);
            eEnemyNum randomEnemyNum = enemyList[randomIndex];

            // 생성할 몬스터 초기화
            Enemy enemy = EnemyFactory.CreateEnemy(randomEnemyNum);
            AddInitialEnemy(enemy, randomEnemyNum);
            
            */
            eEnemyNum enemyNum = GetRegionWeightedEnemy(environmentType, 70);
            Enemy? enemy = EnemyFactory.CreateEnemy(enemyNum);

            while(enemy == null)
            {
                enemyNum = GetRegionWeightedEnemy(environmentType, 70);
                enemy = EnemyFactory.CreateEnemy(enemyNum);
            }

            AddInitialEnemy(enemy, enemyNum);
        }

        public void AddInitialEnemy((Enemy, eEnemyNum) enemy)
        {
            if (initialEnemies == null)
                initialEnemies = new();

            if (initialEnemies.Count > 3) return;


            if (!initialEnemies.Contains(enemy))
                initialEnemies.Add(enemy);
        }


        public void AddInitialEnemy(Enemy enemy, eEnemyNum eEnemyNum)
        {
            (Enemy, eEnemyNum) _enemy = new(enemy, eEnemyNum);

            if (initialEnemies == null)
                initialEnemies = new();

            if (initialEnemies.Count > 3) return;

            if (!initialEnemies.Contains(_enemy))
                initialEnemies.Add(_enemy);
        }


        public void RemoveInitialEnemy((Enemy, eEnemyNum) enemy)
        {
            if (initialEnemies == null)
                initialEnemies = new();

            if (initialEnemies.Contains(enemy))
                initialEnemies.Remove(enemy);
        }

        public void ClearInitialEnemies()
        {
            if (initialEnemies == null)
                initialEnemies = new();

            initialEnemies.Clear();
        }

        public List<(Enemy, eEnemyNum)> GetInitialEnemies()
        {
            if (initialEnemies == null)
                initialEnemies = new();

            return initialEnemies;
        }


        public Enemy AddEnemy(Enemy enemy, eEnemyNum eEnemyNum)
        {
            enemies.Add(enemy);
            enemy.SettingStatus(eEnemyNum);
            return enemy;
        }

        public void Update()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].isDie == true)
                {
                    enemies[i].Release();
                    enemies.Remove(enemies[i]);
                }
                else
                    enemies[i].Update();
            }
        }
        public List<Enemy> GetEnemyList()
        {
            return enemies;
        }

        public void Render()
        {
            foreach (var item in enemies)
            {
                item.Render();
            }
        }

        public void ClearEnemy()
        {
            enemies.Clear();
        }
    }
}
