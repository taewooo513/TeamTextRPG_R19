using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Enemy;
using TeamRPG.Core.QuestManager;
using TeamRPG.Core.EncounterManager;

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
        eGhost,
        eSwordsman,

        // 보스
        eBoss,

        // 인카운터
        // 
    }

    public enum eEnvironmentType
    {
        eWilderness,
        eDevildom,
        eForest,
        eCemetery,
        eNone
    }

    public enum eEnemyTier
    {
        Normal,
        Elite,
        Boss
    }

    public class EnemyManager : Singleton<EnemyManager>
    {
        public int CycleCount = 1;
        public static eEnemyTier NowMonsterTier; // 현재 몬스터 티어

        List<(Enemy, eEnemyNum)> initialEnemies = new(); // GameScene이 시작되면 생성할 적들
        List<Enemy> enemies;

        Dictionary<eEnvironmentType, List<eEnemyNum>> environmentEnemyDictionary = new()
        {
            { eEnvironmentType.eWilderness, new List<eEnemyNum> { eEnemyNum.eGoblin, eEnemyNum.eOgre, eEnemyNum.eTroll } },
            { eEnvironmentType.eDevildom, new List<eEnemyNum> { eEnemyNum.eImp, eEnemyNum.eSuccubus, eEnemyNum.eArchdemon } },
            { eEnvironmentType.eForest, new List<eEnemyNum> { eEnemyNum.eWolf, eEnemyNum.eWildBoar, eEnemyNum.eCentaur } },
            { eEnvironmentType.eCemetery, new List<eEnemyNum> { eEnemyNum.eSkeleton, eEnemyNum.eZombie, eEnemyNum.eLich } },
            { eEnvironmentType.eNone, new List<eEnemyNum>() { eEnemyNum.eSlime, eEnemyNum.eGolem, eEnemyNum.eMimic, eEnemyNum.eBandit, eEnemyNum.eSwordsman, eEnemyNum.eGhost, eEnemyNum.eBoss } }
        };

        Dictionary<eEnemyNum, eEnemyTier> enemyTierDictionary = new()
        {
            // 일반 몬스터
            { eEnemyNum.eWolf, eEnemyTier.Normal },
            { eEnemyNum.eGoblin, eEnemyTier.Normal },
            { eEnemyNum.eSkeleton, eEnemyTier.Normal },
            { eEnemyNum.eImp, eEnemyTier.Normal },

            { eEnemyNum.eSlime, eEnemyTier.Normal },
            { eEnemyNum.eBandit, eEnemyTier.Normal },
            { eEnemyNum.eGhost, eEnemyTier.Normal },
            { eEnemyNum.eSwordsman, eEnemyTier.Normal },

            // 정예 몬스터
            { eEnemyNum.eWildBoar, eEnemyTier.Elite },

            { eEnemyNum.eOgre, eEnemyTier.Elite },

            { eEnemyNum.eZombie, eEnemyTier.Elite },

            { eEnemyNum.eSuccubus, eEnemyTier.Elite },
            { eEnemyNum.eGolem, eEnemyTier.Elite },
            { eEnemyNum.eMimic, eEnemyTier.Elite },

            // 보스
            { eEnemyNum.eBoss, eEnemyTier.Boss },

            { eEnemyNum.eCentaur, eEnemyTier.Boss },

            { eEnemyNum.eTroll, eEnemyTier.Boss },

            { eEnemyNum.eLich, eEnemyTier.Boss },

            { eEnemyNum.eArchdemon, eEnemyTier.Boss },

        };

        public eEnemyNum GetRegionWeightedEnemy(eEnvironmentType envType, List<eEnemyTier> allowedTiers, int regionRate = 70)
        {
            Random random = new();
            int roll = random.Next(0, 100); // 0~99

            // 전체 몬스터 리스트
            List<eEnemyNum> allMonsters = Enum.GetValues<eEnemyNum>().ToList();

            // eNone 지역 몬스터 제거
            if (environmentEnemyDictionary.TryGetValue(eEnvironmentType.eNone, out var noneEnemies))
                allMonsters.RemoveAll(e => noneEnemies.Contains(e));

            allMonsters = allMonsters
                .Where(e => enemyTierDictionary.ContainsKey(e) && allowedTiers.Contains(enemyTierDictionary[e]))
                .ToList();

            bool useRegion = roll < regionRate;
            List<eEnemyNum> candidateList;

            if (useRegion && environmentEnemyDictionary.TryGetValue(envType, out var regionEnemies))
            {
                candidateList = regionEnemies
                    .Where(e => allMonsters.Contains(e)) // eNone 및 티어 필터된 몬스터 중 해당 지역 몬스터만
                    .ToList();
            }
            else
            {
                var regionSet = environmentEnemyDictionary.ContainsKey(envType)
                    ? environmentEnemyDictionary[envType].ToHashSet()
                    : new HashSet<eEnemyNum>();

                candidateList = allMonsters
                    .Where(e => !regionSet.Contains(e))
                    .ToList();
            }

            if (candidateList.Count == 0)
                return allMonsters[random.Next(allMonsters.Count)];

            return candidateList[random.Next(candidateList.Count)];
        }

        /*
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
        */

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

            // 8회차는 보스 인트로 씬으로 전환
            if (CycleCount >= 8)
            {
                if (!QuestManager.QuestManager.GetInstance().IsQuestting && !EncounterManager.EncounterManager.GetInstance().IsEncountering)
                {
                    SceneManager.SceneManager.GetInstance().ChangeScene("BossIntroScene");
                    return;
                }
            }

            List<eEnemyTier> tierList = new();

            if (CycleCount <= 1)
            {
                tierList = new List<eEnemyTier> { eEnemyTier.Normal }; // 1회차는 일반 몬스터만
            }
            else if (CycleCount == 2)
            {
                tierList = new List<eEnemyTier> { eEnemyTier.Normal, eEnemyTier.Elite }; // 2회차는 일반 + 정예 몬스터
            }
            else
            {
                tierList = new List<eEnemyTier> { eEnemyTier.Elite, eEnemyTier.Boss }; // 4회차부터는 일반 + 정예 + 보스 몬스터
            }

            eEnemyNum enemyNum = GetRegionWeightedEnemy(environmentType, tierList);
            Enemy? enemy = EnemyFactory.CreateEnemy(enemyNum);


            // 고블린 스켈레톤으 3마리씩 추가
            if (enemyNum == eEnemyNum.eGoblin)
            {
                Enemy enemy1 = new Goblin(-35, 5, "1");
                Enemy enemy2 = new Goblin(0, 5, "2");
                Enemy enemy3 = new Goblin(35, 5, "3");

                AddInitialEnemy(enemy1, eEnemyNum.eGoblin); // 초기 적 추가
                AddInitialEnemy(enemy2, eEnemyNum.eGoblin); // 초기 적 추가
                AddInitialEnemy(enemy3, eEnemyNum.eGoblin); // 초기 적 추가
            }
            else if(enemyNum == eEnemyNum.eSkeleton)
            {
                Enemy enemy1 = new Skeleton(40, 5, "1");
                Enemy enemy2 = new Skeleton(75, 5, "2");
                Enemy enemy3 = new Skeleton(110, 5, "3");

                AddInitialEnemy(enemy1, eEnemyNum.eSkeleton); // 초기 적 추가
                AddInitialEnemy(enemy2, eEnemyNum.eSkeleton); // 초기 적 추가
                AddInitialEnemy(enemy3, eEnemyNum.eSkeleton); // 초기 적 추가
            }
            else
            {
                while (enemy == null)
                {
                    enemyNum = GetRegionWeightedEnemy(environmentType, tierList);
                    enemy = EnemyFactory.CreateEnemy(enemyNum);
                }

                AddInitialEnemy(enemy, enemyNum);
            }

            NowMonsterTier = enemyTierDictionary[enemyNum]; // 현재 몬스터 티어 설정
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
            if (enemies == null)
                enemies = new();

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
