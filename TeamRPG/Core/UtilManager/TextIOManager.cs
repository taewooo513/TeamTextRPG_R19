using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Text.Encodings
namespace TeamRPG.Core.UtilManager
{
    public class TextIOManager : Singleton<TextIOManager>
    {
        Dictionary<String, char[,]> printPictures;
        char[,] frontBuffer;
        char[,] backBuffer;
        char[,] defaultBuffer;
        ConsoleColor[,] consoleColors;
        public int winWidth, winHeight;
        List<String>[] strs;

        public void Init(int width, int height)
        {
            printPictures = new Dictionary<String, char[,]>();
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
                    consoleColors[w, h] = ConsoleColor.Magenta;
                    defaultBuffer[w, h] = ' ';
                }
            }
            Console.SetWindowSize(width, height );
            Console.CursorVisible = false;
            strs = new List<String>[winHeight];
            for (int i = 0; i < winHeight; i++)
            {
                strs[i] = new List<string>();
            }
        }

        public void OutputSmartText(string text, int x, int y, ConsoleColor color = ConsoleColor.White)
        {
            int _x = x;
            foreach (char ch in text)
            {
                int width = IsKorean(ch) ? 2 : 1;

                if (_x >= winWidth )
                    break;

                backBuffer[_x, y] = ch;
                consoleColors[_x, y] = color;

                if (width == 2 && _x + 1 < winWidth)
                {
                    backBuffer[_x + 1, y] = '\0'; // 덮어쓰기 방지
                }

                _x += width;
            }
        }

        public int OutputSmartTextLength(string text)
        {
            int length = 0;
            foreach (char ch in text)
            {
                length += IsKorean(ch) ? 2 : 1;
            }
            return length;
        }


        private bool IsKorean(char ch)
        {
            return (ch >= 0xAC00 && ch <= 0xD7A3);
        }

        public void OutputText4Byte(String str, int x, int y, ConsoleColor color = ConsoleColor.Magenta)
        { // 한글이랑 특수문자가 4byte라 텍스트가 밀림
            int _x = 0;
            foreach (var ch in str)
            {
                if (x + _x < winWidth)
                {

                    consoleColors[x + _x, y] = color;
                    backBuffer[x + _x, y] = ch;
                    backBuffer[x + _x + 1, y] = '\0';

                }
                _x += 2;
            }
        }
        public void OutputText(String str, int x, int y, ConsoleColor color = ConsoleColor.Magenta)
        {
            int _x = 0;
            foreach (var ch in str)
            {
                _x++;
                if (_x + x < winWidth && _x + x >= 0 && y < winHeight && y >= 0)
                {
                    consoleColors[x + _x, y] = color;
                    backBuffer[x + _x, y] = ch;
                }
            }
        }
        public void OutputText(char ch, int x, int y, ConsoleColor color = ConsoleColor.Magenta) // 출력은 이함수 사용하면됨
        {
            consoleColors[x, y] = color;
            backBuffer[x, y] = ch;
        }

        public void DrawText() // 백버퍼에 새로운 값을넣어주고 프론트버퍼가 출력이되면 프론트버퍼에 백버퍼를 넣어주고 백버퍼 초기화
        {
            MergeStr();
            for (int h = 0; h < winHeight; h++)
            {
                for (int w = 0; w < strs[h].Count; w++)
                {
                    Console.Write(strs[h][w]);
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

        private void MergeStr()
        {
            for (int i = 0; i < winHeight; i++)
            {
                strs[i].Clear();
            }
            for (int y = 0; y < winHeight; y++)
            {
                String str = "";
                for (int x = 0; x < winWidth; x++)
                {
                    str += frontBuffer[x, y];
                }
                strs[y].Add(str);
            }
        }
        public void AddPicture(String key, char[,] chars) // 아직 미구현
        {
            printPictures.Add(key, chars);
        }
        private void BufferClear()
        {
            Array.Copy(defaultBuffer, backBuffer, winWidth * winHeight);
        }
    }
}
