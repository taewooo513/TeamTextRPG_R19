using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Object.Data;
using TeamRPG.Game.Object.Enemy;
using TeamRPG.Core.EncounterManager;
using TeamRPG.Core.EnemyManager;

namespace TeamRPG.Core.QuestManager
{
    internal class QuestManager : Singleton<QuestManager>
    {
        private Dictionary<string, QuestData> quests = new();

        public bool IsQuestting
        {
            get
            {
                if (CurrentQuest == null)
                    return false;

                return !CurrentQuest.IsCompleted;
            }
        }

        public List<QuestData> Quests 
        {
            get { return quests.Values.ToList(); }
        }


        public QuestData CurrentQuest { get; set; }

        public void Init()
        {
            quests = new();

            QuestData quest;

            // e = new Slime(UIManager.HalfWidth, 5, "Slime");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eSlime);

            // e = new Mimic(UIManager.HalfWidth, 5, "Mimic");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eMimic);

            // e = new Golem(UIManager.HalfWidth, 5, "Golem");
            // EnemyManager.GetInstance().AddEnemy(e, eEnemyNum.eGolem);

            // 슬라임
            quest = new QuestData();
            quest.QuestName = "슬라임 퇴치";
            quest.QuestEnemy = new Slime(UIManager.HalfWidth, 5, "Slime");
            quest.eEnemyNum = eEnemyNum.eSlime;
            quest.Description = """
                슬라임들이 내 화단을 망치고 있어
                잡아주면 고맙겠어.
                """;
            quest.MinRewardGold = 150;
            quest.MaxRewardGold = 150;

            AddQuest(quest.QuestName, quest);

            // 미믹
            quest = new QuestData();
            quest.QuestName = "미믹 퇴치";
            quest.QuestEnemy = new Mimic(UIManager.HalfWidth, 5, "Mimic");
            quest.eEnemyNum = eEnemyNum.eMimic;
            quest.Description = """
                        내 보물 상자를 훔쳐간 미믹을 잡아줘.
                        보상은 충분히 줄게.
                        """;
            quest.MinRewardGold = 250;
            quest.MaxRewardGold = 250;

            AddQuest(quest.QuestName, quest);

            // 골렘
            quest = new QuestData();
            quest.QuestName = "골렘 퇴치";
            quest.QuestEnemy = new Golem(UIManager.HalfWidth, 5, "Golem");
            quest.eEnemyNum = eEnemyNum.eGolem;
            quest.Description = """
                                근처에서 길을 막고 있는 골렘을 처치해줘. 
                                그러면 골렘의 핵을 팔아서 돈을 나눠줄게
                                """;
            quest.MinRewardGold = 10;
            quest.MaxRewardGold = 300;

            AddQuest(quest.QuestName, quest);
        }

        public void AddQuest(string key, QuestData quest)
        {
            if (!quests.ContainsKey(key))
                quests.Add(key, quest);
        }

        public QuestData? GetQuest(string key)
        {
            quests.TryGetValue(key, out QuestData? quest);
            return quest;
        }
    }
}
