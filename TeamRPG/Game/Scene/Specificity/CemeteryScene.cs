using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene.Specificity
{
    internal class CemeteryScene : SpecificityScene
    {
        Animation nextSceneAni;
        public override void Init()
        {
            base.Init();

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
            DrawText();
        }
        public override void Release()
        {
            base.Release();
        }
        protected override void DrawMap()
        {
            TextIOManager.GetInstance().OutputText("⠀⠄⠀⡀⠌⢖⢌⠈⠨⠨⡈⡆⡒⠵⣷⣝⣮⣟⡿⣾⣗⣏⡝⣗⣿⢽⢾⣻⣟⣮⣿⠯⣿⡺⡗⢻⢌⣗⠽⣿⣗⣯⡿⣿⣿⡋⡁⠐⡄⠄⠐⣿⣿⣾⢿⣗⠀⣡⣮⠿⣿⡷⠑⠹⡟⠛⣒⣗⡿⣿⣟⣯⡿⣿⣞⣟⡿⣽⣗⣿⣺⡿⣽⣌⢀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠉⡑⣿⡪⢑⣿    ", 25, 1);
            TextIOManager.GetInstance().OutputText("⠀⡱⠠⠀⢈⠢⡃⣂⠆⠆⠅⣁⡠⢕⢱⠽⣯⢿⡿⣗⣯⣿⣽⣾⣟⣶⣾⣯⣿⢯⡾⠽⣵⠩⣣⡴⣽⣺⣳⣽⢻⣟⣿⢿⣽⣟⢧⣫⡂⠀⢀⣿⣷⣿⣿⣷⡾⠟⢅⢲⣿⠃⢀⣠⣼⣶⡿⣿⣻⢻⣮⢝⢝⣷⣽⢟⣿⣽⣻⡫⠋⠛⠟⡎⠑⠀⠀⠀⠀⠀⠀⢐⠨⢐⠑⠍⡫⣇⡂⢾    ", 25, 2);
            TextIOManager.GetInstance().OutputText("⠀⠀⡈⣄⠦⠚⠊⠉⠉⡍⠯⠌⠒⢜⢝⣷⣾⢿⡿⣿⡿⣿⢿⣷⡟⢻⠽⡮⣌⠁⢁⠄⠸⠘⠈⣬⣯⣷⢿⣝⣽⣿⣽⣯⣿⣟⠏⠎⠆⡀⢐⣿⣽⣾⣿⡻⠈⠀⡀⣿⣿⡷⡿⣿⣵⣮⡎⢍⠋⠁⠗⠙⢸⠽⣝⣘⠑⠙⠪⠧⢆⠂⡀⠀⠀⠀⠀⠀⠀⠀⠀⡄⡀⣠⣳⣗⣯⣿⡎⣺    ", 25, 3);
            TextIOManager.GetInstance().OutputText("⡴⣝⣩⡤⡦⠖⠖⠽⠩⠡⡁⠑⠥⡐⢟⢧⠮⠞⣗⣽⣽⠻⢻⠑⠙⢯⣫⣿⣪⣷⣼⣧⣦⣦⣬⣾⣻⡾⣿⣯⣿⣯⣿⣻⣟⣷⠀⡀⠀⠀⢸⣿⣻⣽⣿⡿⠔⡬⣾⣿⠟⠕⡕⢗⡇⢇⢍⢚⠨⡳⣅⠀⠐⠃⠈⠋⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⡵⣽⣖⣷⡯⡿⠾⣞⣿⢾     ", 25, 4);
            TextIOManager.GetInstance().OutputText("⢻⢉⢊⠣⡙⠕⢄⢄⠀⠀⠨⠐⠄⠈⠐⠄⡈⡈⣺⣽⡽⡕⡀⢡⠕⣇⢫⢟⢟⠝⠀⡨⣎⣟⣿⣚⣯⢿⡿⣽⣿⢽⣿⣟⣿⣟⠮⡚⢣⢀⣿⡿⣟⣿⣽⠈⣴⣿⡿⡯⡃⠀⠀⢱⢫⡀⡁⡁⠁⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢂⢦⣕⣹⣽⢓⠙⠐⠀⠀⠀⠀⣿⣝       ", 25, 5);
            TextIOManager.GetInstance().OutputText("⠢⢍⡷⣅⢎⠪⠠⠀⠉⢦⠀⠅⠂⠀⠈⠀⠀⠀⠉⠡⠱⠣⡲⣯⣳⠝⢤⠘⠌⠄⠊⡛⣊⣊⣿⡻⣻⣿⣿⡑⠃⠑⠛⣿⣽⣿⣆⠀⠀⣺⣿⣿⢿⣿⣧⣾⣿⡓⠩⠈⠒⢀⢀⠀⠁⠗⠌⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠸⢽⢞⢿⠪⠊⠘⠔⠔⠵⣴⣔⣸⣿       ", 25, 6);
            TextIOManager.GetInstance().OutputText("⠈⠠⢹⡱⡵⣹⠨⠠⢀⠀⡑⠄⠅⡄⡅⠠⠀⠁⠢⠀⠀⠈⠘⠳⠓⠁⠁⠀⠀⡠⡠⣯⡷⠏⡳⡿⡎⠃⠉⣷⣌⠀⠀⢻⣿⢷⣟⠀⠠⣿⣿⣽⢿⣿⣽⡷⣯⣞⢖⣮⠦⣓⢁⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣢⡻⡈⡂⠀⠀⠈⠀⢀⢅⣵⠻⡨⠈⠛⣿        ", 25, 7);
            TextIOManager.GetInstance().OutputText("⠀⠀⠂⠘⢌⢓⢧⠡⡐⡄⢇⢝⠌⡪⠠⢡⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⢗⠓⢹⢱⡝⠈⠀⠀⠀⠀⠙⠷⣦⣹⣿⣻⣿⡀⢨⣿⡷⣿⢿⣯⡗⡅⣎⠟⠟⡮⢫⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⠑⢀⠠⣰⡄⣆⡦⣥⣯⣣⣑⠀⠠⠀⣹          ", 25, 8);
            TextIOManager.GetInstance().OutputText("⠀⠀⠄⠀⢕⢔⠀⠡⢁⠁⠢⢀⠑⡨⠨⢊⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢿⣯⡿⣷⠅⣼⣿⢿⡽⣿⠯⠛⠎⠯⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢤⡠⣰⡰⢜⣓⢗⣯⢻⠚⣦⠛⠜⠜⠢⠁⠀⠀⢺            ", 25, 9);
            TextIOManager.GetInstance().OutputText("⠀⠐⠈⠈⠔⢑⠑⠄⡆⡆⡂⠑⡕⡘⠐⠄⠄⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢘⣾⣿⣻⣧⣿⣿⣽⢽⠯⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢐⢜⢕⡕⣕⡇⡏⢮⢿⢾⡪⠂⠀⠀⠀⠀⡀⡨⣘            ", 25, 10);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠈⠈⠀⠀⡁⠈⠂⠂⢀⠈⡢⣠⢠⢁⣐⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡾⣯⣿⣻⢿⣺⢯⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢄⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⢟⠇⡫⢢⠣⣫⡞⠅⡅⢇⠀⠀⠠⡀⡁⠌⠊⠪             ", 25, 11);
            TextIOManager.GetInstance().OutputText("⠀⣄⡄⡄⡄⡀⠀⠀⢀⠰⡨⠠⡑⣜⢯⢧⡳⣕⢵⢕⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣿⢿⣞⣯⣿⢽⠩⡐⡐⠨⡐⡰⡱⡵⣄⠀⠀⠀⠀⢦⢝⢜⡤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠕⠫⠪⢨⡠⢡⠳⠻⢢⠪⡒⠄⠀⠐⠈⠊⠈⠀⠠           ", 25, 12);
            TextIOManager.GetInstance().OutputText("⣌⣞⡷⡕⡗⡄⣠⢾⣫⠣⡊⡎⣒⢮⣫⢗⢕⢇⢏⢇⠀⢔⢐⠰⡱⡰⡠⡀⣄⢄⠀⠀⠀⠀⢀⢎⠬⡸⡜⡦⡀⠀⠀⠀⠀⢽⡿⣽⣳⢯⠣⡑⢔⢌⢎⢔⢝⢜⢎⢞⢆⠀⠀⠀⠁⢽⢅⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⠢⡢⡢⡰⡀⠈⠠⡱⡝⡇⡁⠅⠀⠁⢀⠄⢄⢐⢄⠀⠀⠀⠅      ", 25, 13);
            TextIOManager.GetInstance().OutputText("⣗⣗⢿⢕⢱⡱⡽⠝⠨⠈⠌⠨⡨⣾⣳⢏⢮⢎⡪⡪⡌⡢⡑⡕⢕⢕⢵⡑⣗⣝⢦⠀⢀⡠⣈⣂⢣⢫⡪⡪⡢⡀⠀⠀⡀⣸⣟⣟⡾⠣⠑⢅⠣⠣⢣⢣⢱⢱⢱⢱⢱⠁⠀⠀⣗⢽⠰⡠⠀⡀⣤⢴⡴⣤⣐⡀⠑⢕⢕⢕⢬⡂⣖⡷⡽⡽⡽⣝⡯⡷⡵⣤⢥⡑⡜⡕⠠⡠⢠⡀   ", 25, 14);
            TextIOManager.GetInstance().OutputText("⡕⣗⢯⠢⡑⣯⢾⣫⢯⡪⣝⢜⡽⣯⣿⣣⢣⢣⢳⢱⡻⡜⡜⡌⡢⡑⠔⡕⢜⢮⢪⠂⢸⡺⣷⡳⡑⡵⡱⢱⡑⢕⣠⡪⣞⣞⡷⣕⣬⢬⡦⣦⡢⣱⢸⢐⠕⡕⡕⡝⠔⣕⢢⢵⢦⠕⢕⣮⢾⡽⡽⣽⣮⡯⡯⣿⣲⣤⠥⡑⡵⡱⡨⣝⢾⢽⣝⢷⢽⢽⢽⢽⢯⠢⡣⡹⡸⡸⡘⡮  ", 25, 15);
            TextIOManager.GetInstance().OutputText("⡹⣮⣻⢨⠪⡯⡿⣝⡷⡱⡱⣇⢯⢿⣽⡎⡎⢜⢜⢜⢎⡇⣗⢑⢐⠌⡌⡪⡪⡪⡣⡁⢸⢝⡷⡯⡺⣮⠪⢢⢳⡣⣿⢽⡺⣜⣯⢷⣻⣽⡽⡾⡇⡇⢇⢕⠱⡱⡱⡹⠨⡸⡸⣸⡿⡍⠮⣞⣯⣳⣻⣟⣾⣻⣗⡽⡽⣾⢑⢔⢝⢜⡄⣗⢯⡳⡳⣝⢽⢝⣽⢽⣻⢸⡨⡒⣼⡓⡌⡿  ", 25, 16);
            TextIOManager.GetInstance().OutputText("⣝⢞⣞⢔⢕⢯⢿⡽⣺⢵⢽⡮⣯⣿⣟⡧⡱⡱⡱⡱⣻⢮⢮⠢⢡⢑⢔⢱⢸⢸⢸⠀⠸⣝⡽⡧⠱⡯⡪⡘⢜⢜⣿⢽⡺⣪⢾⢽⣳⢯⡿⣽⡫⡪⠢⡡⡑⡕⢜⠜⠌⢜⢜⢼⣻⠌⢜⣗⣿⡽⣯⢷⣳⣻⡽⣿⣟⣽⢂⢿⢪⢣⠣⣪⡳⣝⢽⡸⣕⢯⡺⡽⡽⡘⡆⢕⢼⡪⡪⣫  ", 25, 17);
            TextIOManager.GetInstance().OutputText("⢮⣳⣳⢱⠨⡯⡯⣟⡭⡧⣍⢎⡕⡑⢍⠇⡇⡇⢇⢇⢖⡲⡔⡎⡢⡑⢔⠱⡱⡱⡕⠅⢘⢮⢯⡇⡣⣟⢌⢎⢪⢣⢿⡳⣝⢼⢽⢽⢽⡯⣟⡷⡇⡇⠕⠔⠌⡎⡪⡪⠡⡱⡱⣹⢾⡑⡘⣮⡷⣟⣗⢽⡺⣪⢯⢷⣟⢾⠠⣹⢪⢪⠨⡪⣎⢮⡣⡫⡮⣳⡹⣕⢯⢪⠪⡨⣺⢪⢘⢮  ", 25, 18);
            TextIOManager.GetInstance().OutputText("⢳⡳⣽⢸⢸⢽⡺⣽⣝⢮⣳⢱⣑⠸⡰⡡⢱⢑⢇⢇⡂⡎⡎⢎⢪⠨⠢⡑⣝⢵⣱⠁⢸⢝⡵⣣⠱⡗⢌⢂⢪⢪⢿⣝⢮⣳⣻⢽⢽⣽⣫⡯⣇⢇⠕⠅⠕⡜⢜⢌⠪⡘⡜⣜⢿⡐⢨⢗⣿⡣⣗⢽⣺⡽⣽⢽⣗⢯⢂⢺⡸⡸⠨⡪⣎⢮⢮⡫⣞⢮⣞⣞⢽⢸⠘⢌⢺⡑⠠⡳  ", 25, 19);
            TextIOManager.GetInstance().OutputText("⣯⣯⡷⡣⡇⣟⢮⡳⣗⢕⢧⠣⢢⠑⠌⢎⠆⢕⢕⢕⠔⡕⡕⢕⢆⢑⢑⢌⢎⢗⢕⢕⢜⣽⣺⡣⢭⠁⡂⡂⡂⡣⣿⣞⣟⣞⢷⢽⢽⣺⣺⢽⡇⡇⠕⠅⠕⢜⢌⢆⢑⢕⢕⢵⣻⠌⢌⢯⡷⡝⣎⢗⢗⡿⣽⢽⡯⣳⠐⢽⠨⡪⢨⢺⢪⢮⡳⣝⡮⣗⣗⣗⡧⡱⡑⠐⢽⡊⡆⡗  ", 25, 20);
            TextIOManager.GetInstance().OutputText("⣟⣾⣻⡵⣝⡽⡪⣞⢧⣧⣯⢮⣦⣯⣮⡮⢸⠨⡨⢪⣳⣿⢽⢨⠪⡪⡢⡪⠊⠊⠁⠁⢹⣺⢵⡏⣎⠂⡂⠢⡐⡸⡽⣞⣜⡬⣌⣗⣟⣞⣞⣗⢧⢃⠣⡑⢅⠣⡑⢕⢐⢕⢕⢽⢾⢕⢕⡗⣿⢝⡎⣎⢯⢯⢿⣝⣯⢞⠌⣺⠱⣘⠰⡹⣕⢷⢝⡮⡯⣞⣞⣞⣧⢱⠠⠡⣹⢯⡮⡪  ", 25, 21);
            TextIOManager.GetInstance().OutputText("⠫⠻⠳⠫⠳⡯⡺⣜⡝⣾⣻⣻⣟⣿⡿⣝⠔⢅⠣⡣⣫⢞⢕⢕⢕⢕⢕⠽⡀⡀⢀⠀⢸⣺⡽⡺⣜⢔⢬⢆⢮⢎⠈⠐⢸⢝⣞⣞⣞⣞⣞⡮⡗⡅⡃⡊⡢⡣⡑⡑⡐⢕⢕⢽⣫⣟⢮⡺⣯⢗⡕⡵⢽⢽⣳⡳⣯⢯⢂⢗⠱⡑⡕⣝⢮⣳⡻⣮⣻⣪⢷⣻⡧⡣⡡⣑⠌⠑⠉⠈  ", 25, 22);
            TextIOManager.GetInstance().OutputText("⠁⠀⡄⡠⣀⡿⡸⡲⣝⢜⢞⡞⣞⣷⣟⡧⡡⡑⠅⡇⡎⡗⡕⠅⠁⠀⢀⠀⠀⠀⢀⢠⣸⣗⡿⣯⢪⢫⢫⢫⢳⢱⢰⢈⢀⢁⠃⣷⣳⢳⡳⣝⢧⢑⢌⠢⡑⢌⠪⡂⠪⡢⡱⢁⠁⠈⠱⣹⡯⣇⢗⡝⡵⣝⢞⣞⣯⢯⢸⡊⡊⠄⡃⡯⣟⣞⡯⡷⡷⣻⡽⡾⡯⡪⡜⢴⢡⠀⠀⠀   ", 25, 23);
            TextIOManager.GetInstance().OutputText("⠐⠀⣟⣟⣷⡟⡜⡮⡺⡸⣸⣪⡳⣯⣗⡏⡎⢌⠣⡘⡜⡜⡕⡕⡆⠀⠀⢸⣺⣞⣦⡯⣮⡵⣭⣝⣕⢕⢥⢥⢳⣪⢖⢕⢳⢣⠃⣷⡳⣏⡯⡮⡇⢇⠆⢕⢌⢪⠨⠨⡘⢔⢜⠀⠀⠀⢘⢮⣿⢵⣳⢝⣞⢮⡳⡽⣗⣟⢼⠢⠠⠁⢌⣟⣟⣞⢯⢟⢿⡳⡿⡽⡾⡎⠮⡪⡓⢕⢔⢦   ", 25, 24);
            TextIOManager.GetInstance().OutputText("⠐⠔⢏⣗⡭⣹⢪⢪⢗⢕⡕⡵⣝⣞⣗⡏⡎⡂⢕⢌⢪⢪⠢⡪⣕⡵⣵⡲⡽⣾⣳⣯⣷⣻⣳⣻⢮⢙⢜⡬⡪⢮⡺⡸⠜⠎⠎⣷⢯⣳⢽⣪⡇⢇⠣⡑⠔⢔⢅⢑⢘⠔⡕⠀⠀⠄⢨⣗⣟⡿⡾⣿⢽⣿⡽⡿⣗⣗⢽⢥⡱⣕⢵⡹⠾⡻⠿⢿⢿⣻⣿⢾⣷⢿⣷⢸⡪⡏⡣⡫  ", 25, 25);
            TextIOManager.GetInstance().OutputText("⠀⠀⢝⣷⣻⣝⢎⢧⢫⢪⠪⡪⣺⢺⣳⢇⠕⡄⡑⠌⡎⡧⡱⢸⢽⢝⡎⡯⠈⠘⠘⠘⠘⠜⠍⠋⠋⠃⠃⠁⠁⠀⠀⠀⠀⠀⢈⡯⣟⡮⣗⣗⡇⡣⡑⢌⢪⢂⢆⠢⡡⢣⢪⠀⢸⢼⢼⢼⢝⣝⢟⣝⡟⣗⣟⢟⣟⢟⡎⡗⠝⠜⡑⢌⠪⡨⠨⡐⡽⣟⡾⡯⣟⣿⢽⢰⢱⢱⠱⠹   ", 25, 26);
            TextIOManager.GetInstance().OutputText("⠢⠑⠕⢗⠟⢮⢳⡱⡝⡆⢝⢜⢼⢽⣯⡳⡑⠔⠌⠌⢎⢎⠎⠎⠓⠑⠙⠘⠑⠁⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⣿⢽⡽⣳⣳⢕⠕⢌⢪⢢⠢⡑⢕⢌⢢⢣⠀⢸⣯⢯⡯⣳⡳⣫⣗⣯⣞⡮⣗⢯⢿⡽⣽⣻⢕⠰⠠⢱⢑⡑⡌⠈⠀⠈⠈⠈⠈⠉⠃⠑⠑⠀⠀     ", 25, 27);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠐⡵⡱⣣⢣⢣⢳⢝⢽⢸⢱⢨⢑⢍⢎⢂⠇⡇⡃⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⣾⣯⢿⡽⣞⡇⡅⢕⢕⢕⢕⢕⢕⢕⢕⣕⢄⢼⢾⣻⣽⢷⣻⣵⣗⣿⣺⣽⢾⣝⣗⡯⣗⡯⡇⡕⢅⢇⢕⡜⡜⡔⡄⡀⠀⠀⠠⠀⠀⠀⠀⠀⠀        ", 25, 28);
            TextIOManager.GetInstance().OutputText("⡢⠀⠀⠀⠀⢀⢯⣣⢳⢕⣕⢽⠱⡑⡕⢕⢌⢆⢕⠕⡌⡎⡌⢆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠀⠀⠀⢀⢀⢠⣿⣾⢿⣻⣽⡇⣇⢇⣧⡳⡵⡳⡫⡋⢏⠪⠢⢀⢂⢄⡢⡱⠉⠊⠃⠫⠫⠞⠯⡳⠯⠻⢽⢻⢎⢎⢎⠪⠑⠁⠁⠈⠀⠂⠁⠀⠀⠀⠀⠀⠀⠀⠀        ", 25, 29);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⣗⢵⢝⣎⣊⠢⣑⠬⡨⡪⡪⡪⡣⡣⡱⡱⡘⡢⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠀⠀⡴⣔⣌⣌⣂⣑⡑⢕⠫⡛⠏⡛⡓⠍⠣⢑⠑⠌⡊⡨⡨⡢⣪⢪⢮⡚⡮⡪⡣⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀           ", 25, 30);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠈⡮⣏⢯⣺⣺⡕⡜⡜⡸⡸⡸⡨⡪⡸⡨⡪⡸⣘⠀⠀⠀⠀⠀⠀⠀⠁⠁⠐⠀⠀⠀⠀⠀⠀⡯⣟⢷⣻⡯⣷⢿⣻⣽⣾⣵⢷⣖⣮⡆⡆⣇⢧⡳⡵⡵⡝⡮⡳⡱⡱⡱⡱⡸⡀⡀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀          ", 25, 31);
            TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠐⣽⢽⢵⣳⣻⡺⡘⡜⡜⡜⡜⡌⡎⡎⡎⣎⡮⣮⢀⢀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠐⢈⠠⣝⣞⣯⢷⣻⣯⡿⣽⣞⣷⣻⣽⢽⣞⡗⡕⡕⣕⢗⡝⡮⣪⢧⡫⡺⡪⢃⠣⢃⠃⠁⠑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀          ", 25, 32);
            TextIOManager.GetInstance().OutputText("⢀⢀⠠⡠⡠⡢⣿⡯⣟⡷⣯⣷⣕⣵⣕⣧⡣⣎⡮⡞⡞⡗⢏⢏⠢⡑⡠⣡⡥⣣⠀⠀⠀⠀⠀⠀⠨⡨⡪⠯⡞⢽⢺⢽⢝⣮⡻⡽⣞⢷⢿⢾⣻⡮⣇⢎⡮⡺⡜⡎⡝⠜⠜⠘⠁⠄⠠⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀         ", 25, 32);
            TextIOManager.GetInstance().OutputText("⣗⢦⢧⣪⢬⢨⣘⡘⡹⡙⡛⢗⢛⠎⢎⠪⢪⢂⣣⣢⢦⢌⢢⣓⢕⢜⡾⣽⣻⢮⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠁⠁⠁⡁⠁⠉⠋⠙⠪⡫⢯⠺⡸⠪⠊⠊⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀           ", 25, 33);
            TextIOManager.GetInstance().OutputText("⡿⣯⣳⣫⣟⣮⢾⣽⡺⣞⡶⣢⡂⣌⡖⣽⢝⡯⣗⣽⢫⣎⣮⡮⣾⣫⢯⢗⢓⠫⠨⠨⡐⣐⢰⠀⠀⢀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀             ", 25, 34);
        }
        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("잠든 자들의 속삭임 속에, 이승과 저승의 경계가 흐려질것 같다.", 48, 36);
        }
    }
    internal class CemeteryStartScene : CemeteryScene
    {
        public override void Init()
        {
            base.Init();
            trait = PlayerManager.GetInstance().GetPlayer().RandomTrait();

            stopwatch = new Stopwatch();
            stopwatch.Start();
        }
        public override void Update()
        {
        }
        public override void Release()
        {
            stopwatch.Stop();
            stopwatch.Reset();
        }
        public override void Render()
        {
            base.GetSpecificityEvent();
            DrawText();
        }
        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("당신은 으스스한 기운이 감도는 묘지에서 여정을 시작했다.", 48, 36);
        }
    }
}
/*
 * 
 * 
TextIOManager.GetInstance().OutputText("⢿⢿⡯⣻⣹⢌⠌⠂⢈⠘⡘⡈⠀⠀⠀⠀⠀⠀⠈⠝⡿⣟⣟⡟⡟⠟⠝⣴⡿⣿⣿⣿⣯⢰⡀⢔⢧⡛⢿⣿⣿⣿⣿⣿⡟⡮⡧⣳⢥⣹⣽⡿⣿⣿⣿⣿⣿⠿⢿⢵⣿⣟⢿⠟⢛⢿⣿⣿⣿⣿⣗⣿⢽⢿⣿⣿⢟⢷⣷⡯⠁⢙⠃⠀⠀⠀⠀⠀⠈⡘⢌⢪⠀⠅⠨⡻⡅⠈⢜⢦    
TextIOManager.GetInstance().OutputText("⢳⣻⣽⢣⢧⣱⣡⠑⠂⠃⢂⢀⠀⠄⠀⠀⠀⠀⠀⠀⠈⢙⠐⣝⢯⡫⣏⡿⢍⠨⢪⢛⢿⣷⡊⠀⢉⢠⣳⢻⢿⣿⣿⣟⣝⢍⢫⣿⣽⣿⣾⣿⡿⣷⢿⢿⡯⡠⢼⠞⢗⢝⢻⣾⣼⣇⣿⡫⠟⡏⠟⢻⣢⠧⣥⣁⠙⠉⠳⠁⠀⠐⠨⠐⡐⠐⠀⠀⠀⠀⠀⠐⢕⡥⡳⡀⢣⠁⠳⣵    
TextIOManager.GetInstance().OutputText("⢰⠏⠊⣞⡮⣓⢝⢍⠢⠡⠄⠄⢂⠐⢐⠀⠀⠀⠀⠀⠀⠀⠀⠋⠀⢫⢧⢎⠰⢽⢺⠄⠀⣝⣷⣌⡳⣿⢦⠢⢛⣿⣿⢿⢾⢺⢷⣿⣿⣷⣿⣟⣿⣻⣯⣿⡷⣿⢫⣾⡳⡾⣟⣿⣯⣿⣿⣯⣥⣻⣼⣔⠉⠩⠏⠯⠓⠂⠀⠀⠀⢀⢀⠂⠨⢀⢄⠠⠀⠄⠨⢨⢂⢝⢌⡃⢝⣎⠨⣻    
TextIOManager.GetInstance().OutputText("⢽⡥⠎⡂⣆⠧⡪⡪⠳⠡⢁⢂⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠈⣄⢟⢷⠂⢔⢰⢼⣷⣦⣻⣮⢝⢬⣿⡿⣿⢫⣪⣿⣯⣿⣟⡾⢟⣿⣯⣷⣿⡿⣟⣯⣫⢿⣻⣿⢿⣿⡏⣿⡾⣿⡾⡾⣄⢎⢆⢰⡆⡀⣄⠄⡀⠀⢀⠀⠀⠀⠠⢘⢬⢮⡢⣅⠧⢏⠊⡪⣇⢐⢽⣎⢾     
TextIOManager.GetInstance().OutputText("⡟⠔⡨⠜⠊⠄⢌⠢⡡⡂⡐⠀⠁⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡠⡨⡻⢂⢛⢖⢀⡁⣜⣮⣾⣿⣾⡪⣫⣭⢾⣿⣿⣿⠅⣻⢿⢼⣊⠣⢻⣿⣿⣿⣿⣟⠟⢚⣺⣿⢿⣿⣿⣿⢻⠪⣲⡹⡿⡻⡟⡎⡆⢃⢐⡻⠹⡺⡳⠗⠼⠞⢂⠠⠠⡀⢄⠁⡀⡁⡑⠑⢄⠁⠢⢧⡢⡊⣿⡻    
TextIOManager.GetInstance().OutputText("⣅⢗⢷⢬⡒⣝⢴⠸⡐⡲⡐⠈⢐⠀⢐⢀⠀⠀⠀⠀⠀⠀⠀⢀⠹⡽⢾⢶⣿⣯⡯⣿⡿⣿⣻⣿⣟⣿⡿⣿⣿⣿⣯⣿⣿⡿⣼⣽⣾⣅⡠⣿⣿⣿⣿⣿⡶⠏⠉⠏⠎⣮⣿⣭⢐⢙⠁⠋⡃⣔⢗⣗⡟⣄⠳⢜⣴⣢⣬⡢⡨⠀⠀⠀⠁⠌⡂⢇⢐⠀⢌⠈⠊⠳⡐⢵⠌⢓⢻⣿    
TextIOManager.GetInstance().OutputText("⠉⠅⠡⡱⣗⢕⡳⡹⡢⡲⡀⠡⢀⢢⢂⡂⣆⣆⡰⣄⣄⣄⡮⣖⡅⣭⣧⡾⣾⣗⠯⡃⡽⡩⣽⡈⢋⠻⣿⣯⣷⣿⣿⣿⣻⣻⢷⢯⢗⠋⢹⣿⣿⣿⣾⣿⠙⠀⡀⠌⣠⣿⣟⣿⢿⠙⢻⣯⡻⣻⣻⣽⡿⣾⣗⢄⡍⣏⣎⡊⡉⣌⢤⢬⢂⠐⠀⠁⠑⠐⠊⠔⢄⢀⠀⠹⡧⡢⢘⣿  

TextIOManager.GetInstance().OutputText("⣗⣬⢬⣂⣊⢪⠪⡛⢟⢟⠾⡿⡵⠵⢓⢋⠣⠣⢑⢉⡢⣢⡢⣖⣝⢮⢏⣗⢽⢵⣫⣞⢾⣝⢮⡢⡠⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠄⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀             ", 55, 2);
TextIOManager.GetInstance().OutputText("⣿⣺⡽⡾⣝⣗⡯⣞⢶⢔⡥⣂⡂⣁⢢⢰⢬⣪⢾⢕⡯⣳⢝⣮⡺⡽⣕⢯⢯⢻⢚⢎⢗⠍⠃⠃⠃⠪⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀             ", 55, 2);
TextIOManager.GetInstance().OutputText("⣿⢾⣯⣟⣷⣻⣞⡽⣽⢽⣝⢷⡝⣜⢮⡳⡽⣺⢕⡯⡯⣞⡽⡮⡞⡻⡸⡑⠕⠑⠅⠋⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀              ", 55, 2);
TextIOManager.GetInstance().OutputText("⣗⢽⡺⡱⡽⣞⢷⢿⢽⣗⣯⣗⣯⡪⣗⣽⡺⡵⡻⡝⡍⢞⠎⠱⠱⢑⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀               ", 55, 2);
TextIOManager.GetInstance().OutputText("⠀⠐⠈⠋⠚⠜⠵⢻⢕⢗⢝⢗⢗⢏⣗⢜⠪⡎⢧⠳⡨⠠⡢⢄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                ", 55, 2);
TextIOManager.GetInstance().OutputText("⠀⠀⠀⠀⠀⠀⠀⠀⠁⠁⠁⠃⠉⠑⠁⠁⠁⠈⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀                                                      ", 55, 2);
 */