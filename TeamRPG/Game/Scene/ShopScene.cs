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
    public class ShopData
    {
        public string ShopName { get; set; } = "상점"; // 상점 이름
        public string MerchantName { get; set; } = "상인"; // 상인 이름
        public List<Item> Items { get; set; } = new List<Item>();

        public int ItemLenth { get; set; } // 상점 아이템 개수 (6개로 고정)
        public int RerollCost { get; set; } = 30; // 아이템 리롤 비용
        public int Gold { get; set; } = 1000; // 테스트용 임시 골드 <- 나중에 캐릭터에 연결해야됨

        public string MerchantImage { get; set; }
        public string LobbyComment { get; set; } = "필요한 물건이 있으신가요?"; // 상점 로비 코멘트
        public string BuyComment { get; set; } = "물건을 구매하시겠습니까?"; // 상점 구매 코멘트
        public string BuySuccessComment { get; set; } = "구매 감사합니다!"; // 아이템 구매 성공 코멘트
        public string BuyFailComment { get; set; } = "돈이 부족해!!"; // 아이템 구매 실패 코멘트
        public string SellComment { get; set; } = "물건을 판매하시겠습니까?"; // 상점 판매 코멘트
        public string SellSuccessComment { get; set; } = "판매 감사합니다!"; // 아이템 판매 성공 코멘트
        public string SellFailComment { get; set; } = "대체 뭐를 팔겠단거야!"; // 아이템 판매 실패 코멘트

        public string RerollSuccessComment { get; set; } = "새로운 상품입니다!"; // 아이템 리롤 코멘트
        public List<string> TalkList { get; set; } = new List<string>
        {
            "안녕하세요, 여행자님!",
            "이곳은 다양한 물건을 판매하는 상점입니다.",
            "저희 상점에서는 다양한 아이템을 구매할 수 있습니다.",
            "저도 한때는 모험가를 꿈꿔왔습니다...",
            "그래서 물건은 사실건가요?"
        };
        public ShopData()
        {
            // 초기 아이템 목록 생성
            RerollItems();
        }

        public void RerollItems()
        {
            Items = ItemManager.GetInstance().GetRandomItems(6);
        }
        public void AddItem(Item item)
        {
            if (Items.Count < 6)
            {
                Items.Add(item);
            }
            else
            {
                Console.WriteLine("상점 아이템 슬롯이 가득 찼습니다.");
            }
        }
        public void RemoveItem(Item item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
            else
            {
                Console.WriteLine("해당 아이템이 상점에 없습니다.");
            }
        }
        public void ClearItems()
        {
            Items.Clear();
        }


    }

    public class ShopScene : SceneClass
    {
        private int gold = 1000; // 테스트용 임시 골드 <- 나중에 캐릭터에 연결해야됨

        private ShopData shopData;

        private Player player;
        private Text goldText;
        private Text titleText;
        private RawText merchantImageText;
        private RawText merchantCommentText;

        private string merchantLobbyComment = """
                상인
                필요한 물건이 있으신가요?
                """;

        public string merchantBuyComment = """
                상인
                물건을 구매하시겠습니까?
                """;

        public string merchantSellComment = """
                상인
                물건을 판매하시겠습니까?
                """;

        public List<string> talkList = new()
        {
            """
            상인
            안녕하세요, 여행자님!
            """,
            """
            상인
            이곳은 다양한 물건을 판매하는 상점입니다.
            """,
            """
            상인
            저희 상점에서는 다양한 아이템을 구매할 수 있습니다.
            """,
            """
            상인
            저도 한때는 모험가를 꿈꿔왔습니다...
            """,
            """
            상인
            그래서 물건은 사실건가요?
            """
        };

        private BoxMenu actionBoxMenu;
        private BoxMenu itemBoxMenu;
        private BoxMenu currentMenu = null; // 현재 활성화된 메뉴

        private int shopItemSlotLenth = 6; // 상점 아이템 슬롯 개수 (6개로 고정)
        private List<MenuItem> shopMenuItems = new();
        private List<Item> shopItems = new List<Item>();
        private MenuItem goldTextSlot;

        private int rerollCost = 30; // 아이템 리롤 비용

        public void Init()
        {
            string merchantImage = """
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠐⡈⠔⣐⠢⡌⢂⠡⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⠠⡘⢤⡿⣾⢿⢿⣮⡢⢑⡀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡀⠱⣨⢿⡽⣳⠯⣟⡾⣽⡢⠄⡁⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠄⢣⡼⢯⣟⠡⢂⡙⢯⣷⡳⢌⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠰⡁⢆⠱⡌⢆⡇⡘⡤⢌⠛⠤⢈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⢡⠊⡔⠡⢎⡼⢠⠑⡌⠌⠥⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⠌⢢⠑⡌⠱⡈⠔⡡⢎⠰⡉⠆⡤⢤⠤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠠⢀⠢⠄⡫⢖⣭⠐⣡⠊⠔⣡⢉⠬⡑⢌⠢⣉⠜⣷⡩⢞⠴⣩⠇⡐⢠⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠄⡂⠱⢈⠄⠃⡐⢀⡟⣼⣃⠒⡌⢧⠈⠄⢳⣖⢉⠢⡐⡴⢈⠞⣷⡩⢞⡥⣋⠐⠠⠑⡈⠅⢊⠄⡠⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⡡⠒⡈⠐⡁⢂⢈⡐⠄⣚⣼⠳⡜⢦⡸⣌⢧⠈⢧⣬⠓⣠⠝⣆⢣⡜⡹⣷⢩⠖⣭⠂⢡⠂⢄⠈⠄⡘⠠⢑⡀⠂⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠂⠄⢁⠠⢁⠰⡀⠆⠠⠃⣼⣏⢳⡙⢦⠳⣌⠎⣧⢳⣜⡡⢇⡛⣬⠳⣜⡱⣹⣧⢛⡴⠈⡀⠊⢄⢊⡐⠠⠐⡀⠄⢉⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⡀⢂⠈⡀⠢⠌⡐⠠⠁⢂⢡⣟⢮⣗⡻⣎⢷⣌⡻⢤⠳⣌⠳⣍⠞⡴⣋⠶⣱⢣⢿⡜⡼⡁⢀⠁⠂⠄⢂⠑⡂⠄⡈⢀⠂⢡⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠨⡑⡄⠠⠐⡀⠐⠠⢀⠡⢀⡾⣝⡞⣮⢗⣯⢳⡞⣽⢫⣗⢮⡳⢮⣝⠶⣭⢞⣥⡳⢮⣿⡴⡇⠀⠂⡁⠐⡀⠂⠐⡀⠄⠂⣌⠲⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⣉⠒⡡⢄⠌⠀⠀⠀⣼⠡⠟⠞⡙⠚⠘⠋⠘⠉⠡⠈⡁⢉⠈⢈⠉⠠⠉⡀⠉⠡⠹⡇⠙⠀⠀⠀⠀⠐⠈⢠⡀⢆⠃⠆⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⢘⡀⠎⡐⡀⠀⢰⠇⣀⣂⣄⠐⡈⠤⢁⠌⠤⠁⢆⠐⠤⢈⠂⠤⠁⠆⢄⠡⠂⡔⣻⣤⢧⠀⠀⠀⠀⢀⠃⡌⠄⡩⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⡈⠔⡠⠀⡞⣰⢯⣝⠆⢈⠀⡁⠂⡈⢂⠉⠔⣈⠂⠅⣊⠐⠩⡐⠨⡐⠡⡐⠸⣯⡞⣧⠀⠀⠠⠌⡂⠔⠡⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠡⠒⡠⢑⡃⣟⡞⡞⠀⠄⠂⡀⠁⠄⠠⠈⠠⠀⠌⠐⠠⢊⠡⡐⠡⠄⢃⠰⠁⢿⡞⣵⠆⢀⠅⠢⢁⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣵⢂⠳⢨⡌⢻⣥⣬⡴⣤⣤⣥⢦⣥⢦⣥⢦⣬⣤⣥⣤⣥⢦⣱⣬⢦⣬⣡⣞⣯⠗⣉⠎⡜⣡⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣌⢣⢁⠻⣟⣾⣵⣿⣳⣯⣾⣟⣾⣟⡾⣟⣾⢧⡿⣾⢾⣯⢷⡯⡿⢾⠷⡾⢽⡾⢏⡘⠴⡱⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⣰⢎⡷⡌⠀⠄⠠⢀⠀⠄⡀⠠⠀⠄⡀⠄⡀⠄⠠⢀⠠⠀⡐⠀⠆⢒⠠⢊⡴⢦⣌⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣯⢻⡼⢃⠈⠄⠂⠠⠈⠠⠐⢀⠡⠀⠄⡐⠀⡐⠠⠀⡐⢀⠐⠈⠌⢂⠢⠁⢿⡹⣞⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠰⡭⣗⣻⠀⡐⠠⠁⠄⡁⠐⢈⠠⠀⠌⢀⠐⡀⠐⡀⠁⠄⡀⠂⡁⠈⠤⣁⠩⢸⣝⡞⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡱⣏⡞⠀⠄⠂⡐⠀⡐⠈⠠⠐⢈⠀⢂⠠⠐⢀⠐⢈⠠⠐⠀⠄⡁⠰⠀⠆⡱⣞⠵⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⡱⣏⡞⠀⠂⡁⠄⠂⠐⢈⠠⠈⠠⠐⢀⠐⢀⠂⢈⠠⠐⠠⠁⡐⠀⢂⠩⡐⠄⣿⢱⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠁⠀⠀⠀⠀⠀⠀⠀⢷⡱⣏⡆⠁⡐⠀⠄⡁⠌⢀⠐⢈⠠⠈⠠⠐⢀⠈⠄⠐⠠⠁⡐⠀⠌⣀⠒⡠⢁⡟⣦⢣⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠠⠀⠀⠠⠀⠀⠄⠀⠀⠀⠀⠀⠀⢀⢧⢳⡝⡆⠁⠄⢈⠠⠀⢂⠠⠈⠠⠐⢈⠠⠈⡀⢂⠈⠐⡀⠁⠄⠈⢄⡐⢂⠡⢂⡽⣆⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢘⣎⢳⡽⡃⠠⢈⠠⠐⢈⠀⡐⠈⠠⢈⠠⠐⠀⠄⠂⡈⠄⠐⢈⠠⢁⠆⠰⠈⡔⢂⡼⣏⢮⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡸⣌⢳⡽⡃⠠⠀⢂⠈⠠⠐⠀⠌⠠⠀⡐⠈⡀⠂⡁⠄⠠⣁⠢⠌⢂⡘⠄⡃⠔⢂⡼⣝⡲⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡵⢪⡝⡾⡅⡀⠡⢀⠂⠁⠄⡁⠂⠄⡁⠄⠂⢄⠡⢐⡈⠥⠐⣂⠩⢐⠠⡑⠐⡌⢂⡽⣺⠵⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣏⠳⡜⣽⢣⡐⡁⠆⡘⠐⠢⡐⠡⠒⡈⠔⡉⢄⠊⢄⠒⡈⠥⢐⠨⠐⡂⢌⠒⢠⠂⣽⢧⣛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⣎⢳⡹⡜⢯⡽⣝⡾⣲⢏⣦⡥⣎⣥⣘⣠⡘⣀⠎⡠⢊⡐⠌⡐⠌⣁⠒⢠⠊⢄⢊⡷⣫⢞⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡌⢧⠳⣜⢣⠻⣜⣳⡭⣟⢶⣹⢳⣎⢷⡳⡽⣭⡻⣝⢯⣝⣻⢼⡳⣞⣞⡳⣞⡞⣮⢳⡝⢮⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼⡘⢧⡛⣬⢣⡛⣬⢳⡹⢮⣻⢼⡳⣽⢺⡵⣻⢵⣛⡮⣟⡼⣣⢯⢷⡹⣎⡷⣝⠾⣭⠳⣜⢣⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣧⡙⢦⡙⢦⢣⡝⢦⢣⡝⢦⡙⢮⡙⡞⢧⠻⡵⣫⢞⡵⣏⠾⣭⡛⢮⡝⢧⡛⣬⠳⣌⢳⣌⢳⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡶⡩⢧⡙⣎⠳⣜⢣⠳⣜⢣⡝⣲⠹⣜⢣⡛⡴⢣⠞⡴⣩⠞⡴⣩⠳⣜⢣⡝⢦⡛⣬⠳⣌⢣⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡷⣙⢦⡹⣌⢳⡌⢧⡛⣬⠳⡜⣥⢛⡬⢣⡝⣜⢣⡛⡴⢣⡛⡴⢣⡛⣬⠳⣜⢣⡝⢆⠯⣜⢣⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠨⡵⣩⢖⡱⢎⠳⠜⢣⠙⠢⠙⠌⠄⡃⠌⡡⠌⡠⢃⠩⢘⠣⠙⡜⣣⠝⣦⢛⡬⡓⣬⢋⡞⣬⢣⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠐⠌⠰⢈⠢⠘⠠⢁⠃⡉⠌⠒⡈⠔⡐⠌⡐⠂⡅⠢⠌⢡⠐⡠⢉⡐⠋⠴⣙⢦⢫⡜⢦⡓⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡀⢂⠠⠐⢀⠡⠀⡐⠀⠄⡁⠐⠠⠈⠠⠑⠈⠄⠱⢈⠂⠜⡀⠆⡠⠉⡔⠠⠌⢡⠘⢃⡙⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                """;
            merchantImageText = new RawText(merchantImage, Console.WindowWidth / 2, 0, ConsoleColor.Green, TextAlign.Center);

            goldText = new Text($"보유 금액 : {gold} G", 2, 2, ConsoleColor.Yellow, TextAlign.Left);

            actionBoxMenu = new BoxMenu(20, Console.WindowHeight / 2, 14, 6, ConsoleColor.DarkGray);
            actionBoxMenu.AddItem("Buy", OnShopBuy, ConsoleColor.Green);
            actionBoxMenu.AddItem("Sell", OnShopSell, ConsoleColor.Yellow);
            actionBoxMenu.AddItem("Talk", OnShopTalk, ConsoleColor.Cyan);
            actionBoxMenu.AddItem("Back", OnShopBack, ConsoleColor.Red);

            itemBoxMenu = new BoxMenu(10, Console.WindowHeight / 2, 60, 13, ConsoleColor.DarkGray);
            itemBoxMenu.SetVisible(false);

            InitItemBoxMenu();

            merchantCommentText = new RawText(merchantLobbyComment, Console.WindowWidth - 48, 5, ConsoleColor.White, TextAlign.Left);
            titleText = new Text("Shop", Console.WindowWidth / 2, 1, ConsoleColor.Yellow, TextAlign.Center);

            currentMenu = actionBoxMenu;
        }
        public void Update()
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


        public void Render() { }

        public void Release() { }

        void UpdateGoldText()
        {
            goldText.SetText($"보유 금액 : {gold} G");
            goldTextSlot.Text = ($"보유 골드 : {gold} G");
        }

        void UpdateComment(string comment)
        {
            merchantCommentText.SetText(comment);
        }


        string GetItemBuyInfo(Item item)
        {
            return $"{item.Name} : {item.Description} ({item.Gold} G)";
        }

        void InitItemBoxMenu()
        {
            shopItems = ItemManager.GetInstance().GetRandomItems(6);

            itemBoxMenu.ClearItems();

            for (int i = 0; i < shopItemSlotLenth; i++)
            {
                MenuItem item = itemBoxMenu.AddItem($"Item {i + 1}", () => Console.WriteLine($"Selected Item {i + 1}"), ConsoleColor.Green);
                shopMenuItems.Add(item);
            }

            UpdateItemMenuSlots();

            itemBoxMenu.AddEmptyItem();
            goldTextSlot = itemBoxMenu.AddTextItem($"보유 골드 : {gold} G");
            itemBoxMenu.AddEmptyItem();
            itemBoxMenu.AddItem($"돌리기 {rerollCost}", RerollItmes);

            itemBoxMenu.AddItem("돌아가기", () =>
            {
                itemBoxMenu.SetVisible(false);
                currentMenu = actionBoxMenu;
                UpdateComment(merchantLobbyComment);
            }
            , ConsoleColor.Red);
        }

        // itemMenuSlot 업데이트
        void UpdateItemMenuSlots()
        {
            var menuItemList = itemBoxMenu.Items;
            for (int i = 0; i < shopItemSlotLenth; i++)
            {
                if (i < shopItems.Count)
                {
                    int index = i; // 클로저 안전하게
                    menuItemList[i].Text = GetItemBuyInfo(shopItems[i]);
                    menuItemList[i].OnSelect = () => ShopBuy(shopItems[index]);
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
            if (gold < rerollCost)
            {
                comment = """
                상인
                돈이 부족해!!
                """;
                UpdateComment(comment);
                return;
            }

            gold -= rerollCost;
            shopItems = ItemManager.GetInstance().GetRandomItems(6);
            UpdateItemMenuSlots();
            UpdateGoldText();

            comment = """
                상인
                새로운 상품입니다!
                """;
            UpdateComment(comment);
        }

        private void OnShopBuy()
        {
            currentMenu = itemBoxMenu;
            itemBoxMenu.SetVisible(true);

            if(gold == 0)
            {
                string comment = """
                    상인
                    돈 없으면 저리 썩 꺼져!!
                    """;
                UpdateComment(comment);
            }
            else
                UpdateComment(merchantBuyComment);


        }
        private void OnShopSell()
        {
            currentMenu = itemBoxMenu;
            itemBoxMenu.SetVisible(true);
            UpdateComment(merchantSellComment);
        }
        private void OnShopTalk()
        {
            currentMenu = actionBoxMenu;
            itemBoxMenu.SetVisible(false);
            ShopTalk();
        }

        private void OnShopBack() {
            SceneManager.GetInstance().ChangeScene("UITestScene");
        }

        public void ShopBuy(Item item)
        {
            string comment;
            if (item == null) return;
            if (gold < item.Gold)
            {
                comment = $"""
                    상인
                    그 돈으로는 부족합니다!
                    """;

                UpdateComment(comment);
                return;
            }

            gold -= item.Gold;
            // player.AddItem(item);

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
            
            gold += item.Gold;
            // player.RemoveItem(item);

            string comment = $"""
                상인
                {item.Name} 판매 감사합니다!
                """;

            UpdateGoldText();
            UpdateComment(comment);
        }

        public void ShopTalk()
        {
            if (talkList.Count == 0) return;

            Random random = new Random();
            int index = random.Next(talkList.Count);
            string comment = talkList[index];

            UpdateComment(comment);
        }
    }

}
