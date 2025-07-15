using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.Enemy;

namespace TeamRPG.Game.Scene
{
    public class GameScene : Core.SceneManager.Scene
    {
        Enemy e;
        Enemy e1;
        Enemy e2;
        int selectNum = 0;
        public void Init()
        {
            selectNum = 0;
            e = new Goblin(0, 5, "A");
            e1 = new Goblin(-30, 0, "B");
            e2 = new Goblin(30, 0, "C");
        }

        public void Release()
        {
        }

        public void Render()
        {
            e2.Render();
            e.Render();
            e1.Render();


        }



        public void Update()
        {
            e.Update();
            e1.Update();
            e2.Update();

            PlayerManager.GetInstance().GetPlayer().UIRender();
        }
    }

}