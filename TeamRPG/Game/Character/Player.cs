using System;
using System.Collections.Generic;
using System.Linq;
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
        private bool isAttack;
        private int attackIndex;
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
            if (isAttack == false)
                SelectPlayButton();
            if (isAttack == true)
                SelectAttackButton();

        }
        public void PlayerImageRender()
        {
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

            //TextIOManager.GetInstance().OutputSmartText("⡤⠤⠠⠤⠠⢄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 11);
            //TextIOManager.GetInstance().OutputSmartText("⠈⠲⡕⣗⣷⢶⣄⡍⡒⠔⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 10);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠈⠪⢺⢸⡪⡻⡻⢶⢦⣬⡑⠢⢄⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 9);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠈⠘⠙⠜⠕⡕⡯⡻⡶⣦⣉⡒⠔⢄⡀⡀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 8);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠁⠃⠣⠓⢯⢻⡲⡬⣌⠢⠢⣀⡀⠀⠀⣰⡫⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 7);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠊⠪⠫⠺⡤⡌⣓⢼⣱⢀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 6);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢉⡪⡳⠱⢡⠱⡑⢕⠔⢔⠈⠄⢄⠀⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 5);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣄⡲⣹⠁⠀⠀⠑⡕⡅⡣⡑⠡⠌⠂⡅⠀⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 4);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠉⢪⠂⠀⠀⠀⡸⡐⢕⠸⡈⡅⡂⢌⠆⠀⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 3);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢎⢌⢪⢨⠀⠪⡢⠣⡑⢄⠀⠀⠀⠀⠀", 70, TextIOManager.GetInstance().winHeight - 2);
            //TextIOManager.GetInstance().OutputSmartText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡸⡐⡱⢨⠢⠁⠈⢎⢪⢘⠔⡄⠀", 70, TextIOManager.GetInstance().winHeight - 1);
        }

        /*
         * 
⡤⠤⠠⠤⠠⢄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠈⠲⡕⣗⣷⢶⣄⡍⡒⠔⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠈⠪⢺⢸⡪⡻⡻⢶⢦⣬⡑⠢⢄⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⠘⠙⠜⠕⡕⡯⡻⡶⣦⣉⡒⠔⢄⡀⡀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠁⠃⠣⠓⢯⢻⡲⡬⣌⠢⠢⣀⡀⠀⠀⣰⡫⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠊⠪⠫⠺⡤⡌⣓⢼⣱⢀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢉⡪⡳⠱⢡⠱⡑⢕⠔⢔⠈⠄⢄⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣄⡲⣹⠁⠀⠀⠑⡕⡅⡣⡑⠡⠌⠂⡅⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠉⢪⠂⠀⠀⠀⡸⡐⢕⠸⡈⡅⡂⢌⠆⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢎⢌⢪⢨⠀⠪⡢⠣⡑⢄⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡸⡐⡱⢨⠢⠁⠈⢎⢪⢘⠔⡄⠀

         */
        public void UIRender()
        {
            StateBox();
            TextIOManager.GetInstance().OutputText(name, 7, 33);
            PlayerImageRender();
            AttackSelectUI();
            PlaySelectUI();
            HpBarRender();
            MpBarRender();
            if (isAttack == true)
            {
                EnemyManager.GetInstance().GetEnemyList()[attackIndex].SelectEnemy();
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
                }
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
        }
        private void AttackSelectUI()
        {
            if (isAttack == true)
            {
                switch (selectNum)
                {
                    case 0:
                        TextIOManager.GetInstance().OutputText4Byte("▶", 30, 20);
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
                if (val <= currentStatus.currentHp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 5 + 2 * i, 35);
                }
                else if (val - 10 <= currentStatus.currentHp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 5 + 2 * i, 35);
                }
            }
        }

        private void MpBarRender()
        {
            for (int i = 1; i <= currentStatus.MP / 10; i++)
            {
                int val = currentStatus.MP / 10 * i;
                if (val <= currentStatus.currentMp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 5 + 2 * i, 37);
                }
                else if (val - 10 <= currentStatus.currentMp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 5 + 2 * i, 37);
                }
            }
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
