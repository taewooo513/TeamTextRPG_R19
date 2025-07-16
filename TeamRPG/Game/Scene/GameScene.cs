using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        bool isStartGame = false;
        Stopwatch timer;
        Enemy e;
        Enemy e1;
        Enemy e2;
        int selectNum = 0;
        public void Init()
        {
            isStartGame = false;
            timer = new Stopwatch();
            timer.Start();
            PlayerManager.GetInstance().GetPlayer().PlayerTurnSetting();
            PlayerManager.GetInstance().gameMsg = "고블린 3명을 마주쳤습니다.";
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
            PlayerManager.GetInstance().GetPlayer().UIRender();

            int uiY = 0;
            EnemyManager.GetInstance().GetEnemyList().ForEach(e =>
            {
                e.EnemyUIBar(uiY);
                uiY += 3;
            });
            ArroRender();
            TextIOManager.GetInstance().OutputSmartText(PlayerManager.GetInstance().gameMsg, 3, 1);
        }

        void ArroRender()
        {
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
            if (isStartGame == true)
            {
                if (PlayerManager.GetInstance().GetPlayer().isPlayerTurn == true)
                {
                    PlayerManager.GetInstance().GetPlayer().Update();
                }
            }
            if (timer.ElapsedMilliseconds >= 3000 && isStartGame == false)
            {
                isStartGame = true;
                PlayerManager.GetInstance().gameMsg = "플레이어의 턴";
            }
            // e.InputKeyPad();
        }
    }

}