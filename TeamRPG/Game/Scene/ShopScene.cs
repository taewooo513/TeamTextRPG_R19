using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.ItemManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Object.UI;
using SceneClass = TeamRPG.Core.SceneManager.Scene;
using TeamRPG.Game.Object.Item;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene
{
    public class ShopScene : SceneClass
    {
        private Player player;
        private Text goldText;
        private Text titleText;
        private RawText merchantImageText;
        private RawText merchantCommentText;
        private BoxMenu actionBoxMenu;
        private BoxMenu itemBoxMenu;

        int number = 1; // 메뉴 선택 번호
        public void Init()
        {
            string merchantImage = """
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣼⣿⡧⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⢰⣶⡴⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⢀⣠⣤⣶⣴⣶⣦⣦⣄⣀⢀⠀⠀⠀⠀⠀⠀⡇⢘⣷⣿⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠹⣿⣿⣿⣽⣳⠯⢾⣹⣎⠛⡳⢶⠀⠀⠀⡇⠈⠻⡏⠁⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⣼⣿⣟⣿⣿⡼⣻⢯⣳⣏⡗⡡⢎⡝⡄⢰⠇⠀⠀⠁⠀⠀⠀
                ⠀⠀⠀⠀⠀⣠⡴⣿⣿⣯⣿⣿⣿⣷⣿⣷⣿⣝⣳⣯⣗⠃⢸⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⢀⡴⣋⢧⣿⣽⣿⣻⡿⣿⣿⣿⣿⣛⣭⣻⣿⠿⠀⠀⣸⠀⠀⠀⠀⠀⠀⠀
                ⠀⢀⣿⣳⣽⡾⣿⣿⣿⣿⣿⣿⣚⣿⣿⣟⣖⡻⣏⠃⠀⢠⡟⡄⠀⠀⠀⠀⠀⠀
                ⠀⠀⢿⣷⣿⣿⣾⣿⣷⣿⣯⣕⠙⣟⣿⡟⢶⣿⠇⡀⠀⣸⣿⠁⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠛⠿⠻⣧⣻⣿⣿⡝⣼⣧⢿⣈⢾⡳⢍⣷⣏⣷⢿⣯⠄⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⢸⣶⣟⡿⣟⣾⣿⣿⣞⡽⣁⣾⡛⢬⠌⠻⢾⢿⠃⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⣾⡟⠺⣟⣿⣿⣿⣿⣿⣲⢥⡿⣱⠞⠏⢀⡄⢸⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⣼⣿⠁⢰⢸⣾⣟⣷⣻⣽⡛⣿⡟⡳⢶⡞⠁⠀⣾⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠉⢀⣈⣷⠿⣻⢧⣿⣯⣱⣿⣳⣽⣏⡍⠀⠀⡏⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⢹⠦⡈⠀⢻⣿⣻⣴⣳⡼⢿⣷⡺⡜⡆⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠛⠞⣃⣴⣿⣷⢣⣜⠋⠁⠘⠛⣿⡵⣺⢰⡇⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠸⠛⠉⣾⣯⣷⠏⠀⠀⠀⠀⣽⡿⣽⣾⡅⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣳⡯⠀⠀⠀⠀⠀⢹⣿⣶⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⡀⠀⣽⣿⣳⢡⡄⣤⢠⣀⡀⢸⣿⡷⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠉⠒⡭⣽⣿⣼⣿⢣⢞⡲⡭⢶⡙⡾⢿⣿⣟⣿⣦⠴⡠⠤⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠙⠹⠉⠧⠋⠎⠱⠙⠆⠙⠑⠋⠘⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀
                """;
            merchantImageText = new RawText(merchantImage, 55, 0, ConsoleColor.Green, TextAlign.Center);

            actionBoxMenu = new BoxMenu(20, 10, 14, 6, ConsoleColor.DarkGray);
            actionBoxMenu.AddItem("Buy", OnShopBuy, ConsoleColor.Green);
            actionBoxMenu.AddItem("Sell", OnShopSell, ConsoleColor.Yellow);
            actionBoxMenu.AddItem("Talk", OnShopTalk, ConsoleColor.Cyan);
            actionBoxMenu.AddItem("Back", OnShopBack, ConsoleColor.Red);

            itemBoxMenu = new BoxMenu(10, 6, 50, 8, ConsoleColor.DarkGray);
            itemBoxMenu.SetVisible(false);

            for (int i = 0; i < 6; i++) { 
                itemBoxMenu.AddItem($"Item {i + 1}", () => Console.WriteLine($"Selected Item {i + 1}"), ConsoleColor.Green);
            }

            UpdateItemMenu();


            string merchantComment = """
                상인
                필요한 물건이 있으신가요?
                """;

            merchantCommentText = new RawText(merchantComment, 80, 8, ConsoleColor.White, TextAlign.Left);
            titleText = new Text("Shop", 60, 1, ConsoleColor.Yellow, TextAlign.Center);
        }
        public void Update()
        {
            var inputManager = KeyInputManager.GetInstance();
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow))
            {

                actionBoxMenu.MoveUp();
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow))
            {
                actionBoxMenu.MoveDown();
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                actionBoxMenu.Select();
            }
        }


        public void Render()
        {

        }

        public void Release() { }


        void UpdateItemMenu()
        {
            var randomItems = ItemManager.GetInstance().GetRandomItems(6);
            var menuItemList = itemBoxMenu.Items;

            for(int i = 0; i < menuItemList.Count; i++)
            {
                if (i < randomItems.Count)
                {
                    string text = $"{randomItems[i].Name} : {randomItems[i].Description} ({randomItems[i].Gold} G)";
                    menuItemList[i].Text = text;
                    menuItemList[i].OnSelect = () => ShopBuy(randomItems[i]);
                    menuItemList[i].IsEnabled = true;
                }
                else
                {
                    menuItemList[i].Text = "Empty";
                    menuItemList[i].OnSelect = null;
                    menuItemList[i].IsEnabled = false;
                }

            }

        }

        private void OnShopBuy()
        {
            itemBoxMenu.SetVisible(true);
        }
        private void OnShopSell()
        {
            itemBoxMenu.SetVisible(true);
        }
        private void OnShopTalk()
        {
            itemBoxMenu.SetVisible(false);
        }

        private void OnShopBack() {
            SceneManager.GetInstance().ChangeScene("UITestScene");
        }

        public void ShopBuy(Item item)
        {
            if (item == null) return;
            /*
            if (player.CurrentStatus.Gold < item.Gold) return;

            player.Gold -= item.Gold;
            player.AddItem(item);
            */
            itemBoxMenu.SetVisible(false);
        }

        public void ShopSell(Item item)
        {
            if (item == null) return;
            /*
            player.Gold += item.Gold / 2;
            player.RemoveItem(item);
            */
            itemBoxMenu.SetVisible(false);
        }
    }

}
