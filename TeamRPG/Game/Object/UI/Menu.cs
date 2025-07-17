using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    public enum DirectionType
    {
        Horizontal,
        Vertical
    }

    internal class MenuItem
    {
        public string Text { get; set; }
        public Action OnSelect { get; set; }
        public bool IsEnabled { get; set; }
        public ConsoleColor Color { get; set; }

        public MenuItem(string text, Action onSelect, bool isEnabled = true, ConsoleColor color = ConsoleColor.White)
        {
            Text = text;
            OnSelect = onSelect;
            IsEnabled = isEnabled;
            Color = color;
        }
    }

    internal class Menu : UIElement
    {
        public DirectionType DirectionType { get; set; } = DirectionType.Vertical; // 메뉴 방향 (수평 또는 수직)
        private List<MenuItem> items = new List<MenuItem>();
        private int selectedIndex = 0; // 현재 선택된 항목

        public Menu(int x, int y, DirectionType directionType = DirectionType.Vertical) : base(x, y, ConsoleColor.White) {
            DirectionType = directionType;
        }
        public MenuItem AddItem(string text, Action onSelect, bool isEnabled = true, ConsoleColor color = ConsoleColor.White)
        {
            var item = new MenuItem(text, onSelect, isEnabled, color);
            items.Add(item);
            return item;
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

            if(DirectionType == DirectionType.Vertical)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];

                    // 선택된 항목은 강조 표시
                    string displayText = (i == selectedIndex) ? $"> {item.Text}" : $"{item.Text}";
                    TextIOManager.GetInstance().OutputSmartText(displayText, X, Y + i);
                }
            }
            else if (DirectionType == DirectionType.Horizontal)
            {
                int _x = 0;
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    // 선택된 항목은 강조 표시
                    string displayText = (i == selectedIndex) ? $"> {item.Text}" : $"{item.Text}";
                    TextIOManager.GetInstance().OutputSmartText(displayText, X + _x, Y);
                    _x += TextIOManager.GetInstance().OutputSmartTextLength(displayText) + 3; // 항목 간격 추가
                }
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
