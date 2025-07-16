using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Data;
using TeamRPG.Game.Object.Item;

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

            var encounter = new EncounterData();
            encounter.Name = "버려진 폐가";
            encounter.Description = "버려진 폐가가 보인다. 필요한 물품을 얻을 수 도 있겠지만\n묘한 기척이 느껴진다.";
            encounter.ImageName = "폐가"; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "들어간다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Description = """
                                폐가엔 떠돌이 고양이가 있었다. 이녀석의 기척이었던 모양이다.
                                누군가가 남기고 간 물건을 흭득했다. [포션 +1 약초 +1]
                                """,
                                MenuText = "돌아간다",
                                ImageName = "폐가",
                                Action = (player) =>
                                {

                                }
                        },
                        // 완화
                        MitigatedResult = new EncounterResult
                        {
                                Description = """
                                버려진 집은 고블린들의 소굴이였다.
                                모두 잡으러가자..
                                """,
                                MenuText = "공격한다",
                                ImageName = "폐가",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },

                        // 실패
                        BadResult = new EncounterResult
                        {

                                Description = """
                                버려진 집은 고블린들의 소굴이였다.
                                놈들이 덤벼온다.
                                """,
                                MenuText = "전투진입",
                                ImageName = "폐가",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "들어가지 않는다",
                        GoodReulst = new EncounterResult
                        {
                                Description = "모험을 할 필요는 없다.",
                                MenuText = "지나친다",
                                ImageName = "폐가", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        MitigatedResult = new EncounterResult
                        {
                                Description = "무엇이 있었는지는 알 수 없다.",
                                MenuText = "무시한다",
                                ImageName = "폐가", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Description = "누군가의 시선을 애써 무시한다.",
                                MenuText = "도망친다",
                                ImageName = "폐가", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

            encounters.Add(encounter.Name, encounter);

            // ------------------------------------------------------------------------------------------------------

            encounter = new EncounterData();
            encounter.Name = "약초 스승";
            encounter.Comment = """
                약초가 필요한데..
                혹시 약초를 건네주지 않겠나?

                약초를 준다면 내 검술을 전수해주지.
                """;
            encounter.ImageName = "약초 스승"; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "약초를 준다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Description = "약초를 받고 당신에게 비기를 전수해준다. [공격력 +8 약초 -1]",
                                Comment = "내 모든 것을 전수해주마",
                                MenuText = "돌아간다",
                                ImageName = "약초 스승",
                                Action = (player) =>
                                {
                                    player.currentStatus.MinAttack += 5;
                                    player.currentStatus.MaxAttack += 5;
                                    
                                    Item hurb = ItemManager.GetInstance().GetItem("향긋한 허브");
                                    if(player.Inventory.Contains(hurb))
                                        player.Inventory.Remove(hurb);

                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 완화
                        MitigatedResult = new EncounterResult
                        {
                                Description = "약초를 받고 당신에게 검술을 전수해준다. [공격력 +5 약초 -1]",
                                Comment = "좋아 약속대로 검술을 전수해주지",
                                MenuText = "돌아간다",
                                ImageName = "약초 스승",
                                Action = (player) =>
                                {
                                    player.currentStatus.MinAttack += 5;
                                    player.currentStatus.MaxAttack += 5;

                                    Item hurb = ItemManager.GetInstance().GetItem("향긋한 허브");
                                    if(player.Inventory.Contains(hurb))
                                        player.Inventory.Remove(hurb);

                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 실패
                        BadResult = new EncounterResult
                        {
                                Description = "약초를 받고 당신에게 검술을 말해준다. [공격력 +1 약초 -1]",
                                Comment = "기초만 알려주지",
                                MenuText = "돌아간다",
                                ImageName = "약초 스승",
                                Action = (player) =>
                                {
                                    player.currentStatus.MinAttack -= 1;
                                    player.currentStatus.MaxAttack -= 1;

                                    Item hurb = ItemManager.GetInstance().GetItem("향긋한 허브");
                                    if(player.Inventory.Contains(hurb))
                                        player.Inventory.Remove(hurb);

                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "주지 않는다",
                        GoodReulst = new EncounterResult
                        {
                                Description = """
                                그래 이해한다. 약초는 귀중한 물건이지
                                """,
                                MenuText = "돌아간다",
                                ImageName = "약초 스승", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        MitigatedResult = new EncounterResult
                        {
                                Comment = """
                                약초 하나를 못준다니 
                                슬프군.
                                """,
                                MenuText = "돌아간다",
                                ImageName = "약초 스승", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Comment = """
                                주기 싫다면 직접 빼앗아주마
                                """,
                                Description = "남자가 당신에게 덤벼든다.",
                                MenuText = "돌아간다",
                                ImageName = "약초 스승", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

            encounters.Add(encounter.Name, encounter);

            // ------------------------------------------------------------------------------------------------------

            encounter = new EncounterData();
            encounter.Name = "수상한 남자";
            encounter.Description = "수상해 보이는 남자가 도움을 요청한다.";
            encounter.Comment = """
                이봐 거기, 날 도와줄 수 있겠나?

                부상을 입어 움직일 수가 없군
                """;
            encounter.ImageName = "수상한 남자"; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "다가간다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Comment = "고맙군, 이거라도 받아가게",
                                Description = "수상한 남자가 약초를 3개 건넸다.",
                                MenuText = "다음 지역으로",
                                ImageName = "수상한 남자",
                                Action = (player) =>
                                {
                                    Item hurb = ItemManager.GetInstance().GetItem("향긋한 허브");
                                    for(int i = 0; i < 3; i++)
                                        player.Inventory.Add(hurb);

                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 완화
                        MitigatedResult = new EncounterResult
                        {
                                Comment = """
                                아니, 생각이 바꼈어.
                                나 혼자 쉬도록하지.
                                """,
                                Description = "남자는 당신을 보내줬다.",
                                MenuText = "다음 지역으로",
                                ImageName = "수상한 남자",
                                Action = (player) =>
                                {
                                    Item hurb = ItemManager.GetInstance().GetItem("향긋한 허브");
                                    player.Inventory.Add(hurb);

                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 실패
                        BadResult = new EncounterResult
                        {
                                Comment = """
                                요즘같은 시대에
                                선행은 멍청한 짓이지
                                """,
                                Description = "남자는 산적이였다. 남자가 덤벼들어온다.",
                                MenuText = "전투개시",
                                ImageName = "수상한 남자",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "지나친다",
                        GoodReulst = new EncounterResult
                        {
                                Comment = """
                                그래 선행은 어리석은 짓이지.
                                """,
                                MenuText = "돌아간다",
                                ImageName = "수상한 남자", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        MitigatedResult = new EncounterResult
                        {
                                Comment = """
                                본 척도 안하는군.
                                """,
                                MenuText = "돌아간다",
                                ImageName = "수상한 남자",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Comment = """
                                매정한 녀석...
                                """,
                                MenuText = "돌아간다",
                                ImageName = "수상한 남자", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

            encounters.Add(encounter.Name, encounter);

            // ------------------------------------------------------------------------------------------------------

            encounter = new EncounterData();
            encounter.Name = "버섯";
            encounter.Comment = """
                맛있어보이는 버섯이다.
                혹시 독이 있을까?
                """;
            encounter.ImageName = "버섯"; // 이미지 경로 또는 이미지 데이터
            encounter.Selections = new List<EncounterSelection>
                {
                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "먹는다",
                        // 성공
                        GoodReulst = new EncounterResult
                        {
                                Description = "맛있다. 독은 없는 것 같다. [생명력 +10]",
                                MenuText = "다음 지역으로",
                                ImageName = "버섯",
                                Action = (player) =>
                                {
                                    PlayerManager.GetInstance().GetPlayer().currentStatus.HP += 10;
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 완화
                        MitigatedResult = new EncounterResult
                        {
                                Description = "아프지만 버틸만하다. [생명력 -15]",
                                MenuText = "다음 지역으로",
                                ImageName = "버섯",
                                Action = (player) =>
                                {
                                    PlayerManager.GetInstance().GetPlayer().currentStatus.HP -= 15;
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        // 실패
                        BadResult = new EncounterResult
                        {
                                Description = "속이 아프다... 괜히 먹은 것 같다. [생명력 -15 랜덤 디버프]",
                                MenuText = "다음 지역으로",
                                ImageName = "버섯",
                                Action = (player) =>
                                {
                                    PlayerManager.GetInstance().GetPlayer().currentStatus.HP -= 15;
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        },

                        new EncounterSelection
                        {
                            Data = encounter,
                        MenuText = "먹지 않는다",
                        GoodReulst = new EncounterResult
                        {
                                Description = "자세히보니 독버섯이였다.",
                                MenuText = "다음 지역으로",
                                ImageName = "버섯", // 성공 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        MitigatedResult = new EncounterResult
                        {
                                Description = "저거말고도 먹을 것은 많다.",
                                MenuText = "다음 지역으로",
                                ImageName = "버섯",
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        },
                        BadResult = new EncounterResult
                        {
                                Description = "저건 분명 독버섯일거야...",
                                MenuText = "다음 지역으로",
                                ImageName = "버섯", // 실패 이미지 경로 또는 데이터
                                Action = (player) =>
                                {
                                    SceneManager.GetInstance().ChangeScene("ShopScene");
                                }
                        }
                        }
                };

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
    }
}
