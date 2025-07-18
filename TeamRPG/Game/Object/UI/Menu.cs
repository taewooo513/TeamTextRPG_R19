using System;
using System.Collections.Generic;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    public enum DirectionType
    {
        Horizontal,
        Vertical
    }
    public class MenuItem
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

    public class Menu : UIElement
    {
        public DirectionType DirectionType { get; set; } = DirectionType.Vertical;
        public HorizontalAlign HorizontalAlign { get; set; } = HorizontalAlign.Left;
        public VerticalAlign VerticalAlign { get; set; } = VerticalAlign.Top;

        private List<MenuItem> items = new List<MenuItem>();
        private int selectedIndex = 0;

        public Menu(int x, int y, DirectionType directionType = DirectionType.Vertical) : base(x, y, ConsoleColor.White)
        {
            DirectionType = directionType;
            InitSelectedIndex();
        }

        public MenuItem AddItem(string text, Action onSelect, bool isEnabled = true, ConsoleColor color = ConsoleColor.White)
        {
            var item = new MenuItem(text, onSelect, isEnabled, color);
            items.Add(item);
            InitSelectedIndex();
            return item;
        }

        private void InitSelectedIndex()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].IsEnabled)
                {
                    selectedIndex = i;
                    return;
                }
            }
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

            var textIO = TextIOManager.GetInstance();

            if (DirectionType == DirectionType.Vertical)
            {
                int totalHeight = items.Count;
                int baseY = Y;

                // 수직 정렬
                switch (VerticalAlign)
                {
                    case VerticalAlign.Middle:
                        baseY = Y - totalHeight / 2;
                        break;
                    case VerticalAlign.Bottom:
                        baseY = Y - totalHeight;
                        break;
                    case VerticalAlign.Top:
                    default:
                        break;
                }

                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    if (!item.IsEnabled) continue;

                    string displayText = (i == selectedIndex) ? $"> {item.Text}" : $"{item.Text}";
                    int smartLength = textIO.OutputSmartTextLength(displayText);

                    int drawX = X;

                    switch (HorizontalAlign)
                    {
                        case HorizontalAlign.Center:
                            drawX = X - smartLength / 2;
                            break;
                        case HorizontalAlign.Right:
                            drawX = X - smartLength;
                            break;
                        case HorizontalAlign.Left:
                        default:
                            break;
                    }

                    textIO.OutputSmartText(displayText, drawX, baseY + i, item.Color);
                }
            }
            else if (DirectionType == DirectionType.Horizontal)
            {
                int _x = 0;
                int baseX = X;
                int baseY = Y;
                int totalWidth = 0;
                foreach (var item in items)
                {
                    if (!item.IsEnabled) continue;
                        totalWidth += textIO.OutputSmartTextLength(item.Text) + 3;
                }
                if(totalWidth > 0)
                    totalWidth -= 3;


                switch (VerticalAlign)
                {
                    case VerticalAlign.Middle:
                        baseY = Y;
                        break;
                    case VerticalAlign.Bottom:
                        baseY = Y;
                        break;
                    case VerticalAlign.Top:
                    default:
                        break;
                }

                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    if (!item.IsEnabled) continue;

                    string displayText = (i == selectedIndex) ? $"> {item.Text}" : $"{item.Text}";
                    int smartLength = textIO.OutputSmartTextLength(displayText);

                    int drawX = X + _x;

                    switch (HorizontalAlign)
                    {
                        case HorizontalAlign.Center:
                            drawX -= smartLength / 2;
                            break;
                        case HorizontalAlign.Right:
                            drawX -= smartLength;
                            break;
                        case HorizontalAlign.Left:
                        default:
                            break;
                    }

                    textIO.OutputSmartText(displayText, drawX, baseY, item.Color);
                    _x += smartLength + 3;
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
