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
            public State(int _hp, string _name, int _dmg, int _def, int _mgDef, int _dex, int _exDmg, int _currentHp)
            {
                hp = _hp;
                name = _name;
                dmg = _dmg;
                def = _def;
                mgDef = _mgDef;
                dex = _dex;
                exDmg = _exDmg;
                currentHp = _currentHp;
            }
            public int hp;
            public string name;
            public int dmg;
            public int def;
            public int mgDef;
            public int dex;
            public int exDmg;
            public int currentHp;

        }
        Queue<ConsoleKey> keyPad;
        public bool isDie = false;
        bool isExSkill = false;
        protected State state;
        public Enemy()
        {
        }
        public String GetName()
        {
            return state.name;
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
            if (state.currentHp <= 0)
            {
                isDie = true;
            }
        }
        public virtual void Render()
        {
            DrawImage();
        }
        public virtual void Release()
        {
        }
        public virtual void SelectEnemy()
        {
        }
        public virtual void EnemyUIBar(int y)
        {
            TextIOManager.GetInstance().OutputText4Byte(state.name, 132, 7 + y);

            for (int i = 1; i <= 7; i++)
            {
                int val = state.hp / 7 * i;
                if (val<= state.currentHp)
                {
                    TextIOManager.GetInstance().OutputText4Byte("■", 130 + 2 * i, 8 + y);
                }
                else if (state.currentHp % 7 != 0)
                {
                    TextIOManager.GetInstance().OutputText4Byte("□", 130 + 2 * i, 8 + y);
                    break;
                }
            }
        }
        public void EnemyTurnSetting()
        {
            keyPad = new Queue<ConsoleKey>();

            SettingExSkill();
        }
        private void SettingExSkill()
        {
            Random rd = new Random();
            for (int i = 0; i < 5; i++)
            {
                switch (rd.Next(0, 4))
                {
                    case 0:
                        keyPad.Enqueue(ConsoleKey.RightArrow);
                        break;
                    case 1:
                        keyPad.Enqueue(ConsoleKey.LeftArrow);
                        break;
                    case 2:
                        keyPad.Enqueue(ConsoleKey.UpArrow);
                        break;
                    case 3:
                        keyPad.Enqueue(ConsoleKey.DownArrow);
                        break;
                }
            }
        }
        protected virtual void ExSkill()
        {
            PlayerManager.GetInstance().GetPlayer().HitPlayer(state.exDmg);
        } //특수기믹
        protected virtual void DrawImage() { } //이미지 

        public void InputKeyPad()
        {
            if (KeyInputManager.GetInstance().GetIsKeyDown())
            {
                if (KeyInputManager.GetInstance().KeyDown() != keyPad.Dequeue())
                {
                    ExSkill();
                    keyPad.Clear();
                }
            }
        }
        public Queue<ConsoleKey> GetKeyPad()
        {
            return keyPad;
        }
        public void Attack()
        {

        }
        public void HitEnemy(int _dmg)
        {
            state.currentHp -= _dmg;
        }
    }
}
