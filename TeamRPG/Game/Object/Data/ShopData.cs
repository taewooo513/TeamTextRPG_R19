using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.ItemManager;

namespace TeamRPG.Game.Object.Data
{
    using Item = Item.Item; // Item 클래스의 경로를 명시적으로 지정

    public class ShopData
    {
        public string ShopName { get; set; } = "상점"; // 상점 이름
        public string MerchantName { get; set; } = "상인"; // 상인 이름

        public List<string> DefaultItemNames { get; set; }
        public List<string> RandomItemNames { get; set; }

        public List<Item> Items { get; set; } = new List<Item>();

        public int ItemLength { get; set; } = 6; // 상점 아이템 개수 (6개로 고정)
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
        public string RerollFailComment { get; set; } = "돈이 부족해!!"; // 아이템 리롤 실패 코멘트
        public List<string> TalkList { get; set; } = new List<string>();

        public void RerollItems()
        {
            Items = ItemManager.GetInstance().GetRandomItems(ItemLength, DefaultItemNames, RandomItemNames);
        }
        public void AddItem(Item item)
        {
            if (Items.Count < ItemLength)
                Items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            if (Items.Contains(item))
                Items.Remove(item);
        }
        public void ClearItems()
        {
            Items.Clear();
        }

        public string GetNameComment(string comment)
        {
            return $"{MerchantName}\n{comment}";
        }

        public string GetRandomTalk()
        {
            return TalkList.Count > 0
                ? TalkList[new Random().Next(TalkList.Count)]
                : "묵묵히 당신을 쳐다봅니다.";
        }
    }
}
