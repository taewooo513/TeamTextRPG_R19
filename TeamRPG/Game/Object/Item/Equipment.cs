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
        public int Mana { get; private set; }
        public int MaxDurability { get; protected set; } = 10;
        public int CurrentDurability { get; protected set; }

        public bool IsBroken => CurrentDurability <= 0;

        public override void Init()
        {
            CurrentDurability = MaxDurability;
        }

        public Equipment(int mana = 0, int maxDurability = 20) : this(maxDurability)
        {
            Mana = mana;
        }

        public Equipment(int maxDurability = 20)
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

            OnUseEffect(target); // 무기나 방어구의 효과 실행
            ReduceDurability(1);
        }

        // 이건 무기/방어구가 구체적으로 구현할 부분
        protected abstract void OnUseEffect(Player target);

        // 착용은 따로
        public abstract void EquipTo(Player target);
    }
}
