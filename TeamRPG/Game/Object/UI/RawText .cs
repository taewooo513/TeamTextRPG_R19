using System;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    internal class RawText : UIElement
    {
        private string rawString;
        public TextAlign Align { get; set; }

        public RawText(string text, int x, int y, ConsoleColor color = ConsoleColor.White, TextAlign align = TextAlign.Left)
            : base(x, y, color)
        {
            rawString = text;
            Align = align;
        }

        public override void Draw()
        {
            var lines = rawString.Replace("\r", "").Split('\n');
            var textIO = TextIOManager.GetInstance();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
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
