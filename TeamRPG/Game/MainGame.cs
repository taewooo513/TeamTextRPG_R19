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
            SceneManager.GetInstance().AddScene("CemeteryScene", new CemeteryScene());
            SceneManager.GetInstance().AddScene("ShopScene", new ShopScene());
            SceneManager.GetInstance().AddScene("GameScene", new GameScene());
            SceneManager.GetInstance().AddScene("ShopScene", new ShopScene());
            SceneManager.GetInstance().AddScene("CharInfoScene", new CharInfoScene());
            
            TextIOManager.GetInstance().Init(156, 40);
            TimerManager.GetInstance().Init();
            SoundManager.GetInstance().Init();
            SoundManager.GetInstance().AddSound("Test", "Test2.mp3", true, true);
            SoundManager.GetInstance().AddSound("Clicksmall", "../../../../Sounds/Clicksmall.mp3", false, false);
            SoundManager.GetInstance().AddSound("ShopSelect", "../../../../Sounds/ShopSelect.mp3", false, false);
            SoundManager.GetInstance().AddSound("BlopSound", "../../../../Sounds/BlopSound.mp3", false, false);
            SoundManager.GetInstance().AddSound("BossmainTheme", "../../../../Sounds/BossmainTheme.mp3", true, true);
            SoundManager.GetInstance().AddSound("BossmainTheme", "../../../../Sounds/BossmainTheme.mp3", true, true);
            SoundManager.GetInstance().AddSound("DevildomBGM", "../../../../Sounds/DevildomBGM.mp3", true, true);
            SoundManager.GetInstance().AddSound("ShopBGM", "../../../../Sounds/ShopBGM.mp3", true, true);
            SoundManager.GetInstance().AddSound("Tier1NomalBattleBGM", "../../../../Sounds/Tier1NomalBattleBGM.mp3", true, true);
            SoundManager.GetInstance().AddSound("FireplaceSound", "../../../../Sounds/FireplaceSound.mp3", true, true);
            SoundManager.GetInstance().PlaySound("Test", .1f);
            PlayerManager.GetInstance().Init("asd", (Race)1);
            SceneManager.GetInstance().ChangeScene("TitleScene");

            ItemManager.GetInstance().Init();
            ShopManager.GetInstance().Init();

            PlayerManager.GetInstance().Init("test", Race.Human);
            SceneManager.GetInstance().ChangeScene("GameScene");

        }
        public void Update()
        {
            KeyInputManager.GetInstance().Update();
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


