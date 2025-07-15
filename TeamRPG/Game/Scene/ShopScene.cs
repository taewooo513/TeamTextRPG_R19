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
        private ShopData shopData;
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

        private BoxMenu? actionBoxMenu; // 상점 액션 메뉴 (구매, 판매, 대화, 뒤로가기)
        private BoxMenu? itemBuyMenu; // 아이템 구매 메뉴
        private BoxMenu? itemSellMenu; // 아이템 판매 메뉴
        private BoxMenu? currentMenu = null; // 현재 활성화된 메뉴

        private int shopItemSlotLenth = 6; // 상점 아이템 슬롯 개수 (6개로 고정)
        private List<Item> shopBuyItems = new();

        private MenuItem? buyGolTextSlot;
        private MenuItem? sellGoldTextSlot;

        private int rerollCost = 30; // 아이템 리롤 비용

        public void Init()
        {
            player = new("Name", Race.Human);
            
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
            merchantImageText = new RawText(merchantImage, Console.WindowWidth / 2, 0, ConsoleColor.Green, TextAlign.Center);
            merchantCommentText = new RawText(merchantLobbyComment, Console.WindowWidth - 54, 4, ConsoleColor.White, TextAlign.Left);

            actionBoxMenu = new BoxMenu(20, Console.WindowHeight / 2, 14, 6, ConsoleColor.DarkGray);
            actionBoxMenu.AddItem("Buy", () => ChangeMenu(ShopMenuType.Buy), ConsoleColor.Green);
            actionBoxMenu.AddItem("Sell", () => ChangeMenu(ShopMenuType.Sell), ConsoleColor.Yellow);
            actionBoxMenu.AddItem("Talk", () => ChangeMenu(ShopMenuType.Talk), ConsoleColor.Cyan);
            actionBoxMenu.AddItem("Back", OnShopBack, ConsoleColor.Red);

            titleText = new Text("Shop", Console.WindowWidth / 2, 1, ConsoleColor.Yellow, TextAlign.Center);
            goldText = new Text($"보유 금액 : {player.Gold} G", 2, 2, ConsoleColor.Yellow, TextAlign.Left);
            currentMenu = actionBoxMenu;
        }

        void InitItemBoxMenu()
        {
            // itemBuyMenu 초기화
            itemBuyMenu = new BoxMenu(10, Console.WindowHeight / 2, 60, 13, ConsoleColor.DarkGray);
            itemBuyMenu.SetVisible(false);

            for (int i = 0; i < shopItemSlotLenth; i++)
            {
                MenuItem item = itemBuyMenu.AddItem("", () => { }, ConsoleColor.Green);
            }

            itemBuyMenu.AddEmptyItem();
            buyGolTextSlot = itemBuyMenu.AddTextItem($"보유 골드 : {player.Gold} G");
            itemBuyMenu.AddEmptyItem();
            itemBuyMenu.AddItem($"돌리기 {rerollCost} G", RerollItmes);
            itemBuyMenu.AddItem("돌아가기", BackMenu, ConsoleColor.Red);

            // itemSellMenu 초기화
            if (player == null) return;
            itemSellMenu = new BoxMenu(10, Console.WindowHeight / 2, 60, 13, ConsoleColor.DarkGray);
            itemSellMenu.SetVisible(false);

            for (int i = 0; i < shopItemSlotLenth; i++)
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
            shopBuyItems = ItemManager.GetInstance().GetRandomItems(shopItemSlotLenth, defaultItems);
        }

        void UpdateItemBuyMenuSlots()
        {
            var menuItemList = itemBuyMenu.Items;
            for (int i = 0; i < shopItemSlotLenth; i++)
            {
                if (i < shopBuyItems.Count)
                {
                    int index = i; // 클로저 안전하게
                    menuItemList[i].Text = GetItemBuyInfo(shopBuyItems[i]);
                    menuItemList[i].OnSelect = () => ShopBuy(shopBuyItems[index]);
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
            for (int i = 0; i < shopItemSlotLenth; i++)
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
            if (player.Gold < rerollCost)
            {
                comment = """
                상인
                돈이 부족해!!
                """;
                UpdateComment(comment);
                return;
            }

            player.Gold -= rerollCost;
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
                    comment = merchantBuyComment;
                    break;

                case ShopMenuType.Sell:
                    UpdateItemSellMenuSlots();
                    currentMenu = itemSellMenu;
                    comment = merchantSellComment;
                    break;

                case ShopMenuType.Talk:
                    ShopTalk();
                    currentMenu = actionBoxMenu;
                    comment = talkList.Count > 0 ? talkList[new Random().Next(talkList.Count)] : merchantLobbyComment;
                    break;
                case ShopMenuType.Lobby:
                default:
                    currentMenu = actionBoxMenu;
                    comment = merchantLobbyComment;
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
            if (talkList.Count == 0) return;

            Random random = new Random();
            int index = random.Next(talkList.Count);
            string comment = talkList[index];

            UpdateComment(comment);
        }
    }

}
