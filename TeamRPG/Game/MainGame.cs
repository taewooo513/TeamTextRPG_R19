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
using TeamRPG.Core;

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
            SceneManager.GetInstance().AddScene("EnddingScene", new EnddingScene());


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


            //Arrskill
            SoundManager.GetInstance().AddSound("rain", "../../../../Sounds/battle/Arrow-skill/애로우레인.mp3", false, false);
            SoundManager.GetInstance().AddSound("wind", "../../../../Sounds/battle/Arrow-skill/윈드스톰.mp3", false, false);
            SoundManager.GetInstance().AddSound("heal", "../../../../Sounds/battle/Arrow-skill/힐링.mp3", false, false);

            //Swd Skill
            SoundManager.GetInstance().AddSound("attack", "../../../../Sounds/battle/Sword-skill/레이징어택.mp3", false, false);
            SoundManager.GetInstance().AddSound("blow", "../../../../Sounds/battle/Sword-skill/배쉬블로우.mp3", false, false);
            SoundManager.GetInstance().AddSound("strike", "../../../../Sounds/battle/Sword-skill/파워스트라이크.mp3", false, false);

            //Hammer-skill
            SoundManager.GetInstance().AddSound("발구르기", "../../../../Sounds/battle/Hammer-skill/발구르기.mp3", false, false);
            SoundManager.GetInstance().AddSound("지진", "../../../../Sounds/battle/Hammer-skill/지진.mp3", false, false);
            SoundManager.GetInstance().AddSound("화산강림", "../../../../Sounds/battle/Hammer-skill/화신강림.mp3", false, false);


            //Normal
            SoundManager.GetInstance().AddSound("ArrowNormal", "../../../../Sounds/battle/normal/Arrow.mp3", false, false);
            SoundManager.GetInstance().AddSound("ArrowNormal2", "../../../../Sounds/battle/normal/Arrow2.mp3", false, false);
            SoundManager.GetInstance().AddSound("ArrowNormalCritical", "../../../../Sounds/battle/Critical/ArrowCritical.mp3", false, false);

            SoundManager.GetInstance().AddSound("HammerNorma", "../../../../Sounds/battle/normal/Hammer.mp3", false, false);
            SoundManager.GetInstance().AddSound("HammerNorma2", "../../../../Sounds/battle/normal/Hammer2.mp3", false, false);
            SoundManager.GetInstance().AddSound("HammerNormaCritical", "../../../../Sounds/battle/Critical/HammerCritical.mp3", false, false);

            SoundManager.GetInstance().AddSound("SwordNorma", "../../../../Sounds/battle/normal/Sword.mp3", false, false);
            SoundManager.GetInstance().AddSound("SwordNorma2", "../../../../Sounds/battle/normal/Sword2.mp3", false, false);
            SoundManager.GetInstance().AddSound("SwordNormaCritical", "../../../../Sounds/battle/Critical/SwordCritical.mp3", false, false);



            // bgm
            SoundManager.GetInstance().AddSound("FireplaceSound", "../../../../Sounds/Bgm/FireplaceSound.mp3", true, true);

            // encounter
            SoundManager.GetInstance().AddSound("RandomEncounterSound4", "../../../../Sounds/encounter/RandomEncounterSound4.mp3", true, true);


            // empty
            SoundManager.GetInstance().AddSound("Forest", "../../../../Sounds/Bgm/Forest.mp3", true, true);
            SoundManager.GetInstance().AddSound("tomb", "../../../../Sounds/Bgm/tomb.mp3", true, true);
            SoundManager.GetInstance().AddSound("Wild", "../../../../Sounds/Bgm/Wild.mp3", true, true);
            SoundManager.GetInstance().AddSound("DevildomBGM", "../../../../Sounds/DevildomBGM.mp3", true, true);

            
            // Parry
            SoundManager.GetInstance().AddSound("Parry", "../../../../Sounds/battle/Parry.mp3", false, false);


            QuestManager.GetInstance().Init();
            ItemManager.GetInstance().Init();
            ShopManager.GetInstance().Init();
            ImageManager.GetInstance().Init();

   
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


