using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG.Game.Object.Data
{
    public class QuestData
    {
        public string QuestName { get; set; } // 퀘스트 이름
        public string Description { get; set; } // 퀘스트 설명
        public int MinRewardGold { get; set; } // 최소 보상 금액
        public int MaxRewardGold { get; set; } // 최대 보상 금액
        public int MinRewardExp { get; set; } // 최소 보상 경험치
        public int MaxRewardExp { get; set; } // 최대 보상 경험치


        // 퀘스트 수락
        public void AcceptQuest()
        {
            Console.WriteLine($"퀘스트 '{QuestName}'을(를) 수락했습니다.");
            Console.WriteLine($"설명: {Description}");
        }

        public void GetReward(out int gold, out int exp)
        {
            Random random = new Random();
            gold = random.Next(MinRewardGold, MaxRewardGold + 1);
            exp = random.Next(MinRewardExp, MaxRewardExp + 1);
        }

    }
}
