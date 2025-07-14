using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Scene
{
    internal class UITestScene : Core.SceneManager.Scene
    {
        public void Init()
        {
        }

        public void Release()
        {
        }

        public void Render()
        {
            Box box = new Box(0, 0, 100, 25, ConsoleColor.DarkGray);
            Text label = new Text("Test Scene", 50, 1, ConsoleColor.Cyan, TextAlign.Left);
            Menu menu = new Menu(50, 3);
            menu.AddItem("Start Game", ()=> menu.GetItem(0).Text = "Hello!");
            menu.AddItem("Options", ()=> menu.GetItem(1).Text = "Oh!");
            menu.Select();

        }

        public void Update()
        {
        }
            
    }
}
