using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Object.Item
{
    public class Consumable : Item
    {
        public int HealAmount { get; private set; }
        public int ManaAmount { get; private set; }
        public Action<Player> OnUseEffect { get; set; }

        public Consumable(string name, string desc, int price, int heal, int mana)
        {
            Name = name;
            Description = desc;
            Gold = price;
            Type = ItemType.Consumable;
            HealAmount = heal;
            ManaAmount = mana;
        }

        public override void Init() { }

        public override void Use(Player target)
        {
            /*
            if (HealAmount > 0)
                target.CurrentStatus.HP += HealAmount;
            if (ManaAmount > 0)
                target.CurrentStatus.MP += ManaAmount;
            */
            OnUseEffect?.Invoke(target);
        }
    }

}
