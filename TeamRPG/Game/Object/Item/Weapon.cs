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
        public int DamagePoint { get; private set; }
        public DamageType DamageType { get; private set; } // 기본값은 물리 공격
        public string AsciiArt { get; private set; }
        public string BrokenAsciiArt { get; private set; }

        
        public Weapon(string name, string desc, int gold, int damagePoint, DamageType damageType = DamageType.Physical, int mana = 0, int maxDurability = 20, string asciiArt = "", string brokenArt = "")
            : base(mana, maxDurability)
        {
            Name = name;
            Description = desc;
            Gold = gold;
            Type = ItemType.Weapon;
            DamagePoint = damagePoint;
            DamageType = damageType;
            AsciiArt = asciiArt;
            BrokenAsciiArt = brokenArt;
        }
        

        public override void EquipTo(Player target)
        {
            //target.EquipItem(this);
        }

        protected override void OnUseEffect(Player target)
        {
            // 공격 처리 로직
            //target.Attack(AttackPower);
        }

        public string GetAsciiArt()
        {
            return IsBroken ? BrokenAsciiArt : AsciiArt;
        }
    }
}
