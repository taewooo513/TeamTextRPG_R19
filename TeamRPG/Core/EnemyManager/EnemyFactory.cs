using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Object.Enemy;

namespace TeamRPG.Core.EnemyManager
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(eEnemyNum eEnemyNum)
        {
            int x = UIManager.HalfWidth;
            int y = 5;

            // 스위치 표현식
            Enemy enemy = eEnemyNum switch
            {
                eEnemyNum.eWolf => new Wolf(x, y, "Wolf"),
                eEnemyNum.eWildBoar => new WildBoar(x, y, "Wild Boar"),
                eEnemyNum.eCentaur => new Centaur(x, y, "Centaur"),
                eEnemyNum.eBandit => new Bandit(x, y, "Bandit"),
                eEnemyNum.eGoblin => new Goblin(x - 80, y, "Goblin"),
                eEnemyNum.eOgre => new Ogre(x, y, "Ogre"),
                eEnemyNum.eTroll => new Troll(x, y, "Troll"),
                eEnemyNum.eSkeleton => new Skeleton(x, y, "Skeleton"),
                eEnemyNum.eZombie => new Zombie(x, y, "Zombie"),
                eEnemyNum.eLich => new Lich(x, y, "Lich"),
                eEnemyNum.eLich2 => new Lich(x, y, "Lich2"),
                eEnemyNum.eImp => new Imp(x, y, "Imp"),
                eEnemyNum.eSuccubus => new Succubus(x, y, "Succubus"),
                eEnemyNum.eArchdemon => new Archdemon(x, y, "Archdemon"),
                eEnemyNum.eSlime => new Slime(x, y, "Slime"),
                eEnemyNum.eGolem => new Golem(x, y, "Golem"),
                eEnemyNum.eMimic => new Mimic(x, y, "Mimic"),
                eEnemyNum.eGhost => new Ghost(x, y, "Ghost"),
                eEnemyNum.eSwordsman => new Swordsman(x, y, "Swordsman"),
                _ => new Troll(x, y, "Troll")
            };

            return enemy;
        }
    }
}
