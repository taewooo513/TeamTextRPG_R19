using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.ItemManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Scene;
using TeamRPG.Game.Scene.Specificity;
using static System.Net.Mime.MediaTypeNames;
using TeamRPG.Core.ShopManager;
using TeamRPG.Core.EncounterManager;
using TeamRPG.Core.ImageManager;
using TeamRPG.Core.QuestManager;

namespace TeamRPG.Game
{
    public class MainGame // 여기선 씬선언 제외 사용하지마세요
    {
        public void Init() // 씬선언 여기서 하세요, 싸운드 선언도 여기서 하세요
        {
            SceneManager.GetInstance().Init();
            SceneManager.GetInstance().AddScene("TestScene", new TestScene());
            SceneManager.GetInstance().AddScene("TitleScene", new TitleScene());
            SceneManager.GetInstance().AddScene("UITestScene", new UITestScene());
            SceneManager.GetInstance().AddScene("CharSelectScene", new CharSelectScene());
            SceneManager.GetInstance().AddScene("ShopScene", new ShopScene());
            SceneManager.GetInstance().AddScene("GameScene", new GameScene());
            SceneManager.GetInstance().AddScene("CharInfoScene", new CharInfoScene());
            SceneManager.GetInstance().AddScene("RestScene", new RestScene());
            SceneManager.GetInstance().AddScene("EncounterScene", new EncounterScene());
            SceneManager.GetInstance().AddScene("BossEnemyScene", new BossEnemyScene());
            SceneManager.GetInstance().AddScene("DiedScene", new DiedScene());
            SceneManager.GetInstance().AddScene("BossIntroScene", new BossIntroScene());
            

            SceneManager.GetInstance().AddScene("WildernessScene", new WildernessScene());
            SceneManager.GetInstance().AddScene("WildernessStartScene", new WildernessStartScene());

            SceneManager.GetInstance().AddScene("DevildomScene", new DevildomScene());
            SceneManager.GetInstance().AddScene("DevildomStartScene", new DevildomStartScene());

            SceneManager.GetInstance().AddScene("ForestScene", new ForestScene());
            SceneManager.GetInstance().AddScene("ForestStartScene", new ForestStartScene());

            SceneManager.GetInstance().AddScene("CemeteryScene", new CemeteryScene());
            SceneManager.GetInstance().AddScene("CemeteryStartScene", new CemeteryStartScene());


            TextIOManager.GetInstance().Init(156, 40);
            TimerManager.GetInstance().Init();
            SoundManager.GetInstance().Init();

            // basics
            SoundManager.GetInstance().AddSound("Test", "Test2.mp3", true, true);
            SoundManager.GetInstance().AddSound("Clicksmall", "../../../../Sounds/basics/Clicksmall.mp3", false, false);
            SoundManager.GetInstance().AddSound("BlopSound", "../../../../Sounds/basics/BlopSound.mp3", false, false);

            // shop
            SoundManager.GetInstance().AddSound("ShopBGM", "../../../../Sounds/shop/ShopBGM.mp3", true, true);
            SoundManager.GetInstance().AddSound("ShopSelect", "../../../../Sounds/shop/ShopSelect.mp3", false, false);

            // battle
            SoundManager.GetInstance().AddSound("Bossmain", "../../../../Sounds/battle/bgm/Bossmain.mp3", true, true);
            SoundManager.GetInstance().AddSound("Tier1NomalBattleBGM", "../../../../Sounds/battle/bgm//Tier1NomalBattleBGM.mp3", true, true);
            SoundManager.GetInstance().AddSound("염예찬 튜터님의 가소롭군!", "../../../../Sounds/battle/염예찬 튜터님의 가소롭군!.mp3", false, false);

            // bgm
            SoundManager.GetInstance().AddSound("FireplaceSound", "../../../../Sounds/Bgm/FireplaceSound.mp3", true, true);

            // encounter
            SoundManager.GetInstance().AddSound("RandomEncounterSound4", "../../../../Sounds/encounter/RandomEncounterSound4.mp3", true, true);


            // empty
            SoundManager.GetInstance().AddSound("DevildomBGM", "../../../../Sounds/DevildomBGM.mp3", true, true);


            SoundManager.GetInstance().PlaySound("Test", .1f);
            PlayerManager.GetInstance().Init("asd", (Race)1);

            QuestManager.GetInstance().Init();
            ItemManager.GetInstance().Init();
            ShopManager.GetInstance().Init();
            ImageManager.GetInstance().Init();

            PlayerManager.GetInstance().Init("test", Race.Human);
            SceneManager.GetInstance().ChangeScene("TitleScene");
            EncounterManager.GetInstance().Init();

        }
        public void Update()
        {
            KeyInputManager.GetInstance().Update();
            switch (KeyInputManager.GetInstance().KeyDown())
            {
                case ConsoleKey.F1:
                    PlayerManager.GetInstance().GetPlayer().isCheat = !PlayerManager.GetInstance().GetPlayer().isCheat;
                    break;
                case ConsoleKey.F2:
                    SceneManager.GetInstance().ChangeScene("EncounterScene");
                    break;
                case ConsoleKey.F3:
                    SceneManager.GetInstance().ChangeScene("RestScene");
                    break;
                case ConsoleKey.F4:
                    SceneManager.GetInstance().ChangeScene("ShopScene");
                    break;
                case ConsoleKey.F5:
                    SceneManager.GetInstance().ChangeScene("GameScene");
                    break;
                case ConsoleKey.F6:
                    SceneManager.GetInstance().ChangeScene("BossIntroScene");
                    break;
                case ConsoleKey.F7:
                    SceneManager.GetInstance().ChangeScene("TitleScene");
                    break;
                case ConsoleKey.F8:
                    EnemyManager.GetInstance().CycleCount++;
                    break;


                case ConsoleKey.U:
                    SceneManager.GetInstance().ChangeScene("ForestScene");
                    break;


                case ConsoleKey.I:
                    SceneManager.GetInstance().ChangeScene("WildernessScene");
                    break;


                case ConsoleKey.O:
                    SceneManager.GetInstance().ChangeScene("DevildomScene");
                    break;


                case ConsoleKey.P:
                    SceneManager.GetInstance().ChangeScene("CemeteryScene");
                    break;
            }
            SceneManager.GetInstance().Update();
            TimerManager.GetInstance().Update();
            SoundManager.GetInstance().Update();
            EnemyManager.GetInstance().Update();
        }
        public void Render()
        {
            SceneManager.GetInstance().Render();
            EnemyManager.GetInstance().Render();
            TextIOManager.GetInstance().DrawText();
            UIManager.GetInstance().DrawUI();
            //Console.WriteLine(TimerManager.GetInstance().GetMillisecond().ToString());
            //Console.WriteLine(TimerManager.GetInstance().GetFrame().ToString());
        }
        public void Release()
        {
        }
    }
}


