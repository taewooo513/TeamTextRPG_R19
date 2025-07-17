using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene
{
    public class CharSelectScene : Core.SceneManager.Scene
    {
        Stopwatch nextSceneStopWatch;
        String name = "";
        int selectChar;
        bool isSelectRace = false;
        bool isSelectName = false;
        bool isSelectNameComplete = false;
        int widthL = 0;
        public void Init()
        {
            selectChar = 0;
            isSelectName = false;
            isSelectRace = false;
            name = "";
            widthL = 30;
            nextSceneStopWatch = new Stopwatch();

        }

        public void Release()
        {
            nextSceneStopWatch.Stop();
        }

        public void Render()
        {

            TextIOManager.GetInstance().OutputText4Byte("인간", 3, 5);
            TextIOManager.GetInstance().OutputText4Byte("생명력", 3, 7);
            TextIOManager.GetInstance().OutputText4Byte("마나", 3, 8);
            TextIOManager.GetInstance().OutputText4Byte("공격력", 3, 9);
            TextIOManager.GetInstance().OutputText4Byte("재빠름", 3, 10);
            TextIOManager.GetInstance().OutputText4Byte("강인함", 3, 11);
            TextIOManager.GetInstance().OutputText4Byte("행운", 3, 12);



            TextIOManager.GetInstance().OutputText("인간", 17 + widthL, 29);
            TextIOManager.GetInstance().OutputText("드워프", 43 + widthL, 29);
            TextIOManager.GetInstance().OutputText("하프엘프", 68 + widthL, 29);

            switch (selectChar)
            {
                case 0:
                    TextIOManager.GetInstance().OutputText("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 3);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠣⣠⣤⣤⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 4);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣿⣿⣿⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 5);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣰⠟⣿⣿⣿⡟⡭⢭⡡⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 6);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡜⡏⣼⣨⣟⣿⣮⣽⣏⡵⡟⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣟⢧⣧⣿⣾⡿⣿⡞⡿⣟⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣷⢲⡽⢷⣞⣿⣟⠃⠀⡯⣵⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⡰⢯⣿⣿⣗⡞⣮⣿⣿⣯⣄⠀⢻⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⡝⢮⣽⣿⣿⢧⡾⣽⣿⣾⣷⣿⣿⡠⣼⣾⡇⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣔⢫⣳⣼⣻⣾⣿⣷⣏⡞⣽⡿⣼⣿⣿⣿⡅⢈⠉⠙⣿⡿⡴⢠⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⣱⣞⣯⣷⣿⣿⣿⡿⢻⣿⡜⡶⣿⡽⣿⣿⣿⣣⠄⠀⠀⠀⠀⢉⠃⠲⠍⣖⠢⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢟⣳⠜⣧⣾⣿⣿⣿⠑⣼⣯⣟⣚⣷⣿⣿⣯⣿⣿⢆⠀⠀⢄⠈⠄⡈⠐⡀⠀⠉⠐⠙⠝⣒⡤⡀⠀⠀⠀⠀⠀", 25 + widthL, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠇⢸⣿⣿⣿⣟⡆⠈⣯⣿⣿⣎⣿⠋⣿⠗⢽⣯⣿⣇⠌⠄⡈⠐⠠⠁⠀⠁⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀", 25 + widthL, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠋⣈⣿⣿⠀⢃⢸⣿⣿⠏⠇⢀⢠⠀⠌⢿⣿⣿⠀⠂⠄⡑⠠⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⠟⠋⠀⠈⠄⡘⣿⣿⠀⠈⠄⠂⠈⠀⠘⣿⣷⠈⠐⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠋⠀⠀⠀⠀⠀⢀⣠⣿⣿⠀⠀⠀⠀⠀⠀⠄⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25 + widthL, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠂⠐⠀⠂⠐⠀⠒⠒⠒⠒⠋⠛⠙⠋⠓⠒⠂⠒⠒⠒⠛⠙⠋⠓⠒⠒⠒⠒⠒⠒⠒⠂⠐⠀⠂⠐⠀⠂⠐⠀", 25 + widthL, 19);

                    TextIOManager.GetInstance().OutputSmartText("지워지지 않는 온기를 품고, 그는 또다시 검을 쥐고 나아간다.", 20 + widthL, 26);
                    TextIOManager.GetInstance().OutputText(">", 14 + widthL, 29);
                    break;
                case 1:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢠⣀⢀⡀⣀⢀⣀⠤⡤⣔⣲⣒⡖⣦⢠⡀⢄⡀⠀⠀⠀⠀", 30 + widthL, 1);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠈⠑⠛⠼⠫⠞⠹⠓⠙⠒⠳⢺⡽⢢⠍⠦⡙⢂⡏⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 2);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠴⡫⡗⣞⣘⡣⢰⣑⡈⠈⡒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 3);
                    TextIOManager.GetInstance().OutputText("⠀⡰⣥⣻⣽⣳⢦⣀⣀⢀⣤⣤⣀⡀⠀⠀⣏⢞⡀⠝⣋⣿⣝⢧⡭⠥⠐⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 4);
                    TextIOManager.GetInstance().OutputText("⠀⢱⠒⠋⠒⠋⠋⠛⠞⡿⣶⢯⢿⡽⣯⣀⣈⣓⢮⡝⣮⢟⢸⠄⠒⢦⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 5);
                    TextIOManager.GetInstance().OutputText("⠀⢈⡱⠀⠀⠀⠀⠀⣨⢷⣯⢟⣯⣽⡃⢟⣮⣛⢮⡽⣝⣎⠇⠒⡍⠸⣤⢊⠴⡠⢄⡤⠄⣤⢀⠀⠀⠀⠀⠀", 30 + widthL, 6);
                    TextIOManager.GetInstance().OutputText("⠀⢨⠇⡄⠀⠀⠀⠀⣽⣻⢮⣟⣞⣠⢽⣛⡶⣭⢿⡹⡍⢚⡴⢡⣸⣖⣣⢏⡶⣱⢞⣦⢚⡤⣋⠆⠀⠀⠀⠀", 30 + widthL, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠰⠤⠃⠀⠀⢠⢶⣯⢷⣻⡼⣎⡷⣫⢷⡻⠽⣮⣕⡸⠏⣞⡑⡯⢶⣹⣎⠷⣹⢾⡽⣎⢶⡹⡆⠀⠀⠀⠀", 30 + widthL, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠃⠀⠀⠀⠀⠛⣞⣯⢷⣫⡽⣞⡵⢫⡕⣡⠘⣮⡙⣭⠃⣉⡽⢛⠾⣼⢤⣻⠯⣿⣽⣳⢿⡄⠀⠀⠀⠀", 30 + widthL, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠐⣟⣮⡗⣯⢷⣫⣞⣣⣞⣼⢋⠶⡙⣤⢖⣫⢼⠈⠻⣜⣧⣟⣣⠳⡹⣏⢯⡂⠀⠀⠀⠀", 30 + widthL, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠉⠐⠙⠃⣹⡞⣷⡻⣞⠾⣭⢻⡭⣖⢯⡞⣿⣇⠳⣽⠂⠈⠳⣏⠶⣩⢲⡱⠄⠀⠀⠀", 30 + widthL, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡴⣯⢟⣧⢿⣭⢷⢮⣳⡽⣚⠷⣫⢝⣪⣽⣏⠃⠀⣰⢯⡿⢴⢣⣟⣥⠄⠀⠀", 30 + widthL, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⣠⠞⣧⢻⣽⣻⡞⣿⣺⢯⣟⡷⣻⣵⣻⡽⢾⡟⢷⣟⡆⠀⠸⣯⢟⡟⠮⡷⣞⠯⠀⠀", 30 + widthL, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⡴⢣⢻⠀⠀⣿⣳⣟⣲⣙⡶⡾⣽⡷⣯⢷⡽⣯⢷⣻⣼⠇⠀⣠⣟⡯⣞⣱⡝⣏⠀⠀⠀", 30 + widthL, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⢀⠜⣘⠣⡍⠀⠀⠱⣻⣞⡷⣯⢿⣽⣳⣽⠾⣯⡹⢭⠿⣽⣻⣇⡸⣔⡯⢷⣹⡼⣝⡎⠀⠀", 30 + widthL, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠰⢈⠜⠀⠁⠂⠀⠀⠀⣟⡾⣽⢯⣟⡾⣣⢟⣸⢇⡳⣉⡿⠽⢟⡾⣝⡿⣜⣯⢷⣻⡝⠀⠀⠀⠀", 30 + widthL, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣻⡽⣯⢟⡾⡵⢋⡾⣽⠫⣖⣧⠖⣉⣛⡾⡝⠚⠙⠚⠫⠗⠀⠀⠀⠀⠀", 30 + widthL, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣞⣳⣭⢗⣯⢻⣼⣻⢯⡿⣝⢿⡝⠲⣿⣭⢏⡿⡥⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠘⠡⠈⠘⠿⣪⣟⣯⢷⣻⠸⣿⣻⢷⣏⡿⣭⢷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠠⠀⢄⠠⡄⠤⣀⠄⢀⡀⣤⢷⣻⣞⣯⢷⡄⢻⡽⣿⢾⡽⢯⣟⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠮⠱⡌⠳⠔⡮⣷⢯⣟⣽⣳⢾⡽⣯⠖⣡⢻⣟⡯⡝⣧⢞⣥⠢⡘⠰⢠⠀⠀⠀⠀⠀", 30 + widthL, 21);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠋⠝⠻⣎⠷⣋⠯⡝⣭⢓⢦⣹⢿⡼⣕⣫⡞⣷⢧⠉⠁⠀⠀⠀⠀⠀⠀", 30 + widthL, 22);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠈⠁⠉⠀⠉⠐⢩⠳⣿⡽⣯⣟⣧⠿⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 23);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠉⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀", 30 + widthL, 24);

                    TextIOManager.GetInstance().OutputSmartText("분노에 삶을 태우며 살아가지만, 잿빛 흉터가 남아 있다.", 24 + widthL, 26);
                    TextIOManager.GetInstance().OutputText(">", 40 + widthL, 29);
                    break;
                case 2:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 1);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢄⠀            ", 38 + widthL, 2);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠡⡀⠀⠀⠀            ", 38 + widthL, 3);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠀⠀⠀            ", 38 + widthL, 4);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠰⡸⠁⠄⣷⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡌⠀⠀⠀⠀            ", 38 + widthL, 5);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⣴⡆⣦⣄⣼⠳⣅⠊⡷⠻⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⠀⠀⠀⠀            ", 38 + widthL, 6);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠈⠁⠊⠙⠁⢠⠏⢀⡤⣀⣄⠠⠄⠄⠶⠶⠖⠞⠛⡅⠀⠀⠀⠀            ", 38 + widthL, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢈⢲⣹⠃⡞⡬⡾⣝⢮⠃⠀⠀⠀⠀⠀⠀⠀⠸⠀⠀⠀⠀            ", 38 + widthL, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⡰⢥⡀⠀⣯⢳⢯⡽⡱⢟⠬⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀            ", 38 + widthL, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠉⡟⣮⢴⡻⣟⡄⠐⡀⠀⠀⠀⠀⠀⠀⠀⠠⠁⠀⠀⠀⠀            ", 38 + widthL, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠹⣎⡷⡍⠙⣾⢦⣥⠀⠀⠀⠀⠀⠀⢀⠂⠀⠀⠀⠀⠀            ", 38 + widthL, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⢿⣼⠁⢈⢖⡛⠾⡰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢈⡱⠙⠇⡐⢥⡙⠻⣆⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣻⡼⠀⠀⢽⣦⠻⡤⠈⠑⠣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣳⢿⠀⠀⠸⣽⡃⠈⠡⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠬⣫⠇⠀⠀⢹⡽⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⢫⠂⠀⠀⢢⢻⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⣏⠀⠀⠀⠀⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢀⡾⣮⠀⠀⠀⢈⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 38 + widthL, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠒⠋⠉⠁⠀⠀⠀⠰⣺⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38 + widthL, 21);

                    TextIOManager.GetInstance().OutputSmartText("경계에 선 이방인, 복잡한 시선으로 세상을 응시한다.", 25 + widthL, 26);
                    TextIOManager.GetInstance().OutputText(">", 65 + widthL, 29);
                    break;
            }

            if (nextSceneStopWatch.ElapsedMilliseconds > 2000)
            {
                Random rd = new Random(2);
                PlayerManager.GetInstance().environment = "";
                switch (rd.Next(0, 2))
                {
                    case 0:
                        PlayerManager.GetInstance().environment = "ForestScene";
                        break;
                    case 1:
                        PlayerManager.GetInstance().environment = "CemeteryScene";
                        break;
                }

                SceneManager.GetInstance().ChangeScene(PlayerManager.GetInstance().environment);
            }

        }

        public void Update()
        {

            if (isSelectRace == false)
            {
                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                {
                    isSelectRace = true;
                }
                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow) && selectChar > 0)
                {
                    selectChar--;
                }
                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow) && selectChar < 2)
                {
                    selectChar++;
                }
            }

            else if (isSelectRace == true)
            {
                InputName();
            }
        }

        public void InputName()
        {
            if (isSelectName == false)
            {
                TextIOManager.GetInstance().OutputSmartText("이름을 작성해 주세요.", 38 + widthL, 34);
                TextIOManager.GetInstance().OutputSmartText(name, 0, 1);

                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                {
                    isSelectName = true;
                }
                else
                {
                    ConsoleKey val = KeyInputManager.GetInstance().KeyDown();
                    if ((val >= ConsoleKey.A && val <= ConsoleKey.Z))
                    {
                        if (val != 0)
                            name += val;
                    }
                    if (val == ConsoleKey.Backspace)
                    {
                        if (name.Length != 0)
                            name = name.Remove(name.Length - 1, 1);
                    }
                    else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
                    {
                        name = "";
                        isSelectRace = false;
                    }
                }

                TextIOManager.GetInstance().OutputSmartText(name, 38 + widthL, 32);
            }
            else
            {
                TextIOManager.GetInstance().OutputSmartText("입력하신 이름 " + name + " ", 38 + widthL, 32);
                if (isSelectNameComplete == false)
                {
                    if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                    {
                        isSelectNameComplete = true;
                        PlayerManager.GetInstance().Init(name, (Race)selectChar);
                        nextSceneStopWatch.Start();
                    }
                    else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
                    {
                        name = "";
                        isSelectName = false;
                    }
                }
            }
        }
    }
}
