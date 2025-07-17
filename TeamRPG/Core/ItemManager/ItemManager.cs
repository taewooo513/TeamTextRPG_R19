using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Item;

namespace TeamRPG.Core.ItemManager
{
    internal class ItemManager : Singleton<ItemManager>
    {
        private Dictionary<string, Item> itemDictionary;

        //상점
        //회복계열
        //30G
        //향긋한 약초 - 매 행동시 생명력 +3 / 서큐버스의 라이프 드레인과 유사한 매커니즘 // 이게 핵심 소모품으로써 자리하고자 설계 했습니다. / 전투 종료시 까지 지속
        //가격 조율이 필요할 듯 합니다 / QA 돌려봐야 알겠지만 가성비가 좀 오밸같아 보임
        //50G
        //회복포션(생명력 30 회복) - %회복할지 고정값 회복을 할지 고민 해봤는데 스탯치가 높은편이 아니라 고정값 회복으로 채택했습니다
        //마나포션(마나 50 회복)
        //150G
        //강철 검 - 공격력 +6 , 내구도 20
        //라운드 실드 - 생명력 +12 , 내구도 20 / 스탯을 추가로 부여할지 고민을 많이 했으나, 방어력을 넣고 또 방어력 계산식을 넣는거보다 생명력으로 퉁치는게 편해서
        //                 / 생명력으로 진행 스탯 상승폭 기준은 Tier 1 몬스터 기준으로 잡았습니다.
        //수습생의 지팡이 - 마법공격력 +5 / 최대 마나 +10 / 내구도 20
        //200G
        //현자의 로브 - 생명력 +5 / 최대 마나 +10 / 내구도 20
        //250G
        //마력의 탈리스만 - 마법공격력 +10 / 내구도 무제한 / 스킬(마법)공격력을 향상시킬 수단으로 추가 했습니다.
        //마나의 탈리스만 - 최대 마나 +20 / 내구도 무제한

        //방랑상인
        //500G
        //엘릭서(Elixir) - 전투당 1번 사망시 최대 생명력의 50%로 1회 부활(Resurrection)
        //1000G
        //성검(HolySword) - 공격력 +30 마계(성) 환경의 몬스터들의 물리, 마법 저항력을 무시
        //800G
        //수호자의 망치(GuardianHammer) - 공격력 +15 생명력 +20
        //1000G
        //대룡궁(DragonHunter) - 공격력 +20 / 드래곤(Dragon) 계역의 몬스터에게 공격력 +20 추가
        //800G
        //철의의지(IronHeart) - 모든 상태이상 면역
        //800G
        //달의 파편(LunarDust) - 마법 공격력 +15 / 최대 마나 +30 /매 행동시 마나 5 회복

        public void Init()
        {
            itemDictionary = new Dictionary<string, Item>();

            Status temp = StatusFactory.EmptyStatus;

            // 상점
            // 소모품
            var hurb = new Consumable("향긋한 약초", "매 턴 생명력 +3", StatusFactory.EmptyStatus, 30);
            AddItem(hurb);


            temp = StatusFactory.EmptyStatus;
            temp.HP = 30;
            var healingPotion = new Consumable("회복 포션", "HP 30 회복", temp, 50);
            AddItem(healingPotion);

            temp = StatusFactory.EmptyStatus;
            temp.MP = 50;
            var manaPotion = new Consumable("마나 포션", "MP 20 회복", temp, 50);
            AddItem(manaPotion);

            // 무기
            temp = StatusFactory.EmptyStatus;
            var ironSword = new Weapon("강철검", "공격력 +6", temp, 150);
            AddItem(ironSword);

            temp = StatusFactory.EmptyStatus;
            temp.MinAttack = 5;
            temp.MaxAttack = 5;
            temp.MP = 10;
            var magicStaff = new Weapon("수습생의 지팡이", "마법 공격력 +5, 최대 마나 +10", temp, 150, DamageType.Magical);
            AddItem(magicStaff);

            temp = StatusFactory.EmptyStatus;
            temp.MinAttack = 10;
            temp.MaxAttack = 10;
            var talismanOfPower = new Weapon("마력의 탈리스만", "마법 공격력 +10, 내구도 무제한", temp, 250, DamageType.Magical, int.MaxValue);
            AddItem(talismanOfPower);

            // 방어구
            temp = StatusFactory.EmptyStatus;
            temp.HP = 12;
            var roundShield = new Armor("라운드 실드", "HP +12", temp, 150);
            AddItem(roundShield);

            temp = StatusFactory.EmptyStatus;
            temp.HP = 5;
            temp.MP = 10;
            var robeOfWisdom = new Armor("현자의 로브", "HP +5, 최대 MP +10", temp, 150);
            AddItem(robeOfWisdom);

            temp = StatusFactory.EmptyStatus;
            temp.MP = 20;
            var talismanOfMana = new Armor("마나의 탈리스만", "최대 마나 +20, 내구도 무제한", temp, 250);
            AddItem(talismanOfMana);

            // 방랑 상인
            // 소모품
            temp = StatusFactory.EmptyStatus;
            temp.MP = 10;
            var elixir = new Consumable("엘릭서", "전투당 1번 사망시 최대 생명력의 50%로 1회 부활", temp, 500);
            AddItem(elixir);

            // 무기
            temp = StatusFactory.EmptyStatus;
            temp.MinAttack = 30;
            temp.MaxAttack = 30;
            var holySword = new Weapon("성검", "공격력 +30 마계 환경의 몬스터들의 물리, 마법 저항력을 무시", temp, 1000);
            AddItem(holySword);

            temp = StatusFactory.EmptyStatus;
            temp.MinAttack = 15;
            temp.MaxAttack = 15;
            temp.HP = 20;
            var guardianHammer = new Weapon("수호자의 망치", "공격력 +30 마계 환경의 몬스터들의 물리, 마법 저항력을 무시", temp, 1000);
            AddItem(guardianHammer);

            temp = StatusFactory.EmptyStatus;
            temp.MinAttack = 20;
            temp.MaxAttack = 20;
            var dragonHunter = new Weapon("대룡궁", "공격력 +20 / 드래곤 계열의 몬스터에게 공격력 +20 추가", temp, 1000);
            AddItem(dragonHunter);

            temp = StatusFactory.EmptyStatus;
            temp.Agility = 1000;
            var ironHeart = new Armor("철의의지", "모든 상태이상 면역", temp, 800);
            AddItem(ironHeart);

            temp = StatusFactory.EmptyStatus;
            temp.MinAttack = 15;
            temp.MaxAttack = 15;
            temp.MP = 30;
            var lunarDsut = new Weapon("달의 파편", "마법 공격력 +15 / 최대 마나 +30 /매 행동시 마나 5 회복", temp, 800, DamageType.Magical);
            AddItem(lunarDsut);

            //500G
            //엘릭서(Elixir) - 전투당 1번 사망시 최대 생명력의 50%로 1회 부활(Resurrection)
            //1000G
            //성검(HolySword) - 공격력 +30 마계(성) 환경의 몬스터들의 물리, 마법 저항력을 무시
            //800G
            //수호자의 망치(GuardianHammer) - 공격력 +15 생명력 +20
            //1000G
            //대룡궁(DragonHunter) - 공격력 +20 / 드래곤(Dragon) 계역의 몬스터에게 공격력 +20 추가
            //800G
            //철의의지(IronHeart) - 모든 상태이상 면역
            //800G
            //달의 파편(LunarDust) - 마법 공격력 +15 / 최대 마나 +30 /매 행동시 마나 5 회복
        }


