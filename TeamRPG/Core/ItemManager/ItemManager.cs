using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Item;

namespace TeamRPG.Core.ItemManager
{
    internal class ItemManager : Singleton<ItemManager>
    {
        private Dictionary<string, Item> itemDictionary;

        public void Init()
        {
            itemDictionary = new Dictionary<string, Item>();

            // 예시 아이템 추가
            var hurb = new Consumable("향긋한 허브", "매 턴 생명력 +3", 30, 0, 0);
            hurb.OnUseEffect = (Player target) =>
            {
            };
            AddItem("Hurb", hurb);

            var healingPotion = new Consumable("회복 포션", "HP 30 회복", 50, 30, 0);
            AddItem("HealingPotion", healingPotion);

            var manaPotion = new Consumable("마나 포션", "MP 20 회복", 50, 0, 20);
            AddItem("ManaPotion", manaPotion);

            var ironSword = new Weapon("강철검", "공격력 +6", 150, 6, 20, "", "");
            AddItem("IronSword", ironSword);

            // Armors
            var roundShield = new Armor("라운드 실드", "HP +12", 150, 12);
            AddItem("RoundShield", roundShield);


            var squareShield = new Armor("사각 실드", "HP +15", 150, 12);
            AddItem("RoundShield", roundShield);
        }

        public void AddItem(string itemName, Item item)
        {
            if (!itemDictionary.ContainsKey(itemName))
                itemDictionary.Add(itemName, item);
        }

        public Item GetItem(string itemName)
        {
            if (itemDictionary.TryGetValue(itemName, out Item item))
                return item;

            return null;
        }

        public void RemoveItem(string itemName)
        {
            if (itemDictionary.ContainsKey(itemName))
                itemDictionary.Remove(itemName);
        }

        // 복사본 생성 (원본이 공유되면 안 되므로)
        public Item CloneItem(string key)
        {
            var original = GetItem(key);
            if (original == null)
                return null;

            switch (original)
            {
                case Consumable c:
                    var newC = new Consumable(c.Name, c.Description, c.Gold, c.HealAmount, c.ManaAmount);
                    newC.OnUseEffect = c.OnUseEffect;
                    return newC;

                case Weapon w:
                    return new Weapon(w.Name, w.Description, w.Gold, w.AttackPower, w.MaxDurability,
                                      w.AsciiArt, w.BrokenAsciiArt);

                case Armor a:
                    return new Armor(a.Name, a.Description, a.Gold, a.LifeBonus, a.MaxDurability);
            }

            return null;
        }


        public List<Item> GetRandomItems(int count)
        {
            if (itemDictionary == null) Init();

            Random random = new Random();
            List<Item> randomItems = new List<Item>();

            var itemList = itemDictionary.Values.ToList();
            for (int i = 0; i < count; i++)
            {
                if (itemList.Count == 0) break; // 아이템이 더 이상 없으면 중단

                int index = random.Next(itemList.Count);
                randomItems.Add(itemList[index]);
                itemList.RemoveAt(index); // 중복 방지를 위해 제거
            }

            return randomItems;
        }

    }
}
