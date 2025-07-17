using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene
{
    public class CharInfoScene : Core.SceneManager.Scene
    {
        Player player;
        Status status;
        int select;
        bool isSelect = false;


        public void Init()
        {
            select = 0;
            player = new Player("asd", (Race)2);
            status = new Status(70, 50, 12, 16, 30, 50, 10, 70, 50);
            isSelect = false;
        }

        public void Release()
        {
            
        }

        public void Render()
        {
            TextIOManager.GetInstance().OutputSmartText($"이름 : {player.name}({player.race})", 3, 6);
            TextIOManager.GetInstance().OutputSmartText($"레벨 : {player.level}", 3, 8);
            TextIOManager.GetInstance().OutputSmartText($"체력 : {status.currentHp} / {status.HP}", 3, 9);
            TextIOManager.GetInstance().OutputSmartText($"마나 : {status.currentMp} / {status.MP}", 3, 10);
            TextIOManager.GetInstance().OutputSmartText($"공격력 : {status.MinAttack} ~ {status.MaxAttack}", 3, 11);
            TextIOManager.GetInstance().OutputSmartText($"재빠름 : {status.Agility}", 3, 12);
            TextIOManager.GetInstance().OutputSmartText($"강인함 : {status.Tenacity}", 3, 13);
            TextIOManager.GetInstance().OutputSmartText($"운 : {status.Luck}", 3, 14);
            TextIOManager.GetInstance().OutputSmartText($"소지금 {player.Gold}G", 3, 16);
            TextIOManager.GetInstance().OutputSmartText($"스트레스 수치 {status.stress}", 3, 20);
            TextIOManager.GetInstance().OutputSmartText($"다음 레벨까지 EXP {player.expToNextLevel}",3, 22);

            if (status.stress >= 50 && status.stress < 100)
            {
                TextIOManager.GetInstance().OutputSmartText("당신은 스트레스로 인한 피로감을 느끼고 있습니다.", 40, 26, ConsoleColor.DarkRed);
            }
            else if (status.stress >= 100)
            {
                TextIOManager.GetInstance().OutputSmartText("당신은 극도의 스트레스로 인해 탈진되었습니다.", 40, 26, ConsoleColor.Red);
            }
            else
            {
                TextIOManager.GetInstance().OutputSmartText("아직까지는 문제가 없어 보입니다.", 40, 26);
            }

            TextIOManager.GetInstance().OutputSmartText($"1. 보유 스킬", 6, 28);
            TextIOManager.GetInstance().OutputSmartText($"2. 인벤토리", 6, 29);

            List<Skill> skills = StatusFactory.GetSkillsByRace(player.race);
            if (isSelect == false)
            {
                switch (select)
                {
                    case 0:
                        TextIOManager.GetInstance().OutputText(">", 3, 28);
                        if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter)){
                            string skillLine = "";
                            for (int i = 0; i < skills.Count; i++)
                            {
                                skillLine += $"{i + 1}. {skills[i].name}";
                                if (i < skills.Count - 1)
                                    skillLine += "   "; // 스킬 사이 간격
                            }

                            TextIOManager.GetInstance().OutputSmartText($"보유 스킬 : {skillLine}", 10, 30);
                            Thread.Sleep(1000);
                        }
                        break;
                    case 1:
                        TextIOManager.GetInstance().OutputText(">", 3, 29);
                        break;


                }
            }






            switch (player.race)
            {
                case Race.Human:
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


                    break;
                case Race.Dwarf:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢠⣀⢀⡀⣀⢀⣀⠤⡤⣔⣲⣒⡖⣦⢠⡀⢄⡀⠀⠀⠀⠀", 40, 1);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠈⠑⠛⠼⠫⠞⠹⠓⠙⠒⠳⢺⡽⢢⠍⠦⡙⢂⡏⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 40, 2);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠴⡫⡗⣞⣘⡣⢰⣑⡈⠈⡒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 40, 3);
                    TextIOManager.GetInstance().OutputText("⠀⡰⣥⣻⣽⣳⢦⣀⣀⢀⣤⣤⣀⡀⠀⠀⣏⢞⡀⠝⣋⣿⣝⢧⡭⠥⠐⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 40, 4);
                    TextIOManager.GetInstance().OutputText("⠀⢱⠒⠋⠒⠋⠋⠛⠞⡿⣶⢯⢿⡽⣯⣀⣈⣓⢮⡝⣮⢟⢸⠄⠒⢦⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 40, 5);
                    TextIOManager.GetInstance().OutputText("⠀⢈⡱⠀⠀⠀⠀⠀⣨⢷⣯⢟⣯⣽⡃⢟⣮⣛⢮⡽⣝⣎⠇⠒⡍⠸⣤⢊⠴⡠⢄⡤⠄⣤⢀⠀⠀⠀⠀⠀", 40, 6);
                    TextIOManager.GetInstance().OutputText("⠀⢨⠇⡄⠀⠀⠀⠀⣽⣻⢮⣟⣞⣠⢽⣛⡶⣭⢿⡹⡍⢚⡴⢡⣸⣖⣣⢏⡶⣱⢞⣦⢚⡤⣋⠆⠀⠀⠀⠀", 40, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠰⠤⠃⠀⠀⢠⢶⣯⢷⣻⡼⣎⡷⣫⢷⡻⠽⣮⣕⡸⠏⣞⡑⡯⢶⣹⣎⠷⣹⢾⡽⣎⢶⡹⡆⠀⠀⠀⠀", 40, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠃⠀⠀⠀⠀⠛⣞⣯⢷⣫⡽⣞⡵⢫⡕⣡⠘⣮⡙⣭⠃⣉⡽⢛⠾⣼⢤⣻⠯⣿⣽⣳⢿⡄⠀⠀⠀⠀", 40, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠐⣟⣮⡗⣯⢷⣫⣞⣣⣞⣼⢋⠶⡙⣤⢖⣫⢼⠈⠻⣜⣧⣟⣣⠳⡹⣏⢯⡂⠀⠀⠀⠀", 40, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠉⠐⠙⠃⣹⡞⣷⡻⣞⠾⣭⢻⡭⣖⢯⡞⣿⣇⠳⣽⠂⠈⠳⣏⠶⣩⢲⡱⠄⠀⠀⠀", 40, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡴⣯⢟⣧⢿⣭⢷⢮⣳⡽⣚⠷⣫⢝⣪⣽⣏⠃⠀⣰⢯⡿⢴⢣⣟⣥⠄⠀⠀", 40, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⣠⠞⣧⢻⣽⣻⡞⣿⣺⢯⣟⡷⣻⣵⣻⡽⢾⡟⢷⣟⡆⠀⠸⣯⢟⡟⠮⡷⣞⠯⠀⠀", 40, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⡴⢣⢻⠀⠀⣿⣳⣟⣲⣙⡶⡾⣽⡷⣯⢷⡽⣯⢷⣻⣼⠇⠀⣠⣟⡯⣞⣱⡝⣏⠀⠀⠀", 40, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⢀⠜⣘⠣⡍⠀⠀⠱⣻⣞⡷⣯⢿⣽⣳⣽⠾⣯⡹⢭⠿⣽⣻⣇⡸⣔⡯⢷⣹⡼⣝⡎⠀⠀", 40, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠰⢈⠜⠀⠁⠂⠀⠀⠀⣟⡾⣽⢯⣟⡾⣣⢟⣸⢇⡳⣉⡿⠽⢟⡾⣝⡿⣜⣯⢷⣻⡝⠀⠀⠀⠀", 40, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣻⡽⣯⢟⡾⡵⢋⡾⣽⠫⣖⣧⠖⣉⣛⡾⡝⠚⠙⠚⠫⠗⠀⠀⠀⠀⠀", 40, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣞⣳⣭⢗⣯⢻⣼⣻⢯⡿⣝⢿⡝⠲⣿⣭⢏⡿⡥⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 40, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠘⠡⠈⠘⠿⣪⣟⣯⢷⣻⠸⣿⣻⢷⣏⡿⣭⢷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 40, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠠⠀⢄⠠⡄⠤⣀⠄⢀⡀⣤⢷⣻⣞⣯⢷⡄⢻⡽⣿⢾⡽⢯⣟⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀", 40, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠮⠱⡌⠳⠔⡮⣷⢯⣟⣽⣳⢾⡽⣯⠖⣡⢻⣟⡯⡝⣧⢞⣥⠢⡘⠰⢠⠀⠀⠀⠀⠀", 40, 21);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠋⠝⠻⣎⠷⣋⠯⡝⣭⢓⢦⣹⢿⡼⣕⣫⡞⣷⢧⠉⠁⠀⠀⠀⠀⠀⠀", 40, 22);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠈⠁⠉⠀⠉⠐⢩⠳⣿⡽⣯⣟⣧⠿⠀⠀⠀⠀⠀⠀⠀⠀", 40, 23);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠉⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀", 40, 24);

                    break;
                case Race.HalfElf:
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

                    break;
            }
        }
        

        public void Update()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow) && select > 0)
            {
                select--;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow) && select < 1)
            {
                select++;
            }
        }
    }
}
