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

        public Armor(string name, string desc, Status status, int gold, int maxDurability = 20) : base(name, desc, status, gold, maxDurability)
        {
            Type = ItemType.Armor;
        }

        public override void EquipTo(Player target)
        {
            // target.EquipArmor(this);
        }

    }
}
