using System;
using System.Collections.Generic;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    internal class MenuItem
    {
        public string Text { get; set; }
        public Action OnSelect { get; set; }
        public bool IsEnabled { get; set; }
        public ConsoleColor Color { get; set; }

        public MenuItem(string text, Action onSelect, ConsoleColor color = ConsoleColor.White, bool isEnabled = true)
        {
            Text = text;
            OnSelect = onSelect;
            IsEnabled = isEnabled;
            Color = color;
        }
    }

    internal class Menu : UIElement
    {
        private List<MenuItem> items = new List<MenuItem>();
        private int selectedIndex = 0; // 현재 선택된 항목

        public Menu(int x, int y) : base(x, y, ConsoleColor.White) { }
        public Menu(int x, int y, List<MenuItem> menuItems) : base(x, y, ConsoleColor.White)
        {
            items = menuItems ?? new List<MenuItem>();
        }

        public void AddItem(string text, Action onSelect, ConsoleColor color = ConsoleColor.White, bool isEnabled = true)
        {
            items.Add(new MenuItem(text, onSelect, color, isEnabled));
        }

        public MenuItem? GetItem(int index)
        {
            if (index < 0 || index >= items.Count)
                return null;
            return items[index];
        }

        public List<MenuItem> GetItems() => items;

        public void RemoveItem(int index)
        {
            if (index < 0 || index >= items.Count)
                return;
            items.RemoveAt(index);
        }

        public override void Draw()
        {
            if (!IsVisible) return;

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i];

                // 선택된 항목은 강조 표시
                string displayText = (i == selectedIndex) ? $"▶ {item.Text}" : $"{item.Text}";
                ConsoleColor color = item.IsEnabled
                    ? (i == selectedIndex ? ConsoleColor.Yellow : item.Color)
                    : ConsoleColor.DarkGray;

                TextIOManager.GetInstance().OutputSmartText(displayText, X, Y + i, color);
            }
        }

        public void MoveUp()
        {
            int count = items.Count;
            if (count == 0) return;

            do
            {
                selectedIndex = (selectedIndex - 1 + count) % count;
            }
            while (!items[selectedIndex].IsEnabled);

            SoundManager.GetInstance().PlaySound("Clicksmall", 1f);
        }

        public void MoveDown()
        {
            int count = items.Count;
            if (count == 0) return;

            do
            {
                selectedIndex = (selectedIndex + 1) % count;
            }
            while (!items[selectedIndex].IsEnabled);

            SoundManager.GetInstance().PlaySound("Clicksmall", 1f);
        }

        public void Select()
        {
            if (selectedIndex >= 0 && selectedIndex < items.Count)
            {
                var item = items[selectedIndex];
                if (item.IsEnabled)
                {
                    item.OnSelect?.Invoke();
                }
            }

            SoundManager.GetInstance().PlaySound("ShopSelect", 1f);
        }

        public void SelectByIndex(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                selectedIndex = index;
                Select();
            }
        }

        public void SelectByNumber(int number)
        {
            SelectByIndex(number - 1);
        }

        public int GetSelectedIndex()
        {
            return selectedIndex;
        }
    }
}
