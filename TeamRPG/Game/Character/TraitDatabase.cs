using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Character
{
    public class TraitDatabase
    {
        public static List<Trait> commonTraits = new List<Trait>
        {
            new Trait("사형수의 면죄부", "아무 효과 없음"),
            new Trait("두둑한 주머니", "초기 소지금 500G 추가", player => player.Gold += 500),
            new Trait("은퇴한 노장", " 최소 공격력 5감소", player => player.baseStatus.MinAttack -= 5),
            new Trait("자연 친화력", "최대마나 20 증가", player =>
             {
                player.baseStatus.MP += 20;
                player.baseStatus.currentMp += 20;
             })
        };

        public static List<Trait> GetTraitsByRace(Race race)
        {
            switch (race)
            {
                case Race.Human:
                    return new List<Trait>
                    {
                        new Trait("초심자의 행운", "운 10 증가", player => player.baseStatus.Luck += 10),
                        new Trait("공격은 최선의 방어", "공격력 5증가 체력 10감소", player =>
                        {
                            player.baseStatus.MinAttack += 5;
                            player.baseStatus.MaxAttack += 5;
                            player.baseStatus.HP -= 10;
                        })
                    };
                case Race.Dwarf:
                    return new List<Trait>
                    {
                        new Trait("튼튼한 위장", "강인함 20 증가", player => player.baseStatus.Tenacity += 20),
                        new Trait("산맥의 수호자", "최대체력 30 증가", player =>
                        {
                            player.baseStatus.HP += 30;
                            player.baseStatus.currentHp += 30;
                        })
                    };
                case Race.HalfElf:
                    return new List<Trait>
                    {
                        new Trait("가벼운 몸놀림", "재빠름 10 증가", player => player.baseStatus.Agility += 10),
                        new Trait("눈먼 숲의 사냥꾼", "최소 공격력 7 감소 / 최대 공격력 12 증가", 
                        player => 
                        { 
                            player.baseStatus.MinAttack -= 7; 
                            player.baseStatus.MaxAttack += 12;
                        })
                    };
                default:
                    return new List<Trait>();
            }
        }
    }
}
