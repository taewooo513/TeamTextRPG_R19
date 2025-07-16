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
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].isDie == true)
                    enemies.Remove(enemies[i]);
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
