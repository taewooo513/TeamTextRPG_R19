using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Object.Item
{
    public class Armor : Equipment
    {
        public int LifeBonus { get; private set; }

        public Armor(string name, string desc, int gold, int lifeBonus, int mana = 0, int maxDurability = 20) : base(mana, maxDurability)
        {
            Name = name;
            Description = desc;
            Gold = gold;
            Type = ItemType.Armor;
            LifeBonus = lifeBonus;
        }

        public override void EquipTo(Player target)
        {
            // target.EquipArmor(this);
        }

        protected override void OnUseEffect(Player target)
        {

        }
    }
}
