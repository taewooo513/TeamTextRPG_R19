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
                case eEnemyNum.eWolf:
                    int Wolfhp = rd.Next(32, 37);
                    return new Enemy.State(Wolfhp, "울프", rd.Next(5, 11), 0, 0, 30, 25, Wolfhp);
                case eEnemyNum.eWildBoar:
                    int WildBoarhp = rd.Next(38, 43);
                    return new Enemy.State(WildBoarhp, "와일드보어", rd.Next(14, 19), 0, 0, 20, 30, WildBoarhp);
                case eEnemyNum.eCentaur:
                    int Centaurhp = rd.Next(110, 110);
                    return new Enemy.State(Centaurhp, "켄타우로스", rd.Next(25, 39), 0, 0, 70, 55, Centaurhp);
                //환경 묘지
                case eEnemyNum.eSkeleton:  // 3마리씩 등장
                    int Skeletonhp = rd.Next(15, 23);
                    return new Enemy.State(Skeletonhp, "스켈레톤", rd.Next(5, 10), 0, 0, 0, 15, Skeletonhp);
                case eEnemyNum.eZombie:
                    int Zombiehp = rd.Next(50, 50);
                    return new Enemy.State(Zombiehp, "좀비", rd.Next(14, 23), 0, 0, 0, 35, Zombiehp);
                case eEnemyNum.eLich:    // 얘 부활하게 코드필요해용
                    int Lichhp = rd.Next(45, 45);
                    return new Enemy.State(Lichhp, "리치", rd.Next(5, 5), 0, 0, 10, 50, Lichhp);
                case eEnemyNum.eLich2:    // 리치 2페이즈
                    int Lich2hp = rd.Next(65, 65);
                    return new Enemy.State(Lich2hp, "리치", rd.Next(5, 5), 0, 0, 100, 100, Lich2hp);
                //환경 황야
                case eEnemyNum.eGoblin:
                    int Goblinhp = rd.Next(15, 23);
                    return new Enemy.State(Goblinhp, "고블린", rd.Next(5, 10), 0, 0, 50, 10, Goblinhp);

                case eEnemyNum.eOgre:
                    int Ogrehp = rd.Next(45, 61);
                    return new Enemy.State(Ogrehp, "오우거", rd.Next(18, 26), 0, 0, 30, 40, Ogrehp);

                case eEnemyNum.eTroll:
                    int Trollhp = rd.Next(150, 150); // 1턴당 체력 3 회복 기믹 넣어주세요 (트롤의 체력)
                    return new Enemy.State(Trollhp, "트롤", rd.Next(1, 41), 0, 0, 0, 50, Trollhp);
                //환경 마계
                case eEnemyNum.eImp:
                    int Imphp = rd.Next(20, 29);
                    return new Enemy.State(Imphp, "임프", rd.Next(4, 13), 0, 0, 20, 18, Imphp);
                case eEnemyNum.eSuccubus:
                    int Succubushp = rd.Next(44, 51); // 패링 실패시 서큐버스 체력 회복 가능 한가요?
                    return new Enemy.State(Succubushp, "서큐버스", rd.Next(18, 25), 0, 0, 50, 25, Succubushp);

                case eEnemyNum.eArchdemon:
                    int Archdemonhp = rd.Next(120, 120);
                    return new Enemy.State(Archdemonhp, "데몬", rd.Next(28, 35), 0, 0, 50, 65, Archdemonhp);
                //마법생물
                case eEnemyNum.eGolem:
                    int golemhp = rd.Next(35, 75);
                    return new Enemy.State(golemhp, "골렘", rd.Next(1, 30), 25, 25, 0, rd.Next(0, 50), golemhp);

                case eEnemyNum.eMimic:
                    int mimichp = 50;
                    return new Enemy.State(mimichp, "미믹", 35, 20, 20, 0, 55, mimichp);

                case eEnemyNum.eSlime:
                    int slimehp = rd.Next(15, 25);
                    return new Enemy.State(slimehp, "슬라임", rd.Next(5, 20), 90, 0, 0, 25, slimehp);
                case eEnemyNum.eBoss:
                    int Bosshp = rd.Next(350, 350);
                    return new Enemy.State(Bosshp, "???", rd.Next(35, 55), 0, 0, 80, 100, Bosshp);

                //랜덤인카운터
                case eEnemyNum.eBandit:
                    int Bandithp = rd.Next(40, 60);
                    return new Enemy.State(Bandithp, "산적", rd.Next(28, 39), 0, 0, 70, 45, Bandithp);
                case eEnemyNum.eSwordsman:
                    int Swordsmanhp = rd.Next(50, 70);
                    return new Enemy.State(Swordsmanhp, "검사", rd.Next(20, 30), 0, 10, 60, 50, Swordsmanhp);
                case eEnemyNum.eGhost:
                    int Ghosthp = rd.Next(30, 30);
                    return new Enemy.State(Ghosthp, "유령", rd.Next(10, 15), 0, 40, 20, 30, Ghosthp);

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
