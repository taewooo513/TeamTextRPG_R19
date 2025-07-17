using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.ItemManager;

namespace TeamRPG.Game.Object.Item
{
    public class Inventory
    {

        public List<Item> AllItems => itemDictionary.Values.SelectMany(items => items).ToList(); // 모든 아이템 목록을 반환

        public int Count => itemDictionary.Count; // 아이템 종류의 개수

        public Dictionary<string, List<Item>> itemDictionary = new();

        public bool ContainsItem(string itemName)
        {
            return itemDictionary.ContainsKey(itemName) && itemDictionary[itemName].Count > 0; // 아이템 목록이 존재하고 개수가 0보다 큰 경우
        }

        public bool TryGetItemLength(string itemName, out int length)
        {
            if (itemDictionary.TryGetValue(itemName, out List<Item> items))
            {
                length = items.Count; // 아이템 목록의 길이 반환
                return true; // 아이템 목록이 존재하는 경우
            }

            length = 0; // 아이템 목록이 존재하지 않는 경우
            return false;
        }

        public bool TryGetItems(string itemName, out List<Item> items)
        {
            if (itemDictionary.TryGetValue(itemName, out items))
                return true; // 아이템 목록이 존재하는 경우

            items = null; // 아이템 목록이 존재하지 않는 경우
            return false;
        }

        public bool AddItem(string itemName)
        {
            return AddItem(itemName, 1);
        }

        public bool AddItem(string itemName, int count)
        {
            if (count <= 0)
                return false; // 아이템 개수가 0 이하인 경우 추가하지 않음

            Item item = ItemManager.GetInstance().GetItem(itemName);
            if (item == null)
                return false; // 아이템이 존재하지 않는 경우 추가하지 않음

            for (int i = 0; i < count; i++)
            {
                if (!AddItem(item))
                    return false; // 아이템 추가에 실패한 경우
            }
            return true; // 모든 아이템이 성공적으로 추가된 경우
        }

        public bool AddItem(Item item)
        {
            if (item == null || item.Name == null)
                return false; // 아이템이 null이거나 이름이 없는 경우 추가하지 않음

            if (!itemDictionary.ContainsKey(item.Name))
                itemDictionary[item.Name] = new();

            itemDictionary[item.Name].Add(item);
            return true;
        }

        public bool RemoveItem(string itemName)
        {
            return RemoveItem(itemName, 1);
        }

        public bool RemoveItem(string itemName, int count)
        {
            if (itemName == null || !itemDictionary.ContainsKey(itemName) || count <= 0)
                return false; // 아이템 이름이 null이거나 존재하지 않거나 개수가 0 이하인 경우 제거하지 않음

            var itemList = itemDictionary[itemName];
            if (itemList.Count < count)
                return false; // 아이템 목록의 개수가 요청한 개수보다 적은 경우 제거하지 않음

            for (int i = 0; i < count; i++)
            {
                itemList.RemoveAt(0); // 첫 번째 아이템 제거
            }

            if (itemList.Count == 0)
                itemDictionary.Remove(itemName); // 아이템 목록이 비어있으면 해당 키 제거

            return true; // 아이템이 성공적으로 제거된 경우
        }

        public bool RemoveItem(Item item)
        {
            if (item == null || item.Name == null || !itemDictionary.ContainsKey(item.Name))
                return false; // 아이템이 null이거나 이름이 없는 경우 또는 아이템이 존재하지 않는 경우 제거하지 않음

            var itemList = itemDictionary[item.Name];
            if (itemList.Count > 0)
            {
                itemList.Remove(item);
                if (itemList.Count == 0)
                    itemDictionary.Remove(item.Name); // 아이템 목록이 비어있으면 해당 키 제거
                return true;
            }
            return false; // 아이템 목록이 비어있는 경우 제거하지 않음
        }


        public void Clear()
        {
            itemDictionary.Clear(); // 모든 아이템 제거
        }
    }
}
