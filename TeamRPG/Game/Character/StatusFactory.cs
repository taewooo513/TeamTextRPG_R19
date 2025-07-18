using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Game.Object.Enemy;

namespace TeamRPG.Game.Character
{
    public static class StatusFactory
    {
        public static Status GetStatusByRace(Race race) // (int hp, int mp, int minAtk, int maxAtk, int agi, int tena, int luck, int currentHP, int currentMP)
        {
            switch (race)
            {
                case Race.Human:
                    return new Status(70, 50, 12, 16, 30, 50, 10, 70, 50);
                case Race.Dwarf:
                    return new Status(80, 40, 14, 15, 10, 70, 10, 80, 40);
                case Race.HalfElf:
                    return new Status(65, 70, 8, 18, 50, 30, 10, 65, 70);
                default:
                    throw new System.ArgumentException("Unknown race");
            }
        }
        public static Enemy.State GetStatusByEnemy(eEnemyNum enemyNum) // (int _hp, string _name, int _dmg, int _def, int _mgDef, int _dex, int _exDmg)
        {
            Random rd = new Random();
            switch (enemyNum)
            {
                //case eEnemyNum.eWolf:
                //    return new Enemy.State();
                case eEnemyNum.eGoblin:
                    int Goblinhp = rd.Next(15, 20);
                    return new Enemy.State(Goblinhp, "고블린", rd.Next(5, 7), 0, 0, 50, 10, h);

                case eEnemyNum.eWildBoar:
                    int WildBoarhp = rd.Next(15, 20);
                    return new Enemy.State(WildBoarhp, "고블린", rd.Next(5, 7), 0, 0, 50, 10, h);

                case eEnemyNum.eSlime:
                    int Slimehp = rd.Next(15, 20);
                    return new Enemy.State(Slimehp, "고블린", rd.Next(5, 7), 0, 0, 50, 10, h);

                case eEnemyNum.eBoss:
                    int Bosshp = rd.Next(150, 151);
                    return new Enemy.State(Bosshp, "???", rd.Next(35, 45), 80, 80, 80, 100, bosshp);

                case eEnemyNum.eGolem:
                    int golemhp = rd.Next(1, 50);
                    return new Enemy.State(golemhp, "골렘", rd.Next(1, 30), 25, 25, 0, rd.Next(0, 50), golemhp);

                case eEnemyNum.eMimic:
                    int mimichp = 50;
                    return new Enemy.State(mimichp, "미믹", 35, 20, 20, 0, 55, mimichp);

                case eEnemyNum.eSlime:
                    int slimehp = rd.Next(15, 25);
                    return new Enemy.State(slimehp, "슬라임", rd.Next(5, 20), 90, 0, 0, 25, slimehp);

                default:
                    throw new System.ArgumentException("Unknown race");
            }
        }


        public static Status Clone(Status source)
        {
            if (source == null)
                return null;

            return new Status(
                    source.HP,
                    source.MP,
                    source.MinAttack,
                    source.MaxAttack,
                    source.Agility,
                    source.Tenacity,
                    source.Luck,
                    source.currentHp,
                    source.currentMp
            );
        }
        public static Status EmptyStatus
        {
            get
            {
                return new Status(0, 0, 0, 0, 0, 0, 0, 0, 0);
            }
        }

        public static List<Skill> GetSkillsByRace(Race race) // (string _name, string _description, int _mpCost, int _power = 0, int _heal = 0)
        {
            switch (race)
            {
                case Race.Human:
                    return new List<Skill>
                    {
                        new Skill("파워 스트라이크", "검에 화검에 화염을 감아 강력한 내려베기를 시전한다.", 15, 25),
                        new Skill("배쉬 블로우", "마력을 모아 강력한 올려베기를 시전한다", 25, 35),
                        new Skill("레이징 어택", "분노의 힘을 해방해 잠재력을 끌어올려 공격한다", 35, 50)
                    };
                case Race.Dwarf:
                    return new List<Skill>
                    {
                        new Skill("발구르기", "대지의 힘을 담아 지면을 향해 발을 구른다", 10, 15),
                        new Skill("지진", "땅의 힘으로 지진을 일으킨다", 30, 40),
                        new Skill($"화신강림", "산맥의 영혼을 받아들여 강신 상태가 된다", 100, 0, 80) // 공격강화, 최대 체력 회복 아직 구현 못했고 드워프 최대 체력으로 수치 저장
                    };
                case Race.HalfElf:
                    return new List<Skill>
                    {
                        new Skill("힐링", "상처를 회복한다", 30, 0, 15),
                        new Skill("윈드스톰", "바람의 힘으로 빠른 사격을 가한다", 25, 40),
                        new Skill("애로우 레인", "마력을 담은 화살의 비를 내린다", 45, 60)
                    };
                default:
                    throw new ArgumentException("Unknown race");
            }
        }
    }
}
