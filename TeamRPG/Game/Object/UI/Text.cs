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

        public void SetText(string text)
        {
            Lines = text.Replace("\r", "").Split('\n');
        }

        public override void Draw()
        {
            if (!IsVisible) return;

            var textIO = Core.UtilManager.TextIOManager.GetInstance();

            for (int i = 0; i < Lines.Length; i++)
            {
                string line = Lines[i];
                int drawX = X;

                // 문자 길이 기준으로 정렬 위치 계산
                int smartLength = textIO.OutputSmartTextLength(line);
                switch (Align)
                {
                    case TextAlign.Center:
                        drawX = X - (smartLength / 2);
                        break;
                    case TextAlign.Right:
                        drawX = X - smartLength;
                        break;
                    case TextAlign.Left:
                    default:
                        drawX = X;
                        break;
                }

                textIO.OutputSmartText(line, drawX, Y + i, Color);
            }
        }
    }
}
