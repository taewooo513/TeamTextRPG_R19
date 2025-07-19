using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.ItemManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object;

namespace TeamRPG.Game.Scene
{
    public class CharInfoScene : Core.SceneManager.Scene
    {
        Player player;
        Status status;
        int select;
        int menuState;
        bool isSelect = false;
        int skillSelectIndex = 0;
        int inventorySelectIndex = 0;
        bool showingSkillDetail = false;
        bool showingTraitDetail = false;
        List<Skill> skills;
        //Trait trait;


        public void Init()
        {
            select = 1;
            menuState = 0;
            //player = new Player(player.name, player.race);
            player = PlayerManager.GetInstance().GetPlayer();
            status = StatusFactory.GetStatusByRace(player.race);
            isSelect = false;
            skills = StatusFactory.GetSkillsByRace(player.race);
            //player.RandomTrait();

        }

        public void Release()
        {

        }

        public void Render()
        {
            TextIOManager.GetInstance().OutputSmartText($"이름 : {player.name}({player.race})", 3, 6);
            TextIOManager.GetInstance().OutputSmartText($"레벨 : {player.level}", 3, 8);
            TextIOManager.GetInstance().OutputSmartText($"체력 : {player.baseStatus.currentHp} / {player.baseStatus.HP}", 3, 9);
            TextIOManager.GetInstance().OutputSmartText($"마나 : {player.baseStatus.currentMp} / {player.baseStatus.MP}", 3, 10);
            TextIOManager.GetInstance().OutputSmartText($"공격력 : {player.currentStatus.MinAttack} ~ {player.currentStatus.MaxAttack}", 3, 11);
            TextIOManager.GetInstance().OutputSmartText($"재빠름 : {player.currentStatus.Agility}", 3, 12);
            TextIOManager.GetInstance().OutputSmartText($"강인함 : {player.currentStatus.Tenacity}", 3, 13);
            TextIOManager.GetInstance().OutputSmartText($"운 : {player.currentStatus.Luck}", 3, 14);
            TextIOManager.GetInstance().OutputSmartText($"소지금 {player.Gold}G", 3, 16);
            TextIOManager.GetInstance().OutputSmartText($"스트레스 수치 {player.currentStatus.stress}", 3, 20);
            TextIOManager.GetInstance().OutputSmartText($"다음 레벨까지 EXP {player.expToNextLevel}", 3, 22);

            if (player.currentStatus.stress >= 50 && status.stress < 100)
            {
                TextIOManager.GetInstance().OutputSmartText("당신은 스트레스로 인한 피로감을 느끼고 있습니다.", 30, 29);
            }
            else if (player.currentStatus.stress >= 100)
            {
                TextIOManager.GetInstance().OutputSmartText("당신은 극도의 스트레스로 인해 탈진되었습니다.", 30, 29);
            }
            else
            {
                TextIOManager.GetInstance().OutputSmartText("아직까지는 문제가 없어 보입니다.", 40, 29);
            }

            TextIOManager.GetInstance().OutputSmartText($"특성 : {player.trait.name}", 40, 2);
            TextIOManager.GetInstance().OutputSmartText($"1. 보유 스킬", 6, 32);
            TextIOManager.GetInstance().OutputSmartText($"2. 인벤토리", 6, 33);
            TextIOManager.GetInstance().OutputSmartText($"3. 돌아가기", 6, 34);

            List<Skill> skills = StatusFactory.GetSkillsByRace(player.race);
            if (menuState == 0)
            {
                switch (select)
                {
                    case 0:
                        TextIOManager.GetInstance().OutputText(">", 37, 2);
                        if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                        {
                            menuState = 2;
                            showingTraitDetail = true;
                        }
                        break;
                    case 1:
                        TextIOManager.GetInstance().OutputText(">", 3, 32);
                        if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                        {
                            menuState = 1;
                        }
                        break;
                    case 2:
                        TextIOManager.GetInstance().OutputText(">", 3, 33);
                        if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                        {
                            menuState = 3;
                        }
                        break;
                    case 3:
                        if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                        {
                            SceneManager.GetInstance().ChangeScene(PlayerManager.GetInstance().environment);
                        }
                        TextIOManager.GetInstance().OutputText(">", 3, 34);
                        break;

                }
            }
            else if (menuState == 1) // 스킬창 상태
            {
                string skillLine = "";
                int cursorX = 32; // 시작 X 좌표
                int cursorY = 32;

                for (int i = 0; i < skills.Count; i++)
                {
                    // > 위치 계산
                    if (i == skillSelectIndex)
                    {
                        TextIOManager.GetInstance().OutputText(">", cursorX - 2, cursorY); // 스킬 왼쪽에 출력
                    }

                    TextIOManager.GetInstance().OutputSmartText($"{i + 1}. {skills[i].name}", cursorX, cursorY);
                    cursorX += skills[i].name.Length + 12; // 다음 스킬의 x 좌표 (간격 조절)
                }

                // 상세 정보 출력

                var selectedSkill = skills[skillSelectIndex];
                TextIOManager.GetInstance().OutputSmartText($"[{selectedSkill.name}]", 34, 34);
                TextIOManager.GetInstance().OutputSmartText($"{selectedSkill.description}", 34, 35);
                TextIOManager.GetInstance().OutputSmartText($"MP 소모량 : {selectedSkill.mpCost}", 34, 36);
                if (selectedSkill.power > 0)
                    TextIOManager.GetInstance().OutputSmartText($"공격력 : {selectedSkill.power}", 34, 37);
                if (selectedSkill.heal > 0)
                    TextIOManager.GetInstance().OutputSmartText($"회복량 : {selectedSkill.heal}", 34, 37);

            }
            else if (menuState == 2)
            {
                TextIOManager.GetInstance().OutputSmartText($"{player.trait.name} : {player.trait.description}", 39, 31);
            }
            else if (menuState == 3)
            {
                int cursorX = 34;
                int cursorY = 31;
                var inventory = player.Inventory;
                TextIOManager.GetInstance().OutputSmartText("체력과 마나가 최대치일시 소모품 사용은 안됩니다.", 30, 30);
                TextIOManager.GetInstance().OutputSmartText("[ 인벤토리 ]", cursorX, cursorY++);

                var itemList = inventory.ItemDictionary.ToList(); // 키-값 쌍을 리스트로 변환

                if (itemList.Count == 0)
                {
                    TextIOManager.GetInstance().OutputSmartText("소지한 아이템이 없습니다.", cursorX, cursorY++);
                }
                else
                {
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        var itemGroup = itemList[i];
                        string itemName = itemGroup.Key;
                        int itemCount = itemGroup.Value.Count;

                        if (i == inventorySelectIndex)
                        {
                            TextIOManager.GetInstance().OutputText(">", cursorX - 2, cursorY);
                        }

                        TextIOManager.GetInstance().OutputSmartText($"{itemName} x{itemCount}", cursorX, cursorY++);
                    }

                    // 선택된 아이템 효과 출력
                    var selectedItem = itemList[inventorySelectIndex].Value.First();
                    TextIOManager.GetInstance().OutputSmartText($"[{selectedItem.Name}] {selectedItem.Description}", cursorX, cursorY++);
                }

                TextIOManager.GetInstance().OutputSmartText("ESC를 눌러 돌아가기", cursorX, cursorY + 1);
            }





