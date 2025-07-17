using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            TextIOManager.GetInstance().OutputSmartText("휴식", 45, 38);
            TextIOManager.GetInstance().OutputSmartText("상인", 65, 38);
            TextIOManager.GetInstance().OutputSmartText("탐색", 85, 38);
            TextIOManager.GetInstance().OutputSmartText("이동", 105, 38);

            TextIOManager.GetInstance().OutputText4Byte("▶", 42 + selectNum * 20, 38);
        }

        public virtual void Update()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow) && selectNum > 0)
            {
                selectNum--;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow) && selectNum < 3)
            {
                selectNum++;
            }
        }

        protected virtual void DrawMap()
        {

        }

    }
}
