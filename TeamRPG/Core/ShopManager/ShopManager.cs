using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Object.Item;
using TeamRPG.Game.Scene;
using TeamRPG.Core.ItemManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Object.Data;


namespace TeamRPG.Core.ShopManager
{
    public class ShopManager : Singleton<ShopManager>
    {
        Dictionary<string, ShopData> shops = new();

        public void Init()
        {
            shops = new Dictionary<string, ShopData>();

            

            // 기본 상점 데이터 추가
            AddShop("상점", new ShopData
                {
                        ShopName = "던전 상점",
                        MerchantName = "상인",
                        MerchantImageName = "상인", // 상인 이미지 이름
                        DefaultItemNames = new List<string>
                        {
                            "회복 포션"
                        },
                        RandomItemNames = new List<string>
                        {
                            "향긋한 허브", "마나 포션", "균형의 정수", "정령의 숨결", "바위의 혼", "강철검", "수습생의 지팡이", "마력의 탈리스만",
                            "부러진 단검", "나무 몽둥이", "순은의 검", "요정의 활", "대장장이의 망치", "강철 전투도끼",
                            "라운드 실드", "현자의 로브", "마나의 탈리스만", "녹슨 철갑옷"
                        },
                        LobbyComment = "필요한 물건이 있으신가요?",
                        BuyComment = "물건을 구매하시겠습니까?",
                        BuySuccessComment = "구매 감사합니다!",
                        BuyFailComment = "돈이 부족해!!",
                        SellComment = "물건을 판매하시겠습니까?",
                        SellSuccessComment = "판매 감사합니다!",
                        SellFailComment = "대체 뭐를 팔겠단거야!",
                        RerollSuccessComment = "새로운 상품입니다!",
                        RerollFailComment = "돈이 없는데 뭘 보겠단거야!",
                        ItemLength = 6,


                        TalkList = new List<string>
                        {
                            "안녕하세요, 여행자님!",
                            "이곳은 다양한 물건을 판매하는 상점입니다.",
                            "저희 상점에서는 다양한 아이템을 구매할 수 있습니다.",
                            "여기에는 저 말고도 다른 상인이 존재합니다.",
                            "그래서 물건은 사실건가요?"
                        }
                });

            AddShop("방랑상인", new ShopData
            {
                ShopName = "떠돌이의 휴식처",
                MerchantName = "방랑상인",
                MerchantImageName = "방랑상인", // 상인 이미지 이름
                DefaultItemNames = new List<string>
                {
                },
                RandomItemNames = new List<string>
                {
                    "엘릭서", "성검", "수호자의 망치", "대룡궁",
                    "철의의지", "달의 파편", "도박사의 대검"
                },
                LobbyComment = "운명이군요.",
                BuyComment = "가치는 충분합니다.",
                BuySuccessComment = "편안한 여졍되시길...",
                BuyFailComment = "아직 필요하지 않은 것 같군요",
                SellComment = "의미없는 것들은 털어버리시죠.",
                SellSuccessComment = "당신의 짐을 덜어드리겠습니다.",
                SellFailComment = "Error",
                RerollSuccessComment = "이번에는 괜찮은게 나왔나요?",
                RerollFailComment = "다음에 봅시다.",
                ItemLength = 6,
                TalkList = new List<string>
                        {
                            "반갑습니다.",
                            "약초 하나 정도는 기회가된다면 가지고 다니시죠.",
                            "수상한 버섯은 되도록 먹지 않는게 좋습니다.",
                            "우물에는 많은 것이 있습니다. 해로운것도 말이죠...",
                            "이곳은 위험한 곳입니다. 항상 조심하세요.",
                            "상인은 취미입니다. 제 걱정은 괜찮습니다."
                        }
            });
        }

        public void AddShop(string shopName, ShopData shopData)
        {
            if (!shops.ContainsKey(shopName))
            {
                shops[shopName] = shopData;
            }
        }
        public ShopData? GetShop(string shopName)
        {
            if (shops.TryGetValue(shopName, out var shopData))
                return shopData;
            else
                return null;
        }

        public ShopData? GetRandomShop()
        {
            if (shops.Count == 0)
                return null;

            /*
            var random = new Random();
            int index = random.Next(shops.Count);
            return shops.ElementAt(index).Value;
            */

            var random = new Random();
            int index = random.Next(1, 101);
            if (index <= 95) // 95% 확률로 기본 상점
            {
                return GetShop("상점");
            }
            else // 5% 확률로 방랑상인
            {
                return GetShop("방랑상인");
            }
        }

    }
}
