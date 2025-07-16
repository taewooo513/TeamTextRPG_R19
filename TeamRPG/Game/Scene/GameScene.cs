using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Enemy;

namespace TeamRPG.Game.Scene
{
    public class GameScene : Core.SceneManager.Scene
    {
        Enemy e;
        Enemy e1;
        Enemy e2;
        int selectNum = 0;
        public void Init()
        {
            selectNum = 0;
            e1 = new Goblin(-30, 0, "A");
            EnemyManager.GetInstance().AddEnemy(e1, eEnemyNum.eGoblin);
            e = new Goblin(0, 5, "B");
            EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eGoblin);
            e2 = new Goblin(30, 0, "C");
            EnemyManager.GetInstance().AddEnemy(e2, eEnemyNum.eGoblin);
            e.EnemyTurnSetting();

        }

        public void Release()
        {
        }

        public void Render()
        {
            //PlayerManager.GetInstance().GetPlayer().UIRender();

            int uiY = 0;
            EnemyManager.GetInstance().GetEnemyList().ForEach(e =>
            {
                e.EnemyUIBar(uiY);
                uiY += 3;
            });
            int arrUiX = 0;
            foreach (var item in e.GetKeyPad().ToList())
            {
                arrUiX += 3;
                switch (item)
                {
                    case ConsoleKey.UpArrow:
                        TextIOManager.GetInstance().OutputText4Byte("↑", 14 + arrUiX, 32);
                        break;
                    case ConsoleKey.RightArrow:
                        TextIOManager.GetInstance().OutputText4Byte("→", 14 + arrUiX, 32);
                        break;
                    case ConsoleKey.DownArrow:
                        TextIOManager.GetInstance().OutputText4Byte("↓", 14 + arrUiX, 32);
                        break;
                    case ConsoleKey.LeftArrow:
                        TextIOManager.GetInstance().OutputText4Byte("←", 14 + arrUiX, 32);
                        break;
                }

            }
        }



        public void Update()
        {
            PlayerManager.GetInstance().GetPlayer().Update();
            e.InputKeyPad();
        }
    }

}