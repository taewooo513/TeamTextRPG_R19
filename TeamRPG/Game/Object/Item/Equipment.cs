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
        public ItemType itemType { get; set; }

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

        public void ReduceDurability(int amount, Player owner = null)
        {
            if (IsBroken) return;

            CurrentDurability -= amount;
            if (CurrentDurability <= 0)
            {
                CurrentDurability = 0;
                if (owner != null)
                    OnBreak(owner);
            }
        }

        public void RestoreDurability(int amount)
        {
            CurrentDurability = Math.Min(CurrentDurability + amount, MaxDurability);
        }

        protected virtual void OnBreak(Player owner)
        {
            // 플레이어가 장착 해제하고 인벤토리에서 제거
            if (itemType == ItemType.Weapon && owner.eWeapon == this)
            {
                owner.eWeapon = null;
            }
            else if (itemType == ItemType.Armor && owner.eArmor == this)
            {
                owner.eArmor = null;
            }

            owner.Inventory.RemoveItem(this);

            owner.RecalculateCurrentStatus();

            PlayerManager.GetInstance().gameMsg += $"\n{this.Name}이(가) 완전히 파괴되어 장비 해제 및 제거되었습니다!";
        }

        public override void Use(Player target)
        {
            if (IsBroken) return;

            ReduceDurability(1, target);
            OnUse?.Invoke(target); // 아이템 사용 이벤트 호출
        }

    }
}
