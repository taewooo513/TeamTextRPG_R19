using System;
using TeamRPG.Game.Character;


namespace TeamRPG.Game.Object.Item
{
    public enum DamageType
    {
        Physical,
        Magical,
        Fire,
        Ice,
        Lightning,
        Poison
    }

    public abstract class Equipment : Item
    {
        public int MaxDurability { get; protected set; } = 10;
        public int CurrentDurability { get; protected set; }
        public bool IsBroken => CurrentDurability <= 0;

        public override void Init()
        {
            CurrentDurability = MaxDurability;
        }

        public Equipment(string name, string desc, Status status, int gold = 0, int maxDurability = 20, ItemType itemType = ItemType.Weapon) : base(name, desc, status, gold, itemType)
        {
            MaxDurability = maxDurability;
            CurrentDurability = maxDurability;
        }

        public void ReduceDurability(int amount)
        {
            if (IsBroken) return;

            CurrentDurability -= amount;
            if (CurrentDurability <= 0)
            {
                CurrentDurability = 0;
                OnBreak();
            }
        }

        public void RestoreDurability(int amount)
        {
            CurrentDurability = Math.Min(CurrentDurability + amount, MaxDurability);
        }

        protected virtual void OnBreak()
        {
            // 장비 파괴됐을 때 기능
        }

        public override void Use(Player target)
        {
            if (IsBroken) return;

            ReduceDurability(1);
            OnUse?.Invoke(target); // 아이템 사용 이벤트 호출
        }

    }
}
