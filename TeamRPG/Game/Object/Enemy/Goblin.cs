using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.UtilManager;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamRPG.Game.Object.Enemy
{
    public class Goblin : Enemy
    {
        int x = 0;
        int y = 0;
        string gNum = "";
        public Goblin(int _x, int _y, string _num) // default는 중앙으로잡고 거기서 위치를잡게끔
        {
            gNum = _num;
            x = _x;
            y = _y;
        }

        protected override void DrawImage()
        {

            TextIOManager.GetInstance().OutputSmartText("고블린" + gNum, 71 + x, 3 + y);
            // 두번 다신 텍스트 게임안만든다
            TextIOManager.GetInstance().OutputSmartText("    ⠀⠀⠀  ⠀⡠⡔⡆⡦⣄", 60 + x, 4 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⢣⢤⣸⣸⡨⡪⣂⣇⡯⡴⡊", 60 + x, 5 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠩⡺⡜⡝⡕⢵⣱⡣⡯⡰⡰⡒⢆⢆⠤⣀", 60 + x, 6 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⢀⢼⢵⠽⣞⡷⢮⢞⢜⢜⢔⢌⡢⡢⡑⢌⠪⡩⡲⢤⢀", 60 + x, 7 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⢪⢮⣻⣽⡘⢜⢵⣫⠪⡸⡨⣳⢏⠈⠚⠚⠪⡎⡎⢎⠎", 60 + x, 8 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⡐⡷⣕⣯⣻⢽⡗⡕⡕⡜⡜⣗⢽⠀⠀⠀⡰⡑⡕⠕⠁", 60 + x, 9 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⢀⢜⢐⢍⡗⠳⣫⣗⡯⣞⡎⣎⣞⢎⢮⢳⣄⢜⢌⠎⠂⠀⠀⠀⠀⠀⠐", 60 + x, 10 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⡠⡃⡆⠓⠁⠀⠀⠁⠙⢯⣳⢽⡱⡱⣕⢕⢯⢪⢢⢑⢥⣀", 60 + x, 11 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⡜⢔⠕⠁⠀⠀⠀⠀⠀⠀⠈⣻⢼⣻⡺⣮⣳⢯⠪⡂⡆⡎⡾⡅", 60 + x, 12 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⢰⢑⢑⡂⠀⠀⠀⠀⠀⠀⠀⣠⢾⢽⣞⣽⣺⢾⡝⣱⡡⣣⡳⡝⣅", 60 + x, 13 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⢕⡱⠁⠪⠄⠀⠀⠀⠀⣠⢾⢿⢽⣽⣽⣾⡟⣯⢇⡿⣜⡧⡻⠝⠂", 60 + x, 14 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⢱⠡⡀⠀⠀⠀⠀⠀⣖⡯⡿⣽⣝⣾⠷⠇⠀⢿⡵⣿⢮⢾⡀", 60 + x, 15 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠑⠀⠀⠀⠀⠀⣞⣗⣯⢿⢷⡛⠈⢀⠀⠀⠈⣿⢝⣗⢿⡆", 60 + x, 16 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡾⣞⣯⢿⡠⠈⠄⠄⠡⢀⠙⣽⢮⢯⢷⡀", 60 + x, 17 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠐⠈⠀⠀⠂⠀⠐⠈⠀⠂⢻⣽⣺⡻⡇⠅⠅⢅⢑⢐⠨⢘⡿⡽⡽⣮⡀⠀⠈", 60 + x, 18 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⢀⠠⠀⢁⠀⡁⢈⠀⡁⠡⠈⢾⢾⡽⡏⠌⠌⡐⢐⢐⠨⢀⢻⢽⢽⢺⡆⠀⠀⠀⠀⢀", 60 + x, 19 + y);
            TextIOManager.GetInstance().OutputSmartText("⠈⠀⠀⠀⠀⠀⡀⠠⠀⠄⠂⠡⠈⣟⣞⢷⠁⠅⠂⡐⢐⠨⢐⢈⢫⣯⣳⡗⠀⠀⠂⠁⠀⠀⠀⠀⠁", 60 + x, 20 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠐⠈⠀⠀⢀⠐⢀⠡⣈⢰⠸⣘⢵⡑⡈⠄⠠⠀⠌⢐⠐⠄⢟⡞⡞⠀⠀⠄⠀⠀⢀⠀⠂", 60 + x, 21 + y);
            TextIOManager.GetInstance().OutputSmartText("⡀⠈⠀⠀⠄⠐⠨⠤⡒⢆⢣⢪⡢⡱⡠⠣⡳⢀⠈⡀⠂⡈⠄⠨⢈⠢⡳⣝⢆⠀⠄⠀⠁", 60 + x, 22 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠀⠐⢀⠀⠄⠈⠈⠈⠉⡀⠂⠐⠈⠈⠉⢈⠀⠠⠀⠠⠀⠐⢈⠠⢑⣽⢵⢝⢦⡀⠐⢀⠐⠀⠠", 60 + x, 23 + y);
            TextIOManager.GetInstance().OutputSmartText("⠀⠁⢀⠀⠀⠀⡀⠈⠀⡀⠀⠠⠐⠈⠀⠁⡀⠀⠂⠀⠂⠀⢁⠠⠐⠐⢘⢵⢝⣞⣜⢆⠀⠀⡀", 60 + x, 24 + y);
        }

        protected override void ExSkill()
        {

        }


        /*
    ⠀⠀⠀    ⠀⡠⡔⡆⡦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡱⡱⠨⡪⡪⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢣⢤⣸⣸⡨⡪⣂⣇⡯⡴⡊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠩⡺⡜⡝⡕⢵⣱⡣⡯⡰⡰⡒⢆⢆⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⢼⢵⠽⣞⡷⢮⢞⢜⢜⢔⢌⡢⡢⡑⢌⠪⡩⡲⢤⢀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢪⢮⣻⣽⡘⢜⢵⣫⠪⡸⡨⣳⢏⠈⠚⠚⠪⡎⡎⢎⠎⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⡐⡷⣕⣯⣻⢽⡗⡕⡕⡜⡜⣗⢽⠀⠀⠀⡰⡑⡕⠕⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⢜⢐⢍⡗⠳⣫⣗⡯⣞⡎⣎⣞⢎⢮⢳⣄⢜⢌⠎⠂⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀
⠀⠀⠀⠀⠀⡠⡃⡆⠓⠁⠀⠀⠁⠙⢯⣳⢽⡱⡱⣕⢕⢯⢪⢢⢑⢥⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⡜⢔⠕⠁⠀⠀⠀⠀⠀⠀⠈⣻⢼⣻⡺⣮⣳⢯⠪⡂⡆⡎⡾⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢰⢑⢑⡂⠀⠀⠀⠀⠀⠀⠀⣠⢾⢽⣞⣽⣺⢾⡝⣱⡡⣣⡳⡝⣅⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢕⡱⠁⠪⠄⠀⠀⠀⠀⣠⢾⢿⢽⣽⣽⣾⡟⣯⢇⡿⣜⡧⡻⠝⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢱⠡⡀⠀⠀⠀⠀⠀⣖⡯⡿⣽⣝⣾⠷⠇⠀⢿⡵⣿⢮⢾⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠑⠀⠀⠀⠀⠀⣞⣗⣯⢿⢷⡛⠈⢀⠀⠀⠈⣿⢝⣗⢿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡾⣞⣯⢿⡠⠈⠄⠄⠡⢀⠙⣽⢮⢯⢷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠐⠈⠀⠀⠂⠀⠐⠈⠀⠂⢻⣽⣺⡻⡇⠅⠅⢅⢑⢐⠨⢘⡿⡽⡽⣮⡀⠀⠈⠀⠀⠀⠀⠀⠀⠀
⠀⢀⠠⠀⢁⠀⡁⢈⠀⡁⠡⠈⢾⢾⡽⡏⠌⠌⡐⢐⢐⠨⢀⢻⢽⢽⢺⡆⠀⠀⠀⠀⢀⠀⠀⠀⠀
⠈⠀⠀⠀⠀⠀⡀⠠⠀⠄⠂⠡⠈⣟⣞⢷⠁⠅⠂⡐⢐⠨⢐⢈⢫⣯⣳⡗⠀⠀⠂⠁⠀⠀⠀⠀⠁
⠀⠀⠀⠐⠈⠀⠀⢀⠐⢀⠡⣈⢰⠸⣘⢵⡑⡈⠄⠠⠀⠌⢐⠐⠄⢟⡞⡞⠀⠀⠄⠀⠀⢀⠀⠂⠀
⡀⠈⠀⠀⠄⠐⠨⠤⡒⢆⢣⢪⡢⡱⡠⠣⡳⢀⠈⡀⠂⡈⠄⠨⢈⠢⡳⣝⢆⠀⠄⠀⠁⠀⠀⠀⠀
⠀⠀⠐⢀⠀⠄⠈⠈⠈⠉⡀⠂⠐⠈⠈⠉⢈⠀⠠⠀⠠⠀⠐⢈⠠⢑⣽⢵⢝⢦⡀⠐⢀⠐⠀⠠⠀
⠀⠁⢀⠀⠀⠀⡀⠈⠀⡀⠀⠠⠐⠈⠀⠁⡀⠀⠂⠀⠂⠀⢁⠠⠐⠐⢘⢵⢝⣞⣜⢆⠀⠀⡀⠀⠀

⠀⠀⠀⠀
         */
    }
}
