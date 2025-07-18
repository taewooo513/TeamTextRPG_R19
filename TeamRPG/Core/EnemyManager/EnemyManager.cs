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
        eBoss
    }
    public class EnemyManager : Singleton<EnemyManager>
    {
        List<Enemy> enemies;

        public void Init()
        {
            enemies = new List<Enemy>();
        }

        public EnemyManager()
        {
            enemies = new List<Enemy>();
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
