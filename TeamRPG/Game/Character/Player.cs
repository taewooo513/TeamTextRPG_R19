using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Item;

namespace TeamRPG.Game.Character
{
    public class Player
    {
        public string name { get; private set; }
        public Race race { get; private set; }
        public int level { get; private set; } = 1;

        public Status baseStatus { get; private set; }
        public Status currentStatus { get; private set; }

        private List<Status> equipments = new List<Status>();

        public Player(string _name, Race _race)
        {
            name = _name;
            race = _race;
            baseStatus = StatusFactory.GetStatusByRace(race);
            currentStatus = baseStatus;
        }

        public void LevelUp()
        {
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
            Status totalEquip = new Status(0, 0, 0, 0, 0, 0, 0);
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
    }
}
