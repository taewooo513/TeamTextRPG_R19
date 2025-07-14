using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Character
{
    public class Status
    {
        public int HP { get; set; }
        public int MP { get; set; }
        public int MinAttack { get; set; }
        public int MaxAttack { get; set; }
        public int Agility { get; set; }
        public int Tenacity { get; set; }
        public int Luck { get; set; }

        public Status(int hp, int mp, int minAtk, int maxAtk, int agi, int tena, int luck)
        {
            HP = hp;
            MP = mp;
            MinAttack = minAtk;
            MaxAttack = maxAtk;
            Agility = agi;
            Tenacity = tena;
            Luck = luck;
        }

        public Status Add(Status other)
        {
            return new Status(
                HP + other.HP,
                MP + other.MP,
                MinAttack + other.MinAttack,
                MaxAttack + other.MaxAttack,
                Agility + other.Agility,
                Tenacity + other.Tenacity,
                Luck + other.Luck
            );
        }

        public override string ToString()
        {
            return $"HP:{HP}, MP:{MP}, ATK:{MinAttack}-{MaxAttack}, AGI:{Agility}, TEN:{Tenacity}, LUK:{Luck}";
        }
    }
}
