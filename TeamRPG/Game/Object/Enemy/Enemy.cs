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
            public State(int _hp, string _name, int _dmg, int _def, int _mgDef, int _dex, int _exDmg)
            {
                hp = _hp;
                name = _name;
                dmg = _dmg;
                def = _def;
                mgDef = _mgDef;
                dex = _dex;
                exDmg = _exDmg;
            }

            public int hp;
            public string name;
            public int dmg;
            public int def;
            public int mgDef;
            public int dex;
            public int exDmg;
        }
        public State state { get; private set; }
        public Enemy(String _name, int _hp, int _dmg, int _def, int _mgDef, int _dex, int _exDmg)
        {
            state = new State(_hp, _name, _dmg, _def, _mgDef, _dex, _exDmg);
            Init();
        }

        protected virtual void Init()
        {

        }
        protected virtual void Update()
        {
            ExSkill();
        }
        protected virtual void Render()
        {
            DrawImage();
        }
        protected virtual void Release()
        {

        }

        protected abstract void ExSkill(); //특수기믹
        protected abstract void DrawImage(); //이미지 

    }
}
