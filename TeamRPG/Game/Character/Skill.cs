using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Character
{
    public class Skill
    {
        public string name { get; }
        public string description { get; }
        public int mpCost { get; }
        public int power { get; }
        public int heal { get; }

        public Skill(string _name, string _description, int _mpCost, int _power = 0, int _heal = 0)
        {
            this.name = _name;
            this.description = _description;
            this.mpCost = _mpCost;
            this.power = _power;
            this.heal = _heal;
        }
    }
}
