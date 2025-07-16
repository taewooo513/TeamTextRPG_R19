using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
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

            string rawTextString = """
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⡪⡣⢣⠣⡣⡣⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢧⢫⠸⡐⢅⠣⡣⣫⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡄⡀⢐⢇⢇⠣⡑⢌⠜⡜⡜⡆⣠⢴⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠯⣳⢝⣞⡷⣕⢱⢼⢺⢏⢗⡝⠁⠀⢀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⢱⣫⡲⡱⣕⢅⡳⣕⣳⣝⢎⢇⢗⠕⡙⢜⢘⢒⠔⡄⣀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⣶⡹⣪⣮⣾⣺⢼⣪⡪⡸⣸⡐⡅⡌⢔⢐⢐⠑⠌⡂⡣⠩⡊⡆⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡸⢵⣏⢗⢎⢎⢧⢫⣞⢜⢜⢘⠜⡜⣮⣓⠳⢕⢵⢱⢜⣔⡕⡕⢕⢕⠭⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣪⡫⡾⡿⣖⣔⣜⣞⢮⢣⢑⠅⡕⡵⣻⣪⡀⠀⠀⠀⠁⢐⢕⢕⠱⣘⠎⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢳⣯⡫⣟⣽⢳⡻⣗⢕⢇⢇⢣⢣⢫⡺⣜⠆⠀⠀⠀⢠⠪⡊⢆⠇⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠜⢐⠱⡱⡏⢗⣟⣗⣯⣻⡺⡼⡜⡜⡜⣼⢪⡪⡝⣦⡀⢠⠣⡃⡎⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⡠⠪⡨⣢⠫⠊⠀⠀⠱⠯⡾⣞⡾⣝⢮⢗⢯⢳⢱⡱⣹⣪⢻⡘⢌⢪⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⢀⠜⡨⡪⠊⠀⠀⠀⠀⠀⠀⠀⠈⠻⣺⡵⣗⢧⡣⡳⡱⡕⣇⢗⢕⢅⠕⡐⢭⡲⡤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⡠⢣⢱⠑⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡳⡽⡯⡯⡯⡯⣞⡾⢵⡑⢅⢪⡐⡅⡯⣫⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⡎⢆⠑⠅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⢿⢽⢽⢽⢝⣮⢿⢽⡱⡊⡎⢜⢜⢼⣘⢯⡂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⢠⠣⢢⠉⢎⡀⠀⠀⠀⠀⠀⠀⠀⢀⡤⣯⣯⣻⣻⣻⡯⣿⣽⢿⣽⢢⢷⡣⣻⢜⣽⣺⡸⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⢌⢪⠐⠀⠐⢒⠀⠀⠀⠀⠀⠀⡠⡾⣽⢳⣳⣳⢷⣻⡿⡷⠛⣟⣮⢸⣟⡎⣟⡇⠟⠚⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⢂⢝⢄⠀⠀⠀⠀⠀⠀⠀⠀⣖⢿⢽⢯⣻⣳⡻⣟⣟⠿⠁⠀⢿⢧⣟⣗⣗⣽⡮⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠑⢐⠀⠀⠀⠀⠀⠀⢀⡼⣮⢯⣯⢿⡽⣾⠽⠝⠁⠀⠀⠀⠈⣟⡾⣝⡷⡵⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣽⣺⣳⢿⣽⣻⠏⠀⢀⠠⠀⠠⠀⠀⢸⡯⣗⢯⢽⣺⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⡷⣻⣽⣺⢾⣢⠐⢀⠠⠐⢀⠂⠐⢀⠹⣽⢝⣗⡯⡿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                ⠀⠀⠀⠀⠠⠀⠀⡀⠀⢀⠀⠀⠄⠂⠀⢿⣽⣺⣺⢯⡿⢀⢂⠂⠅⡂⠌⠌⠠⢀⠫⣟⢷⣛⣽⢾⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
                """;
            if (KeyInputManager.GetInstance().GetKeyDownOnce(ConsoleKey.Enter))
            {
                RawText rawText = new RawText(rawTextString, 50, 5, ConsoleColor.Green, TextAlign.Center);
                menu.AddItem("Start Game", () => menu.GetItem(0).Text = "Hello!");
                menu.AddItem("Options", () => menu.GetItem(1).Text = "Oh!");
                menu.SelectByIndex(1);
            }

        }

        public void Update()
        {
        }

    }
}
