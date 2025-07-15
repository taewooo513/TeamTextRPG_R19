using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Character
{
    public static class ExpTable
    {
        public static int maxLevel = 10;


        public static int GetExpToNextLevel(int currentLevel)
        {
            if (currentLevel >= maxLevel)
            {
                return 0;
            }

            if (currentLevel == 1)
            {
                return 10;
            }
            else
            {
                return (int)Math.Pow(currentLevel - 1, 2) + 10; // Lv.3 필요 경험치 : (2 - 1)^2 + 10
            }
        }
    }
}
