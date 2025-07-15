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
using TeamRPG.Core.ShopManager;

namespace TeamRPG.Game.Scene
{
    public enum ShopMenuType
    {
        Lobby, // 상점 로비
        Buy, // 아이템 구매
        Sell, // 아이템 판매
        Talk, // 상인과 대화
        Reroll, // 아이템 리롤
        Exit // 상점 나가기
    }

    public class ShopScene : SceneClass
    {
        public ShopData ShopData { get; set; }
        private ShopMenuType ShopMenuType { get; set; } = ShopMenuType.Buy; // 현재 메뉴 타입

        public List<string> defaultItems = new()
        {
            "HealingPotion",
        };

        private Player player;
        private Text goldText;
        private Text titleText;
        private RawText merchantImageText;
        private RawText merchantCommentText;

        private BoxMenu? actionBoxMenu; // 상점 액션 메뉴 (구매, 판매, 대화, 뒤로가기)
        private BoxMenu? itemBuyMenu; // 아이템 구매 메뉴
        private BoxMenu? itemSellMenu; // 아이템 판매 메뉴
        private BoxMenu? currentMenu = null; // 현재 활성화된 메뉴

        private MenuItem? buyGolTextSlot;
        private MenuItem? sellGoldTextSlot;

        public void Init()
        {
            player = new("Name", Race.Human);
            SoundManager.GetInstance().PlaySound("ShopBGM", .2f);

            InitShoptData();
            InitCommonUI();
            InitItemBoxMenu();
            UpdateShopItems();
        }
        public void Update()
        {
            InputMenu();
        }

        public void Render() { }

        public void Release() { }

        void InitShoptData()
        {
            ShopData = ShopManager.GetInstance().GetRandomShop();
        }

