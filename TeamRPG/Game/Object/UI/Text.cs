using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Object.UI
{
    public enum TextAlign
    {
        Left,
        Center,
        Right
    }

    internal class Text : UIElement
    {
        
        public string[] Lines { get; private set; }
        public TextAlign Align { get; set; }

        public Text(string text, int x, int y, ConsoleColor color = ConsoleColor.White, TextAlign align = TextAlign.Left) : base(x, y, color)
        {
            Lines = new string[] { text };
            Align = align;
        }

        public Text(string[] lines, int x, int y, ConsoleColor color = ConsoleColor.White, TextAlign align = TextAlign.Left) : base(x, y, color)
        {
            Lines = lines;
            Align = align;
        }

        public override void Draw()
        {
            var textIO = Core.UtilManager.TextIOManager.GetInstance();

            for (int i = 0; i < Lines.Length; i++)
            {
                string line = Lines[i];
                int drawX = X;

                switch (Align)
                {
                    case TextAlign.Center:
                        drawX = X - (line.Length / 2);
                        break;
                    case TextAlign.Right:
                        drawX = X - line.Length;
                        break;
                    case TextAlign.Left:
                    default:
                        drawX = X;
                        break;
                }

                textIO.OutputText(line, drawX, Y + i, Color);
            }
        }
    }
}
