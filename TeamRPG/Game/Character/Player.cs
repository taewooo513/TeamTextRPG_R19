using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Character
{
    public class Player
    {
        public string Name { get; private set; }
        public Race Race { get; private set; }
        public int Level { get; private set; } = 1;

        public Status BaseStatus { get; private set; }
        public Status CurrentStatus { get; private set; }

        private List<Status> Equipments = new List<Status>();

        public Player(string name, Race race)
        {
            Name = name;
            Race = race;
            BaseStatus = RaceStatusFactory.GetStatusByRace(race);
            CurrentStatus = BaseStatus;
        }

        public void LevelUp()
        {
            Level++;

            BaseStatus.HP += 5;
            BaseStatus.MinAttack += 2;
            BaseStatus.MaxAttack += 2;

            RecalculateCurrentStatus();
        }

        public void EquipItem(Status equip)
        {
            Equipments.Add(equip);
            RecalculateCurrentStatus();
        }

        public void UnequipItem(Status equip)
        {
            Equipments.Remove(equip);
            RecalculateCurrentStatus();
        }

        private void RecalculateCurrentStatus()
        {
            Status totalEquip = new Status(0, 0, 0, 0, 0, 0, 0);
            foreach (var equip in Equipments)
            {
                totalEquip = totalEquip.Add(equip);
            }
            CurrentStatus = BaseStatus.Add(totalEquip);
        }

        public void ShowInfo()
        {
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"종족: {Race}");
            Console.WriteLine($"레벨: {Level}");
            Console.WriteLine($"기본 스탯: {BaseStatus}");
            Console.WriteLine($"장비 개수: {Equipments.Count}");
            Console.WriteLine($"현재 스탯: {CurrentStatus}");
            Console.WriteLine("");
        }
    }
}
