using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Scene
{
    internal class SpecificityScene : Core.SceneManager.Scene
    {
        public int selectNum = 0;
        public virtual void Init()
        {
            selectNum = 0;
        }

        public virtual void Release()
        {
        }

        public virtual void Render()
        {
            DrawMap();

            TextIOManager.GetInstance().OutputSmartText("휴식", 35, 38);
            TextIOManager.GetInstance().OutputSmartText("상인", 55, 38);
            TextIOManager.GetInstance().OutputSmartText("탐색", 75, 38);
            TextIOManager.GetInstance().OutputSmartText("이동", 95, 38);
            TextIOManager.GetInstance().OutputSmartText("상태", 115, 38);

            TextIOManager.GetInstance().OutputText4Byte("▶", 32 + selectNum * 20, 38);
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                switch (selectNum)
                {
                    case 0:
                        SceneManager.GetInstance().ChangeScene("RestScene");
                        break;
                    case 1:
                        SceneManager.GetInstance().ChangeScene("ShopScene");
                        break;
                    case 2:
                        SceneManager.GetInstance().ChangeScene("EncounterScene");
                        break;
                    case 3:
                        SceneManager.GetInstance().ChangeScene("GameScene");
                        break;
                }
            }
        }
            
        

        public virtual void Update()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow) && selectNum > 0)
            {
                selectNum--;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow) && selectNum < 4)
            {
                selectNum++;
            }
        }

        protected virtual void DrawMap()
        {

        }

    }
}
