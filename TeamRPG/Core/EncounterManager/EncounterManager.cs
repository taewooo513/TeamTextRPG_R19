using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Data;
using TeamRPG.Game.Object.Item;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Core.EncounterManager
{
    using SceneManager = SceneManager.SceneManager;
    using ItemManager = ItemManager.ItemManager;

    public class EncounterManager : Singleton<EncounterManager>
    {
        private Dictionary<string, EncounterData> encounters = new();

        public void Init()
        {
            // 초기화 로직
            encounters.Clear();

            EncounterResult goodResult, mitigatedResult, badResult;
            EncounterSelection selection;
            // 버려진 폐가
            var encounter = new EncounterData();
            encounter.Selections = new List<EncounterSelection>();
            encounter.Name = "버려진 폐가";
            encounter.Description = "버려진 폐가가 보인다. 필요한 물품을 얻을 수 도 있겠지만\n묘한 기척이 느껴진다.";
            encounter.ImageName = "폐가"; // 이미지 경로 또는 이미지 데이터

            // 버려진 폐가 선택지 1
            selection = new();
            selection.MenuText = "들어간다";

            goodResult = new EncounterResult();
            goodResult.Description = """
                        폐가엔 떠돌이 고양이가 있었다. 이녀석의 기척이었던 모양이다.
                        누군가가 남기고 간 물건을 흭득했다. [포션 +1 약초 +1]
                        """;
            goodResult.MenuText = "돌아간다";
            goodResult.ImageName = "폐가"; // 성공 이미지 경로 또는 데이터
            goodResult.OnExit = (player) =>
            {
                player.Inventory.AddItem("회복 포션", 1);
                player.Inventory.AddItem("향긋한 허브", 1);
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            mitigatedResult = new EncounterResult();
            mitigatedResult.Description = """
                                버려진 집은 고블린들의 소굴이였다.
                                모두 잡으러가자..
                                """;
            mitigatedResult.MenuText = "공격한다";
            mitigatedResult.ImageName = "폐가"; // 완화 이미지 경로 또는 데이터
            mitigatedResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            badResult = new EncounterResult();
            badResult.Description = """
                                        버려진 집은 고블린들의 소굴이였다.
                                        놈들이 덤벼온다.
                                        """;
            badResult.MenuText = "전투진입";
            badResult.ImageName = "폐가"; // 실패 이미지 경로 또는 데이터
            badResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            selection.GoodReulst = goodResult;
            selection.MitigatedResult = mitigatedResult;
            selection.BadResult = badResult;
            encounter.Selections.Add(selection);

            // 버려진 폐가 선택지 2
            selection = new EncounterSelection();
            selection.MenuText = "들어가지 않는다";

            goodResult = new EncounterResult();
            goodResult.Description = "모험을 할 필요는 없다.";
            goodResult.MenuText = "지나친다";
            goodResult.ImageName = "폐가"; // 성공 이미지 경로 또는 데이터
            goodResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            mitigatedResult = new EncounterResult();
            mitigatedResult.Description = "무엇이 있었는지는 알 수 없다.";
            mitigatedResult.MenuText = "무시한다";
            mitigatedResult.ImageName = "폐가"; // 완화 이미지 경로 또는 데이터
            mitigatedResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            badResult = new EncounterResult();
            badResult.Description = "누군가의 시선을 애써 무시한다.";
            badResult.MenuText = "도망친다";
            badResult.ImageName = "폐가"; // 실패 이미지 경로 또는 데이터
            badResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            selection.GoodReulst = goodResult;
            selection.MitigatedResult = mitigatedResult;
            selection.BadResult = badResult;
            encounter.Selections.Add(selection);

            encounters.Add(encounter.Name, encounter);

            // 약초 스승
            encounter = new EncounterData();
            encounter.Selections = new List<EncounterSelection>();
            encounter.Name = "약초 스승";
            encounter.Comment = """
                약초가 필요한데..
                혹시 약초를 건네주지 않겠나?

                약초를 준다면 내 검술을 전수해주지.
                """;
            encounter.ImageName = "약초 스승"; // 이미지 경로 또는 이미지 데이터

            // 약초 스승 선택지 1
            selection = new EncounterSelection();
            selection.MenuText = "약초를 준다";

            goodResult = new EncounterResult();
            goodResult.Description = "약초를 받고 당신에게 비기를 전수해준다. [공격력 +8 약초 -1]";
            goodResult.Comment = "내 모든 것을 전수해주마";
            goodResult.MenuText = "돌아간다";
            goodResult.ImageName = "약초 스승"; // 성공 이미지 경로 또는 데이터
            goodResult.OnExit = (player) =>
            {
                player.PlusAttack(8);
                player.Inventory.RemoveItem("향긋한 허브");
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            mitigatedResult = new EncounterResult();
            mitigatedResult.Description = "약초를 받고 당신에게 검술을 전수해준다. [공격력 +5 약초 -1]";
            mitigatedResult.Comment = "좋아 약속대로 검술을 전수해주지";
            mitigatedResult.MenuText = "돌아간다";
            mitigatedResult.ImageName = "약초 스승"; // 완화 이미지 경로 또는 데이터
            mitigatedResult.OnExit = (player) =>
            {
                player.PlusAttack(5);
                player.Inventory.RemoveItem("향긋한 허브");
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            badResult = new EncounterResult();
            badResult.Description = "약초를 받고 당신에게 검술을 말해준다. [공격력 +1 약초 -1]";
            badResult.Comment = "기초만 알려주지";
            badResult.MenuText = "돌아간다";
            badResult.ImageName = "약초 스승"; // 실패 이미지 경로 또는 데이터
            badResult.OnExit = (player) =>
            {
                player.PlusAttack(1);
                player.Inventory.RemoveItem("향긋한 허브");
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            selection.GoodReulst = goodResult;
            selection.MitigatedResult = mitigatedResult;
            selection.BadResult = badResult;

            encounter.Selections.Add(selection);

            // 약초 스승 선택지 2

            selection = new();
            selection.MenuText = "주지 않는다";

            goodResult = new();
            goodResult.MenuText = "돌아간다";
            goodResult.Comment = "그래 이해한다. 약초는 귀중한 물건이지";
            goodResult.ImageName = "약초 스승"; // 성공 이미지 경로 또는 데이터
            goodResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            mitigatedResult = new();
            mitigatedResult.MenuText = "돌아간다";
            mitigatedResult.Description = "약초를 주지 않는다면 검술을 전수해주지 않겠다.";
            mitigatedResult.ImageName = "약초 스승"; // 완화 이미지 경로 또는 데이터
            mitigatedResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            badResult = new();
            badResult.MenuText = "돌아간다";
            badResult.Description = "남자가 당신에게 덤벼든다.";
            badResult.Comment = "주기 싫다면 직접 빼앗아주마";
            badResult.ImageName = "약초 스승"; // 실패 이미지 경로 또는 데이터
            badResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            selection.GoodReulst = goodResult;
            selection.MitigatedResult = mitigatedResult;
            selection.BadResult = badResult;
            encounter.Selections.Add(selection);

            encounters.Add(encounter.Name, encounter);

            // 수상한 남자

            encounter = new EncounterData();
            encounter.Selections = new List<EncounterSelection>();
            encounter.Name = "수상한 남자";
            encounter.Description = "수상해 보이는 남자가 도움을 요청한다.";
            encounter.Comment = """
                이봐 거기, 날 도와줄 수 있겠나?

                부상을 입어 움직일 수가 없군
                """;
            encounter.ImageName = "수상한 남자"; // 이미지 경로 또는 이미지 데이터

            // 수상한 남자 선택지 1

            selection = new();
            selection.MenuText = "다가간다"; // 선택지 메뉴 텍스트

            goodResult = new();
            goodResult.MenuText = "다음 지역으로"; // 성공 결과 메뉴 텍스트
            goodResult.Comment = "고맙군, 이거라도 받아가게"; // 성공 결과 코멘트
            goodResult.Description = "수상한 남자가 약초를 3개 건넸다. [약초 +3]"; // 성공 결과 설명
            goodResult.ImageName = "수상한 남자"; // 성공 이미지 경로 또는 데이터
            goodResult.OnExit = (player) =>
            {
                player.Inventory.AddItem("향긋한 허브", 3); // 플레이어에게 약초 3개 추가
                SceneManager.GetInstance().ChangeScene("ShopScene"); // 상점 장면으로 이동
            };

            mitigatedResult = new();
            mitigatedResult.MenuText = "다음 지역으로"; // 완화 결과 메뉴 텍스트
            mitigatedResult.Comment = """
                                아니, 생각이 바꼈어.
                                나 혼자 쉬도록하지.
                                """; // 완화 결과 코멘트
            mitigatedResult.Description = "남자는 당신을 보내줬다."; // 완화 결과 설명 함수
            mitigatedResult.ImageName = "수상한 남자"; // 완화 이미지 경로 또는 데이터
            mitigatedResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene"); // 상점 장면으로 이동
            };

            badResult = new();
            badResult.MenuText = "전투개시"; // 실패 결과 메뉴 텍스트
            badResult.Comment = """
                                        요즘같은 시대에
                                        선행은 멍청한 짓이지
                                        """; // 실패 결과 코멘트
            badResult.Description = "남자는 산적이였다. 남자가 덤벼들어온다."; // 실패 결과 설명 함수
            badResult.ImageName = "수상한 남자"; // 실패 이미지 경로 또는 데이터
            badResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene"); // 상점 장면으로 이동
            };

            selection.GoodReulst = goodResult; // 선택지에 성공 결과 설정
            selection.MitigatedResult = mitigatedResult; // 선택지에 완화 결과 설정
            selection.BadResult = badResult; // 선택지에 실패 결과 설정

            encounter.Selections.Add(selection); // 선택지를 encounter에 추가

            // 수상한 남자 선택지 2

            selection = new();
            selection.MenuText = "무시한다"; // 선택지 메뉴 텍스트
            goodResult = new();
            goodResult.MenuText = "무시한다"; // 성공 결과 메뉴 텍스트
            goodResult.Comment = "그래 선행은 어리석은 짓이지..."; // 성공 결과 코멘트
            goodResult.Description = "당신은 남자를 무시한다."; // 성공 결과 설명 함수
            goodResult.ImageName = "수상한 남자"; // 성공 이미지 경로 또는 데이터
            goodResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene"); // 상점 장면으로 이동
            };

            mitigatedResult = new();
            mitigatedResult.MenuText = "무시한다"; // 완화 결과 메뉴 텍스트
            mitigatedResult.Comment = "본 척도 안하는군."; // 완화 결과 코멘트
            mitigatedResult.Description = "당신은 남자를 무시한다."; // 완화 결과 설명 함수
            mitigatedResult.ImageName = "수상한 남자"; // 완화 이미지 경로 또는 데이터
            mitigatedResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene"); // 상점 장면으로 이동
            };

            badResult = new();
            badResult.MenuText = "무시한다"; // 실패 결과 메뉴 텍스트
            badResult.Comment = "매정한 녀석..."; // 실패 결과 코멘트
            badResult.Description = "남자는 당신을 노려본다."; // 실패 결과 설명 함수
            badResult.ImageName = "수상한 남자"; // 실패 이미지 경로 또는 데이터
            badResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene"); // 상점 장면으로 이동
            };

            selection.GoodReulst = goodResult; // 선택지에 성공 결과 설정
            selection.MitigatedResult = mitigatedResult; // 선택지에 완화 결과 설정
            selection.BadResult = badResult; // 선택지에 실패 결과 설정

            encounter.Selections.Add(selection); // 선택지를 encounter에 추가

            encounters.Add(encounter.Name, encounter);

            // 버섯 이벤트
            encounter = new EncounterData();
            encounter.Selections = new List<EncounterSelection>();
            encounter.Name = "버섯";
            encounter.Comment = """
                    맛있어보이는 버섯이다.
                    혹시 독이 있을까?
                    """;
            encounter.ImageName = "버섯";

            // 선택지 1: 먹는다
            selection = new();
            selection.MenuText = "먹는다";

            // 성공
            goodResult = new();
            goodResult.Description = "맛있다. 독은 없는 것 같다. [생명력 +10]";
            goodResult.MenuText = "다음 지역으로";
            goodResult.ImageName = "버섯";
            goodResult.OnExit = (player) =>
            {
                player.HealPlayer(10);
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            // 완화
            mitigatedResult = new();
            mitigatedResult.Description = "속이 쓰리다. 하지만 후유증은 없을 것 같다. [생명력 -15]";
            mitigatedResult.MenuText = "다음 지역으로";
            mitigatedResult.ImageName = "버섯";

            mitigatedResult.OnEnter = () =>
            {
                Player player = PlayerManager.GetInstance().GetPlayer();
                if (player.currentStatus.currentHp - 15 <= 0)
                    GetEncounterData("버섯").Selections[0].MitigatedResult.Description = "곧 죽을 것 같다. [생명력 -15]";
                else
                    GetEncounterData("버섯").Selections[0].MitigatedResult.Description = "속이 쓰리다. 하지만 후유증은 없을 것 같다. [생명력 -15]";
            };

            mitigatedResult.OnExit = (player) =>
            {
                player.HitPlayer(15);
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            // 실패
            badResult = new();
            badResult.Description = "속이 쓰리다. 괜히 먹은 것 같다. [생명력 -15, +랜덤 디버프]";
            badResult.MenuText = "다음 지역으로";
            badResult.ImageName = "버섯";

            badResult.OnEnter = () =>
            {
                Player player = PlayerManager.GetInstance().GetPlayer();
                Random random = new Random();
                int debuffType = random.Next(0, 3); // 0: 중독, 1: 마비, 2: 출혈
                string debuffText = "";

                switch (debuffType)
                {
                    case 0:
                        int poisonDamage = (int)(player.currentStatus.currentHp * 0.1);
                        player.HitPlayer(poisonDamage);
                        debuffText = "중독";
                        break;
                    case 1:
                        player.currentStatus.Agility = Math.Max(0, player.currentStatus.Agility - 10);
                        debuffText = "마비";
                        break;
                    case 2:
                        int bleedDamage = (int)(player.currentStatus.HP * 0.1);
                        player.HitPlayer(bleedDamage);
                        debuffText = "출혈";
                        break;
                }

                if (player.currentStatus.currentHp - 15 <= 0)
                    GetEncounterData("버섯").Selections[0].BadResult.Description = $"내가 버섯 때문에 죽다니. [생명력 -15, +{debuffText}]";
                else
                    GetEncounterData("버섯").Selections[0].BadResult.Description = $"독버섯이였다... [생명력 -15, +{debuffText}]";
            };

            badResult.OnExit = (player) =>
            {
                player.HitPlayer(15);
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            selection.GoodReulst = goodResult;
            selection.MitigatedResult = mitigatedResult;
            selection.BadResult = badResult;
            encounter.Selections.Add(selection);

            // 선택지 2: 먹지 않는다
            selection = new();
            selection.MenuText = "먹지 않는다";

            goodResult = new();
            goodResult.Description = "자세히보니 독버섯이였다.";
            goodResult.MenuText = "다음 지역으로";
            goodResult.ImageName = "버섯";
            goodResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            mitigatedResult = new();
            mitigatedResult.Description = "저거말고도 먹을 것은 많다.";
            mitigatedResult.MenuText = "다음 지역으로";
            mitigatedResult.ImageName = "버섯";
            mitigatedResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            badResult = new();
            badResult.Description = "저건 분명 독버섯일거야...";
            badResult.MenuText = "다음 지역으로";
            badResult.ImageName = "버섯";
            badResult.OnExit = (player) =>
            {
                SceneManager.GetInstance().ChangeScene("ShopScene");
            };

            selection.GoodReulst = goodResult;
            selection.MitigatedResult = mitigatedResult;
            selection.BadResult = badResult;
            encounter.Selections.Add(selection);

            // 추가
            encounters.Add(encounter.Name, encounter);

        }

        public EncounterData GetRandomEncounterData()
        {
            if (encounters == null || encounters.Count == 0) Init();

            Random rand = new Random();
            int index = rand.Next(encounters.Count);
            return encounters.ElementAt(index).Value;
        }

        public EncounterData GetEncounterData(string name)
        {
            if (encounters == null || encounters.Count == 0) Init();

            if (encounters.TryGetValue(name, out EncounterData encounter))
                return encounter;

            return null;
        }


        public static void ChangeDesc(RawText rawText, string text)
        {
            if (rawText != null)
            {
                rawText.SetText(text);
            }
        }
    }
}
