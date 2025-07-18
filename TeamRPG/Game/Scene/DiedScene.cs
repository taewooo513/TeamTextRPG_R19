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
    internal class DiedScene : Core.SceneManager.Scene
    {
        Stopwatch stopwatch;
        int x, y;
        bool isUp = false;
        public void Init()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
            isUp = false;
            x = 50;
            y = 15;
        }

        public void Release()
        {
        }

        public void Render()
        {
            if (isUp == false)
            {
                if (stopwatch.ElapsedMilliseconds > 2000)
                {
                    isUp = true;
                }
            }
            else
            {
                if (stopwatch.ElapsedMilliseconds > 100)
                {
                    stopwatch.Restart();
                    if (y != 8)
                    {
                        y -= 1;
                    }
                }
            }
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 0 + x, 0 + y);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠨⡂⠀⠀⠀⠀⠜⠀⠠⠂⠁⠀⠈⠐⡀⠀⠀⠀⡣⠀⠀⠀⠀⠀⠕⠀⠀⠀⠀⠀⢕⠁⠁⠁⠑⢄⠀⠀⠀⢌⠄⠀⠈⡌⠈⠈⠂⠀⠨⡊⠈⠈⠈⠢⡠⠀⠀⠀⠀", 0 + x, 1 + y);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠨⢂⠀⠀⠌⠀⢐⠅⠀⠀⠀⠀⠀⠈⡂⠀⠠⡑⠀⠀⠀⠀⠀⠅⠀⠀⠀⠀⠀⢅⠀⠀⠀⠀⠀⠣⡂⠀⠢⠂⠀⠀⡊⠀⠀⠀⠀⢐⠂⠀⠀⠀⠀⠐⢅⠀⠀⠀", 0 + x, 2 + y);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠐⠄⠌⠀⠀⠢⠂⠀⠀⠀⠀⠀⠀⠪⠀⠐⡌⠀⠀⠀⠀⠀⠅⠀⠀⠀⠀⠀⢕⠀⠀⠀⠀⠀⢈⡂⠀⡸⠀⠀⠀⢕⢀⠄⠄⠀⢐⠅⠀⠀⠀⠀⠀⢌⠄⠀⠀", 0 + x, 3 + y);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢍⠂⠀⠀⡑⡁⠀⠀⠀⠀⠀⠀⡑⡁⠐⢌⠀⠀⠀⠀⠀⡃⠀⠀⠀⠀⠀⢕⠀⠀⠀⠀⠀⠠⡂⠀⠬⠀⠀⠀⡕⠀⠀⠁⠀⠠⡃⠀⠀⠀⠀⠀⢰⠀⠀⠀", 0 + x, 4 + y);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠢⠂⠀⠀⠈⡂⠀⠀⠀⠀⠀⢀⠊⠀⠀⢅⠀⠀⠀⠀⢀⠂⠀⠀⠀⠀⠀⡕⠀⠀⠀⠀⠀⡐⠁⠀⡑⡁⠀⠀⢆⠀⠀⠀⠀⢈⡂⠀⠀⠀⠀⠀⠆⠀⠀⠀", 0 + x, 5 + y);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⡸⡀⠀⠀⠀⠈⠢⡀⡀⢀⠠⠂⠁⠀⠀⠀⢅⢀⢀⢀⠂⠀⠀⠀⠀⠀⢀⢎⢀⢀⢀⠠⠐⠁⠀⠀⡌⠄⠀⢀⢕⢀⢀⠠⠀⡐⢔⢀⠀⡀⠄⠊⠀⠀⠀⠀", 0 + x, 6 + y);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀", 0 + x, 7 + y);
            if (y == 8)
            {
                TextIOManager.GetInstance().OutputSmartText("당신은 사망하였습니다", 70, 29);
                TextIOManager.GetInstance().OutputSmartText("> 메인화면으로", 73, 34);
                if(KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                {
                    SceneManager.GetInstance().ChangeScene("TitleScene");
                }
            }
        }

        /*
         * 
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀

⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀


         */

        public void Update()
        {
        }
    }
}
