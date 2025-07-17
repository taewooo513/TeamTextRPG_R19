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
        int enemySelect = 0;
        public void Init()
        {
            enemySelect = 0;
            isStartGame = false;
            timer = new Stopwatch();
            timer.Start();

            PlayerManager.GetInstance().GetPlayer().PlayerTurnSetting();
            SoundManager.GetInstance().PlaySound("Bossmain", .1f);
            PlayerManager.GetInstance().gameMsg = "???을 마주쳤습니다.";
            selectNum = 0;
            //e1 = new Goblin(-30, 0, "A");
            //EnemyManager.GetInstance().AddEnemy(e1, eEnemyNum.eGoblin);
            e = new Boss(0, 5, "??");
            EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eBoss);
            //e2 = new Goblin(30, 0, "C");
            //EnemyManager.GetInstance().AddEnemy(e2, eEnemyNum.eGoblin);
        }

        public void Release()
        {
            SoundManager.GetInstance().StopSound("Bossmain");
            UIManager.GetInstance().ClearUI();
        }

        public void Render()
        {
            PlayerManager.GetInstance().GetPlayer().UIRender();

            int uiY = 0;
            EnemyManager.GetInstance().GetEnemyList().ForEach(e =>
            {
                e.EnemyUIBar(uiY);
                uiY += 3;
                if (e.GetKeyPad().Count != 0)
                {
                    e.ArroRender();
                }
            });
            TextIOManager.GetInstance().OutputSmartText(PlayerManager.GetInstance().gameMsg, 3, 1);
        }

        public void Update()
        {
            if (timer.ElapsedMilliseconds >= 3000 && isStartGame == false) // 시작시에 실행되는 첫번째 타이머
            {
                isStartGame = true;
                PlayerManager.GetInstance().gameMsg = "플레이어의 턴";
            }
            if (isStartGame == true)
            {
                if (PlayerManager.GetInstance().GetPlayer().isPlayerTurn == true)
                {
                    PlayerManager.GetInstance().GetPlayer().Update();
                }
                else if (PlayerManager.GetInstance().GetPlayer().timer.ElapsedMilliseconds > 2000)
                {
                    if (EnemyManager.GetInstance().GetEnemyList().Count != 0)
                    {
                        EnemyManager.GetInstance().GetEnemyList()[0].isTurn = true;
                        EnemyManager.GetInstance().GetEnemyList()[0].EnemyTurnSetting();
                    }
                    PlayerManager.GetInstance().GetPlayer().timer.Reset();
                    PlayerManager.GetInstance().GetPlayer().timer.Stop();
                }
            }
            // e.InputKeyPad(); 뜨거운 코딩 레츠고
        }
    }

}