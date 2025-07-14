using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Character
{
    public static class RaceStatusFactory
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
    }
}
