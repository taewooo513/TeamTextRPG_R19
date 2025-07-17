using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.UtilManager;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamRPG.Game.Object.Enemy
{
    public class Goblin : Enemy
    {
        int x = 0;
        int y = 0;
        string gNum = "";
        string name;
        public Goblin(int _x, int _y, string _num) // default는 중앙으로잡고 거기서 위치를잡게끔
        {
            gNum = _num;
            name = "고블린" + gNum;
            x = _x;
            y = _y;
        }
        public override void Init()
        {
            state.name = name;
        }
        public override void SelectEnemy()
        {
            TextIOManager.GetInstance().OutputText4Byte("▶", 69 + x, 3 + y);
        }
        protected override void DrawImage()
        {

            TextIOManager.GetInstance().OutputSmartText("고블린" + gNum, 71 + x, 3 + y);
            // 두번 다신 텍스트 게임안만든다
            if (base.isExSkill == false)
            {
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
            else
            {
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡠", 60 + x - 10, 4 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⢀⠲", 60 + x - 10, 5 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢟⣦⡀⠄⠀⠀⠀⢠⠐⠨⠐⡑⢵⣀⠀⠠⢒⣵⡏⠁", 60 + x - 10, 6 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡽⣇⢑⢄⢼⢐⢕⢈⠐⢌⠮⡚⣵⡪⣸⡾⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⢀⠠⠐", 60 + x - 10, 7 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠩⢯⢷⣪⢧⣂⡂⠇⢎⠎⡑⣔⣦⣿⣟⠎⠀⠀⠀⠀⠀⠀⠀⡨⣇⡼⡘", 60 + x - 10, 8 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⢌⣟⢯⣏⢻⢽⢷⡖⡧⣿⢞⣿⢸⠅⠀⠀⠀⠀⠀⠀⢀⣰⠽⠑⠉⠂", 60 + x - 10, 9 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡐⡜⣜⣔⡪⡪⣲⢱⡠⠒⢟⣞⡷⣿⣕⢮⣸⣺⣿⢺⣾⣢⡦⡄⢄⢀⠀⣠⣺⠊⠁", 60 + x - 10, 10 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⡀⣔⢵⢽⣾⢷⢽⢭⢯⣗⣮⡮⣶⣽⣿⣞⡷⣦⣯⣶⢯⡛⣮⣷⣿⡷⣼⣂⢿⡾⠶", 60 + x - 10, 11 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⢀⢔⢰⣳⢿⠛⠃⠀⠈⠈⠉⢺⣫⣿⢯⣗⢯⣟⣗⣇⡯⣟⠞⠀⠀⠉⠷⠿⡽⣿⣺⣵⢿", 60 + x - 10, 12 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠔⢅⣘⢞⠇⠁⠀⠀⠀⠀⠠⣰⢷⣻⣾⣻⣽⢽⡾⣟⣷⡻⠊⠀⠀⠀⠀⠀⡠⡟⠁⠁⢉⢟", 60 + x - 10, 13 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⣰⢸⣺⡱⣾⣣⢅⠀⠀⠀⠀ ⢨⣺⣿⣿⣿⣽⣾⡿⣿⣻⣿⡀⡀⠀⠀⠀⠀⠀⠘⠀⠀⠈⠁⡩⠇", 60 + x - 10, 14 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⢀⢞⢼⣎⠏⠈⠁⠉⢫⢺⠀⠀⠀⠀⠁⡗⡿⣾⢿⣽⣷⣿⢿⣿⢿⣿⣿⣳⣕⡄⡀⠀⠀⠀⠀⠀⠈⠈", 60 + x - 10, 15 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⢯⣗⢍⠀⠀⠀⠀⠨⠃⠀⠀⠀⠀⡀⠌⡪⡫⡿⣿⢿⣾⡿⣟⣿⣿⣽⣻⡺⣕⢗⡦⡀", 60 + x - 10, 16 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠛⠆⠀⠀⠀⠀⠀⠀⠀⠀⡠⠪⢺⠪⠸⣸⢾⡻⢫⡷⣟⡯⣯⣿⣽⣯⡿⣯⡷⣳⡝", 60 + x - 10, 17 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠑⢦⢦⣲⡽⡧⡯⣗⡿⣼⣺⢝⢤⢮⡿⣯⡻⣾⣻⠽⠞⠏⠋⠉⠈", 60 + x - 10, 18 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠈⠀⢨⣻⢿⡝⠊⢂⢼⡽⣿⡋⠊⠃⠁", 60 + x - 10, 19 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣾⣟⡏⠀⠀⠘⣯⡿⣿⣄", 60 + x - 10, 20 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⡞⣟⡟⠀⠀⠀⠈⢿⣟⣿⣦⡀⡀", 60 + x - 10, 21 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⡵⣝⢾⢽⠀⠠⢀⠂⢌⠻⠯⡿⣻⣽⣳⡵⠀⢀", 60 + x - 10, 22 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢔⢷⣿⢸⢿⣕⢧⠨⢐⠨⠐⠈⠐⠈⠀⠀⠁⠐⠈", 60 + x - 10, 23 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠉⠙⠙⠉⠓⠓⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 24 + y);
            }
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢢⡢⡀⡄⡠⣀⢆⡧⣯⢡⣲⡵⣝⣆⡢⣳⣝⣯⢃⢀⡸⡽⣯⣟⣗⢯⢿⣿⡿⣟⣯⣿⡽⣟⡿⡺⠝⠓⠉⠀", 60 + x, 25 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠽⢺⡽⣞⣯⠿⠳⣻⣝⣯⣷⣳⡻⣳⠽⠝⣴⢗⣿⣽⢿⣺⣺⢽⣻⠳⠟⠏⠟⠘⠈⠁", 60 + x, 26 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢨⡳⣯⡿⣞⡾⠚⠑⢁⣜⡮⣿⣷⡿⠟⠑⠫⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 27 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢮⣾⡿⣽⠃⠀⠀⠀⣷⣳⣟⣿⣾⣏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 28 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣷⡿⣟⣿⣗⠀⠀⠀⠀⠈⢷⡿⣽⣯⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 29 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢞⣽⢻⡿⣿⠀⠀⠀⠀⠀⠈⢿⣻⣽⡿⣾⣧⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 30 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡯⣹⢪⢳⢯⣻⠀⠀⢀⠀⡀⡀⡈⢻⣿⣻⣯⣷⣿⣷⣶⣦⢤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 31 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣜⡮⣟⢼⣝⣷⢽⢅⢂⢐⠐⡐⡐⠌⡢⠩⠫⠻⡳⠿⡾⣞⡮⡿⡽⢑⠨⠐⡈⢀⠂⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 32 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢺⣜⣾⣟⢔⣯⣿⢕⡵⡂⠢⡈⡂⠢⡑⠨⠨⠈⠂⠈⠐⠐⠐⠐⠐⠐⠐⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 33 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣞⢮⣾⠿⣗⢼⢽⢿⣻⠬⡇⠅⠂⠈⠐⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 34 + y);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠁⠀⠀⠈⠊⠁⠀⠈⠑⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x, 35 + y);
        }
        /*
         */

        protected override void ExSkill()
        {
            base.ExSkill();
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
