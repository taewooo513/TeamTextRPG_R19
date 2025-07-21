using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.ItemManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene
{
    public class TitleScene : Core.SceneManager.Scene
    {
        int x = 0;
        int y = 0;
        Stopwatch timerTextTimer;
        bool isStop = false;
        bool isStop2 = false;
        bool isStop3 = false;

        Stopwatch timer;
        Stopwatch titleLogoTimerUp;
        Stopwatch titleLogoTimerDown;
        Stopwatch timerEnd;
        int yUp = 0;
        bool isChar = false;
        int yDown = 0;
        public void Init()
        {
            x = -20;
            isStop = false;
            isStop2 = false;
            titleLogoTimerUp = new Stopwatch();
            titleLogoTimerDown = new Stopwatch();
            timerEnd = new Stopwatch();
            timer = new Stopwatch();
            timerTextTimer = new Stopwatch();
            timer.Start();
            timerTextTimer.Start();
            titleLogoTimerUp.Start();
            titleLogoTimerDown.Start();
            yUp = -10;
            yDown = 10;
            isStop3 = false;
            String str1 = "", str2 = "";
            if (FileIOManager.GetInstance().IsFileCheck("PlayerStatus"))
            {
                isChar = true;
                List<string> strs = FileIOManager.GetInstance().GetLoadFile("PlayerStatus");
                Player player = new Player();
                player.LoadToFileGetStatus(strs, ref str1, ref str2);
            }
            if (FileIOManager.GetInstance().IsFileCheck("ItemList"))
            {
                FileIOManager.GetInstance().LoadItemList();
                List<string> strs = FileIOManager.GetInstance().GetLoadFile("ItemList");
                PlayerManager.GetInstance().GetPlayer().LoadToItemList(strs);
                if (str1 != "")
                {
                    PlayerManager.GetInstance().GetPlayer().eArmor = (Object.Item.Armor)ItemManager.GetInstance().GetItem("str1");
                }
                if (str2 != "")
                {
                    PlayerManager.GetInstance().GetPlayer().eWeapon = (Object.Item.Weapon)ItemManager.GetInstance().GetItem("str2");
                }
            }
        }

        public void Release()
        {
            Console.ForegroundColor = ConsoleColor.White;

        }

        public void Render()
        {
            Random r = new Random();

            int a = (int)(timerEnd.ElapsedMilliseconds / 100);
            Console.ForegroundColor = (ConsoleColor)r.Next(0, 15);
            TextIOManager.GetInstance().OutputSmartText("Team 19세넘었조", 1, 1);
            TextIOManager.GetInstance().OutputSmartText("TeamLeader Mr.Park", 1, 2);

            switch (a)
            {
                case 0:
                    goto case 1;
                case 1:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⢀⢩⣾⣿⣿⡿⢡⣿⡟⣡⠟⣰⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣌⢻⡜⣿⣷⡘⣿⣿⣿⣿⣇⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 45, 12 + yUp);
                    goto case 2;
                case 2:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣹⣾⣿⣿⡿⢀⣾⡟⢫⡴⢋⠴⠉⠂⠈⠀⠀⠀⠈⠑⠲⣌⠹⢦⡹⣿⣧⠘⣿⣿⣿⣷⣷⠀⢀⠀⠀⠀⠀⠀", 45, 11 + yUp);
                    goto case 3;
                case 3:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣐⢞⣾⣿⣿⣟⠋⣰⢮⡗⣋⡴⠒⢋⡑⢡⡉⢌⡙⠚⠤⣍⡛⢾⡷⣌⠻⣿⣿⣿⣾⣧⠀⠠⠀⠀⠀⠀⠀", 45, 10 + yUp);
                    goto case 4;
                case 4:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣎⣾⣷⣿⢯⡿⢉⢢⣄⢯⡖⠳⡙⣋⠛⣑⠳⠞⣽⣲⢤⣈⠻⢿⣿⣿⣿⣷⣄⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 45, 9 + yUp);
                    goto case 5;
                case 5:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠐⣤⣻⣼⡿⣽⢮⠷⠙⢊⡁⡡⢌⠤⣁⣉⡈⠓⠻⢞⣯⡿⣿⣷⣛⣦⠀⠀⡀⠀⠀", 45, 8 + yUp);
                    goto case 6;
                case 6:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⣆⡳⣜⣶⡻⣭⢟⡶⣹⢞⡼⣋⡷⣭⢷⡻⣷⢧⣯⠴⣄⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 45, 7 + yUp);
                    goto case 7;
                case 7:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣄⠰⣒⠬⣥⣙⢦⣍⢧⡹⣔⡢⡔⡤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 45, 6 + yUp);
                    goto case 8;
                case 8:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 45, 5 + yUp);
                    break;
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                    TextIOManager.GetInstance().OutputSmartText("해당 게임은 전체화면에 최적화 되어있습니다.", 50, 12);
                    TextIOManager.GetInstance().OutputSmartText("전체화면으로 이용해 주시는 것을 권장 드립니다.", 50, 15);
                    break;
                case 35:
                    if (isChar == false)
                    {
                        SceneManager.GetInstance().ChangeScene("CharSelectScene");
                    }
                    else
                    {
                        SceneManager.GetInstance().ChangeScene(PlayerManager.GetInstance().environment);
                    }
                    break;
            }

            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣶⡶⠶⢶⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", x, 13);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣿⣗⣀⣸⡿⠂⠀⠴⠶⠶⢶⣆⡀⠀⢰⣶⡰⠶⣦⡀⠀⠰⠶⠶⠶⣦⡀⠀⢀⣰⡶⠶⣶⣀⠀⠀⣶⣆⠶⣶⣄⠀⠀⣠⡶⠶⢶⣄⠀⠀⢶⣦⡰⢶⣆⡀⠀⠀⠀", x, 14);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣿⣏⠉⠉⠁⠀⠀⣤⣾⠒⠾⣿⡇⠀⢸⣿⠁⠀⠛⠃⠀⢠⣾⠖⠓⣿⡧⠀⢸⣿⠆⠀⠉⠁⠀⠀⣿⡏⠀⠘⠛⠀ ⣿⡇⠀⢸⣿⠀⠀⣿⣯⠁⢘⣿⡅⠀⠀⠀", x, 15);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣿⣇⠀⠀⠀⠀⠀⠾⣿⣠⣘⣿⡇⠀⢸⣿⠀⠀  ⠀⠸⣿⣤⣀⣿⡧⠀⠘⢿⣇⣄⣶⠶⠀⠀⣿⡇⠀⠀⠀⠀ ⢿⣧⣄⣸⡿⠀⠀⣾⡷⠀⠸⣿⠆", x, 16);

            switch (a)
            {
                case 0:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⣟⣿⣿⣿⣿⡘⣿⣷⡹⣧⠙⣦⠀⡀⠈⠀⠀⠀⠀⠀⠀⠄⣀⠾⣁⣾⢋⣿⣿⢡⣿⣿⣿⣿⡟⠀⠈⠀", 45, 18 + yDown);
                    goto case 1;
                case 1:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢾⣿⣿⣿⣧⡘⣿⣷⣜⢷⣌⠳⢦⣄⡐⣀⢀⢂⣡⢰⡚⢌⣱⡞⣣⣿⡿⢃⣾⣿⣿⣿⡟⠀⠐⠀", 45, 19 + yDown);
                    goto case 2;
                case 2:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠘⢟⣿⣿⣿⣿⣷⣌⡙⠿⣿⣷⣮⣬⣭⣯⣭⣴⣶⣿⡿⠟⢋⣤⣿⣿⣿⣿⡿⠟⠀⠠⠀⠀⠀⠀", 45, 20 + yDown);
                    goto case 3;
                case 3:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠀⠺⡽⣿⣿⣿⣿⣿⣶⣤⣍⣙⢋⠛⠛⡛⢩⣉⣥⣴⣾⣿⣿⣿⣿⣿⠿⠉⢀⠈⠀⠀⠀⠀⠀⠀", 45, 21 + yDown);
                    goto case 4;
                case 4:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠘⢽⡻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢟⡻⠈⠀⠐⠀⠀⠀⠀⠀⠀⠀", 45, 22 + yDown);
                    goto case 5;
                case 5:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠀⠀⠘⠹⢋⠿⠿⣿⡿⣿⡿⣿⢿⡿⢟⡟⠽⠃⠉⡀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 45, 23 + yDown);
                    goto case 6;
                case 6:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⢈⠈⠁⠑⠁⡁⠀⠈⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 45, 24 + yDown);
                    break;
            }
            //어때요
        }
        public void Update()
        {
            TitleTextUpdate();
            TitleLogoUpUpdate();
            TitleLogoDownUpdate();
        }

        void TitleTextUpdate()
        {
            if (isStop == false)
            {
                if (timerTextTimer.ElapsedMilliseconds > 7)
                {
                    x++;
                    if (x == 29 + 20)
                    {
                        isStop = true;
                    }
                    timerTextTimer.Restart();
                }
            }
            else
            {
                if (timerTextTimer.ElapsedMilliseconds > 2000)
                {
                    timerTextTimer.Restart();
                    isStop = false;
                    timerEnd.Start();
                }
            }
        }

        void TitleLogoUpUpdate()
        {
            if (isStop2 == false)
            {
                if (titleLogoTimerUp.ElapsedMilliseconds > 50)
                {
                    yUp++;
                    if (yUp == 0)
                    {
                        isStop2 = true;
                    }
                    titleLogoTimerUp.Restart();
                }
            }
        }
        void TitleLogoDownUpdate()
        {
            if (isStop3 == false)
            {
                if (titleLogoTimerDown.ElapsedMilliseconds > 50)
                {
                    yDown--;
                    if (yDown == 0)
                    {
                        isStop3 = true;
                    }
                    titleLogoTimerDown.Restart();
                }
            }
        }
    }
}
