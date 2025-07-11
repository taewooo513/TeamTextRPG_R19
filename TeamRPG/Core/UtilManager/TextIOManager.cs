using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Core.UtilManager
{
    public class TextIOManager : Singleton<TextIOManager>
    {
        char[,] frontBuffer;
        char[,] backBuffer;
        char[,] defaultBuffer;
        ConsoleColor[,] consoleColors;

        private int winWidth, winHeight;
        public void Init(int width, int height)
        {
            frontBuffer = new char[width, height];        // 윈도우 사이즈랑 얼마나 그릴건지 
            backBuffer = new char[width, height];         // 원레라면 윈도우 핸들가져와야되는데 아쉽게도 텍스트니까 이렇게
            winWidth = width;
            winHeight = height;
            defaultBuffer = new char[width, height];
            consoleColors = new ConsoleColor[width, height];
            for (int h = 0; h < height; h++)
            {
                for (int w = 0; w < width; w++)
                {
                    consoleColors[w, h] = ConsoleColor.White;
                    defaultBuffer[w, h] = ' ';
                }
            }
            Console.SetWindowSize(width, height);
            Console.CursorVisible = false;
        }
        public void OutputText(String str, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            int _x = 0;
            foreach (var ch in str)
            {
                _x++;
                consoleColors[x + _x, y] = color;
                backBuffer[x + _x, y] = ch;
            }
        }
        public void OutputText(char ch, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            consoleColors[x, y] = color;
            backBuffer[x, y] = ch;
        }

        public void DrawText()
        {

            for (int y = 0; y < winHeight; y++)
            {
                for (int x = 0; x < winWidth; x++)
                {
                    //Console.ForegroundColor = consoleColors[x, y];
                    Console.Write(backBuffer[x, y]);
                }
                Console.WriteLine();
            }
            BufferCopy();
            BufferClear();
            Console.SetCursorPosition(0, 0);
        }

        private void BufferCopy()
        {
            Array.Copy(backBuffer, frontBuffer, winWidth * winHeight);
        }

        private void BufferClear()
        {
            Array.Copy(defaultBuffer, backBuffer, winWidth * winHeight);
        }
    }
}
