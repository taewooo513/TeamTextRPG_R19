using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Character
{
    public class Trait
    {
        public string name { get; }
        public string description { get; }
        private Action<Player> effect;
        public Trait(string _name, string _description, Action<Player> _effect = null)
        {
            this.name = _name;
            this.description = _description;
            this.effect = _effect;
        }
        public void ApplyEffect(Player player)
        {
            effect?.Invoke(player);
        }
    }
}
