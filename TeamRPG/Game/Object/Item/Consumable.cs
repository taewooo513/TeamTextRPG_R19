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
        public Action<Player> OnUseEffect { get; set; }

        public Consumable(string name, string description, Status status, int gold = 0)
            : base(name, description, status, gold)
        {
            Type = ItemType.Consumable;
        }

        public override void Init() { }

        public override void Use(Player target)
        {
            if (target == null)
                {
                        throw new ArgumentNullException(nameof(target), "Target player cannot be null.");
                }

            target.currentStatus.Add(Status);

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
