using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Scene
{
    public class TestScene : Core.SceneManager.Scene
    {
        string[] bossAscii = new string[]
{
    "                     ███████████████                     ",
    "                ███████████████████████                 ",
    "             █████████████████████████████              ",
    "           ████████▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓████████           ",
    "         ██████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██████         ",
    "       █████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████        ",
    "      ████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████      ",
    "     ███▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓███     ",
    "     ██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██     ",
    "     ██▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓██     ",
    "     ███▓▓▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▓▓███     ",
    "     ████▓▓▒▒▒▒▒▒▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓▓▒▒▒▒▓▓████     ",
    "      ████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████      ",
    "       ████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓████       ",
    "        █████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓█████        ",
    "         █████▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓█████         ",
    "          █████▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓████          ",
    "            ████▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓███           ",
    "              ██▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▒▒▒▒▓▓▓▓██            ",
    "               █▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▒▒▒▒▓▓▓▓▓█              ",
    "                █▓▓▓▓▓▓▓▓▓▓▓▒▒▒▒▒▒▓▓▓▓▓▓█               ",
    "                 █▓▓▓▓▓▓▓▓▓▓▓▓▒▒▒▓▓▓▓▓▓█                ",
    "                  █▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓██                 ",
    "                    █████████████████                  "
};

        public void Init()
        {
        }

        public void Release()
        {
        }

        public void Render()
        {
            TextIOManager.GetInstance().OutputText(TimerManager.GetInstance().GetFrame().ToString(), 0, 0);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 6, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⡪⡣⢣⠣⡣⡣⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 7, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢧⢫⠸⡐⢅⠣⡣⣫⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 8, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡄⡀⢐⢇⢇⠣⡑⢌⠜⡜⡜⡆⣠⢴⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 9, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠯⣳⢝⣞⡷⣕⢱⢼⢺⢏⢗⡝⠁⠀⢀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 10, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⢱⣫⡲⡱⣕⢅⡳⣕⣳⣝⢎⢇⢗⠕⡙⢜⢘⢒⠔⡄⣀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 11, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣶⡹⣪⣮⣾⣺⢼⣪⡪⡸⣸⡐⡅⡌⢔⢐⢐⠑⠌⡂⡣⠩⡊⡆⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 12, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡸⢵⣏⢗⢎⢎⢧⢫⣞⢜⢜⢘⠜⡜⣮⣓⠳⢕⢵⢱⢜⣔⡕⡕⢕⢕⠭⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 13, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣪⡫⡾⡿⣖⣔⣜⣞⢮⢣⢑⠅⡕⡵⣻⣪⡀⠀⠀⠀⠁⢐⢕⢕⠱⣘⠎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 14, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢳⣯⡫⣟⣽⢳⡻⣗⢕⢇⢇⢣⢣⢫⡺⣜⠆⠀⠀⠀⢠⠪⡊⢆⠇⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 15, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠜⢐⠱⡱⡏⢗⣟⣗⣯⣻⡺⡼⡜⡜⡜⣼⢪⡪⡝⣦⡀⢠⠣⡃⡎⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 16, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⡠⠪⡨⣢⠫⠊⠀⠀⠱⠯⡾⣞⡾⣝⢮⢗⢯⢳⢱⡱⣹⣪⢻⡘⢌⢪⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 17, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢀⠜⡨⡪⠊⠀⠀⠀⠀⠀⠀⠀⠈⠻⣺⡵⣗⢧⡣⡳⡱⡕⣇⢗⢕⢅⠕⡐⢭⡲⡤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 18, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⡠⢣⢱⠑⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡳⡽⡯⡯⡯⡯⣞⡾⢵⡑⢅⢪⡐⡅⡯⣫⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 19, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⡎⢆⠑⠅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢿⢽⢽⢽⢝⣮⢿⢽⡱⡊⡎⢜⢜⢼⣘⢯⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 20, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⢠⠣⢢⠉⢎⡀⠀⠀⠀⠀⠀⠀⠀⢀⡤⣯⣯⣻⣻⣻⡯⣿⣽⢿⣽⢢⢷⡣⣻⢜⣽⣺⡸⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 21, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⢌⢪⠐⠀⠐⢒⠀⠀⠀⠀⠀⠀⡠⡾⣽⢳⣳⣳⢷⣻⡿⡷⠛⣟⣮⢸⣟⡎⣟⡇⠟⠚⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 22, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⢂⢝⢄⠀⠀⠀⠀⠀⠀⠀⠀⣖⢿⢽⢯⣻⣳⡻⣟⣟⠿⠁⠀⢿⢧⣟⣗⣗⣽⡮⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 23, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠑⢐⠀⠀⠀⠀⠀⠀⢀⡼⣮⢯⣯⢿⡽⣾⠽⠝⠁⠀⠀⠀⠈⣟⡾⣝⡷⡵⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 24, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣽⣺⣳⢿⣽⣻⠏⠀⢀⠠⠀⠠⠀⠀⢸⡯⣗⢯⢽⣺⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 25, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⡷⣻⣽⣺⢾⣢⠐⢀⠠⠐⢀⠂⠐⢀⠹⣽⢝⣗⡯⡿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 26, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠠⠀⠀⡀⠀⢀⠀⠀⠄⠂⠀⢿⣽⣺⣺⢯⡿⢀⢂⠂⠅⡂⠌⠌⠠⢀⠫⣟⢷⣛⣽⢾⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 27, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠠⠀⠀⡀⠀⢀⠀⠠⠀⠄⠀⠂⠨⣞⢾⣺⢯⢾⢆⠂⠅⠅⡂⠅⠅⡁⡂⠐⣻⡽⡮⣫⢯⢯⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀", 0, 28, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⡀⠀⢀⠀⠠⠀⠄⠂⠈⡀⠂⠸⡿⡽⡯⣟⠢⠈⠌⠐⠠⢈⠐⡀⢂⠁⡐⡯⡯⡯⣳⢯⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 29, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠁⠀⠁⠀⠀⠀⠀⡀⢀⠀⠄⠠⠀⡈⠄⠩⡯⣟⣽⡃⠅⠨⠀⠁⠄⠂⡐⢐⢐⢀⠚⣽⢝⣗⣟⠇⠀⠀⠀⠠⠀⠀⠀⠄⠀⠀⢀⠀", 0, 30, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠠⠀⠄⠠⢁⢎⢇⢷⣐⢁⠂⢈⠀⠀⠂⠀⡂⢐⠠⠂⠜⣯⢗⡯⡇⠀⠀⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0, 31, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠁⠀⠀⠠⠐⠈⠀⠀⢈⠀⢄⢢⢌⠪⡊⠎⠜⠨⡪⡪⡢⠈⡀⠀⡁⢀⠁⠀⠄⠨⢈⠂⠍⣝⢼⢥⠀⠀⠀⠀⠀⠀⠄⠀⠀⠄⠀⠀", 0, 32, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠠⠀⠀⠀⡀⠀⠀⠀⠐⡜⡒⡍⢕⢁⢆⠵⣸⣸⡸⣨⢐⢜⠼⠀⡀⠄⠀⠀⡀⠂⠐⠀⠂⠡⡑⣜⡮⡮⣣⠀⠁⠀⠐⠀⠀⠀⠀⠀⠀⠀", 0, 33, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠠⠐⠀⠀⠠⠈⠈⠈⠀⠁⠀⢀⠠⠀⠁⠁⠁⢀⠀⠀⠀⠂⠀⠀⡀⠁⢈⠐⢨⢺⢮⡫⡮⣳⢄⠀⠠⠀⠀⠠⠐⠀⠀⠀", 0, 34, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠐⠀⠈⠀⠈⠀⠀⠀⠀⠀⠀⠀⢀⠀⠁⠀⠁⠀⠀⠀⠀⠂⠀⠄⠀⠈⠀⠀⠄⠂⠀⠠⠀⠐⠠⢙⢝⢮⡺⣸⢵⢱⠀⠀⠁⠀⠀⠀⠀⠀", 0, 35, ConsoleColor.Yellow);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⡀⠀⠀⠀⠠⠐⠈⠀⠀⠀⠀⠀⢀⠀⠀⠠⠀⠂⠀⠀⠀⠠⠐⠀⠀⠀⠀⠠⠀⠁⠐⠀⡉⠳⣹⡪⡳⠝⠡⠀⠀⠄⠀⠀⠀⢀", 0, 36, ConsoleColor.Yellow);


            int height = 0;
            foreach (var item in bossAscii)
            {
                //TextIOManager.GetInstance().OutputText(item, 0, height);
                height++;
            }
        }

        public void Update()
        {
        }
    }
}
