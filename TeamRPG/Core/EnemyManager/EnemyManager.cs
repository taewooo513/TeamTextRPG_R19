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
        eGoblin
    }
    public class EnemyManager : Singleton<EnemyManager>
    {
        List<Enemy> enemies;
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
            foreach (var item in enemies)
            {
                item.Update();
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
    }
}
