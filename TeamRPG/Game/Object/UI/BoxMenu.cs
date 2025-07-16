using System;
using System.Collections.Generic;
using System.Text;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    internal class BoxMenu : UIElement
    {
        private Box box;
        private Menu menu;
        private int paddingLeft = 1;
        private int paddingTop = 1;

        public List<MenuItem> Items => menu.GetItems();

        public BoxMenu(int x, int y, int width, int height, ConsoleColor boxColor = ConsoleColor.White, ConsoleColor textColor = ConsoleColor.White)
            : base(x, y, textColor)
        {
            box = new Box(x, y, width, height, boxColor);
            menu = new Menu(x + paddingLeft, y + paddingTop);
        }

        public MenuItem AddItem(string text, Action onSelect, bool isEnabled = true, ConsoleColor? color = null)
        {
            string trimmedText = TrimTextToFit(text);
            menu.AddItem(trimmedText, onSelect, isEnabled, color ?? Color);
            return menu.GetItem(menu.GetItems().Count - 1) ?? throw new InvalidOperationException("Failed to add item to menu.");
        }


        public void AddEmptyItem()
        {
            menu.AddItem("", () => { }, false);
        }

        public MenuItem AddTextItem(string text)
        {
            return AddItem(text, () => { }, false);
        }

        public void ClearItems()
        {
            menu.GetItems().Clear();
        }

        public void SelectByNumber(int number)
        {
            menu.SelectByNumber(number);
        }

        public void MoveUp()
        {
            menu.MoveUp();
        }

        public void MoveDown()
        {
            menu.MoveDown();
        }

        public void Select()
        {
            menu.Select();
        }

        public override void Draw()
        {
            if (!IsVisible) return;

            box.Draw();

            int maxItems = box.Height - 2;
            var items = menu.GetItems();
            int selectedIndex = menu.GetSelectedIndex();

            for (int i = 0; i < Math.Min(items.Count, maxItems); i++)
            {
                var item = items[i];
                string text = TrimTextToFit(item.Text);
                string displayText = (i == selectedIndex) ? $"▶ {text}" : $"{text}";

                ConsoleColor color = item.IsEnabled
                    ? (i == selectedIndex ? ConsoleColor.Yellow : item.Color)
                    : ConsoleColor.DarkGray;

                TextIOManager.GetInstance().OutputSmartText(text, box.X + paddingLeft, box.Y + paddingTop + i, color);
            }
        }
        private string TrimTextToFit(string text)
        {
            int maxWidth = box.Width - 4;
            int curWidth = 0;
            StringBuilder sb = new StringBuilder();

            foreach (char ch in text)
            {
                int width = TextIOManager.GetInstance().OutputSmartTextLength(ch.ToString());
                if (curWidth + width > maxWidth - 3) // "..." 포함
                {
                    sb.Append("...");
                    break;
                }
                sb.Append(ch);
                curWidth += width;
            }
            return sb.ToString();
        }


        public void SetVisible(bool visible)
        {
            IsVisible = visible;
            box.IsVisible = visible;
            menu.IsVisible = visible;
        }

        public void SetColor(ConsoleColor color)
        {
            box.Color = color;
            menu.Color = color;
        }
    }
}
