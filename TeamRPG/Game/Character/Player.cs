using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Item;

namespace TeamRPG.Game.Character
{
    public class Player
    {
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
                totalEquip = totalEquip.Add(equip);
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
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.DownArrow))
            {
                selectNum++;
            }
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.UpArrow))
            {
                selectNum--;
            }
        }
        public void UIRender()
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
    }
}
