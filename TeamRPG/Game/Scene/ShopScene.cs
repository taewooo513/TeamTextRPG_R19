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
using Microsoft.VisualBasic.FileIO;

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

        public void Release() {
            SoundManager.GetInstance().StopSound("ShopBGM");
            UIManager.GetInstance().ClearUI();
        }

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
            merchantCommentText = new RawText(ShopData.GetNameComment(ShopData.LobbyComment), Console.WindowWidth - 54, 4, ConsoleColor.White, TextAlign.Left);

            actionBoxMenu = new BoxMenu(20, Console.WindowHeight / 2, 14, 6);
            actionBoxMenu.AddItem("Buy", () => ChangeMenu(ShopMenuType.Buy));
            actionBoxMenu.AddItem("Sell", () => ChangeMenu(ShopMenuType.Sell));
            actionBoxMenu.AddItem("Talk", () => ChangeMenu(ShopMenuType.Talk));
            actionBoxMenu.AddItem("Back", OnShopBack);

            titleText = new Text($"{ShopData.ShopName}", Console.WindowWidth / 2, 1, ConsoleColor.Yellow, TextAlign.Center);
            goldText = new Text($"보유 금액 : {player.Gold} G", 2, 2, ConsoleColor.Yellow, TextAlign.Left);
            currentMenu = actionBoxMenu;
        }

        void InitItemBoxMenu()
        {
            int boxWidth = 78;
            int boxHeight = 13;

            // itemBuyMenu 초기화
            itemBuyMenu = new BoxMenu(10, UIManager.HalfHeight, boxWidth, boxHeight);
            itemBuyMenu.SetVisible(false);

            for (int i = 0; i < ShopData.ItemLength; i++)
            {
                MenuItem item = itemBuyMenu.AddItem("", () => { });
            }

            itemBuyMenu.AddEmptyItem();
            buyGolTextSlot = itemBuyMenu.AddTextItem($"보유 골드 : {player.Gold} G");
            itemBuyMenu.AddEmptyItem();
            itemBuyMenu.AddItem($"돌리기 {ShopData.RerollCost} G", RerollItmes);
            itemBuyMenu.AddItem("돌아가기", BackMenu);

            // itemSellMenu 초기화
            if (player == null) return;
            itemSellMenu = new BoxMenu(10, UIManager.HalfHeight, boxWidth, boxHeight);
            itemSellMenu.SetVisible(false);

            for (int i = 0; i < ShopData.ItemLength; i++)
            {
                MenuItem item = itemSellMenu.AddItem("", () => { });
            }

            itemSellMenu.AddEmptyItem();
            sellGoldTextSlot = itemSellMenu.AddTextItem($"보유 골드 : {player.Gold} G");
            itemSellMenu.AddEmptyItem();
            itemSellMenu.AddItem("돌아가기", BackMenu);
        }

        void BackMenu()
        {
            ChangeMenu(ShopMenuType.Lobby);
        }

        void UpdateShopItems()
        {
            ShopData.RerollItems();
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
            string comment = player.Gold >= ShopData.RerollCost ? ShopData.RerollSuccessComment : ShopData.RerollFailComment;

            if (player.Gold < ShopData.RerollCost)
            {
                UpdateComment(comment);
                return;
            }

            player.Gold -= ShopData.RerollCost;
            UpdateShopItems();
            UpdateItemBuyMenuSlots();
            UpdateGoldText();

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
            comment = ShopData.GetNameComment(comment);
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
            string comment = "";

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
                    currentMenu = actionBoxMenu;
                    comment = ShopData.GetRandomTalk();
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
            string comment = player.Gold >= item.Gold? ShopData.BuySuccessComment : ShopData.BuyFailComment;
            
            if (item == null) return;
            if (player.Gold < item.Gold)
            {
                UpdateComment(comment);
                return;
            }

            player.Gold -= item.Gold;
            player.Inventory.Add(item);

            UpdateGoldText();
            UpdateComment(comment);
        }

        public void ShopSell(Item item)
        {
            if (item == null) return;
            string comment = player.Inventory.Contains(item)? ShopData.SellSuccessComment : ShopData.SellFailComment;
            player.Gold += GetItemSellGold(item);

            // 플레이어 인벤토리에서 아이템 제거
            if (player.Inventory.Contains(item) == false)
            {
                UpdateComment(comment);
                return;
            }

            player.Inventory.Remove(item);

            UpdateGoldText();
            UpdateItemSellMenuSlots();
            UpdateComment(comment);
        }
    }

}
