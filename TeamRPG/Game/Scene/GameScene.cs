using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EncounterManager;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.QuestManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Enemy;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Scene
{
    public class GameScene : Core.SceneManager.Scene
    {
        bool isStartGame = false;
        Stopwatch timer;
        Enemy e;
        bool isEnd = false;
        Enemy e1;
        Enemy e2;
        int selectNum = 0;
        int enemySelect = 0;
        bool isReword = false;
        RawText gameMsgText;
        public void Init()
        {
            UIManager.GetInstance().AddUIElement(PlayerManager.GetInstance().GetPlayer().itemBoxUI);
            isReword = false;
            enemySelect = 0;
            isReword = false;
            isStartGame = false;
            timer = new Stopwatch();
            timer.Start();
            isEnd = false;
            gameMsgText = new RawText("", 3, 1);
            PlayerManager.GetInstance().GetPlayer().PlayerTurnSetting();
            SoundManager.GetInstance().PlaySound("Bossmain", .1f);
            PlayerManager.GetInstance().gameMsg = "적을 마주쳤습니다."; // 개같이부활
            selectNum = 0;
            //e1 = new Goblin(-30, 0, "A");
            //EnemyManager.GetInstance().AddEnemy(e1, eEnemyNum.eGoblin);
            // e = new Goblin(0, 4, "???");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eGoblin);
            //e2 = new Goblin(30, 0, "C");
            //EnemyManager.GetInstance().AddEnemy(e2, eEnemyNum.eGoblin);
            // e = new Slime(UIManager.HalfWidth, 5, "Slime");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eSlime);
            // e = new Skeleton(UIManager.HalfWidth, 5, "");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eMimic);
            // e = new Mimic(UIManager.HalfWidth, 5, "Mimic");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eMimic);

            // e = new Golem(UIManager.HalfWidth, 5, "Golem");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eGolem);
            InitEnemies();

            //e = new Mimic(UIManager.HalfWidth, 5, "Mimic");
            // e = new Lich(60, 0, "Troll");
            //EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eTroll);
        }

        public void Release()
        {
            timer.Reset();
            timer.Stop();
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
            gameMsgText.SetText(PlayerManager.GetInstance().gameMsg);
            // TextIOManager.GetInstance().OutputSmartText(PlayerManager.GetInstance().gameMsg, 3, 1);
        }

        public void InitEnemies()
        {
            EnemyManager enemyManager = EnemyManager.GetInstance();

            // 현재 생성할 적이 없다면 현재 지역의 적을 랜덤으로 생성
            if (enemyManager.GetInitialEnemies().Count == 0)
                enemyManager.InitInitialEnemy(enemyManager.CurrentEnvironmentType());

            // initialEnemies들 생성
            var initialEnemies = enemyManager.GetInitialEnemies();

            for (int i = 0; i < initialEnemies.Count; i++)
                enemyManager.AddEnemy(initialEnemies[i].Item1, initialEnemies[i].Item2);

            enemyManager.ClearInitialEnemies();
        }

        public void Update()
        {
            if (timer.ElapsedMilliseconds >= 3000 && isStartGame == false) // 시작시에 실행되는 첫번째 타이머
            {
                isStartGame = true;
                PlayerManager.GetInstance().gameMsg = "플레이어의 턴";
            }
            if (isStartGame == true && isEnd == false)
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
            if (isEnd == false)
            {
                if (EnemyManager.GetInstance().GetEnemyList().Count == 0)
                {
                    timer.Restart();
                    isEnd = true;
                }
            }
            else
            {
                if (timer.ElapsedMilliseconds > 3000 && isReword == false)
                {
                    timer.Restart();
                    isReword = true;
                    switch (EnemyManager.NowMonsterTier)
                    {
                        case eEnemyTier.Normal:
                            PlayerManager.GetInstance().GetPlayer().GetReword(56, 18);
                            break;
                        case eEnemyTier.Elite:
                            PlayerManager.GetInstance().GetPlayer().GetReword(84, 32);
                            break;
                        case eEnemyTier.Boss:
                            PlayerManager.GetInstance().GetPlayer().GetReword(140, 40);
                            break;
                    }
                }
                else if (timer.ElapsedMilliseconds > 3000)
                {
                    if (QuestManager.GetInstance().IsQuestting)
                    {
                        QuestManager.GetInstance().CurrentQuest.IsCompleted = true;
                        SceneManager.GetInstance().ChangeScene("ShopScene");
                    }
                    else if(EncounterManager.GetInstance().IsEncountering) // 만약 현재 인카운터 중이라면
                    {
                        EncounterManager.GetInstance().IsEncountering = false;
                        SceneManager.GetInstance().ChangeScene("GameScene");
                    }
                    else if(PlayerManager.GetInstance().isBoss == true)
                    {
                        SceneManager.GetInstance().ChangeScene("EnddingScene");
                    }
                    else
                    {
                        EnemyManager.GetInstance().CycleCount++;
                        SceneManager.GetInstance().ChangeScene(PlayerManager.GetInstance().environment);
                    }
                }
            }
        }
    }
}