        public void AddItem(Item item)
        {
            AddItem(item.Name, item);
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
                    var newC = new Consumable(c.Name, c.Description, StatusFactory.Clone(c.Status), c.Gold);
                    // newC.OnUseEffect = c.OnUseEffect;
                    return newC;

                case Weapon w:
                    return new Weapon(w.Name, w.Description, StatusFactory.Clone(w.Status), w.Gold, w.DamageType, w.MaxDurability);
                case Armor a:
                    return new Armor(a.Name, a.Description, StatusFactory.Clone(a.Status), a.Gold, a.MaxDurability);
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


        public List<Item> GetRandomItems(int count, List<string> defaultItems)
        {
            if (itemDictionary == null) Init();
            var allItemList = itemDictionary.Values.ToList();
            var resultItemList = new List<Item>();
            Random random = new Random();

            // 기본 아이템을 우선적으로 추가
            foreach (var itemName in defaultItems)
            {
                if (resultItemList.Count <= count) break; // 아이템 개수가 지정된 수에 도달하면 중단

                if (itemDictionary.TryGetValue(itemName, out Item item))
                {
                    resultItemList.Add(item);
                    allItemList.Remove(item); // 중복 방지를 위해 제거
                }
            }

            for (int i = resultItemList.Count; i < count; i++)
            {
                if (resultItemList.Count <= count) break; // 아이템 개수가 지정된 수에 도달하면 중단
                if (allItemList.Count == 0) break; // 아이템이 더 이상 없으면 중단

                int index = random.Next(allItemList.Count);
                resultItemList.Add(allItemList[index]);
                allItemList.RemoveAt(index); // 중복 방지를 위해 제거
            }

            return resultItemList;
        }


        public List<Item> GetRandomItems(int count, List<string> defaultItems, List<string> randomItems)
        {
            if (itemDictionary == null) Init();
            var defaultItemList = defaultItems.Where(name => itemDictionary.ContainsKey(name)).Select(name => itemDictionary[name]).ToList();
            var randomItemList = randomItems.Where(name => itemDictionary.ContainsKey(name)).Select(name => itemDictionary[name]).ToList();
            var resultItemList = new List<Item>();
            Random random = new Random();

            // 기본 아이템을 우선적으로 추가
            foreach (var item in defaultItemList)
            {
                if (resultItemList.Count >= count) return resultItemList; // 아이템 개수가 지정된 수에 도달하면 중단
                resultItemList.Add(item);
            }

            var rand = new Random();
            for (int i = randomItemList.Count - 1; i > 0; i--)
            {
                int j = rand.Next(i + 1);
                (randomItemList[i], randomItemList[j]) = (randomItemList[j], randomItemList[i]);
            }

            // 랜덤 아이템을 추가
            for (int i = 0; i < randomItemList.Count && resultItemList.Count < count; i++)
            {
                if (resultItemList.Count >= count) return resultItemList; // 아이템 개수가 지정된 수에 도달하면 중단
                resultItemList.Add(randomItemList[i]);
            }

            return resultItemList;
        }

    }
}