            switch (player.race)
            {
                case Race.Human:
                    TextIOManager.GetInstance().OutputText("         ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 6);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠣⣠⣤⣤⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣿⣿⣿⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣰⠟⣿⣿⣿⡟⡭⢭⡡⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡜⡏⣼⣨⣟⣿⣮⣽⣏⡵⡟⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⣟⢧⣧⣿⣾⡿⣿⡞⡿⣟⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣷⢲⡽⢷⣞⣿⣟⠃⠀⡯⣵⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⡰⢯⣿⣿⣗⡞⣮⣿⣿⣯⣄⠀⢻⣼⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⡝⢮⣽⣿⣿⢧⡾⣽⣿⣾⣷⣿⣿⡠⣼⣾⡇⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣔⢫⣳⣼⣻⣾⣿⣷⣏⡞⣽⡿⣼⣿⣿⣿⡅⢈⠉⠙⣿⡿⡴⢠⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⣱⣞⣯⣷⣿⣿⣿⡿⢻⣿⡜⡶⣿⡽⣿⣿⣿⣣⠄⠀⠀⠀⠀⢉⠃⠲⠍⣖⠢⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢟⣳⠜⣧⣾⣿⣿⣿⠑⣼⣯⣟⣚⣷⣿⣿⣯⣿⣿⢆⠀⠀⢄⠈⠄⡈⠐⡀⠀⠉⠐⠙⠝⣒⡤⡀⠀⠀⠀⠀⠀", 25, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠇⢸⣿⣿⣿⣟⡆⠈⣯⣿⣿⣎⣿⠋⣿⠗⢽⣯⣿⣇⠌⠄⡈⠐⠠⠁⠀⠁⠀⠀⠀⠀⠀⠈⠁⠀⠀⠀⠀⠀", 25, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠋⣈⣿⣿⠀⢃⢸⣿⣿⠏⠇⢀⢠⠀⠌⢿⣿⣿⠀⠂⠄⡑⠠⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⠟⠋⠀⠈⠄⡘⣿⣿⠀⠈⠄⠂⠈⠀⠘⣿⣷⠈⠐⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠋⠀⠀⠀⠀⠀⢀⣠⣿⣿⠀⠀⠀⠀⠀⠀⠄⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 25, 21);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠂⠐⠀⠂⠐⠀⠒⠒⠒⠒⠋⠛⠙⠋⠓⠒⠂⠒⠒⠒⠛⠙⠋⠓⠒⠒⠒⠒⠒⠒⠒⠂⠐⠀⠂⠐⠀⠂⠐⠀", 25, 22);


                    break;
                case Race.Dwarf:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢠⣀⢀⡀⣀⢀⣀⠤⡤⣔⣲⣒⡖⣦⢠⡀⢄⡀⠀⠀⠀⠀", 32, 4);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠈⠑⠛⠼⠫⠞⠹⠓⠙⠒⠳⢺⡽⢢⠍⠦⡙⢂⡏⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 32, 5);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠴⡫⡗⣞⣘⡣⢰⣑⡈⠈⡒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 32, 6);
                    TextIOManager.GetInstance().OutputText("⠀⡰⣥⣻⣽⣳⢦⣀⣀⢀⣤⣤⣀⡀⠀⠀⣏⢞⡀⠝⣋⣿⣝⢧⡭⠥⠐⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 32, 7);
                    TextIOManager.GetInstance().OutputText("⠀⢱⠒⠋⠒⠋⠋⠛⠞⡿⣶⢯⢿⡽⣯⣀⣈⣓⢮⡝⣮⢟⢸⠄⠒⢦⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 32, 8);
                    TextIOManager.GetInstance().OutputText("⠀⢈⡱⠀⠀⠀⠀⠀⣨⢷⣯⢟⣯⣽⡃⢟⣮⣛⢮⡽⣝⣎⠇⠒⡍⠸⣤⢊⠴⡠⢄⡤⠄⣤⢀⠀⠀⠀⠀⠀", 32, 9);
                    TextIOManager.GetInstance().OutputText("⠀⢨⠇⡄⠀⠀⠀⠀⣽⣻⢮⣟⣞⣠⢽⣛⡶⣭⢿⡹⡍⢚⡴⢡⣸⣖⣣⢏⡶⣱⢞⣦⢚⡤⣋⠆⠀⠀⠀⠀", 32, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠰⠤⠃⠀⠀⢠⢶⣯⢷⣻⡼⣎⡷⣫⢷⡻⠽⣮⣕⡸⠏⣞⡑⡯⢶⣹⣎⠷⣹⢾⡽⣎⢶⡹⡆⠀⠀⠀⠀", 32, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠃⠀⠀⠀⠀⠛⣞⣯⢷⣫⡽⣞⡵⢫⡕⣡⠘⣮⡙⣭⠃⣉⡽⢛⠾⣼⢤⣻⠯⣿⣽⣳⢿⡄⠀⠀⠀⠀", 32, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠐⣟⣮⡗⣯⢷⣫⣞⣣⣞⣼⢋⠶⡙⣤⢖⣫⢼⠈⠻⣜⣧⣟⣣⠳⡹⣏⢯⡂⠀⠀⠀⠀", 32, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠉⠐⠙⠃⣹⡞⣷⡻⣞⠾⣭⢻⡭⣖⢯⡞⣿⣇⠳⣽⠂⠈⠳⣏⠶⣩⢲⡱⠄⠀⠀⠀", 32, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡴⣯⢟⣧⢿⣭⢷⢮⣳⡽⣚⠷⣫⢝⣪⣽⣏⠃⠀⣰⢯⡿⢴⢣⣟⣥⠄⠀⠀", 32, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⣠⠞⣧⢻⣽⣻⡞⣿⣺⢯⣟⡷⣻⣵⣻⡽⢾⡟⢷⣟⡆⠀⠸⣯⢟⡟⠮⡷⣞⠯⠀⠀", 32, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⡴⢣⢻⠀⠀⣿⣳⣟⣲⣙⡶⡾⣽⡷⣯⢷⡽⣯⢷⣻⣼⠇⠀⣠⣟⡯⣞⣱⡝⣏⠀⠀⠀", 32, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⢀⠜⣘⠣⡍⠀⠀⠱⣻⣞⡷⣯⢿⣽⣳⣽⠾⣯⡹⢭⠿⣽⣻⣇⡸⣔⡯⢷⣹⡼⣝⡎⠀⠀", 32, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠰⢈⠜⠀⠁⠂⠀⠀⠀⣟⡾⣽⢯⣟⡾⣣⢟⣸⢇⡳⣉⡿⠽⢟⡾⣝⡿⣜⣯⢷⣻⡝⠀⠀⠀⠀", 32, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣻⡽⣯⢟⡾⡵⢋⡾⣽⠫⣖⣧⠖⣉⣛⡾⡝⠚⠙⠚⠫⠗⠀⠀⠀⠀⠀", 32, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣞⣳⣭⢗⣯⢻⣼⣻⢯⡿⣝⢿⡝⠲⣿⣭⢏⡿⡥⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 32, 21);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠘⠡⠈⠘⠿⣪⣟⣯⢷⣻⠸⣿⣻⢷⣏⡿⣭⢷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 32, 22);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠠⠀⢄⠠⡄⠤⣀⠄⢀⡀⣤⢷⣻⣞⣯⢷⡄⢻⡽⣿⢾⡽⢯⣟⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀", 32, 23);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠮⠱⡌⠳⠔⡮⣷⢯⣟⣽⣳⢾⡽⣯⠖⣡⢻⣟⡯⡝⣧⢞⣥⠢⡘⠰⢠⠀⠀⠀⠀⠀", 32, 24);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠋⠝⠻⣎⠷⣋⠯⡝⣭⢓⢦⣹⢿⡼⣕⣫⡞⣷⢧⠉⠁⠀⠀⠀⠀⠀⠀", 32, 25);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠈⠁⠉⠀⠉⠐⢩⠳⣿⡽⣯⣟⣧⠿⠀⠀⠀⠀⠀⠀⠀⠀", 32, 26);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠁⠉⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀", 32, 27);

