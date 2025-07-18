using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Object.Enemy;

namespace TeamRPG.Core.EnemyManager
{
    public enum eEnemyNum
    {
        eWolf,
        eWildBoar,
        eCentaur,
        eSkeleton,
        eZombie,
        eLich,
        eLich2,
        eGoblin,
        eOgre,
        eTroll,
        eImp,
        eSuccubus,
        eArchdemon,
        eSlime,
        eGolem,
        eMimic,
        eBoss,
        eBandit
    }
    public class EnemyManager : Singleton<EnemyManager>
    {
        List<(Enemy, eEnemyNum)> initialEnemies = new(); // GameScene이 시작되면 생성할 적들
        List<Enemy> enemies;

        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }

        public void AddInitialEnemy((Enemy, eEnemyNum) enemy)
        {
            if(initialEnemies == null)
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
