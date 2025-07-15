using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.UtilManager;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamRPG.Game.Object.Enemy
{
    public class Goblin : Enemy
    {
        public Goblin(string _name, int _hp, int _dmg, int _def, int _mgDef, int _dex, int _exDmg) : base(_name, _hp, _dmg, _def, _mgDef, _dex, _exDmg)
        {

        }

        protected override void DrawImage()
        {
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠄⠀⠀⠀⠀⠀⠀⠀            ", 38, 1);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢄⠀            ", 38, 2);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠡⡀⠀⠀⠀            ", 38, 3);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢁⠀⠀⠀            ", 38, 4);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠰⡸⠁⠄⣷⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡌⠀⠀⠀⠀            ", 38, 5);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⣴⡆⣦⣄⣼⠳⣅⠊⡷⠻⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⠀⠀⠀⠀            ", 38, 6);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠈⠁⠊⠙⠁⢠⠏⢀⡤⣀⣄⠠⠄⠄⠶⠶⠖⠞⠛⡅⠀⠀⠀⠀            ", 38, 7);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢈⢲⣹⠃⡞⡬⡾⣝⢮⠃⠀⠀⠀⠀⠀⠀⠀⠸⠀⠀⠀⠀            ", 38, 8);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⡰⢥⡀⠀⣯⢳⢯⡽⡱⢟⠬⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀            ", 38, 9);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠉⡟⣮⢴⡻⣟⡄⠐⡀⠀⠀⠀⠀⠀⠀⠀⠠⠁⠀⠀⠀⠀            ", 38, 10);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠹⣎⡷⡍⠙⣾⢦⣥⠀⠀⠀⠀⠀⠀⢀⠂⠀⠀⠀⠀⠀            ", 38, 11);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⢿⣼⠁⢈⢖⡛⠾⡰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 12);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢈⡱⠙⠇⡐⢥⡙⠻⣆⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 13);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣻⡼⠀⠀⢽⣦⠻⡤⠈⠑⠣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 14);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⣳⢿⠀⠀⠸⣽⡃⠈⠡⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 15);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠬⣫⠇⠀⠀⢹⡽⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 16);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⢫⠂⠀⠀⢢⢻⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 17);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⢰⣏⠀⠀⠀⠀⢿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 18);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⢀⡾⣮⠀⠀⠀⢈⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀", 38, 19);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠒⠋⠉⠁⠀⠀⠀⠰⣺⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 20);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀            ", 38, 21);
        }

        protected override void ExSkill()
        {

        }


        /*
    ⠀⠀⠀    ⠀⡠⡔⡆⡦⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡱⡱⠨⡪⡪⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢣⢤⣸⣸⡨⡪⣂⣇⡯⡴⡊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠩⡺⡜⡝⡕⢵⣱⡣⡯⡰⡰⡒⢆⢆⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢀⢼⢵⠽⣞⡷⢮⢞⢜⢜⢔⢌⡢⡢⡑⢌⠪⡩⡲⢤⢀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⢪⢮⣻⣽⡘⢜⢵⣫⠪⡸⡨⣳⢏⠈⠚⠚⠪⡎⡎⢎⠎⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⡐⡷⣕⣯⣻⢽⡗⡕⡕⡜⡜⣗⢽⠀⠀⠀⡰⡑⡕⠕⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⢀⢜⢐⢍⡗⠳⣫⣗⡯⣞⡎⣎⣞⢎⢮⢳⣄⢜⢌⠎⠂⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀
⠀⠀⠀⠀⠀⡠⡃⡆⠓⠁⠀⠀⠁⠙⢯⣳⢽⡱⡱⣕⢕⢯⢪⢢⢑⢥⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⡜⢔⠕⠁⠀⠀⠀⠀⠀⠀⠈⣻⢼⣻⡺⣮⣳⢯⠪⡂⡆⡎⡾⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢰⢑⢑⡂⠀⠀⠀⠀⠀⠀⠀⣠⢾⢽⣞⣽⣺⢾⡝⣱⡡⣣⡳⡝⣅⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢕⡱⠁⠪⠄⠀⠀⠀⠀⣠⢾⢿⢽⣽⣽⣾⡟⣯⢇⡿⣜⡧⡻⠝⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⢱⠡⡀⠀⠀⠀⠀⠀⣖⡯⡿⣽⣝⣾⠷⠇⠀⢿⡵⣿⢮⢾⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠑⠀⠀⠀⠀⠀⣞⣗⣯⢿⢷⡛⠈⢀⠀⠀⠈⣿⢝⣗⢿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⡾⣞⣯⢿⡠⠈⠄⠄⠡⢀⠙⣽⢮⢯⢷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠐⠈⠀⠀⠂⠀⠐⠈⠀⠂⢻⣽⣺⡻⡇⠅⠅⢅⢑⢐⠨⢘⡿⡽⡽⣮⡀⠀⠈⠀⠀⠀⠀⠀⠀⠀
⠀⢀⠠⠀⢁⠀⡁⢈⠀⡁⠡⠈⢾⢾⡽⡏⠌⠌⡐⢐⢐⠨⢀⢻⢽⢽⢺⡆⠀⠀⠀⠀⢀⠀⠀⠀⠀
⠈⠀⠀⠀⠀⠀⡀⠠⠀⠄⠂⠡⠈⣟⣞⢷⠁⠅⠂⡐⢐⠨⢐⢈⢫⣯⣳⡗⠀⠀⠂⠁⠀⠀⠀⠀⠁
⠀⠀⠀⠐⠈⠀⠀⢀⠐⢀⠡⣈⢰⠸⣘⢵⡑⡈⠄⠠⠀⠌⢐⠐⠄⢟⡞⡞⠀⠀⠄⠀⠀⢀⠀⠂⠀
⡀⠈⠀⠀⠄⠐⠨⠤⡒⢆⢣⢪⡢⡱⡠⠣⡳⢀⠈⡀⠂⡈⠄⠨⢈⠢⡳⣝⢆⠀⠄⠀⠁⠀⠀⠀⠀
⠀⠀⠐⢀⠀⠄⠈⠈⠈⠉⡀⠂⠐⠈⠈⠉⢈⠀⠠⠀⠠⠀⠐⢈⠠⢑⣽⢵⢝⢦⡀⠐⢀⠐⠀⠠⠀
⠀⠁⢀⠀⠀⠀⡀⠈⠀⡀⠀⠠⠐⠈⠀⠁⡀⠀⠂⠀⠂⠀⢁⠠⠐⠐⢘⢵⢝⣞⣜⢆⠀⠀⡀⠀⠀

⠀⠀⠀⠀
         */
    }
}
