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
        ConsoleKey lastKey = 0;
        bool isKeyDown = false;
        public void Init()
        {
        }

        public void Update()
        {
            isKeyDown = false;
            lastKey = key;
            key = 0;
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey().Key;
                isKeyDown = true;
            }
        }
        public ConsoleKey KeyDown()
        {
            return key;
        }
        public bool GetIsKeyDown()
        {
            return isKeyDown;
        }

        public bool GetKeyDown(ConsoleKey _key)
        {
            return _key == key;// 이거말고 다른함수 었으면 작동했을텐데 안됨
        }

        public bool GetKeyUp(ConsoleKey _key)
        {
            return _key != key && _key == lastKey;
        }

        public bool GetKeyDownOnce(ConsoleKey _key)
        {
            return _key == key && key != lastKey;
        }
    }
}
