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
        public Consumable(string name, string description, Status status, int gold = 0)
            : base(name, description, status, gold)
        {
            Type = ItemType.Consumable;
        }

        public override void Init() { }

        public override void Use(Player target)
        {
            if (target == null)
                return;

            BaseEffect(target);
            OnUse?.Invoke(target); // 아이템 사용 이벤트 호출
        }

        public virtual void BaseEffect(Player target)
        {
            target.currentStatus.Add(Status);
        }
    }

}
