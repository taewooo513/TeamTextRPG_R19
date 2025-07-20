using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Scene
{
    internal class EnddingScene : Core.SceneManager.Scene
    {
        Stopwatch stopwatch;
        Stopwatch stopwatch2;

        bool isEndStart = false;
        bool isEndEnd = false;

        int y = 0;
        public void Init()
        {
            stopwatch2 = new Stopwatch();
            stopwatch = new Stopwatch();
            stopwatch.Start();
            isEndStart = false;
            isEndEnd = false;
        }

        public void Update()
        {
        }

        public void Render()
        {
            TextIOManager.GetInstance().OutputText("ParaCron", 73, 1);
            TextIOManager.GetInstance().OutputText("─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────", 0, 3);
            if (isEndEnd == false)
            {
                if (stopwatch.ElapsedMilliseconds > 1000 && isEndStart == false)
                {
                    isEndStart = true;
                    stopwatch.Restart();
                }
                else if (isEndStart == true && stopwatch.ElapsedMilliseconds > 30)
                {
                    stopwatch.Restart();
                    y--;
                }
                TextIOManager.GetInstance().EndRender("████████╗██╗  ██╗███████╗    ███████╗███╗   ██╗██████╗ ", 50, 15 + y);
                TextIOManager.GetInstance().EndRender("╚══██╔══╝██║  ██║██╔════╝    ██╔════╝████╗  ██║██╔══██╗", 50, 16 + y);
                TextIOManager.GetInstance().EndRender("   ██║   ███████║█████╗      █████╗  ██╔██╗ ██║██║  ██║", 50, 17 + y);
                TextIOManager.GetInstance().EndRender("   ██║   ██╔══██║██╔══╝      ██╔══╝  ██║╚██╗██║██║  ██║", 50, 18 + y);
                TextIOManager.GetInstance().EndRender("   ██║   ██║  ██║███████╗    ███████╗██║ ╚████║██████╔╝", 50, 19 + y);
                TextIOManager.GetInstance().EndRender("   ╚═╝   ╚═╝  ╚═╝╚══════╝    ╚══════╝╚═╝  ╚═══╝╚═════╝ ", 50, 20 + y);

                TextIOManager.GetInstance().EndRenderSmart("제작진", 10, 45 + y);

                TextIOManager.GetInstance().EndRenderSmart("박기훈 - 팀장", 10, 48 + y);
                TextIOManager.GetInstance().EndRenderSmart("김혜현 - 팀원", 10, 50 + y);
                TextIOManager.GetInstance().EndRenderSmart("송성현 - 팀원", 10, 52 + y);
                TextIOManager.GetInstance().EndRenderSmart("정권우 - 팀원", 10, 54 + y);
                TextIOManager.GetInstance().EndRenderSmart("고태웅 - 팀원", 10, 56 + y);

                TextIOManager.GetInstance().EndRenderSmart("사운드 소스", 10, 64 + y);
                TextIOManager.GetInstance().EndRenderSmart("ellbuymusic.com", 10, 66 + y);
                TextIOManager.GetInstance().EndRenderSmart("bgmstore.net", 10, 67 + y);

                TextIOManager.GetInstance().EndRenderSmart("Make by", 10, 75 + y);
                TextIOManager.GetInstance().EndRenderSmart("Visual Studio", 10, 76 + y);

                TextIOManager.GetInstance().EndRenderSmart("Voice", 10, 84 + y);
                TextIOManager.GetInstance().EndRenderSmart("and", 10, 86 + y);
                TextIOManager.GetInstance().EndRenderSmart("Hidden Thanks", 10, 88 + y);

                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⣀⣀⣀⠀⠀⣿", 55, 92 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⡟⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿", 55, 93 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⣿⣿⣿⣿⣿⣿⢿⡟⠉⠻⠳⠀⠀⠂⠈⠈⠉⠙⣿⣿⣿⣿⣿⣿⣇⣀⣤⣤⣶⣤⣤⣀⣀⡀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⡷⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿", 55, 94 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⡟⠿⠀⠿⠁⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⡀⠀⠀⣿⣿⣿⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿", 55, 95 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⢿⠁⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⢀⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿", 55, 96 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣷⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠉⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿", 55, 97 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣯⣟⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠀⠀⣾⣿⣿⣿⣿⣿⣿⣿⣿⡟⠀⠀⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸", 55, 98 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣏⣡⠩⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⡼⣿⣿⣿⣿⣿⣿⠟⣿⠟⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻", 55, 99 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⣶⣇⡀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⡈⣿⣿⡿⢿⠿⠿⠿⠃⠀⠀⠐⡒⠛⠛⠾⢿⣿⣿⣿⢻⣿⣿⣿⣿⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼", 55, 100 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⣻⣕⣗⡒⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⡝⠐⠒⢶⡮⢊⠀⢀⠡⣶⠶⠒⠐⠀⠉⢸⠏⣾⣿⣿⣿⣿⣿⠓⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸", 55, 101 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣏⢭⡟⣾⣟⠀⠀⣤⢐⠄⠀⠀⠀⠀⠀⠀⠌⣄⠸⣏⣿⣇⠀⠀⠀⠀⢀⠌⠀⠘⠀⠈⠁⠀⠠⠀⠀⠀⠸⣿⣿⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻", 55, 102 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣷⣾⢿⡗⡅⠒⡸⠍⢹⠕⠒⢀⣀⡀⣠⣤⠀⡼⣷⣴⣿⣿⣿⡄⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠇⣿⣿⣿⣿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼", 55, 103 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⣿⡧⣀⠀⠀⠀⠈⠀⠀⠀⣁⠀⠢⡀⠐⠰⣿⣿⣿⣿⣿⣿⠶⠞⣁⠻⠿⠿⠛⠋⠈⠳⣤⡠⠀⠀⠀⠀⣿⣿⣿⣿⣿⡏⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸", 55, 104 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⣿⣏⡁⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⣟⢙⣿⣿⣿⣿⣧⡀⠘⠿⢷⣶⣶⠶⠞⠁⠀⢀⣤⣶⣶⣤⣿⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻", 55, 105 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⣿⠏⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣈⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀⠶⣤⣤⠄⠀⠀⣴⣿⡏⣿⣿⣿⣿⣿⣿⣿⣿⡷⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢼", 55, 106 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣹⣤⡀⠀⠀⠀⣠⣾⡿⠋⢰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⢸", 55, 107 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣠⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⢠⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣶⣤⣤⣀⣀⣹", 55, 108 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠋⠁⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿", 55, 109 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⣀⣀⣠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣽⣟⣿", 55, 110 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿", 55, 111 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿", 55, 112 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿", 55, 113 + y + 10);
                TextIOManager.GetInstance().EndRenderSmart("⠀⢀⣀⣀⣤⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣷⣤⣼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿", 55, 114 + y + 10);
            }

            if (y == -95)
            {
                stopwatch2.Start();
                stopwatch.Stop();
            }
            if (stopwatch2.ElapsedMilliseconds > 2000)
            {
                isEndEnd = true;
                TextIOManager.GetInstance().EndRenderSmart("반복은 소멸이 아닌 축적입니다. 모든 실패가 겹쳐 만들어낸 이 마지막 한 걸음에 당신이 있습니다.", 30, 20);
            }
            if (stopwatch2.ElapsedMilliseconds > 4000)
            {
                SceneManager.GetInstance().ChangeScene("TitleScene");
            }
        }
        /*
        



         */
        public void Release()
        {
        }
    }
}
