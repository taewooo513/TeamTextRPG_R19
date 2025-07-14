using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core.UtilManager
{
    public class KeyInputManager : Singleton<KeyInputManager>
    {
        ConsoleKey key = 0;

        public void Init()
        {
        }

        public void Update()
        {
            key = 0;
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey().Key;
            }
        }


    }
}