        // actionMenu 입력 처리
        void InputMenu()
        {
            var inputManager = KeyInputManager.GetInstance();
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow))
            {
                currentMenu.MoveUp();
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow))
            {
                currentMenu.MoveDown();
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                currentMenu.Select();
            }
        }

        void InitCommonUI()
        {
            merchantImageText = new RawText(ShopData.MerchantImage, Console.WindowWidth / 2, 0, ConsoleColor.Green, TextAlign.Center);
            merchantCommentText = new RawText(ShopData.LobbyComment, Console.WindowWidth - 54, 4, ConsoleColor.White, TextAlign.Left);

            actionBoxMenu = new BoxMenu(20, Console.WindowHeight / 2, 14, 6, ConsoleColor.DarkGray);
            actionBoxMenu.AddItem("Buy", () => ChangeMenu(ShopMenuType.Buy), ConsoleColor.Green);
            actionBoxMenu.AddItem("Sell", () => ChangeMenu(ShopMenuType.Sell), ConsoleColor.Yellow);
            actionBoxMenu.AddItem("Talk", () => ChangeMenu(ShopMenuType.Talk), ConsoleColor.Cyan);
            actionBoxMenu.AddItem("Back", OnShopBack, ConsoleColor.Red);

            titleText = new Text($"{ShopData.ShopName}", Console.WindowWidth / 2, 1, ConsoleColor.Yellow, TextAlign.Center);
            goldText = new Text($"보유 금액 : {player.Gold} G", 2, 2, ConsoleColor.Yellow, TextAlign.Left);
            currentMenu = actionBoxMenu;
        }

        void InitItemBoxMenu()
        {
            // itemBuyMenu 초기화
            itemBuyMenu = new BoxMenu(10, Console.WindowHeight / 2, 60, 13, ConsoleColor.DarkGray);
            itemBuyMenu.SetVisible(false);

            for (int i = 0; i < ShopData.ItemLength; i++)
            {
                MenuItem item = itemBuyMenu.AddItem("", () => { }, ConsoleColor.Green);
            }

            itemBuyMenu.AddEmptyItem();
            buyGolTextSlot = itemBuyMenu.AddTextItem($"보유 골드 : {player.Gold} G");
            itemBuyMenu.AddEmptyItem();
            itemBuyMenu.AddItem($"돌리기 {ShopData.RerollCost} G", RerollItmes);
            itemBuyMenu.AddItem("돌아가기", BackMenu, ConsoleColor.Red);

            // itemSellMenu 초기화
            if (player == null) return;
            itemSellMenu = new BoxMenu(10, Console.WindowHeight / 2, 60, 13, ConsoleColor.DarkGray);
            itemSellMenu.SetVisible(false);

            for (int i = 0; i < ShopData.ItemLength; i++)
            {
                MenuItem item = itemSellMenu.AddItem("", () => { }, ConsoleColor.Yellow);
            }

            itemSellMenu.AddEmptyItem();
            sellGoldTextSlot = itemSellMenu.AddTextItem($"보유 골드 : {player.Gold} G");
            itemSellMenu.AddEmptyItem();
            itemSellMenu.AddItem("돌아가기", BackMenu, ConsoleColor.Red);
        }

        void BackMenu()
        {
            ChangeMenu(ShopMenuType.Lobby);
        }

        void UpdateShopItems()
        {
            ShopData.Items = ItemManager.GetInstance().GetRandomItems(ShopData.ItemLength, defaultItems);
        }

        void UpdateItemBuyMenuSlots()
        {
            var menuItemList = itemBuyMenu.Items;
            for (int i = 0; i < ShopData.ItemLength; i++)
            {
                if (i < ShopData.Items.Count)
                {
                    int index = i; // 클로저 안전하게
                    menuItemList[i].Text = GetItemBuyInfo(ShopData.Items[i]);
                    menuItemList[i].OnSelect = () => ShopBuy(ShopData.Items[index]);
                    menuItemList[i].IsEnabled = true;
                }
                else
                {
                    menuItemList[i].Text = "";
                    menuItemList[i].OnSelect = () => { };
                    menuItemList[i].IsEnabled = false;
                }
            }
        }

        void UpdateItemSellMenuSlots()
        {
            var menuItemList = itemSellMenu.Items;
            for (int i = 0; i < ShopData.ItemLength; i++)
            {
                if (i < player.Inventory.Count)
                {
                    int index = i; // 클로저 안전하게
                    menuItemList[i].Text = GetItemSellInfo(player.Inventory[i]);
                    menuItemList[i].OnSelect = () => ShopSell(player.Inventory[index]);
                    menuItemList[i].IsEnabled = true;
                }
                else
                {
                    menuItemList[i].Text = "";
                    menuItemList[i].OnSelect = null;
                    menuItemList[i].IsEnabled = false;
                }
            }
        }

        void RerollItmes()
        {
            string comment;
            if (player.Gold < ShopData.RerollCost)
            {
                comment = """
                상인
                돈이 부족해!!
                """;
                UpdateComment(comment);
                return;
            }

            player.Gold -= ShopData.RerollCost;
            UpdateShopItems();
            UpdateItemBuyMenuSlots();
            UpdateGoldText();

            comment = """
                상인
                새로운 상품입니다!
                """;
            UpdateComment(comment);
        }

        void UpdateGoldText()
        {
            goldText.SetText($"보유 금액 : {player.Gold} G");
            buyGolTextSlot.Text = ($"보유 골드 : {player.Gold} G");
            sellGoldTextSlot.Text = ($"보유 골드 : {player.Gold} G");
        }

        void UpdateComment(string comment)
        {
            merchantCommentText.SetText(comment);
        }

        string GetItemBuyInfo(Item item)
        {
            return $"{item.Name} : {item.Description} ({item.Gold} G)";
        }
        string GetItemSellInfo(Item item)
        {
            return $"{item.Name} : {item.Description} ({GetItemSellGold(item)} G)";
        }

        int GetItemSellGold(Item item)
        {
            if (item == null) return 0;
            return (int)(item.Gold * 0.8f);
        }


        public void ChangeMenu(ShopMenuType menuType)
        {
            ShopMenuType = menuType;
            currentMenu.SetVisible(false);
            string comment;

            switch (menuType)
            {
                case ShopMenuType.Buy:
                    UpdateItemBuyMenuSlots();
                    currentMenu = itemBuyMenu;
                    comment = ShopData.BuyComment;
                    break;

                case ShopMenuType.Sell:
                    UpdateItemSellMenuSlots();
                    currentMenu = itemSellMenu;
                    comment = ShopData.SellComment;
                    break;

                case ShopMenuType.Talk:
                    ShopTalk();
                    currentMenu = actionBoxMenu;
                    comment = ShopData.TalkList.Count > 0 ? ShopData.TalkList[new Random().Next(ShopData.TalkList.Count)] : ShopData.LobbyComment;
                    break;
                case ShopMenuType.Lobby:
                default:
                    currentMenu = actionBoxMenu;
                    comment = ShopData.LobbyComment;
                    break;
            }

            currentMenu.SetVisible(true);
            UpdateComment(comment);
        }

        private void OnShopBack() {
            ShopMenuType = ShopMenuType.Lobby;
            SceneManager.GetInstance().ChangeScene("UITestScene");
        }

        public void ShopBuy(Item item)
        {
            string comment;
            if (item == null) return;
            if (player.Gold < item.Gold)
            {
                comment = $"""
                    상인
                    그 돈으로는 부족합니다!
                    """;

                UpdateComment(comment);
                return;
            }

            player.Gold -= item.Gold;
            player.Inventory.Add(item);

            comment = $"""
                상인
                {item.Name} 구매 감사합니다!
                """;

            UpdateGoldText();
            UpdateComment(comment);
        }

        public void ShopSell(Item item)
        {
            if (item == null) return;
            string comment;
            player.Gold += GetItemSellGold(item);

            // 플레이어 인벤토리에서 아이템 제거
            if (player.Inventory.Contains(item) == false)
            {
                comment = """
                        상인
                        대체 뭐를 팔겠단거야!
                        """;
                UpdateComment(comment);
                return;
            }

            player.Inventory.Remove(item);


            comment = $"""
                상인
                {item.Name} 판매 감사합니다!
                """;

            UpdateGoldText();
            UpdateItemSellMenuSlots();
            UpdateComment(comment);
        }

        public void ShopTalk()
        {
            if (ShopData.TalkList.Count == 0) return;

            Random random = new Random();
            int index = random.Next(ShopData.TalkList.Count);
            string comment = ShopData.TalkList[index];

            UpdateComment(comment);
        }
    }

}
