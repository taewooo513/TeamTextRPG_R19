using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Object.Item
{
    public class Weapon : Equipment
    {
        public DamageType DamageType { get; private set; } // 기본값은 물리 공격
        public string AsciiArt { get; private set; }
        public string BrokenAsciiArt { get; private set; }


        

        public Weapon(string name, string desc, Status status, int gold, DamageType damageType = DamageType.Physical, int maxDurability = 20, string asciiArt = "", string brokenArt = "")
            : base(name, desc, status, gold, maxDurability)
        {
            Type = ItemType.Weapon;
            DamageType = damageType;
            AsciiArt = asciiArt;
            BrokenAsciiArt = brokenArt;
        }
        

        public override void EquipTo(Player target)
        {
            //target.EquipItem(this);
        }


        public string GetAsciiArt()
        {
            return IsBroken ? BrokenAsciiArt : AsciiArt;
        }
    }
}
