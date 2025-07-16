using System;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    internal class RawText : UIElement
    {
        private string rawString;
        public HorizontalAlign HorizontalAlign { get; set; }
        public VerticalAlign VerticalAlign { get; set; } = VerticalAlign.Top; // 수직 정렬 기본값

        public RawText(string text, int x, int y, HorizontalAlign horizontalAlign = HorizontalAlign.Left, VerticalAlign verticalAlign = VerticalAlign.Top, ConsoleColor color = ConsoleColor.White)
            : base(x, y, color)
        {
            rawString = text;
            HorizontalAlign = horizontalAlign;
            VerticalAlign = verticalAlign;
        }

        public void SetText(string text)
        {
            rawString = text; // \r 제거
        }

        public override void Draw()
        {
            if (!IsVisible) return;
            if (rawString == null) return;

            var lines = rawString.Replace("\r", "").Split('\n');
            var textIO = TextIOManager.GetInstance();


            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int drawX = X;
                int drawY = Y;

                // 문자 길이 기준으로 정렬 위치 계산
                int smartLength = textIO.OutputSmartTextLength(line);
                switch (HorizontalAlign)
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

                // 수직 정렬 위치 계산
                switch (VerticalAlign)
                {
                    case VerticalAlign.Middle:
                        drawY = Y - (lines.Length / 2) + i;
                        break;
                    case VerticalAlign.Bottom:
                        drawY = Y - lines.Length + i;
                        break;
                    case VerticalAlign.Top:
                    default:
                        drawY = Y + i;
                        break;
                }


                textIO.OutputSmartText(line, drawX, drawY, Color);
            }
        }
    }
}
