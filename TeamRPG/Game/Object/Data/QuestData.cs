using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.QuestManager;
using TeamRPG.Core.SceneManager;
using TeamRPG.Game.Scene;

namespace TeamRPG.Game.Object.Data
{
    using Enemy = Enemy.Enemy;
    public class QuestData
    {
        public string QuestName { get; set; } // 퀘스트 이름
        public Enemy QuestEnemy { get; set; } // 퀘스트 몬스터 이름
        public eEnemyNum eEnemyNum { get; set; } // 퀘스트 몬스터 번호
        public string Description { get; set; } // 퀘스트 설명
        public int MinRewardGold { get; set; } // 최소 보상 금액
        public int MaxRewardGold { get; set; } // 최대 보상 금액
        public int MinRewardExp { get; set; } // 최소 보상 경험치
        public int MaxRewardExp { get; set; } // 최대 보상 경험치
        public bool IsCompleted { get; set; } // 퀘스트 완료 여부

        public QuestData()
        {
            QuestName = "빈 퀘스트";
            QuestEnemy = null;
            Description = "";
            MinRewardGold = 0;
            MaxRewardGold = 0;
            MinRewardExp = 0;
            MaxRewardExp = 0;
            IsCompleted = false; // 기본값은 false
        }

        public QuestData(string questName, Enemy questEnemy, string description, int minRewardGold, int maxRewardGold, int minRewardExp, int maxRewardExp)
        {
            QuestName = questName;
            QuestEnemy = questEnemy;
            Description = description;
            MinRewardGold = minRewardGold;
            MaxRewardGold = maxRewardGold;
            MinRewardExp = minRewardExp;
            MaxRewardExp = maxRewardExp;
            IsCompleted = false; // 기본값은 false
        }

        // 퀘스트 수락
        public void AcceptQuest()
        {
            QuestManager.GetInstance().CurrentQuest = this;
            QuestManager.GetInstance().CurrentQuest.IsCompleted = false;
            SceneManager sceneManager = SceneManager.GetInstance();
            GameScene gameScene = sceneManager.GetScene("GameScene") as GameScene;
            if (gameScene == null) return;
            if (QuestEnemy == null) return;

            QuestEnemy.isDie = false;
            (Enemy, eEnemyNum) enemy = (QuestEnemy, eEnemyNum);

            EnemyManager.GetInstance().ClearInitialEnemies();
            EnemyManager.GetInstance().AddInitialEnemy(enemy);
            SceneManager.GetInstance().ChangeScene("GameScene");
        }

        public void GetReward(out int gold, out int exp)
        {
            Random random = new Random();
            gold = random.Next(MinRewardGold, MaxRewardGold + 1);
            exp = random.Next(MinRewardExp, MaxRewardExp + 1);
        }

    }
}
