using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Game.Object.Enemy;

namespace TeamRPG.Game.Character
{
    public static class StatusFactory
    {
        public static Status GetStatusByRace(Race race)
        {
            switch (race)
            {
                case Race.Human:
                    return new Status(70, 50, 12, 16, 30, 50, 10);
                case Race.Dwarf:
                    return new Status(80, 40, 14, 15, 10, 70, 10);
                case Race.HalfElf:
                    return new Status(65, 70, 8, 18, 50, 30, 10);
                default:
                    throw new System.ArgumentException("Unknown race");
            }
        }
        public static Enemy.State GetStatusByEnemy(eEnemyNum enemyNum) // (int _hp, string _name, int _dmg, int _def, int _mgDef, int _dex, int _exDmg)
        {
            switch (enemyNum)
            {
                case eEnemyNum.eWolf:
                    return new Enemy.State(32, "Wolf", 5, 0, 0, 30, 25);
                default:
                    throw new System.ArgumentException("Unknown race");
            }
        }


        public static Status Clone(Status source)
        {
            if (source == null)
                return null;

            return new Status(
                        source.HP,
                        source.MP,
                        source.MinAttack,
                        source.MaxAttack,
                        source.Agility,
                        source.Tenacity,
                        source.Luck
                );
        }
        public static Status EmptyStatus
        {
            get
            {
                return new Status(0, 0, 0, 0, 0, 0, 0);
            }
        }
    }
}
