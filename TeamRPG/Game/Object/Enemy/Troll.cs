using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Object.Enemy
{
    internal class Troll : Enemy
    {
        int x = 0;
        int y = 0;
        string gNum = "";
        string name;
        public Troll(int _x, int _y, string _num) // default는 중앙으로잡고 거기서 위치를잡게끔
        {
        }
        public override void Init()
        {
        }

        public override void Update()
        {
            if (isTurn == true)
            {
                if (isExSkill == false)
                {
                    if (stopwatch.ElapsedMilliseconds > 2000)
                    {
                        isTurn = false; // ?
                        PlayerManager.GetInstance().GetPlayer().selectE++;
                        if (EnemyManager.GetInstance().GetEnemyList().Count > PlayerManager.GetInstance().GetPlayer().selectE)
                        {
                            EnemyManager.GetInstance().GetEnemyList()[PlayerManager.GetInstance().GetPlayer().selectE].EnemyTurnSetting();
                        }
                        else
                        {
                            PlayerManager.GetInstance().GetPlayer().PlayerTurnSetting();
                        }
                        state.currentHp += 3;

                        stopwatch.Reset();
                        stopwatch.Stop();
                    }
                }
                else
                {
                    InputKeyPad();
                    if (parryStopwatch.ElapsedMilliseconds > 2000)
                    {
                        ExSkill();
                        isParreyFail = true;
                        keyPad.Clear();
                        parryStopwatch.Reset();
                        parryStopwatch.Stop();
                        stopwatch.Start();
                        isExSkill = false;
                    }
                    if (stopwatch.ElapsedMilliseconds > 2000)
                    {
                        isTurn = false; // ?
                        PlayerManager.GetInstance().GetPlayer().selectE++;
                        if (EnemyManager.GetInstance().GetEnemyList().Count > PlayerManager.GetInstance().GetPlayer().selectE)
                        {
                            EnemyManager.GetInstance().GetEnemyList()[PlayerManager.GetInstance().GetPlayer().selectE].EnemyTurnSetting();
                        }
                        else
                        {
                            PlayerManager.GetInstance().GetPlayer().PlayerTurnSetting();
                        }
                        state.currentHp += 3;
                        stopwatch.Reset();
                        stopwatch.Stop();
                    }
                }
            }
            if (state.currentHp <= 0)
            {
                isDie = true;
            }
        }
        public override void SelectEnemy()
        {
            TextIOManager.GetInstance().OutputText4Byte("▶", 69 + x, 3 + y);
        }
        protected override void DrawImage()
        {
            TextIOManager.GetInstance().OutputSmartText("트롤", 71 + x, 3 + y);
            if (base.isExSkill == false)
            {
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⢤⢦⣖⣯⠯⣟⠯⢓⢴⢄⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 4 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣟⣷⢽⣺⣲⢤⣂⢲⢽⢵⢷⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 4 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⢰⢽⡽⣾⣹⢻⢪⣫⢮⣢⣱⢽⣻⡮⡫⡍⡕⣀⠀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 5 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⢀⣾⣯⢿⣳⡯⣷⣪⢬⡏⡗⣗⣽⣯⣯⢯⡯⣷⡳⣹⢵⢟⡟⡬⣦⡂⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 6 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⡼⣸⣯⡿⣯⣿⣺⣞⣟⢷⣓⢷⣻⡾⣽⢯⡯⡷⡯⣗⡯⣞⣞⡕⣅⢕⢌⠔⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 7 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⢀⠐⡰⢯⣟⣷⣿⢽⣾⣷⢷⡯⣧⡳⣓⣯⣯⢿⡽⡯⣟⡿⣽⣽⣳⣗⣟⣮⡳⡳⡣⢃⠢⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 8 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠐⡀⠠⢰⡯⣟⣷⣟⣿⣺⣽⣟⡿⣾⣽⣽⣻⣞⡿⣯⣟⣽⢽⣗⣿⣺⣗⣟⡮⣟⢮⣪⡢⡑⡔⡰⢡⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 9 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠂⣼⣽⣻⣯⢳⢿⡽⣯⡷⣿⡽⣷⢷⣻⣽⣞⡯⡷⡷⡽⣕⣗⣗⡯⣟⣯⣯⡏⢟⣞⢮⢯⡺⣜⡜⣎⡆⠄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 10 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⢀⡾⢟⣾⡻⠈⠄⣿⣻⣽⣟⣷⣻⢽⣝⣯⡿⡮⡯⣺⡫⡯⡺⡲⣕⢽⢝⣞⢵⣻⡄⠀⠙⠙⠽⢺⢽⣺⡞⡌⡢⢁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 11 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⢼⡏⣾⡟⢀⠐⠀⣾⣳⣻⣾⣳⢯⣻⡺⣺⢽⢽⢝⡞⣮⣫⣺⡹⣜⢼⢕⣗⢽⡺⡮⠀⠀⠀⠀⠀⠈⢷⣯⡳⡌⡢⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 12 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⣿⡂⠠⠀⡁⠘⡷⡽⣾⢯⣟⣮⡺⡺⣝⣗⢽⡺⣪⢞⡮⣺⣪⡳⣣⢳⢝⢾⢽⠅⠀⠀⠀⠀⠀⠘⣷⢝⣎⢎⠮⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 13 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠙⠂⠄⢁⢀⠡⢸⢯⣻⣟⢾⢽⡏⠈⠃⠳⢳⢝⣞⣝⢮⢳⢕⢵⢱⡱⢝⢭⡳⡧⠀⠀⠀⠀⠀⠀⢹⢽⣺⢜⢜⡢⠀⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 14 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠂⠁⠄⠁⡐⠀⠄⠂⢸⢜⢮⢾⢝⡽⡊⠀⡁⠐⠈⣗⢵⡣⡳⡕⡧⡳⡕⡕⡇⣗⢝⡽⣄⠀⠀⠀⠀⠀⠀⢹⣽⣕⢧⡹⡄⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 15 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠐⠀⠂⢁⠠⠈⠄⠡⢘⢮⣳⡫⡎⣞⠀⠂⡀⠐⠀⠪⡳⣝⡝⡮⣇⢯⡪⣇⢯⢮⢯⢯⣗⡆⠀⠀⠀⠀⠀⠀⠳⣷⡳⡕⣅⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 16 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⢁⠠⠐⠈⡀⢂⢘⢞⡮⡇⡇⡃⠀⠂⠀⠈⠀⠀⠫⣞⢮⡳⣕⣗⣝⡮⣗⡯⣟⣗⡷⡵⣢⠀⠀⠀⠀⠀⠈⢫⣟⢮⡪⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 17 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⢀⠠⠀⡁⡀⠄⢰⢯⣞⢕⠌⠀⠄⠁⠀⠀⠀⠀⢘⣾⣽⣽⣳⣽⢾⡽⣯⡿⡯⣗⣟⣯⣳⠁⠀⠀⠀⠀⠀⠘⣽⡣⣏⡂⠀⠀⠀⠀⠀⠀⠀⠀", 60 + x - 10, 18 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠂⡵⣻⣞⢜⠄⠈⠄⠂⡀⠀⠀⢀⣞⣷⣟⣾⣯⢿⣻⣻⢽⢺⡹⣺⣺⣺⣽⠇⠀⠀⠀⠀⠀⠀⠸⣽⡪⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀  ", 60 + x - 10, 19 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠐⡀⢬⢪⢗⣯⢮⠀⠌⠀⡂⠀⠀⣠⢷⣻⣞⣯⣷⣟⡿⣯⠳⠱⡱⣹⡺⣮⢷⣟⡇⠀⠀⠀⠀⠀⠀⠀⣷⡱⣝⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀  ", 60 + x - 10, 20 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠡⢠⢣⣫⣟⡾⡅⠀⠈⠀⠀⠀⡼⡽⣽⣺⢽⣻⣾⣳⡿⡑⠌⡂⡮⣺⣺⡽⣯⡷⡇⠀⠀⠀⠀⠀⠀⢠⣳⣻⡪⡳⡠⠀⠀⠀⠀⠀⠀⠀⠀  ", 60 + x - 10, 21 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⣼⣺⢾⢽⠀⠈⠀⠀⠀⣸⢽⣝⢾⣺⢯⡿⣞⣷⡏⠢⡡⡪⣞⡵⣯⢿⢽⣞⡇⠀⠀⠀⠀⠀⠀⡎⣖⢵⢝⡎⡎⡆⡀⠀⠀⠀⠀⠀⠀  ", 60 + x - 10, 22 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⢐⣝⢮⣞⡯⠃⠀⠀⠀⠀⢀⡯⡷⡽⣽⡺⡯⣟⣯⣷⡏⢌⢎⣞⡼⣾⢯⡿⣽⢾⡂⠀⠀⠀⠀⠀⠀⢻⢮⠋⠋⢟⡮⣣⣓⢆⠀⠀⠀⠀⠀ ", 60 + x - 10, 23 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⣜⢮⣻⡞⠅⠀⠀⠀⠀⠀⣸⢽⣝⢾⡕⣏⢯⠞⣿⣽⡯⣞⣗⡷⣻⡽⠉⡿⠻⣻⠀⠀⠀⠀⠀⠀⢀⢸⢯⠀⠀⡀⡹⣵⡯⣟⡆⠀⠀⠀⠀  ", 60 + x - 10, 24 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⢠⡳⣯⡗⠁⠀⠀⠀⠀⠀⠀⣼⡳⣳⡣⡇⡇⠇⠀⠀⠫⠉⠳⣗⣟⣯⢿⡥⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠌⠻⣂⣅⠆⣹⣳⣻⢽⠊⠀⠀⠀⠀  ", 60 + x - 10, 25 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⢽⣺⡽⣆⢄⠀⠀⠀⠀⠀⠠⣳⢽⡳⡯⡮⣗⢄⠀⠀⠀⠀⠈⡯⡾⡽⣯⣟⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣄⠀⠀⣶⢽⣺⡺⠁⠀⠀⠀⠀⠀   ", 60 + x - 10, 26 + y);
                TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⢱⢯⡻⡮⣯⡳⣄⠀⠀⢀⠀⠙⢗⡯⡯⣞⣵⡱⡡⡀⠀⠀⠀⢽⣝⡯⣷⣳⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠁⠈⠈⠀⠀⠀⠀⠀⠀⠀   ", 60 + x - 10, 27 + y);
            }
            else
            {
                string parryImage = """
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠐⢌⠔⢌⢢⢂⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢮⡳⡍⢆⠕⡠⡊⡎⣦⢗⣲⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠣⣎⢆⠣⡢⢣⣪⢺⣯⣯⡳⡱⢅⢆⠄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡪⣪⢺⡓⡕⡽⣝⢮⣣⢷⣟⢎⡮⡎⡆⡣⢊⠆⡔⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⡺⡸⣳⡱⣝⢜⣕⢗⣽⣾⣻⢵⡹⡪⢎⢎⢢⢱⢨⢪⢪⢂⢄⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢀⡂⡇⣞⡽⣢⢳⢕⢏⢗⡽⣺⡾⣝⢝⢞⢎⠎⡆⡣⡱⡱⣕⢧⢣⢊⢊⢲⢰⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢆⢷⡱⣱⣹⡸⡽⣟⣾⣼⣪⣷⣽⣯⡻⡵⡱⡕⣗⢝⢝⡕⣝⢕⢕⠕⢕⢱⠐⢅⢇⢇⢎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡪⡫⣚⢎⡗⡕⡝⡜⣟⣿⣻⣯⡷⡻⡜⡎⡮⢣⢣⢃⢇⡣⡻⣜⢎⡎⢬⠸⡸⣸⢢⢣⢣⢣⢕⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣗⢵⡹⣪⡳⡑⡕⡱⡸⡰⣫⢳⢱⠱⡡⡱⡑⡌⡌⢆⠕⡕⢵⢝⡾⣧⢫⣪⡪⣞⢵⢝⢮⣪⡳⡕⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡾⡵⣝⡾⡸⡨⡪⢢⢣⢝⣞⢦⢱⢑⠅⢕⢈⢂⠪⣊⢎⣎⣗⣽⣽⣻⡳⡵⡻⡮⣗⡯⡳⡵⡽⡽⡰⡀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⢵⣏⢮⡪⣎⢞⡼⣳⣳⢝⢮⡪⡪⡦⡣⡲⣕⢷⡻⣺⢮⡷⣿⣳⢹⢍⢮⢫⢺⠺⣝⢝⡽⣹⡪⡎⢂⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⡕⡷⡽⣽⡽⡺⣝⢮⢗⡿⡽⢮⡪⡫⡪⢮⢺⢮⢷⡻⡽⣽⢽⣟⣷⢕⢽⢸⡨⣊⢪⢪⢇⢟⢮⣺⣪⠢⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡳⣝⢮⣻⣿⣽⡽⣎⢯⢣⢯⡚⡜⢜⢕⢷⢵⡝⣕⢕⣗⡽⣞⡿⣟⣿⡯⣎⢇⢧⢪⢲⡱⣝⡵⡳⡱⡪⡈⢂⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢤⡳⣝⡮⡯⣾⣿⣾⣻⢕⢧⡫⣞⢮⡪⡪⡪⡳⣝⣞⡷⣵⢳⢽⢽⣻⣿⣿⣿⣷⣝⢮⣫⣞⣮⡳⡝⡜⡜⡜⢌⠔⡂⡀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⡕⣗⢽⣳⣯⣟⣷⣿⣯⢷⢝⡜⣜⢮⢣⢪⠪⡪⡪⡺⣮⡻⡪⡯⡯⣟⣿⣽⣿⢿⠁⠘⠻⣾⣞⡞⣜⢜⠌⢜⢸⡰⢥⠡⡀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠠⣳⢱⢱⣳⣳⣻⡽⣿⣿⣟⣗⢵⡣⣣⣣⢣⢣⢣⢣⢣⢫⣗⢝⢮⢹⢽⢽⢯⡿⡎⠁⠀⠀⠀⣜⢗⣝⢜⢆⡣⢣⢣⣏⢧⡣⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⢸⡸⡕⡕⡧⣗⣟⢞⣽⣾⡻⣮⢳⡹⣪⢪⢳⢱⠱⡱⡱⡱⣕⢕⢕⢕⢯⢟⢷⡻⡇⠀⠀⠀⠠⣳⠯⣎⢗⢵⢱⢣⣳⡳⣻⢪⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⡔⣗⢝⡮⣳⢳⢵⣻⢷⢯⡻⣮⡳⣝⢜⣝⢵⢱⢱⢱⢱⡹⣜⢼⡸⣪⡳⣝⣗⡽⣵⠀⠀⠀⠀⢯⢯⢞⢵⢑⠱⡕⡗⡵⢕⢇⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⣜⢼⡪⣗⣽⣺⣽⣟⡿⠛⣗⢽⣳⣝⢮⡳⣕⢯⢮⡪⡮⣪⢷⡳⣣⡳⣕⣗⣗⢷⢯⡳⡡⠀⠀⠀⠈⢏⡏⣞⢜⢸⢸⡕⡕⡥⡑⠄⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠠⣣⡳⣝⣞⣞⣷⠏⠂⠀⣜⢞⢽⢮⢿⢽⢾⢽⣽⡳⡯⡯⣟⣽⣺⢵⢹⡰⢵⢽⢽⡽⡾⡵⣅⠀⠀⢀⢇⠧⡣⢣⢱⡱⣕⡕⣏⢮⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⣜⢮⡺⣪⢺⢼⡝⠀⠀⢠⢗⡽⣱⡫⡯⡯⣯⣳⡳⡯⣻⢝⣗⣗⢵⣫⢧⣮⣳⣝⢵⢯⡯⣟⡜⣄⢔⢵⠱⡍⡆⡇⡇⡯⣺⡺⣝⡕⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⡰⡕⣗⣽⣪⢳⣻⠁⠀⠀⡮⡳⣝⣖⢝⡮⣳⢕⢧⡫⣞⢮⡳⣕⢧⣯⢯⢯⢺⢜⣞⢯⣳⢯⣗⣏⢎⢎⢎⢇⢇⢇⢇⢷⡹⡰⣝⢵⢇⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠠⣳⢝⣵⣿⣮⣳⡕⠀⠀⢼⢝⢎⢞⡮⡷⣝⢮⡫⡳⣝⣜⢞⣞⢮⣿⡽⡽⡕⡇⡗⡕⡯⣯⣟⣾⡪⣧⠳⠱⡕⡕⡜⡌⡷⡑⢕⣝⢽⢅⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⣗⢽⣺⢾⣿⣷⣿⣀⡠⡯⡳⡍⣗⢽⢽⡺⡧⣫⣫⡺⡪⣗⢯⣿⣯⢯⡫⡎⡎⡎⡎⣝⢞⣷⣳⣽⣺⠅⠀⢜⢵⡱⡼⣕⢧⣳⣝⢞⡕⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⢮⡣⣟⣿⣻⣿⣟⣯⠫⣫⢳⡹⣜⢮⣻⢎⡯⣺⢲⢝⣝⢮⣟⣿⢾⢯⡪⡎⡎⡪⣪⡪⣿⣺⢿⣽⣞⠅⠀⡣⣣⢳⡻⣝⢵⣻⢮⠋⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠈⢫⢞⣎⣗⡯⡟⠗⠀⢸⢕⢧⣫⣟⣞⡵⣝⢮⢳⢝⡮⣗⡿⣯⣟⣟⢮⡪⡪⡮⣲⡽⣽⡯⣟⣞⣗⡇⢠⡫⡪⡪⡯⣎⢯⡗⠃⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠈⠈⠊⠋⠃⠀⠀⢸⣝⡧⣷⢿⢜⣾⢸⢵⡹⡵⣫⢾⠊⢟⣞⣞⣗⢵⢝⢮⢷⢯⢷⢿⣝⣗⣧⡫⡮⣫⢯⡿⡽⠮⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⡜⣞⡯⣯⢳⢽⡪⡳⣝⣝⢮⢯⠀⠸⣳⣳⡻⡮⡏⡯⣫⡯⡯⣿⣺⣳⢯⡿⡞⠷⠻⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢪⣳⡱⣹⢮⢯⣟⣎⢯⣾⡪⡯⣿⡀⠀⠱⣳⢯⡣⡣⣪⢳⡏⣯⣿⣷⣽⣻⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣞⣮⣗⣿⢽⣞⣗⣯⡳⣝⣯⢿⡧⠀⠀⢹⣷⣝⣞⢮⣳⢽⣺⣽⣿⣿⣿⣵⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣕⣗⢯⣯⣷⣻⣺⡺⣽⣞⡯⡯⠀⠀⢸⣿⣟⡾⣫⢯⢟⡾⣽⣻⣽⡻⣿⡱⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⡯⣗⣗⣿⣞⣞⣞⣗⣯⣿⠇⠀⠀⠨⡿⣷⣯⢷⡽⣽⣺⣳⢿⣳⢯⣗⣗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
             """;
            }
        }
    }
}

/*
 
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀



 */