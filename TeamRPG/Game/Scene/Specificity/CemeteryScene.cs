using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.UtilManager;

namespace TeamRPG.Game.Scene.Specificity
{
    internal class CemeteryScene : SpecificityScene
    {
        Animation nextSceneAni;
        public override void Init()
        {
            //List<String[]> strings = new List<String[]>();
            //for (int w = 0; w < TextIOManager.GetInstance().winWidth / 2; w++)
            //{
            //    for (int i = 0; i < TextIOManager.GetInstance().winHeight / 2; i++)
            //    {
            //    }
            //    strings.Add(s);
            //}
            //base.Init();
            //nextSceneAni = new Animation(strings, 0, 0, 0.1f, false);
        }

        public override void Update()
        {
            base.Update();
        }
        public override void Render()
        {
            base.Render();
        }
        public override void Release()
        {
            base.Release();
        }
        protected override void DrawMap()
        {
            TextIOManager.GetInstance().OutputText("⢿⣿⣟⡡⢌⠃⠌⡀⠀⠙⠻⢿⡿⣿⠟⣿⣿⡘⢛⣿⣿⣿⡿⢿⣿⣿⣿⣿⡟⣿⢿⣿⣿⣿⣿⢿⣿⡻⠿⠟⡉⢃⠄⠂⠉⠙⣤⡛⡇⢿", 25, 2);
            TextIOManager.GetInstance().OutputText("⣞⠕⣫⢻⡔⢊⡐⠠⠀⠀⠀⠈⠘⠣⣸⡇⣸⣷⣻⣧⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣟⣌⣹⢁⡀⠐⡈⠐⢥⣢⣱⠎⣇⢻⣼", 25, 3);
            TextIOManager.GetInstance().OutputText("⣧⣞⣡⡇⢦⡁⠄⢂⠀⠀⠀⠠⢟⣧⣿⣴⣿⣿⣿⣿⣿⣿⣽⣿⣏⢻⣿⣿⡯⠿⢿⣿⠫⠿⣛⣯⡦⣜⣙⣋⡛⢀⠃⢦⠠⠡⠮⣸⠮⣿", 25, 4);
            TextIOManager.GetInstance().OutputText("⢀⠘⢣⠛⠖⣤⢺⣶⣷⣾⣶⢿⣾⣿⣿⣭⣿⢯⣹⣿⣿⣿⣿⠛⡋⢽⣿⣿⢁⣮⣾⠿⡯⣿⣿⣿⣿⣧⣿⣧⣵⣞⠂⠀⠁⠑⠢⠬⣷⢽", 25, 5);
            TextIOManager.GetInstance().OutputText("⠈⣂⠭⠾⢸⠤⢪⣾⣿⣿⣿⣿⣿⣿⠟⡋⠗⢶⣿⣿⣿⣿⣿⠿⡀⢺⣿⣿⠛⣸⣯⣴⣿⠿⠟⠿⣹⡿⠿⢿⡉⠋⠁⠀⢀⢁⢊⣭⣿⣼", 25, 6);
            TextIOManager.GetInstance().OutputText("⠾⠷⢞⣉⠃⡘⢂⠛⢋⣿⡿⢩⡹⢿⡿⢛⣶⣾⣿⣿⣿⣿⣿⡤⣄⣿⣿⡿⣳⣿⠋⢹⡏⠍⠙⠆⠁⠈⠁⠀⠀⠁⠀⣰⣤⡿⠟⠛⠛⣿", 25, 7);
            TextIOManager.GetInstance().OutputText("⠙⣷⣣⠄⠓⣄⢂⡌⠠⡈⠙⠾⠟⡈⢂⣭⡽⣿⠿⢯⡉⢹⣿⡆⣼⣿⣿⣿⣿⣩⣥⠢⠘⠁⠂⠀⠀⠀⠀⠀⠀⠀⣦⠙⠛⡉⢙⡺⠷⢿ ", 25, 8);
            TextIOManager.GetInstance().OutputText("⠀⠄⣋⠒⡓⢌⠣⠴⢁⠀⠀⠀⠀⠀⠀⠋⠙⠃⠀⠀⠙⢾⣿⣗⣾⣿⣿⠷⡏⠋⠡⠁⠀⠀⠀⠀⠀⠀⠀⠀⢠⣐⣬⣴⡷⣞⠿⠷⠀⢸   ", 25, 9);
            TextIOManager.GetInstance().OutputText("⠀⠂⠍⠒⠱⠈⢍⣒⢠⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⣀⡀⠀⠀⠀⠀⠀⠀⠢⡿⢒⢧⡟⣫⠀⣀⠢⠽    ", 25, 10);
            TextIOManager.GetInstance().OutputText("⣸⣶⢆⣰⣦⠹⣼⣿⢫⡟⢠⢄⡤⣀⣀⠀⠀⡰⣄⢦⠀⠀⢻⣿⣿⢏⢆⡭⣞⢷⡀⠀⢺⡓⠀⠀⠀⠀⣄⡠⡑⢉⡶⢎⠓⡁⢂⡌⠁⠢ ", 25, 11);
            TextIOManager.GetInstance().OutputText("⣿⡏⢾⣽⣤⣓⣾⣿⡹⢾⣥⢎⡱⢋⡿⡆⢲⣵⢺⡭⣖⣠⣾⣟⣋⣜⣈⠷⢬⣫⢵⣠⣟⣲⣴⣿⣾⣶⣌⡳⣝⢾⣿⣿⣿⣷⣇⠾⣰", 25, 12);
            TextIOManager.GetInstance().OutputText("⣻⡏⣽⣿⣧⣿⣿⣿⡱⣏⣾⠧⣘⢱⢺⡅⢻⣿⢻⡔⢯⣿⣟⣿⣿⣿⡯⡙⢬⠳⣌⢽⣧⢻⣿⣿⣿⣿⣿⢱⡟⢮⡿⣽⢯⣿⣧⢋⣟", 25, 13);
            TextIOManager.GetInstance().OutputText("⣿⡗⣾⣿⡷⣞⢬⡓⡵⣹⢸⡳⡌⢎⡷⡅⢻⣯⢽⠸⣹⣿⣾⣿⣿⣿⣳⢉⢞⡱⣘⢾⣇⣻⣿⡿⣿⣿⣿⢘⡿⢸⣏⣯⣿⢾⣇⠏⣾", 25, 14);
            TextIOManager.GetInstance().OutputText("⣿⣿⣽⢾⣟⣭⣦⣹⢲⡙⣶⡵⣩⢎⠽⠛⢾⣿⠆⢣⢸⣿⣛⣯⣿⣿⢇⠎⡜⣱⢘⢾⣧⢾⣿⡝⣿⣿⣿⢨⡗⣹⣾⣽⣿⣿⡮⢌⣷", 25, 15);
            TextIOManager.GetInstance().OutputText("⡙⣉⣹⢯⡟⣿⣿⣿⢡⢋⡿⡓⢃⠛⡀⢂⣽⣿⣻⢶⣳⡀⠛⢿⣿⡿⣍⡚⠼⣡⠚⡞⠛⢿⣟⣾⣻⢿⣿⡸⢌⢳⣿⣷⣿⣿⡟⣴⡈", 25, 16);
            TextIOManager.GetInstance().OutputText("⠰⣿⣿⢫⣝⡷⣿⣿⠡⣋⡼⣹⣆⣼⣿⣿⣿⣿⡶⣳⢾⡝⢿⢸⣿⣿⢦⡙⢦⢡⠛⡄⢀⣻⣿⣷⣿⣿⣿⣵⣨⡾⣿⣿⣿⣿⣿⡼⣭", 25, 17);
            TextIOManager.GetInstance().OutputText("⠠⢿⢿⣛⡮⣜⣿⣿⠰⣡⢻⠴⠟⠯⠄⡉⠁⠉⠉⠁⠀⠠⠀⢸⣿⣿⢆⡹⢆⣣⡙⡆⣻⣾⣿⣿⣿⣿⣿⣮⣧⢑⡲⢄⠛⠛⠛⠗⢋⠚", 25, 18);
            TextIOManager.GetInstance().OutputText("⡁⠀⠠⣟⣧⣻⠞⣭⢣⠳⣬⢃⠌⠀⠐⠀⢀⠀⠀⠠⠀⠀⣀⣸⣿⣿⣦⣹⣧⠶⡽⢆⢛⣛⡻⠻⠿⠿⡿⢿⡷⡎⠗⠋⠒⠡⠈⠄⠀⠀ ", 25, 19);
            TextIOManager.GetInstance().OutputText("⠀⠀⠐⣿⣾⣵⠺⡴⣋⠷⣌⡳⠀⠀⠀⠐⠠⠀⠐⠀⣿⣶⣧⣽⣯⣽⣍⣡⣬⣳⣼⡞⣯⣝⡡⢀⠀⠀⠀⠀⠀⠈⠀⠁⠀⠀⠀⠀⠀⠀   ", 25, 20);
            TextIOManager.GetInstance().OutputText("⢂⣀⣨⣿⣿⣿⣱⣏⣧⣻⡼⢿⠰⣠⣤⠀⠀⠀⣊⡴⣿⢿⣿⣿⣿⣿⣿⣇⡿⣵⠻⠞⠓⡈⠡⠉⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀  ", 25, 21);
            TextIOManager.GetInstance().OutputText("⣿⣶⣧⣭⣭⣏⣩⣭⣶⣷⣎⣷⣽⡿⠿⢠⢄⡀⢀⠐⠀⠂⠀⠀⠈⠁⠙⠋⠘⠀⠁⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀   ", 25, 22);
            TextIOManager.GetInstance().OutputText("⣟⣻⠿⡿⣿⣿⡟⢧⠿⣛⢭⣹⣤⣷⣟⣯⣿⣇⠠⠀⠀⠀⠀⠀⠠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     ", 25, 23);
            TextIOManager.GetInstance().OutputText("⣿⣿⣿⣿⣶⣶⡼⣶⢿⣻⣿⣯⢿⡞⠯⠹⢃⠉⠁⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀     ", 25, 24);
            TextIOManager.GetInstance().OutputText("⠛⠻⠻⢿⡿⣿⢿⣛⠿⡽⡘⣁⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀      ", 25, 25);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠈⠀⠉⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀        ", 25, 26);
        }
    }
}
