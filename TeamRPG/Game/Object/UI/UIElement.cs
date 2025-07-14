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

        protected UIElement() : this(0, 0, ConsoleColor.White) { }

        protected UIElement(int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            UIManager.GetInstance().AddUIElement(this);
            X = x;
            Y = y;
            Color = color;
        }

        public abstract void Draw();
    }
}