                    break;
                case Race.HalfElf:
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀            ", 38, 5);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢄⠀            ", 38, 6);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠡⡀⠀⠀⠀            ", 38, 7);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠀⠀⠀            ", 38, 8);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠰⡸⠁⠄⣷⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡌⠀⠀⠀⠀            ", 38, 9);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⣴⡆⣦⣄⣼⠳⣅⠊⡷⠻⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⠀⠀⠀⠀            ", 38, 10);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠈⠁⠊⠙⠁⢠⠏⢀⡤⣀⣄⠠⠄⠄⠶⠶⠖⠞⠛⡅⠀⠀⠀⠀            ", 38, 11);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢈⢲⣹⠃⡞⡬⡾⣝⢮⠃⠀⠀⠀⠀⠀⠀⠀⠸⠀⠀⠀⠀            ", 38, 12);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⡰⢥⡀⠀⣯⢳⢯⡽⡱⢟⠬⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀            ", 38, 13);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠉⡟⣮⢴⡻⣟⡄⠐⡀⠀⠀⠀⠀⠀⠀⠀⠠⠁⠀⠀⠀⠀            ", 38, 14);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠹⣎⡷⡍⠙⣾⢦⣥⠀⠀⠀⠀⠀⠀⢀⠂⠀⠀⠀⠀⠀            ", 38, 15);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⢿⣼⠁⢈⢖⡛⠾⡰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 16);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢈⡱⠙⠇⡐⢥⡙⠻⣆⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 17);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣻⡼⠀⠀⢽⣦⠻⡤⠈⠑⠣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 18);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣳⢿⠀⠀⠸⣽⡃⠈⠡⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 19);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠬⣫⠇⠀⠀⢹⡽⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 20);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⢫⠂⠀⠀⢢⢻⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 21);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⣏⠀⠀⠀⠀⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 22);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢀⡾⣮⠀⠀⠀⢈⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 38, 23);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠒⠋⠉⠁⠀⠀⠀⠰⣺⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 24);
                    TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 25);

                    break;
            }
        }


        public void Update()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow) && select > 0 && menuState == 0)
            {
                select--;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow) && select < 3 && menuState == 0)
            {
                select++;
            }
            if (menuState == 1)
            {
                int maxIndex = skills.Count - 1;

                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow))
                {
                    skillSelectIndex--;
                    if (skillSelectIndex < 0) skillSelectIndex = 0;
                }

                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow))
                {
                    skillSelectIndex++;
                    if (skillSelectIndex > maxIndex) skillSelectIndex = maxIndex;
                }

                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
                {
                    menuState = 0;
                }
            }
            else if (menuState == 2)
            {
                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
                {
                    menuState = 0;
                    showingTraitDetail = false;
                }
            }
            else if (menuState == 3)
            {
                var inventory = player.Inventory;
                int itemCount = inventory.ItemDictionary.Count;

                if (itemCount > 0)
                {
                    if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow))
                    {
                        inventorySelectIndex--;
                        if (inventorySelectIndex < 0)
                            inventorySelectIndex = itemCount - 1; // 맨 위에서 위로 누르면 맨 마지막으로
                    }

                    if (KeyInputManager.GetInstance().KeyDown() == ConsoleKey.DownArrow)
                    {
                        inventorySelectIndex++;
                        if (inventorySelectIndex >= itemCount)
                            inventorySelectIndex = 0; // 맨 아래에서 아래로 누르면 처음으로
                    }
                }

                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
                {
                    var itemList = inventory.ItemDictionary.ToList();
                    if (itemList.Count == 0)
                    {
                        return;
                    }

                    var selectedItem = itemList[inventorySelectIndex].Value.First();

                    switch (selectedItem.Type)
                    {
                        case Object.Item.ItemType.Consumable:
                            if (selectedItem.Name == "회복 포션")
                            {
                                
                                if (player.baseStatus.currentHp == player.baseStatus.HP)
                                {
                                    TextIOManager.GetInstance().OutputSmartText("현재 체력이 최대치 입니다.", 30, 30);
                                }
                                else if (player.baseStatus.currentHp + 30 >= player.baseStatus.HP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    int heal = player.baseStatus.HP - player.baseStatus.currentHp;
                                    player.baseStatus.currentHp += heal;
                                }
                                else if (player.baseStatus.currentHp + 30 <= player.baseStatus.HP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    player.baseStatus.currentHp += 30;
                                }
                                
                                    
                            }
                            else if (selectedItem.Name == "마나 포션")
                            {
                                if (player.baseStatus.currentMp == player.baseStatus.MP)
                                {
                                    TextIOManager.GetInstance().OutputSmartText("현재 마나가 최대치 입니다.", 30, 30);
                                }
                                else if (player.baseStatus.currentMp + 20 >= player.baseStatus.MP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    int heal = player.baseStatus.MP - player.baseStatus.currentMp;
                                    player.baseStatus.currentMp += heal;
                                }
                                else if (player.baseStatus.currentMp + 20 <= player.baseStatus.HP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    player.baseStatus.currentMp += 20;
                                }
                                

                            }
                            else if (selectedItem.Name == "균형의 정수")
                            {
                                inventory.RemoveItem(selectedItem.Name, 1);

                                int mpHealAmount = 30;

                                if (player.baseStatus.currentMp == player.baseStatus.MP && player.baseStatus.currentHp == player.baseStatus.HP)
                                {
                                    TextIOManager.GetInstance().OutputSmartText("현재 체력과 마나가 최대치 입니다.", 30, 30);
                                }

                                if (player.baseStatus.currentMp + mpHealAmount > player.baseStatus.MP)
                                {
                                    mpHealAmount = player.baseStatus.MP - player.baseStatus.currentMp;
                                }
                                player.baseStatus.currentMp += mpHealAmount;

                                int hpHealAmount = 30;

                                if (player.baseStatus.currentHp + hpHealAmount > player.baseStatus.HP)
                                {
                                    hpHealAmount = player.baseStatus.HP - player.baseStatus.currentHp;
                                }
                                player.baseStatus.currentHp += hpHealAmount;

                                

                            }
                            else if (selectedItem.Name == "정령의 숨결")
                            {
                                
                                if (player.baseStatus.currentMp == player.baseStatus.MP)
                                {
                                    TextIOManager.GetInstance().OutputSmartText("현재 마나가 최대치 입니다.", 30, 30);
                                }
                                else if (player.baseStatus.currentMp + 80 >= player.baseStatus.MP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    int heal = player.baseStatus.MP - player.baseStatus.currentMp;
                                    player.baseStatus.currentMp += heal;
                                }
                                else if (player.baseStatus.currentMp + 80 <= player.baseStatus.HP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    player.baseStatus.currentMp += 80;
                                }
                                

                            }
                            else if (selectedItem.Name == "바위의 혼")
                            {
                                
                                if (player.baseStatus.currentHp == player.baseStatus.HP)
                                {
                                    TextIOManager.GetInstance().OutputSmartText("현재 체력이 최대치 입니다.", 30, 30);
                                }
                                else if (player.baseStatus.currentHp + 80 >= player.baseStatus.HP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    int heal = player.baseStatus.HP - player.baseStatus.currentHp;
                                    player.baseStatus.currentHp += heal;
                                }
                                else if (player.baseStatus.currentHp + 80 <= player.baseStatus.HP)
                                {
                                    inventory.RemoveItem(selectedItem.Name, 1);
                                    player.baseStatus.currentHp += 80;
                                }
                                

                            }
                            break;

                        case Object.Item.ItemType.Weapon:
                            var tem = ItemManager.GetInstance().GetItem(itemList[inventorySelectIndex].Key);
                            if (object.ReferenceEquals(tem, player.eWeapon))
                            {
                                player.eWeapon = null;
                                player.UnequipItem(tem.Status);
                            }
                            else
                            {
                                if (player.eWeapon != null)
                                {
                                    player.equipments.Remove(player.eWeapon.Status);
                                }
                                player.eWeapon = (Object.Item.Weapon)tem;
                                player.EquipItem(tem.Status);
                            }
                            break;
                        case Object.Item.ItemType.Armor:
                            var tem2 = ItemManager.GetInstance().GetItem(itemList[inventorySelectIndex].Key);
                            if (object.ReferenceEquals(tem2, player.eArmor))
                            {
                                player.eArmor = null;
                                player.UnequipItem(tem2.Status);
                            }
                            else
                            {
                                if (player.eArmor != null)
                                {
                                    player.equipments.Remove(player.eArmor.Status);
                                }
                                player.eArmor = (Object.Item.Armor)tem2;
                                player.EquipItem(tem2.Status);
                            }
                            break;
                        default:
                            break;
                    }
                }

                if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
                {
                    menuState = 0;
                    showingTraitDetail = false;
                }
            }
        }
    }
}
