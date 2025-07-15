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
    }
    public class EnemyManager : Singleton<EnemyManager>
    {
        List<Enemy> enemies;
        public EnemyManager()
        {
            enemies = new List<Enemy>();
        }
        public void AddEnemy(eEnemyNum name)
        {
            //enemies.Add(new Enemy(name));
        }

        public void Update()
        {
            foreach (var item in enemies)
            {
                item.Update();
            }
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
