using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Object.Item
{
    // 아이템 종류
    public enum ItemType
    {
        Consumable,
        Weapon,
        Armor
    }

    // 아이템 등급
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }

    public abstract class Item
    {
        public string Name { get; protected set; }        // 표시 이름
        public string Description { get; protected set; } // 설명
        public int Gold { get; protected set; }          // 판매 가격
        public ItemType Type { get; protected set; }

        public abstract void Init();

        public abstract void Use(Player target);
    }
}
