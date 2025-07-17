using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Object.Data
{
    public class EncounterData
    {
        public string Name { get; set; }
        public string Description { get; set; } // 상황 설명 ex) 누가 도움을 요청한다, 약초 3개를 가져갔다.
        public string Comment { get; set; } // 인물 코멘트 ex) 나를 도와줄 수 있겠나?
        public string Image { get; set; }

        public List<EncounterSelection> Selections { get; set; } // 선택지들

        public void Select(Player player, int selectionIndex)
        {
            if (selectionIndex < 0 || selectionIndex >= Selections.Count)
                return;

            EncounterSelection selection = Selections[selectionIndex];
            selection.Select(player);
        }
    }

    public class EncounterResult
    {
        public string MenuText { get; set; } // 결과 메뉴 텍스트
        public string Description { get; set; } // 결과 설명
        public string Comment { get; set; } // 결과 코멘트
        public string Image { get; set; } // 결과 이미지
        public Action<Player> Action { get; set; } // 결과 액션
    }

    public class EncounterSelection
    {
        public EncounterData Data { get; set; }

        private bool isAvoid = false; // 회피 여부
        private bool isMitigated = false; // 강인함에 의한 완화 여부

        public int AvoidChanceModifier { get; set; } = 5;
        public int MitigatedChanceModifier { get; set; } = 5; // 강인함에 의한 완화 확률 조정

        public string MenuText = ""; // 기본 메뉴 텍스트

        public EncounterResult Result
        {
            get
            {
                return isAvoid ? GoodReulst : isMitigated ? MitigatedResult : BadResult;
            }
        }

        public EncounterResult GoodReulst = new EncounterResult(); // 좋은 선택지 결과
        public EncounterResult MitigatedResult = new EncounterResult(); // 완화된 선택지 결과 (강인함에 의해서 약화된 결말)
        public EncounterResult BadResult = new EncounterResult(); // 나쁜 선택지 결과

        public void Select(Player player)
        {
            int luck = player.currentStatus.Luck;
            isAvoid = TryAvoidTrap(luck);

            if (isAvoid)
            {
                GoodReulst.Image = !string.IsNullOrWhiteSpace(GoodReulst.Image) ? GoodReulst.Image : Data.Image;
            }
            else
            {
                if (MitigatedResult == null)
                    isMitigated = false;
                else
                    isMitigated = TryMitigatedTrap(player.currentStatus.Agility);

                if (isMitigated)
                {
                    MitigatedResult.Image = !string.IsNullOrWhiteSpace(MitigatedResult.Image) ? MitigatedResult.Image : Data.Image;
                }
                else
                {
                    BadResult.Image = !string.IsNullOrWhiteSpace(BadResult.Image) ? BadResult.Image : Data.Image;
                }
            }
        }

        bool TryAvoidTrap(int luck)
        {
            // 회피 확률 계산 (luck%)
            Random rand = new Random();
            int avoidChance = luck + AvoidChanceModifier;
            int roll = rand.Next(0, 101); // 0부터 100 사이의 랜덤 숫자 생성

            return roll < avoidChance;
        }
        bool TryMitigatedTrap(int agility)
        {
            // 회피 확률 계산 (luck%)
            Random rand = new Random();
            int avoidChance = agility + MitigatedChanceModifier;
            int roll = rand.Next(0, 101); // 0부터 100 사이의 랜덤 숫자 생성

            return roll < avoidChance;
        }
    }

}
