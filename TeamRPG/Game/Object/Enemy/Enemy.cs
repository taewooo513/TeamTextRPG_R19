using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeamRPG.Game.Object.Enemy.Enemy;

namespace TeamRPG.Game.Object.Enemy
{
    public abstract class Enemy
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
        }
        public State state { get; private set; }
        public Enemy()
        {
            state = new State();
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

        protected abstract void ExSkill(); //특수기믹
        protected abstract void DrawImage(); //이미지 

    }
}
