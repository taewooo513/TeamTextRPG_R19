using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.EnemyManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
        bool isParreyFail = false; // 패링 스펠링몰라요
        Stopwatch stopwatch;
        Stopwatch parryStopwatch;

        public bool isTurn = false;
        Queue<ConsoleKey> keyPad;
        public bool isDie = false;
        public bool isExSkill = false;
        protected State state;
        public Enemy()
        {
            keyPad = new Queue<ConsoleKey>();
        }
        public string GetName()
        {
            return state.name;
        }
        public void SettingStatus(eEnemyNum num)
        {
            parryStopwatch = new Stopwatch();
            state = StatusFactory.GetStatusByEnemy(num);
            stopwatch = new Stopwatch();
            Init();
        }
        public virtual void Init()
        {
        }
        public virtual void Update()
        {
            if (isTurn == true)
            {
                if (isExSkill == false)
                {
                    if (stopwatch.ElapsedMilliseconds > 2000)
                    {
                        isTurn = false; // ?
                        PlayerManager.GetInstance().GetPlayer().selectE++;
                        if (EnemyManager.GetInstance().GetEnemyList().Count > PlayerManager.GetInstance().GetPlayer().selectE)
                        {
                            EnemyManager.GetInstance().GetEnemyList()[PlayerManager.GetInstance().GetPlayer().selectE].EnemyTurnSetting();
                        }
                        else
                        {
                            PlayerManager.GetInstance().GetPlayer().PlayerTurnSetting();
                        }
                        stopwatch.Reset();
                        stopwatch.Stop();
                    }
                }
                else
                {
                    InputKeyPad();
                    if (parryStopwatch.ElapsedMilliseconds > 2000)
                    {
                        ExSkill();
                        isParreyFail = true;
                        keyPad.Clear();
                        parryStopwatch.Reset();
                        parryStopwatch.Stop();
                        stopwatch.Start();
                        isExSkill = false;
                    }
                    if (stopwatch.ElapsedMilliseconds > 2000)
                    {
                        isTurn = false; // ?
                        PlayerManager.GetInstance().GetPlayer().selectE++;
                        if (EnemyManager.GetInstance().GetEnemyList().Count > PlayerManager.GetInstance().GetPlayer().selectE)
                        {
                            EnemyManager.GetInstance().GetEnemyList()[PlayerManager.GetInstance().GetPlayer().selectE].EnemyTurnSetting();
                        }
                        else
                        {
                            PlayerManager.GetInstance().GetPlayer().PlayerTurnSetting();
                        }
                        stopwatch.Reset();
                        stopwatch.Stop();
                    }
                }
            }
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
            UIManager.GetInstance().ClearUI();
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
                if (val <= state.currentHp)
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
        public void ArroRender()
        {
            int arrUiX = 0;
            foreach (var item in GetKeyPad().ToList())
            {
                arrUiX += 3;
                switch (item)
                {
                    case ConsoleKey.UpArrow:
                        TextIOManager.GetInstance().OutputText4Byte("↑", 14 + arrUiX, 32);
                        break;
                    case ConsoleKey.RightArrow:
                        TextIOManager.GetInstance().OutputText4Byte("→", 14 + arrUiX, 32);
                        break;
                    case ConsoleKey.DownArrow:
                        TextIOManager.GetInstance().OutputText4Byte("↓", 14 + arrUiX, 32);
                        break;
                    case ConsoleKey.LeftArrow:
                        TextIOManager.GetInstance().OutputText4Byte("←", 14 + arrUiX, 32);
                        break;
                }
            }
        }

        public void EnemyTurnSetting()
        {
            stopwatch.Reset();
            parryStopwatch.Reset();
            isExSkill = false;
            Random rd = new Random();
            isTurn = true;
            if (rd.Next(0, 2) < 1)
            {
                PlayerManager.GetInstance().gameMsg = $"{state.name}의 특수공격!! 패링하세요.";
                SettingExSkill();
                parryStopwatch.Start();
            }
            else
            {
                stopwatch.Start();
                PlayerManager.GetInstance().gameMsg = $"{state.name}에게 {state.dmg}의 피해를 입었습니다.";
                PlayerManager.GetInstance().GetPlayer().HitPlayer(state.dmg);
            }
        }
        protected virtual void SettingExSkill()
        {
            Random rd = new Random();
            isExSkill = true;
            isParreyFail = false;
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
            PlayerManager.GetInstance().gameMsg = $"패링실패!! {state.exDmg}의 피해를 입었습니다";
            PlayerManager.GetInstance().GetPlayer().HitPlayer(state.exDmg);
        }   //특수기믹
        protected virtual void DrawImage() { } //이미지 

        public void InputKeyPad()
        {
            if (keyPad.Count != 0)
            {
                if (KeyInputManager.GetInstance().GetIsKeyDown())
                {
                    if (KeyInputManager.GetInstance().KeyDown() != keyPad.Dequeue())
                    {
                        ExSkill();
                        isParreyFail = true;
                        keyPad.Clear();
                        parryStopwatch.Stop();
                        stopwatch.Start();
                        isExSkill = false;

                    }
                    if (keyPad.Count == 0 && isParreyFail == false)
                    {
                        PlayerManager.GetInstance().gameMsg = "패링성공 !!!";
                        parryStopwatch.Reset();
                        parryStopwatch.Stop();
                        stopwatch.Start();
                        isExSkill = false;
                    }
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
            if (state.currentHp <= 0)
            {
                isDie = true;
            }
        }
    }
}
