using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Scene
{
    public class CharSelectScene : Core.SceneManager.Scene
    {
        int selectChar;
        Status[] state;
        String[] job;// 메모리를희생하고 가독성높이려 만든변수
        public void Init()
        {
            state = new Status[3];
            state[0] = StatusFactory.GetStatusByRace((Race)0);
            state[1] = StatusFactory.GetStatusByRace((Race)1);
            state[2] = StatusFactory.GetStatusByRace((Race)2);
            job = new String[3];
            job[0] = "인간";
            job[1] = "드워프";
            job[2] = "하프엘프";
            UIManager.GetInstance().AddUIElement(new Box(1, 4, 15, 16));
            selectChar = 0;
        }

        public void Release()
        {
            UIManager.GetInstance().ClearUI();
        }

        public void Render()
        {




            TextIOManager.GetInstance().OutputText("인간", 17, 27);
            TextIOManager.GetInstance().OutputText("드워프", 43, 27);
            TextIOManager.GetInstance().OutputText("하프엘프", 68, 27);

            switch (selectChar)
            {
                case 0:
                    TextIOManager.GetInstance().OutputText("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 3);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠣⣠⣤⣤⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 4);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣿⣿⣿⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 5);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣰⠟⣿⣿⣿⡟⡭⢭⡡⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 6);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡜⡏⣼⣨⣟⣿⣮⣽⣏⡵⡟⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣟⢧⣧⣿⣾⡿⣿⡞⡿⣟⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣷⢲⡽⢷⣞⣿⣟⠃⠀⡯⣵⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⡰⢯⣿⣿⣗⡞⣮⣿⣿⣯⣄⠀⢻⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⡝⢮⣽⣿⣿⢧⡾⣽⣿⣾⣷⣿⣿⡠⣼⣾⡇⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣔⢫⣳⣼⣻⣾⣿⣷⣏⡞⣽⡿⣼⣿⣿⣿⡅⢈⠉⠙⣿⡿⡴⢠⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⣱⣞⣯⣷⣿⣿⣿⡿⢻⣿⡜⡶⣿⡽⣿⣿⣿⣣⠄⠀⠀⠀⠀⢉⠃⠲⠍⣖⠢⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢟⣳⠜⣧⣾⣿⣿⣿⠑⣼⣯⣟⣚⣷⣿⣿⣯⣿⣿⢆⠀⠀⢄⠈⠄⡈⠐⡀⠀⠉⠐⠙⠝⣒⡤⡀⠀⠀⠀⠀⠀", 25, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠇⢸⣿⣿⣿⣟⡆⠈⣯⣿⣿⣎⣿⠋⣿⠗⢽⣯⣿⣇⠌⠄⡈⠐⠠⠁⠀⠁⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀", 25, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠋⣈⣿⣿⠀⢃⢸⣿⣿⠏⠇⢀⢠⠀⠌⢿⣿⣿⠀⠂⠄⡑⠠⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⠟⠋⠀⠈⠄⡘⣿⣿⠀⠈⠄⠂⠈⠀⠘⣿⣷⠈⠐⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠋⠀⠀⠀⠀⠀⢀⣠⣿⣿⠀⠀⠀⠀⠀⠀⠄⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠂⠐⠀⠂⠐⠀⠒⠒⠒⠒⠋⠛⠙⠋⠓⠒⠂⠒⠒⠒⠛⠙⠋⠓⠒⠒⠒⠒⠒⠒⠒⠂⠐⠀⠂⠐⠀⠂⠐⠀", 25, 19);

                    TextIOManager.GetInstance().OutputText("지워지지 않는 온기를 품고, 그는 또다시 검을 쥐고 나아간다.", 20, 25);
                    TextIOManager.GetInstance().OutputText(">", 14, 27);
                    break;
                case 1:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢠⣀⢀⡀⣀⢀⣀⠤⡤⣔⣲⣒⡖⣦⢠⡀⢄⡀⠀⠀⠀⠀", 30, 1);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠈⠑⠛⠼⠫⠞⠹⠓⠙⠒⠳⢺⡽⢢⠍⠦⡙⢂⡏⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30, 2);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠴⡫⡗⣞⣘⡣⢰⣑⡈⠈⡒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30, 3);
                    TextIOManager.GetInstance().OutputText("⠀⡰⣥⣻⣽⣳⢦⣀⣀⢀⣤⣤⣀⡀⠀⠀⣏⢞⡀⠝⣋⣿⣝⢧⡭⠥⠐⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30, 4);
                    TextIOManager.GetInstance().OutputText("⠀⢱⠒⠋⠒⠋⠋⠛⠞⡿⣶⢯⢿⡽⣯⣀⣈⣓⢮⡝⣮⢟⢸⠄⠒⢦⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30, 5);
                    TextIOManager.GetInstance().OutputText("⠀⢈⡱⠀⠀⠀⠀⠀⣨⢷⣯⢟⣯⣽⡃⢟⣮⣛⢮⡽⣝⣎⠇⠒⡍⠸⣤⢊⠴⡠⢄⡤⠄⣤⢀⠀⠀⠀⠀⠀", 30, 6);
                    TextIOManager.GetInstance().OutputText("⠀⢨⠇⡄⠀⠀⠀⠀⣽⣻⢮⣟⣞⣠⢽⣛⡶⣭⢿⡹⡍⢚⡴⢡⣸⣖⣣⢏⡶⣱⢞⣦⢚⡤⣋⠆⠀⠀⠀⠀", 30, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠰⠤⠃⠀⠀⢠⢶⣯⢷⣻⡼⣎⡷⣫⢷⡻⠽⣮⣕⡸⠏⣞⡑⡯⢶⣹⣎⠷⣹⢾⡽⣎⢶⡹⡆⠀⠀⠀⠀", 30, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠃⠀⠀⠀⠀⠛⣞⣯⢷⣫⡽⣞⡵⢫⡕⣡⠘⣮⡙⣭⠃⣉⡽⢛⠾⣼⢤⣻⠯⣿⣽⣳⢿⡄⠀⠀⠀⠀", 30, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠐⣟⣮⡗⣯⢷⣫⣞⣣⣞⣼⢋⠶⡙⣤⢖⣫⢼⠈⠻⣜⣧⣟⣣⠳⡹⣏⢯⡂⠀⠀⠀⠀", 30, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠉⠐⠙⠃⣹⡞⣷⡻⣞⠾⣭⢻⡭⣖⢯⡞⣿⣇⠳⣽⠂⠈⠳⣏⠶⣩⢲⡱⠄⠀⠀⠀", 30, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡴⣯⢟⣧⢿⣭⢷⢮⣳⡽⣚⠷⣫⢝⣪⣽⣏⠃⠀⣰⢯⡿⢴⢣⣟⣥⠄⠀⠀", 30, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⣠⠞⣧⢻⣽⣻⡞⣿⣺⢯⣟⡷⣻⣵⣻⡽⢾⡟⢷⣟⡆⠀⠸⣯⢟⡟⠮⡷⣞⠯⠀⠀", 30, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⡴⢣⢻⠀⠀⣿⣳⣟⣲⣙⡶⡾⣽⡷⣯⢷⡽⣯⢷⣻⣼⠇⠀⣠⣟⡯⣞⣱⡝⣏⠀⠀⠀", 30, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⢀⠜⣘⠣⡍⠀⠀⠱⣻⣞⡷⣯⢿⣽⣳⣽⠾⣯⡹⢭⠿⣽⣻⣇⡸⣔⡯⢷⣹⡼⣝⡎⠀⠀", 30, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠰⢈⠜⠀⠁⠂⠀⠀⠀⣟⡾⣽⢯⣟⡾⣣⢟⣸⢇⡳⣉⡿⠽⢟⡾⣝⡿⣜⣯⢷⣻⡝⠀⠀⠀⠀", 30, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣻⡽⣯⢟⡾⡵⢋⡾⣽⠫⣖⣧⠖⣉⣛⡾⡝⠚⠙⠚⠫⠗⠀⠀⠀⠀⠀", 30, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣞⣳⣭⢗⣯⢻⣼⣻⢯⡿⣝⢿⡝⠲⣿⣭⢏⡿⡥⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠘⠡⠈⠘⠿⣪⣟⣯⢷⣻⠸⣿⣻⢷⣏⡿⣭⢷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 30, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠠⠀⢄⠠⡄⠤⣀⠄⢀⡀⣤⢷⣻⣞⣯⢷⡄⢻⡽⣿⢾⡽⢯⣟⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀", 30, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠮⠱⡌⠳⠔⡮⣷⢯⣟⣽⣳⢾⡽⣯⠖⣡⢻⣟⡯⡝⣧⢞⣥⠢⡘⠰⢠⠀⠀⠀⠀⠀", 30, 21);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠋⠝⠻⣎⠷⣋⠯⡝⣭⢓⢦⣹⢿⡼⣕⣫⡞⣷⢧⠉⠁⠀⠀⠀⠀⠀⠀", 30, 22);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠈⠁⠉⠀⠉⠐⢩⠳⣿⡽⣯⣟⣧⠿⠀⠀⠀⠀⠀⠀⠀⠀", 30, 23);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠉⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀", 30, 24);


                    TextIOManager.GetInstance().OutputText("분노에 삶을 태우며 살아가만, 잿빛 흉터가 남아있다.", 24, 25);
                    TextIOManager.GetInstance().OutputText(">", 40, 27);
                    break;
                case 2:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀            ", 38, 1);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢄⠀            ", 38, 2);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠡⡀⠀⠀⠀            ", 38, 3);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠀⠀⠀            ", 38, 4);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠰⡸⠁⠄⣷⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡌⠀⠀⠀⠀            ", 38, 5);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⣴⡆⣦⣄⣼⠳⣅⠊⡷⠻⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⠀⠀⠀⠀            ", 38, 6);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠈⠁⠊⠙⠁⢠⠏⢀⡤⣀⣄⠠⠄⠄⠶⠶⠖⠞⠛⡅⠀⠀⠀⠀            ", 38, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢈⢲⣹⠃⡞⡬⡾⣝⢮⠃⠀⠀⠀⠀⠀⠀⠀⠸⠀⠀⠀⠀            ", 38, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⡰⢥⡀⠀⣯⢳⢯⡽⡱⢟⠬⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀            ", 38, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠉⡟⣮⢴⡻⣟⡄⠐⡀⠀⠀⠀⠀⠀⠀⠀⠠⠁⠀⠀⠀⠀            ", 38, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠹⣎⡷⡍⠙⣾⢦⣥⠀⠀⠀⠀⠀⠀⢀⠂⠀⠀⠀⠀⠀            ", 38, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⢿⣼⠁⢈⢖⡛⠾⡰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢈⡱⠙⠇⡐⢥⡙⠻⣆⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣻⡼⠀⠀⢽⣦⠻⡤⠈⠑⠣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣳⢿⠀⠀⠸⣽⡃⠈⠡⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠬⣫⠇⠀⠀⢹⡽⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⢫⠂⠀⠀⢢⢻⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⣏⠀⠀⠀⠀⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢀⡾⣮⠀⠀⠀⢈⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 38, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠒⠋⠉⠁⠀⠀⠀⠰⣺⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 21);

                    TextIOManager.GetInstance().OutputText("경계에 선 이방인, 복잡한 시선으로 세상을 응시한다.", 25, 25);
                    TextIOManager.GetInstance().OutputText(">", 65, 27);
                    break;
            }
            TextIOManager.GetInstance().OutputSmartText(job[selectChar], 4, 5);
            TextIOManager.GetInstance().OutputSmartText("생명력: " + state[selectChar].HP.ToString(), 4, 8);
            TextIOManager.GetInstance().OutputSmartText("마나:" + state[selectChar].MP.ToString(), 4, 10);
            TextIOManager.GetInstance().OutputSmartText("공격력:" + state[selectChar].MaxAttack.ToString(), 4, 12);
            TextIOManager.GetInstance().OutputSmartText("재빠름:" + state[selectChar].Agility.ToString(), 4, 14);
            TextIOManager.GetInstance().OutputSmartText("강인함:" + state[selectChar].Tenacity.ToString(), 4, 16);
            TextIOManager.GetInstance().OutputSmartText("행운:" + state[selectChar].Luck.ToString(), 4, 18);
        }

        public void Update()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow) && selectChar > 0)
            {
                SoundManager.GetInstance().PlaySound("Clicksmall", .1f);
                selectChar--;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow) && selectChar < 2)
            {
                SoundManager.GetInstance().PlaySound("Clicksmall", .1f);
                selectChar++;
            }
            InputName();
        }

        public string InputName()
        {
            string name = "";

            while (true)
            {
                Console.WriteLine($"이름을 작성해 주세요.");
                if (Console.KeyAvailable)
                {

                    name += Console.ReadKey();

                    if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter)) break;
                }
            }

            Console.WriteLine($"\n입력된 이름: {name}");
            return name;
        }
    }
}
