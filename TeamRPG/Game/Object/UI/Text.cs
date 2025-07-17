using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Object.UI
{
    public enum HorizontalAlign
    {
        Left,
        Center,
        Right
    }
    public enum VerticalAlign
    {
        Top,
        Middle,
        Bottom
    }

    public class Text : UIElement
    {
        
        public string[] Lines { get; private set; }
        public HorizontalAlign Align { get; set; }

        public Text(string text, int x, int y, ConsoleColor color = ConsoleColor.White, HorizontalAlign align = HorizontalAlign.Left) : base(x, y, color)
        {
            Lines = new string[] { text };
            Align = align;
        }

        public Text(string[] lines, int x, int y, ConsoleColor color = ConsoleColor.White, HorizontalAlign align = HorizontalAlign.Left) : base(x, y, color)
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
                    case HorizontalAlign.Center:
                        drawX = X - (smartLength / 2);
                        break;
                    case HorizontalAlign.Right:
                        drawX = X - smartLength;
                        break;
                    case HorizontalAlign.Left:
                    default:
                        drawX = X;
                        break;
                }

                textIO.OutputSmartText(line, drawX, Y + i, Color);
            }
        }
    }
}
