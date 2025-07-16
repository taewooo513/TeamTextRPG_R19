using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using static TeamRPG.Game.Object.Enemy.Enemy;

namespace TeamRPG.Game.Object.Enemy
{
    public class Enemy
    {
        public struct State
        {
            public int hp;
            public string name;
            public int dmg;
            public int def;
            public int mgDef;
            public int dex;
            public int exDmg;
            public int currentHp;
        }
        protected State state;
        public Enemy()
        {
        }
        public void SettingStatus(eEnemyNum num)
        {
            state = StatusFactory.GetStatusByEnemy(num);
            Init();
        }
        public virtual void Init()
        {

        }
        public virtual void Update()
        {
            ExSkill();
        }
        public virtual void Render()
        {
            DrawImage();
        }
        public virtual void Release()
        {
        }
        public virtual void EnemyUIBar(int y)
        {
            TextIOManager.GetInstance().OutputText4Byte(state.name, 132, 7 + y);

            for (int i = 1; i <= 7; i++)
            {
                int val = state.hp / 7 * i;
                if (val <= state.currentHp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 130 + 2 * i, 8 + y);
                }
                else if (val - 10 <= state.currentHp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 130 + 2 * i, 8 + y);
                }
            }
        }
        protected virtual void ExSkill() { } //특수기믹
        protected virtual void DrawImage() { } //이미지 

    }
}
