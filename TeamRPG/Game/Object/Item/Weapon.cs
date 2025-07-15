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
        public int AttackPower { get; private set; }
        public string AsciiArt { get; private set; }
        public string BrokenAsciiArt { get; private set; }

        public Weapon(string name, string desc, int gold, int attackPower, int maxDurability = 20, string asciiArt = "", string brokenArt = "")
            : base(maxDurability)
        {
            Name = name;
            Description = desc;
            Gold = gold;
            Type = ItemType.Weapon;
            AttackPower = attackPower;
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
