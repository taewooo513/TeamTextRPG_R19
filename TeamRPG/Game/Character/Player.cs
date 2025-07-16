using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Item;

namespace TeamRPG.Game.Character
{
    public class Player
    {
        public bool isPlayerTurn = false;
        private bool isAttack;
        private int attackIndex;
        private bool isSkill;
        private List<Skill> skills;
        public string name { get; private set; }
        public Race race { get; private set; }
        public int level { get; private set; } = 1;

        public int currentExp { get; private set; } = 0;
        public int expToNextLevel => ExpTable.GetExpToNextLevel(level);

        public Status baseStatus { get; private set; }
        public Status currentStatus { get; private set; }

        private List<Status> equipments = new List<Status>();
        public List<Item> Inventory { get; set; } = new List<Item>();
        public int Gold { get; set; } = 1000;
        private int selectNum = 0;
        public Player(string _name, Race _race)
        {
            name = _name;
            race = _race;
            baseStatus = StatusFactory.GetStatusByRace(race);
            skills = StatusFactory.GetSkillsByRace(race);
            currentStatus = baseStatus;
        }

        public void GainExp(int _exp)
        {
            if (level >= ExpTable.maxLevel)
            {
                //Console.WriteLine("최대 레벨입니다");
                return;
            }

            currentExp += _exp;

            while (currentExp >= expToNextLevel && level < ExpTable.maxLevel)
            {
                currentExp -= expToNextLevel;
                LevelUp();
            }
        }

        public void LevelUp()
        {
            if (level >= ExpTable.maxLevel)
            {
                //Console.WriteLine("최대 레벨입니다");
                return;
            }

            level++;

            baseStatus.HP += 5;
            baseStatus.MinAttack += 2;
            baseStatus.MaxAttack += 2;

            RecalculateCurrentStatus();
        }
        public void HitPlayer(int _dmg)
        {
            baseStatus.currentHp -= _dmg;
        }

        public void EquipItem(Status equip)
        {
            equipments.Add(equip);
            RecalculateCurrentStatus();
        }

        public void UnequipItem(Status equip)
        {
            equipments.Remove(equip);
            RecalculateCurrentStatus();
        }

