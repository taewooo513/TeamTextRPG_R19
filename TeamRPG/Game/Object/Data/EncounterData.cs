using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.ImageManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Object.Data
{
    public class EncounterData
    {
        public string Name { get; set; }
        public string Description { get; set; } // 상황 설명 ex) 누가 도움을 요청한다, 약초 3개를 가져갔다.
        public string Comment { get; set; } // 인물 코멘트 ex) 나를 도와줄 수 있겠나?

        private string image = "";
        public string Image
        {
            get
            {
                if (string.IsNullOrEmpty(image))
                    image = ImageManager.GetInstance().GetImage(ImageName);

                return image;
            }
        }
    
        public string ImageName { get; set; }

        public List<EncounterSelection> Selections { get; set; } // 선택지들
    }

    public class EncounterResult
    {
        public string MenuText { get; set; } // 결과 메뉴 텍스트
        public string Description { get; set; } // 결과 설명 ex) 약초를 가져갔다, 10의 피해를 입었다.
        public string Comment { get; set; } // 결과 코멘트 ex) 나 좀 도와주게나, 매정한 녀석

        private string image = "";
        public string Image
        {
            get
            {
                if (string.IsNullOrEmpty(image))
                    image = ImageManager.GetInstance().GetImage(ImageName);

                return image;
            }
        }

        public string ImageName { get; set; }

        public Action OnEnter { get; set; } = () => { }; // 결과 초기화 액션
        public Action<Player> OnExit { get; set; } // 결과 액션
    }

    public class EncounterSelection
    {
        public enum ResultType
        {
            Good, // 좋은 결과
            Mitigated, // 완화된 결과
            Bad // 나쁜 결과
        }

        public ResultType GetResultType()
        {
            return isAvoid ? ResultType.Good : isMitigated ? ResultType.Mitigated : ResultType.Bad;
        }

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

        public void ChangeDescription(string desc)
        {
            Result.Description = desc;
        }

        public void Select(Player player)
        {
            int luck = player.currentStatus.Luck;
            isAvoid = TryAvoidTrap(luck);

            if (!isAvoid)
            {
                if (MitigatedResult == null)
                    isMitigated = false;
                else
                    isMitigated = TryMitigatedTrap(player.currentStatus.Tenacity);
            }

            Result?.OnEnter?.Invoke();
        }

        bool TryAvoidTrap(int luck)
        {
            // 회피 확률 계산 (luck%)
            Random rand = new Random();
            int avoidChance = luck + AvoidChanceModifier;
            int roll = rand.Next(0, 101); // 0부터 100 사이의 랜덤 숫자 생성

            return roll < avoidChance;
        }
        bool TryMitigatedTrap(int tenacity)
        {
            // 회피 확률 계산 (luck%)
            Random rand = new Random();
            int avoidChance = tenacity + MitigatedChanceModifier;
            int roll = rand.Next(0, 101); // 0부터 100 사이의 랜덤 숫자 생성

            return roll < avoidChance;
        }
    }

}
