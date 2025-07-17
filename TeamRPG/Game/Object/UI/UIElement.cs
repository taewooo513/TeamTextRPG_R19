using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    public abstract class UIElement
    {
        public int X { get; set; }
        public int Y { get; set; }
        public ConsoleColor Color { get; set; }
        public bool IsVisible { get; set; } = true;

        protected UIElement() : this(0, 0, ConsoleColor.White) { }

        protected UIElement(int x, int y, ConsoleColor color = ConsoleColor.White, bool addUIElement = true)
        {
            if(addUIElement)
                UIManager.GetInstance().AddUIElement(this);
            X = x;
            Y = y;
            Color = color;
        }

        public abstract void Draw();

        public static bool ContainsOnlyKorean(string text)
        {
            foreach (char c in text)
            {
                if (c < 0xAC00 || c > 0xD7A3) // 한글 유니코드 범위
                    return false;
            }
            return true;
        }
    }
}
