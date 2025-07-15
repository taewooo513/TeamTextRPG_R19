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
            if (!IsVisible) return;

            var lines = rawString.Replace("\r", "").Split('\n');
            var textIO = TextIOManager.GetInstance();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
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
