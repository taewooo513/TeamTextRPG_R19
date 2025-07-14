using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    internal class MenuItem
    {
        public string Text { get; set; }
        public Action OnSelect { get; private set; }
        public bool IsEnabled { get; set; }

        public MenuItem(string text, Action onSelect, bool isEnabled = true)
        {
            Text = text;
            OnSelect = onSelect;
            IsEnabled = isEnabled;
        }
    }

    internal class Menu : UIElement
    {
        private List<MenuItem> items = new List<MenuItem>();
        private int selectedIndex = 0;

        public Menu(int x, int y) : base(x, y) { }

        public void AddItem(string text, Action onSelect, bool isEnabled = true)
        {
            items.Add(new MenuItem(text, onSelect, isEnabled));
            if (items.Count == 1 && !isEnabled)  // 첫 아이템이 비활성일 경우 다음 활성 항목으로 선택 이동
            {
                MoveDown();
            }
        }

        public MenuItem? GetItem(int index)
        {
            if (index < 0 || index >= items.Count)
                return null;
        
                return items[index];
        }

        public void MoveUp()
        {
            if (items.Count == 0) return;

            int originalIndex = selectedIndex;
            do
            {
                selectedIndex = (selectedIndex - 1 + items.Count) % items.Count;
                if (items[selectedIndex].IsEnabled)
                    break;
            } while (selectedIndex != originalIndex);
        }

        public void MoveDown()
        {
            if (items.Count == 0) return;

            int originalIndex = selectedIndex;
            do
            {
                selectedIndex = (selectedIndex + 1) % items.Count;
                if (items[selectedIndex].IsEnabled)
                    break;
            } while (selectedIndex != originalIndex);
        }

        public void Select()
        {
            if (items.Count == 0) return;

            if (items[selectedIndex].IsEnabled)
            {
                items[selectedIndex].OnSelect?.Invoke();
            }
        }

        public override void Draw()
        {
            for (int i = 0; i < items.Count; i++)
            {
                bool selected = (i == selectedIndex);
                string prefix = selected ? "▶ " : "  ";

                ConsoleColor color;

                if (!items[i].IsEnabled)
                    color = ConsoleColor.DarkGray;
                else
                    color = selected ? ConsoleColor.Yellow : ConsoleColor.White;

                TextIOManager.GetInstance().OutputText(prefix + items[i].Text, X, Y + i, color);
            }
        }
    }
}
