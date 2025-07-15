using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;

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

        }

        public void Release()
        {
        }

        public void Render()
        {
            int a = (int)(timerEnd.ElapsedMilliseconds / 100);


            switch (a)
            {
                case 0:
                    goto case 1;
                case 1:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⢀⢩⣾⣿⣿⡿⢡⣿⡟⣡⠟⣰⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣌⢻⡜⣿⣷⡘⣿⣿⣿⣿⣇⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 12 + yUp);
                    goto case 2;
                case 2:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣹⣾⣿⣿⡿⢀⣾⡟⢫⡴⢋⠴⠉⠂⠈⠀⠀⠀⠈⠑⠲⣌⠹⢦⡹⣿⣧⠘⣿⣿⣿⣷⣷⠀⢀⠀⠀⠀⠀⠀", 25, 11 + yUp);
                    goto case 3;
                case 3:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣐⢞⣾⣿⣿⣟⠋⣰⢮⡗⣋⡴⠒⢋⡑⢡⡉⢌⡙⠚⠤⣍⡛⢾⡷⣌⠻⣿⣿⣿⣾⣧⠀⠠⠀⠀⠀⠀⠀", 25, 10 + yUp);
                    goto case 4;
                case 4:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣎⣾⣷⣿⢯⡿⢉⢢⣄⢯⡖⠳⡙⣋⠛⣑⠳⠞⣽⣲⢤⣈⠻⢿⣿⣿⣿⣷⣄⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 9 + yUp);
                    goto case 5;
                case 5:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠐⣤⣻⣼⡿⣽⢮⠷⠙⢊⡁⡡⢌⠤⣁⣉⡈⠓⠻⢞⣯⡿⣿⣷⣛⣦⠀⠀⡀⠀⠀", 25, 8 + yUp);
                    goto case 6;
                case 6:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⣆⡳⣜⣶⡻⣭⢟⡶⣹⢞⡼⣋⡷⣭⢷⡻⣷⢧⣯⠴⣄⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 7 + yUp);
                    goto case 7;
                case 7:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣄⠰⣒⠬⣥⣙⢦⣍⢧⡹⣔⡢⡔⡤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 6 + yUp);
                    goto case 8;
                case 8:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 5 + yUp);
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
                    TextIOManager.GetInstance().OutputText("해당 게임은 전체화면에 최적화 되어있습니다.", 25, 12);
                    TextIOManager.GetInstance().OutputText("전체화면으로 이용해 주시는 것을 권장 드립니다.", 25, 15);
                    break;
                case 25:
                    SceneManager.GetInstance().ChangeScene("CharSelectScene");
                    break;
            }

            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣶⡶⠶⢶⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", x, 13);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣿⣗⣀⣸⡿⠂⠀⠴⠶⠶⢶⣆⡀⠀⢰⣶⡰⠶⣦⡀⠀⠰⠶⠶⠶⣦⡀⠀⢀⣰⡶⠶⣶⣀⠀⠀⣶⣆⠶⣶⣄⠀⠀⣠⡶⠶⢶⣄⠀⠀⢶⣦⡰⢶⣆⡀⠀⠀⠀", x, 14);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣿⣏⠉⠉⠁⠀⠀⣤⣾⠒⠾⣿⡇⠀⢸⣿⠁⠀⠛⠃⠀⢠⣾⠖⠓⣿⡧⠀⢸⣿⠆⠀⠉⠁⠀⠀⣿⡏⠀⠘⠛⠀ ⣿⡇⠀⢸⣿⠀⠀⣿⣯⠁⢘⣿⡅⠀⠀⠀", x, 15);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣿⣇⠀⠀⠀⠀⠀⠾⣿⣠⣘⣿⡇⠀⢸⣿⠀⠀  ⠀⠸⣿⣤⣀⣿⡧⠀⠘⢿⣇⣄⣶⠶⠀⠀⣿⡇⠀⠀⠀⠀ ⢿⣧⣄⣸⡿⠀⠀⣾⡷⠀⠸⣿⠆", x, 16);

            switch (a)
            {
                case 0:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⣟⣿⣿⣿⣿⡘⣿⣷⡹⣧⠙⣦⠀⡀⠈⠀⠀⠀⠀⠀⠀⠄⣀⠾⣁⣾⢋⣿⣿⢡⣿⣿⣿⣿⡟⠀⠈⠀", 25, 18 + yDown);
                    goto case 1;
                case 1:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢾⣿⣿⣿⣧⡘⣿⣷⣜⢷⣌⠳⢦⣄⡐⣀⢀⢂⣡⢰⡚⢌⣱⡞⣣⣿⡿⢃⣾⣿⣿⣿⡟⠀⠐⠀", 25, 19 + yDown);
                    goto case 2;
                case 2:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠘⢟⣿⣿⣿⣿⣷⣌⡙⠿⣿⣷⣮⣬⣭⣯⣭⣴⣶⣿⡿⠟⢋⣤⣿⣿⣿⣿⡿⠟⠀⠠⠀⠀⠀⠀", 25, 20 + yDown);
                    goto case 3;
                case 3:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠀⠺⡽⣿⣿⣿⣿⣿⣶⣤⣍⣙⢋⠛⠛⡛⢩⣉⣥⣴⣾⣿⣿⣿⣿⣿⠿⠉⢀⠈⠀⠀⠀⠀⠀⠀", 25, 21 + yDown);
                    goto case 4;
                case 4:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠘⢽⡻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢟⡻⠈⠀⠐⠀⠀⠀⠀⠀⠀⠀", 25, 22 + yDown);
                    goto case 5;
                case 5:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠀⠀⠘⠹⢋⠿⠿⣿⡿⣿⡿⣿⢿⡿⢟⡟⠽⠃⠉⡀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 23 + yDown);
                    goto case 6;
                case 6:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⢈⠈⠁⠑⠁⡁⠀⠈⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 24 + yDown);
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
                    if (x == 29)
                    {
                        isStop = true;
                    }
                    timerTextTimer.Restart();
                }
                if (x > TextIOManager.GetInstance().winWidth)
                {
                    //SceneManager.GetInstance().ChangeScene("CharSelectScene");
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