        private void RecalculateCurrentStatus()
        {
            Status totalEquip = new Status(0, 0, 0, 0, 0, 0, 0, 0, 0);
            foreach (var equip in equipments)
            {
                totalEquip.Add(equip);
            }
            currentStatus = baseStatus.Add(totalEquip);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {name}");
            Console.WriteLine($"종족: {race}");
            Console.WriteLine($"레벨: {level}");
            Console.WriteLine($"기본 스탯: {baseStatus}");
            Console.WriteLine($"장비 개수: {equipments.Count}");
            Console.WriteLine($"현재 스탯: {currentStatus}");
            Console.WriteLine("");
        }
        public void Update()
        {
            if (isAttack == false && isSkill == false)
                SelectPlayButton();
            else if (isAttack == true)
                SelectAttackButton();
            else if (isAttack == false && isSkill == true)
                SelectSkillButton();
        }
        public void PlayerImageRender()
        {
            switch (race)
            {
                case Race.HalfElf:
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⠛⠁⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 11);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⢤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⡿⠁⠀⠀⠀⠀⠀⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 10);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠈⢿⣿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 9);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠙⠈⠛⠷⣤⣀⠀⠀⠀⠀⠀⠀⠀⣼⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 8);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠳⣦⣀⠀⠀⠀⣼⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 7);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠻⢦⣴⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 6);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠌⠙⢿⡿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 5);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢌⠐⠈⠀⠀⠙⠃⠉⠻⢶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 4);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡌⠠⢁⠂⠀⠀⠀⠀⠂⠀⠉⠻⠶⣤⡀⠀⠀⠀⠀⠀⣀⠄⣰⢢⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 3);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠊⠐⠀⠂⠀⡀⠂⠄⠂⠀⠀⠀⠀⠀⠉⠙⠷⣤⡀⣀⠀⠈⠻⣷⡡⢂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 2);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⢂⠈⠀⠀⠄⠂⣜⣩⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠑⢦⣉⠒⡀⠀⠁⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 78, TextIOManager.GetInstance().winHeight - 1);
                    break;
                case Race.Human:
                    TextIOManager.GetInstance().OutputSmartText("⡤⠤⠠⠤⠠⢄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 11);
                    TextIOManager.GetInstance().OutputSmartText("⠈⠲⡕⣗⣷⢶⣄⡍⡒⠔⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 10);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠈⠪⢺⢸⡪⡻⡻⢶⢦⣬⡑⠢⢄⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 9);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠈⠘⠙⠜⠕⡕⡯⡻⡶⣦⣉⡒⠔⢄⡀⡀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 8);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠁⠃⠣⠓⢯⢻⡲⡬⣌⠢⠢⣀⡀⠀⠀⣰⡫⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 7);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠊⠪⠫⠺⡤⡌⣓⢼⣱⢀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 6);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢉⡪⡳⠱⢡⠱⡑⢕⠔⢔⠈⠄⢄⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 5);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣄⡲⣹⠁⠀⠀⠑⡕⡅⡣⡑⠡⠌⠂⡅⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 4);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠉⢪⠂⠀⠀⠀⡸⡐⢕⠸⡈⡅⡂⢌⠆⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 3);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢎⢌⢪⢨⠀⠪⡢⠣⡑⢄⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 2);
                    TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡸⡐⡱⢨⠢⠁⠈⢎⢪⢘⠔⡄⠀", 70, TextIOManager.GetInstance().winHeight - 1);
                    break;
            }

        }
        public void PlayerTurnSetting()
        {
            PlayerManager.GetInstance().gameMsg = "플레이어의 턴";
            isPlayerTurn = true;
        }
        public void UIRender()
        {
            StateBox();
            TextIOManager.GetInstance().OutputText(name, 7, 33);
            PlayerImageRender();
            if (isSkill == false)
            {
                PlaySelectUI();
            }
            else
            {
                SkillSelectUI();
            }

            HpBarRender();
            MpBarRender();
            if (isAttack == true)
            {
                EnemyManager.GetInstance().GetEnemyList()[attackIndex].SelectEnemy();
            }
        }
        private void SelectSkillButton()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow) && selectNum < 3)
            {
                selectNum++;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow) && selectNum > 0)
            {
                selectNum--;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                if (selectNum == 3)
                {
                    isSkill = false;
                    selectNum = 0;
                }
                else if (skills[selectNum].mpCost <= baseStatus.currentMp)
                {
                    isAttack = true;
                }
                else
                {
                    PlayerManager.GetInstance().gameMsg = "마나가 부족합니다.";
                }
            }
        }
        private void SelectPlayButton()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow) && selectNum < 3)
            {
                selectNum++;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow) && selectNum > 0)
            {
                selectNum--;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                switch (selectNum)
                {
                    case 0:
                        isAttack = true;
                        break;
                    case 3:
                        isSkill = true;
                        break;
                }
                selectNum = 0;
            }
        }
        private void SelectAttackButton()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow) && attackIndex < EnemyManager.GetInstance().GetEnemyList().Count - 1)
            {
                attackIndex++;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow) && attackIndex > 0)
            {
                attackIndex--;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Escape))
            {
                isAttack = false;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                if (isSkill == true)
                {
                    Random rd = new Random();
                    EnemyManager.GetInstance().GetEnemyList()[attackIndex].HitEnemy(skills[selectNum].power);
                    baseStatus.currentMp -= skills[selectNum].mpCost;
                    selectNum = 0;
                    PlayerManager.GetInstance().gameMsg = $" !!! {skills[selectNum].name} !!! {EnemyManager.GetInstance().GetEnemyList()[attackIndex].GetName()}에게 {skills[selectNum].power}의 데미지를 입혔습니다.";
                }
                else
                {
                    Random rd = new Random();
                    int dmg = rd.Next(currentStatus.MinAttack, currentStatus.MaxAttack);
                    EnemyManager.GetInstance().GetEnemyList()[attackIndex].HitEnemy(dmg);
                    selectNum = 0;
                    PlayerManager.GetInstance().gameMsg = $" {EnemyManager.GetInstance().GetEnemyList()[attackIndex].GetName()}에게 {dmg}의 데미지를 입혔습니다.";
                }
                attackIndex = 0;
                isAttack = false;
                isSkill = false;
            }
        }
        private void AttackSelectUI()
        {
            if (isAttack == true)
            {
                switch (selectNum) // 얘때문에 버그나는데 얘를 안써도 상관없는코드라서 이거 제가짯어요
                {
                    case 0:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 30, 20);
                        break;
                    case 1:
                        //TextIOManager.GetInstance().OutputText4Byte("▶", 10, 22);
                        break;
                    case 2:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 8, 24);
                        break;
                    case 3:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 11, 26);
                        break;
                }
            }
        }
        private void SkillSelectUI()
        {
            TextIOManager.GetInstance().OutputSmartText(skills[0].name, 11, 20);
            TextIOManager.GetInstance().OutputSmartText(skills[1].name, 11, 22);
            TextIOManager.GetInstance().OutputSmartText(skills[2].name, 11, 24);
            TextIOManager.GetInstance().OutputSmartText("뒤로가기", 11, 27);
            switch (selectNum)
            {
                case 0:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 8, 20);
                    break;
                case 1:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 8, 22);
                    break;
                case 2:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 8, 24);
                    break;
                case 3:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 8, 27);
                    break;
            }
        }
        private void PlaySelectUI()
        {
            TextIOManager.GetInstance().OutputSmartText("Attack", 15, 20);
            TextIOManager.GetInstance().OutputSmartText("Defense", 13, 22);
            TextIOManager.GetInstance().OutputSmartText("Item", 11, 24);
            TextIOManager.GetInstance().OutputSmartText("Skill", 14, 26);
            switch (selectNum)
            {
                case 0:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 12, 20);
                    break;
                case 1:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 10, 22);
                    break;
                case 2:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 8, 24);
                    break;
                case 3:
                    TextIOManager.GetInstance().OutputText4Byte("▶", 11, 26);
                    break;
            }
        }
        private void HpBarRender()
        {
            for (int i = 1; i <= currentStatus.HP / 10; i++)
            {
                int val = currentStatus.HP / 10 * i;
                if (10 * i <= currentStatus.currentHp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 5 + 2 * i, 35);
                }
                else if (currentStatus.currentHp % 10 != 0)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 5 + 2 * i, 35);
                    break;
                }
            }
        }

        private void MpBarRender()
        { //머리가 굳었어요 
            for (int i = 1; i <= currentStatus.MP / 10; i++)
            {
                int val = currentStatus.MP / 10 * i;
                if (10 * i <= currentStatus.currentMp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 5 + 2 * i, 37);
                }
                else if (currentStatus.currentMp % 10 != 0)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 5 + 2 * i, 37);
                    break;
                }
            }
            TextIOManager.GetInstance().OutputText4Byte(currentStatus.currentMp.ToString(), 1, 39);
        }
        private void StateBox()
        {
            int uiX = 0;
            int uiX2 = 0;

            TextIOManager.GetInstance().OutputText("┌", 4, 34);
            for (int i = 1; i <= currentStatus.HP / 10 * 2; i++)
            {
                TextIOManager.GetInstance().OutputText("─", 4 + i, 34);
                TextIOManager.GetInstance().OutputText("─", 4 + i, 36);
                uiX++;

            }
            TextIOManager.GetInstance().OutputText("┐", 4 + uiX + 2, 34);
            TextIOManager.GetInstance().OutputText("│", 4, 35);
            TextIOManager.GetInstance().OutputText("│", 4 + uiX + 2, 35);
            TextIOManager.GetInstance().OutputText("├", 4, 36);
            if (currentStatus.HP == currentStatus.MP)
            {
                TextIOManager.GetInstance().OutputText("┤", 4, 36);
            }
            else
            {
                int temp = Math.Abs(currentStatus.HP / 10 - currentStatus.MP / 10);
                if (currentStatus.HP > currentStatus.MP)
                {
                    TextIOManager.GetInstance().OutputText("┘", 4 + currentStatus.HP / 10 * 2 + 2, 36);
                    TextIOManager.GetInstance().OutputText("┬", 4 + (currentStatus.HP / 10 - temp) * 2 + 2, 36);
                }
                else
                {
                    TextIOManager.GetInstance().OutputText("┐", 4 + currentStatus.HP / 10 * 2 + 2, 36);
                    TextIOManager.GetInstance().OutputText("┴", 4 + (currentStatus.MP / 10 - temp) * 2 + 2, 36);
                }
            }
            for (int i = 1; i <= currentStatus.MP / 10 * 2; i++)
            {
                uiX2++;
                TextIOManager.GetInstance().OutputText("─", 4 + i, 38);
            }
            TextIOManager.GetInstance().OutputText("└", 4, 38);
            TextIOManager.GetInstance().OutputText("┘", 4 + currentStatus.MP / 10 * 2 + 2, 38);

            TextIOManager.GetInstance().OutputText("│", 4, 37);
            TextIOManager.GetInstance().OutputText("│", 4 + currentStatus.MP / 10 * 2 + 2, 37);


        }
    }
}
