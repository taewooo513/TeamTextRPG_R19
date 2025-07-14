using System;
using System.Collections.Generic;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    internal class MenuItem
    {
        public string Text { get; set; }
        public Action OnSelect { get; private set; }
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

        public void RemoveItem(int index)
        {
            if (index < 0 || index >= items.Count)
                return;
            items.RemoveAt(index);
        }

        public override void Draw()
        {
            for (int i = 0; i < items.Count; i++)
            {
                string prefix = $"{i + 1}. ";
                var item = items[i];

                ConsoleColor color = item.IsEnabled ? items[i].Color : ConsoleColor.DarkGray;
                TextIOManager.GetInstance().OutputText(prefix + item.Text, X, Y + i, color);
            }
        }

        public void SelectByIndex(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                var item = items[index];
                if (item.IsEnabled)
                {
                    item.OnSelect?.Invoke();
                }
            }
        }


        public void SelectByNumber(int number)
        {
            SelectByIndex(number - 1);
        }
    }
}
