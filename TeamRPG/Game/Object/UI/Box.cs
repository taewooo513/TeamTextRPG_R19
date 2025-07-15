using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Object.UI
{
    internal class Box : UIElement
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Box(int x, int y, int width, int height, ConsoleColor color = ConsoleColor.White) : base(x, y, color)
        {
            Width = width;
            Height = height;
        }

        public override void Draw()
        {
            if (!IsVisible) return;

            var textIO = TextIOManager.GetInstance();

            // 상단
            textIO.OutputText('┌', X, Y, Color);
            for (int i = 1; i < Width - 1; i++)
                textIO.OutputText('─', X + i, Y, Color);
            textIO.OutputText('┐', X + Width - 1, Y, Color);

            // 중간
            for (int j = 1; j < Height - 1; j++)
            {
                textIO.OutputText('│', X, Y + j, Color);
                for (int i = 1; i < Width - 1; i++)
                    textIO.OutputText(' ', X + i, Y + j);
                textIO.OutputText('│', X + Width - 1, Y + j, Color);
            }

            // 하단
            textIO.OutputText('└', X, Y + Height - 1, Color);
            for (int i = 1; i < Width - 1; i++)
                textIO.OutputText('─', X + i, Y + Height - 1, Color);
            textIO.OutputText('┘', X + Width - 1, Y + Height - 1, Color);
        }
    }
}
