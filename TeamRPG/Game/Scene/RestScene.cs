using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.ImageManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Scene
{
    using Scene = Core.SceneManager.Scene;
    public class RestScene : Scene
    {
        public string NextSceneName { get; set; } = "GameScene"; // 다음 씬 이름

        private int restHpAmount = 20; // 회복량
        private int restMpAmount = 10; // 마나 회복량

        RawText fireText;
        Text titleText;
        Text effectText;
        Text descriptionText;
        RawText leftText;


        public void Init()
        {
            SoundManager.GetInstance().PlaySound("FireplaceSound", 1f);
            string fireImage = ImageManager.GetInstance().GetImage("모닥불");
            fireText = new RawText(fireImage, UIManager.HalfWidth, 2, HorizontalAlign.Center);
            effectText = new Text("생명력이 20 회복되었다!", UIManager.HalfWidth, Console.WindowHeight - 3, ConsoleColor.Yellow, HorizontalAlign.Center);
            descriptionText = new Text("스페이스바를 눌러 게임을 계속하세요.", UIManager.HalfWidth, Console.WindowHeight - 2, ConsoleColor.Yellow, HorizontalAlign.Center);
            leftText = new RawText("모닥불은 소리를 내며\n타오르고 있다.", 30, UIManager.HalfHeight, HorizontalAlign.Center);
            // titleText = new Text("휴식처", UIManager.HalfWidth, 2, ConsoleColor.Yellow, TextAlign.Center);
        }

        public void Release()
        {
            UIManager.GetInstance().ClearUI();
            SoundManager.GetInstance().StopSound("FireplaceSound");
        }

        public void Render()
        {
        }

        public void Update()
        {
            var inputManager = KeyInputManager.GetInstance();
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Spacebar))
            {
                Rest(PlayerManager.GetInstance().GetPlayer());
                SceneManager.GetInstance().ChangeScene(NextSceneName);
            }
        }

        public void Rest(Player player)
        {
            player.currentStatus.HP += restHpAmount;
            // player.currentStatus.MP += restMpAmount;
        }
        
    }
}
