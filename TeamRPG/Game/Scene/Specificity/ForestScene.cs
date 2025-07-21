using System.Diagnostics;
using TeamRPG.Core.AnimationManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene.Specificity
{
    internal class ForestScene : SpecificityScene
    {
        public override void Init()
        {
            base.Init();
            SoundManager.GetInstance().PlaySound("Forest", 0.5f);
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
            SoundManager.GetInstance().StopSound("Forest");
        }
        protected override void DrawMap()
        {
            TextIOManager.GetInstance().OutputText("⢯⣿⢿⣻⢵⢾⠪⡨⠪⣿⢿⣗⠜⣜⢜⣾⣿⢵⣟⢜⢜⣿⡝⢸⢸⢮⢽⡳⣼⡞⡗⡧⣝⢆⢥⢓⣕⡵⡻⡺⡸⣕⢕⢕⢝⠮⡱⡳⡓⡿⡹⣺⡺⡸⣺⢮⣫⣞⣟⢮⡮⣰⢔⢌⢔⢕⢕⠝⢜⠕⡧⡳⡧⡫⢺⢵⡳⡯⣺⢵⢯⣻⡪⡷⡽⣽⢽⣞⣿⣻⣺⢗⢯⢾⣿⣻⢎⡞⣟⣿", 25, 1);
            TextIOManager.GetInstance().OutputText("⣿⢿⣿⣻⢸⣟⠑⢎⡑⣿⣻⡵⡳⣪⣾⢿⣻⡺⡮⣎⢷⡿⣕⢕⢏⣗⣯⣷⢻⡪⣳⡽⡮⡟⣞⢍⢜⢪⢪⢪⡓⣎⡎⡎⢆⢣⢱⢐⡂⡙⢮⡳⡽⡕⡗⢤⢂⠳⢝⡗⡯⡻⡮⡫⡺⡘⠆⠅⠌⣇⢗⢅⢯⢺⡸⣹⡺⣝⢮⡫⣗⢗⣝⢯⢯⣞⡿⡼⣯⣷⣯⢯⢏⣿⣻⣽⢵⣫⢮⢾", 25, 2);
            TextIOManager.GetInstance().OutputText("⣿⣻⣽⣟⢠⢟⡔⡔⡗⣷⣳⣯⢞⣞⡾⣿⡳⣫⢯⢯⡿⣽⡣⡣⣻⣼⣾⣭⢵⡻⣝⢮⢳⢝⣜⢴⢝⢬⣝⢵⢝⢞⢞⢽⡱⣕⡕⡕⡕⡌⡆⢝⢜⢖⣥⠳⣝⢕⢥⡢⡂⡣⡕⠬⡪⠨⡑⡕⡕⢕⢕⡅⡇⢷⢕⡮⡾⣽⡹⡹⡸⡪⣞⢽⡯⣾⠽⡾⣯⢷⡿⣝⣗⡿⣟⣯⢧⢣⡯⣿", 25, 3);
            TextIOManager.GetInstance().OutputText("⣽⣿⣽⣟⢼⣝⡊⡇⡎⣿⡿⣿⣽⠯⣪⣿⡺⣪⡯⡿⣝⣗⣷⢿⣻⢿⢕⢕⢳⢝⢞⢜⡎⣟⢮⣳⢝⣎⢎⠗⡝⡕⢕⠵⡙⡎⡮⡪⡣⡍⡣⡣⢫⢪⢪⢰⢢⠳⡹⣕⢗⡎⡪⡃⢣⢃⠆⡕⢌⡂⡇⣳⢸⢕⢯⣻⣪⢷⡹⡕⣕⢵⢵⡱⣿⢿⢅⢻⡏⣿⣻⣼⡪⣿⣻⢿⣪⢟⢼⣽", 25, 4);
            TextIOManager.GetInstance().OutputText("⣽⣾⣷⡇⢵⡓⠕⡊⡊⡿⡯⣟⡧⣻⢼⣿⡎⢾⣽⡿⣻⡯⡯⣚⢾⡏⡆⡧⣳⡳⡱⡵⡹⡜⡮⣎⡇⡏⡇⡏⡎⡎⡆⡥⡱⡘⡌⡎⢞⢝⣎⢿⢐⢕⢕⡝⡜⣜⠸⠐⡨⡚⢆⠪⠢⡁⡁⠣⡑⡱⡱⡕⢕⢝⢕⢵⡳⣽⣕⢝⣼⣱⢳⢽⢽⢿⡨⣽⢷⢿⣻⣞⡮⣺⣿⡽⣗⡽⣽⡿", 25, 5);
            TextIOManager.GetInstance().OutputText("⣿⡿⣾⢧⣫⠃⢕⢔⠦⣟⣯⣷⠫⡪⣽⣷⣿⡟⣿⢸⢸⣿⢕⢵⣿⣳⢣⢏⢮⡪⣗⢽⡪⡮⡯⡺⣪⢳⢕⢧⢣⢇⣇⡪⡪⡪⡪⡪⣆⢗⣜⡜⣎⢆⡥⢣⡙⠌⢜⠰⢨⢊⢆⠥⡃⡎⡆⣇⢪⢪⢪⡺⡰⣝⢽⢕⢯⢗⣗⢯⡺⣜⢽⢜⣿⣯⢗⣽⣟⣿⢿⣎⢯⢿⣽⣟⣗⢽⣾⣏", 25, 6);
            TextIOManager.GetInstance().OutputText("⣿⢿⣻⣯⡯⣪⠳⣱⢝⣞⣷⣻⢬⢼⣿⢏⣷⢯⣿⡕⢽⣿⡕⣽⡾⣞⡵⣹⢵⢳⣕⣗⡽⣪⡳⣝⢮⣳⢝⢗⣝⣗⢵⣣⢧⡣⡎⡮⡪⢧⢣⢇⠇⡗⡭⢥⢣⠣⡣⣣⠢⠡⡁⡃⢕⢽⢸⠸⣔⣕⢗⣝⣞⢮⣫⢮⢏⣯⣯⡳⡕⡕⡝⣜⢼⣿⡳⣵⡿⣟⣟⣷⡰⣹⢿⣗⣿⣻⢯⢮", 25, 7);
            TextIOManager.GetInstance().OutputText("⣾⣿⣟⣷⣇⠱⠩⡊⠪⣿⣾⡯⣪⣿⠏⢌⣾⣺⢷⣟⣼⣷⣟⡿⡾⣽⣚⣞⢽⣫⣺⡺⣚⢮⡺⡵⣹⡪⡏⡮⡪⣎⢗⣕⢗⡳⡹⡪⣎⡣⣕⡝⡮⠪⠢⡂⠋⠕⡐⢄⠑⡕⡐⡈⡢⣃⡳⣹⣚⢾⡹⡼⣪⢎⢎⢮⡻⣜⣾⣽⢸⢸⢸⢎⢮⣿⡏⢼⡿⣿⡹⣽⡫⣪⣿⣿⣺⣿⢹⡪", 25, 8);
            TextIOManager.GetInstance().OutputText("⣿⣯⣿⣞⣧⠡⢑⠨⠨⣿⣽⣟⣾⢇⢅⢅⣿⢾⡻⣽⣸⣷⡿⡡⣻⣳⡱⣹⢕⣕⢮⢣⢣⡣⡗⣝⢕⢇⡇⡯⣫⢮⣣⡳⣝⢮⣣⣫⢖⣗⣵⣈⡪⡬⡢⡄⡂⠅⠂⡂⠡⡈⡪⡜⣘⠪⡺⣸⢪⢣⢣⣫⢧⢳⡱⣱⣫⢎⢾⡯⣳⢩⢇⢇⣓⣿⣗⢺⣿⣟⡟⣿⡮⣪⣷⣿⣷⣻⣕⢗", 25, 9);
            TextIOManager.GetInstance().OutputText("⣿⡷⣿⢮⢿⡨⠠⡑⢭⡿⣯⣿⣟⡴⡚⢅⢟⣿⠹⣽⣺⣽⡎⣮⢳⣝⣞⡽⣱⣳⡽⣜⢏⢞⢜⡼⡕⡕⡕⢧⢇⢇⠎⡎⡄⡧⡳⡱⡣⣗⡕⡵⣫⣞⢷⣝⢶⡲⡒⡢⡑⠜⡘⡌⡀⡱⣹⢸⠸⡱⡱⣺⢵⡱⡪⡺⣾⢥⡹⣷⣸⢇⢇⢇⢪⢾⡷⣽⣷⢿⠬⣻⡧⢱⣻⣯⣷⣟⣇⢓", 25, 10);
            TextIOManager.GetInstance().OutputText("⣿⣻⣟⡯⣻⣧⠑⠌⢼⣿⣻⣯⢣⠑⢜⠌⡽⣾⢑⢜⣾⢿⡪⡞⣕⢗⡗⡯⣺⣺⢍⢎⢎⢮⡳⣝⢮⢇⢏⢮⡣⣳⢹⢼⠽⡎⣇⢗⡽⢜⢎⢏⢖⣕⠯⣞⣵⡳⣳⡹⣰⢄⠑⣅⠦⠉⠈⣊⠢⡁⡃⣗⢿⡸⡱⡯⣾⢔⢝⣿⢾⡱⡱⡑⢕⣿⣟⢾⣻⡿⡸⢸⣿⠶⣿⣿⣟⡾⣗⢕", 25, 11);
            TextIOManager.GetInstance().OutputText("⣿⣿⣽⣯⢳⣟⠌⠌⢜⣷⣿⣟⠄⠣⠡⡃⢯⣟⡗⢰⢽⣿⣽⢱⢪⢮⣇⢯⡳⣝⢜⠴⡹⣸⢸⣺⢜⡪⣸⠱⣪⣪⢞⢇⠫⢹⠩⢍⠏⡇⢕⢕⢔⢬⢕⢕⢗⢝⡵⣺⡢⣅⡆⠌⠦⡠⢀⠈⡆⠈⠆⣺⣽⡎⡒⣯⡷⢑⠁⣿⢿⡸⡸⡸⣘⣾⡗⣿⣟⣿⣜⠯⣿⡺⣟⣷⡿⣽⣯⢢", 25, 12);
            TextIOManager.GetInstance().OutputText("⣿⡾⣷⣻⡽⣽⢌⠪⣾⣿⢿⡽⡨⡪⡨⡊⣺⣽⣝⢜⣿⢿⣾⡐⢕⢯⣞⢽⣪⢗⢽⢭⢲⡪⣺⢸⢳⢸⡲⡞⡍⠆⢇⢪⠱⠑⠥⡡⡈⡈⠢⠪⡢⠩⡈⠊⠐⠌⠪⡳⢝⢗⢝⠦⠪⠘⢢⡀⢱⢀⠂⢽⣺⣇⠎⣿⡝⢐⠅⣿⢽⣗⢜⢌⢎⣾⣷⣻⣽⡷⡣⣑⣿⡽⣿⣿⡽⣞⣷⢱", 25, 13);
            TextIOManager.GetInstance().OutputText("⣷⣿⡿⣷⢹⢿⢅⣿⣿⣻⣿⢯⠪⡘⡌⢆⢸⣺⡗⡸⣽⣿⢳⣯⣪⡿⣜⡽⣪⡳⡱⡹⡱⣹⢪⡳⣵⡻⣱⠡⡣⡫⣣⡒⢥⢣⢣⡫⡣⡬⢪⡢⣙⢊⡢⡅⠄⠀⠀⠀⠀⠙⠄⢀⠀⠀⠀⡘⡺⣔⡄⡽⡽⣇⢨⡿⡇⠀⠄⣿⡝⣿⡘⡐⡵⣿⡿⣽⢿⣝⠘⣒⣟⣿⢿⣾⣻⢽⣻⢬", 25, 14);
            TextIOManager.GetInstance().OutputText("⣾⣟⣿⣻⢜⣿⣳⡿⣯⣿⢿⣽⢘⢌⢊⢎⣔⣿⠨⡘⣿⣽⢨⢺⣗⣿⣯⡏⣾⢸⢺⢸⢸⢸⣕⡿⡕⡝⡎⣗⡽⠝⠆⢣⢃⠪⢘⢘⠜⠜⡒⠪⡨⠳⠰⠨⣁⢀⠀⡂⠢⠐⠔⠐⠀⠂⢑⠀⠬⡆⡉⡿⣸⢿⡸⣟⡧⢡⢑⣽⡇⢽⡧⣳⢝⣽⣿⣻⣿⡳⡕⣕⢽⣿⣻⣯⣿⢺⢿⡲", 25, 15);
            TextIOManager.GetInstance().OutputText("⣿⣽⡿⣯⡳⣯⣿⠇⣟⣾⣿⣗⢕⢱⢑⠄⣿⣽⣢⢑⣿⡯⡢⡱⣹⣿⢷⡏⣾⡘⢜⢎⢪⡾⣽⢞⡧⢞⡚⡕⡕⡕⡈⢢⢠⠈⠀⠂⠁⠂⠄⠀⠘⠘⡝⠬⢒⡜⡬⡦⡈⢀⠀⠀⠈⠀⠂⠠⠈⡇⡐⣯⠫⣿⢿⡿⡇⡂⠆⣟⡇⢸⡿⡸⠔⢽⣿⢽⣾⡇⡎⡎⡪⣿⣯⣿⡾⢬⢿⡧", 25, 16);
            TextIOManager.GetInstance().OutputText("⣻⣽⣿⡿⣽⣿⠣⠡⣻⣿⣻⡮⡣⡳⡐⠕⣿⣽⡞⡰⣿⡽⡐⡌⢾⣻⡿⣕⡗⡕⡬⣣⠯⡽⡵⡫⡇⣇⢲⢱⠸⡨⡪⡂⡂⡉⠜⢔⠀⠁⡑⠀⠁⠑⠈⠏⡚⣜⠜⡖⠨⢄⢁⠀⠀⠀⠀⠀⡀⡷⡀⡿⡄⣿⢿⡿⡧⠘⢬⢺⡯⠀⣿⠏⠀⠸⣿⣻⡷⡇⡕⡢⡱⣸⣿⣯⡿⣸⣻⡽", 25, 17);
            TextIOManager.GetInstance().OutputText("⣿⣯⣿⣽⣿⣽⠪⡨⣯⣿⣯⡟⡎⣎⠌⡊⣿⢾⡇⢺⣟⣿⢨⢪⣹⡿⣯⣗⡯⡪⣪⣫⢞⢽⡪⡯⡪⡢⢣⠣⡑⢌⠪⡪⡒⡄⠄⠀⠑⢀⠀⠀⠀⠀⠀⠀⠈⠈⠃⠑⠈⠀⠀⠀⠀⠀⢀⢐⠄⢽⣒⢽⡣⣹⣿⣟⡏⠄⠱⣹⣯⠐⣿⡁⠠⠐⣿⡯⣿⡇⠌⡢⠪⣺⣽⣾⢿⡸⣺⣯", 25, 18);
            TextIOManager.GetInstance().OutputText("⢷⣿⣿⣽⡿⣾⡑⡐⣯⣷⣿⢞⡕⢜⠌⡆⣿⢿⣝⢸⡿⣯⢸⢐⢭⣿⣗⢧⡻⣸⢻⣘⢸⢵⢝⢎⢯⢺⡸⣲⢸⢰⢐⠈⠀⠑⠅⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠹⣯⡇⠪⣷⡿⡇⠅⢕⡕⣿⣰⢻⡆⠀⠐⣿⡯⣿⡣⡱⢸⠸⡼⣟⣿⢯⡗⢗⣿", 25, 19);
            TextIOManager.GetInstance().OutputText("⣿⣟⣯⣿⡯⣟⡇⡪⣟⣿⣽⢗⡇⡕⡅⢇⢻⣿⡽⡸⣻⣯⢪⠢⣹⣾⢯⣳⢟⢕⢹⡎⢼⣝⢬⣫⠪⡘⡼⡸⡱⡡⠳⠠⠁⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢵⡇⠄⢯⣿⡇⠨⢐⢭⣻⡃⠸⣷⠀⢰⣻⣯⡿⣇⠑⠱⡹⢽⣿⣻⣯⠃⠠⣻", 25, 20);
            TextIOManager.GetInstance().OutputText("⣽⣟⣿⣽⢯⣟⡧⡐⣿⣿⣯⢣⡗⢜⢜⠌⣾⢷⡿⡸⣿⢷⢘⠨⣺⣻⣿⡝⣝⢔⢔⢇⣯⢷⠍⣞⠌⡲⡁⡠⠑⠁⠉⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⢽⣷⡇⢨⢐⡇⣿⠄⠨⣿⡂⢽⢾⣯⢿⡯⢀⢨⠂⣯⢿⡷⣯⠀⠀⢹", 25, 21);
            TextIOManager.GetInstance().OutputText("⣯⣿⣯⡿⡇⣿⢧⠸⣽⣷⣿⢐⡯⣪⢣⠁⣿⢽⣟⢸⣟⣿⡐⠠⣯⡿⣗⡯⣺⢐⢕⣗⣽⢗⢨⡺⢀⢝⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡧⠀⢽⣾⡇⠐⡔⡭⣿⠂⠀⣿⡅⢽⣻⣿⢽⣯⠂⡌⠇⢾⡿⣿⡽⠀⠀⠈", 25, 22);
            TextIOManager.GetInstance().OutputText("⣿⣿⢾⣻⡕⣽⣿⢜⣯⣿⣾⢐⢽⢸⢂⠃⣿⢽⣗⢸⣟⣷⡅⡇⣿⣟⣯⡗⡵⡱⡑⡵⣟⣇⢢⠇⣐⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⣇⠀⢹⢷⡇⠀⡪⡪⣿⡄⢈⣿⡂⣹⣽⣯⢿⣳⡙⢜⠱⢽⡿⣯⢿⢂⠊⠀", 25, 23);
            TextIOManager.GetInstance().OutputText("⣿⣿⣻⣿⡂⡻⣾⢯⣿⣯⡷⢐⢝⢮⠂⡃⣿⢝⡧⢽⡿⣽⢎⢎⣿⣽⢷⣳⢹⡘⢸⣪⡿⡪⢸⢅⡮⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢝⣇⠀⢸⣟⡇⠀⢪⠢⣻⡅⢐⣿⡂⣺⢾⣯⣟⣿⠈⢎⠂⣟⣿⣟⣿⢐⢔⠠", 25, 24);
            TextIOManager.GetInstance().OutputText("⣿⢾⡿⣾⡢⢸⣟⣟⣾⣯⣿⠀⡯⡣⡃⢕⡿⣝⡯⣻⣟⣿⡕⢕⣿⣽⣟⣗⡽⡨⢸⣸⢯⠇⢸⢕⠅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡧⠀⢸⣽⣗⠀⡱⡑⣿⡂⠢⣿⡇⡿⣽⡷⣯⣿⡆⢕⠁⣿⣽⣾⣻⢌⢎⠪", 25, 25);
            TextIOManager.GetInstance().OutputText("⣻⣿⣟⣿⢌⢘⣽⣗⣿⣯⣿⠐⡝⡎⡪⢸⣟⢸⡇⣿⣯⣷⢯⢸⣟⣾⣽⣞⢮⢪⡸⣼⢯⡃⢸⢕⠅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢪⣿⠀⢸⡷⣿⠀⢜⢌⣿⡂⢪⣿⢇⣿⢽⣯⢷⡿⡇⢕⠀⣿⣿⣽⢯⠢⠑⢸", 25, 26);
            TextIOManager.GetInstance().OutputText("⣿⢷⣟⣯⡇⡂⣟⣮⣿⢿⣾⢈⢎⠎⢌⢪⡗⢌⡇⣿⣳⣿⣳⢸⣿⣽⢾⣳⢝⢂⢣⣟⡯⣆⠸⠱⡁⢀⢀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣾⣇⢜⣿⣻⠄⢕⢸⣽⢎⢲⣿⣣⣿⣻⡯⣟⣿⡝⡐⢅⣿⣷⢿⣻⡕⡕⣕", 25, 27);
            TextIOManager.GetInstance().OutputText("⣟⣿⣻⣟⣎⠢⡹⣞⣽⣿⣷⠐⢄⢑⠄⣟⡇⡘⡎⣿⣻⣾⡇⣿⢾⣯⡿⡽⡝⢎⢝⢙⢔⠢⠣⠹⡘⡰⡑⢕⠕⡕⡝⡜⣔⢢⢢⢠⠠⡀⡀⡀⡀⡀⡀⡀⡀⢀⠀⠀⠀⠀⢀⠀⡄⡔⡄⡔⡤⡄⡔⣔⢝⢮⢟⢯⢻⢳⢕⢼⣽⡇⣗⣿⡺⣹⣺⢿⡽⣯⡧⣌⠢⣿⣾⡿⣟⢮⢺⣸", 25, 28);
            TextIOManager.GetInstance().OutputText("⣿⣻⣯⣿⡻⡲⡸⣳⢿⣿⣾⢘⠜⡔⢅⣿⢑⢅⢳⣽⣟⣷⣯⣿⣿⡓⠟⢜⢎⠮⡸⡰⡱⡱⠭⣪⢲⢢⢎⢦⢣⡑⣅⢑⢌⢢⢑⢐⢑⡐⡕⡔⡕⡕⣌⠲⡨⡢⡪⡘⡜⡜⣔⢕⡕⣕⢵⢹⢜⠮⡽⡸⣕⢳⡹⡜⣕⢵⡳⡽⣾⣗⢵⣿⣏⢖⣿⡽⣟⣿⡎⡮⡹⣷⢿⣻⣿⢱⢱⢵", 25, 29);
            TextIOManager.GetInstance().OutputText("⣿⣽⡿⣾⡳⡰⡁⣿⢿⣻⣞⡢⡓⢜⢰⣿⠢⡣⡱⣽⣻⣽⠳⡛⡞⠻⡱⡳⡢⡣⢮⢲⠸⡜⡬⡲⣔⢵⢜⣌⡣⡣⣑⣑⢕⡂⣅⡑⣑⢨⣘⢌⢊⠪⡒⠝⠜⠬⠨⠌⠎⠎⠎⢖⠕⡕⢍⠣⡫⣩⣊⢎⡆⣕⢎⢮⢲⡣⣣⢫⢮⣺⣼⣫⢷⣳⣯⣿⢯⣿⣞⢵⢽⡿⣿⡿⣯⣪⡳⣽", 25, 30);
            TextIOManager.GetInstance().OutputText("⣾⣯⣿⣟⡯⡘⢌⣿⢿⣿⢷⢐⢨⢐⢸⣿⢠⢑⢝⢏⠺⣙⢗⠮⡬⡕⣕⢕⣱⢍⣢⡣⣕⢜⡬⣕⣔⢵⡹⣘⢜⡑⡑⢌⢂⢑⢐⢌⠢⡢⡢⡢⡡⡱⣐⢅⢣⢢⢑⡐⡌⡪⡪⡲⡱⣪⢲⢝⣜⢮⢮⡳⣝⢮⣺⢳⡳⣝⡮⣫⣫⢞⣞⢮⣻⡺⣮⢻⣽⢿⣾⡫⣿⣻⣿⣻⣷⢳⢝⣾", 25, 31);
            TextIOManager.GetInstance().OutputText("⣾⡿⣾⡿⣇⢑⢰⣻⣿⢿⣿⣔⢄⣑⢸⣿⡐⡌⡐⡜⡨⡢⡡⡡⡌⣂⢣⢱⢨⠢⡱⠌⠌⢌⠮⢌⡪⢜⢜⡳⢝⢺⠪⢎⢎⠎⠆⠣⢑⠌⠪⠘⢜⢊⢎⢊⢣⢣⣃⡃⡇⢇⢕⢭⡪⡪⡕⣝⢜⢮⢺⡪⣞⡵⡕⡷⣝⢮⡺⣕⡳⡽⣪⣫⢺⣙⣞⣝⢮⡻⣺⣪⣿⣯⣿⣿⣯⡷⡽⣺", 25, 32);
            TextIOManager.GetInstance().OutputText("⣯⣿⣿⣻⣗⢔⢼⣯⣿⣿⢷⢉⢇⡳⡼⡫⡟⡳⡱⣞⢞⠾⣜⠮⢮⢮⠾⣜⢦⡳⣝⢮⢏⣮⡪⣖⣎⣣⢕⡕⣕⢑⢕⠱⠡⠣⠡⡁⡅⡅⡅⡥⡢⣕⢜⠼⡜⡲⡢⡇⠧⡣⠇⠧⠳⡱⡹⡸⡕⡵⠕⢗⠵⢝⢝⢝⢵⢳⢹⢸⢹⡚⣺⢸⢝⢶⡳⡓⣏⣟⡞⣏⢿⢝⢾⡻⣺⡫⢟⣽", 25, 33);
            TextIOManager.GetInstance().OutputText("⣯⣷⣿⢿⣽⢴⣿⣻⣽⡾⣿⣧⣥⡱⣘⢜⣌⢮⢪⢢⢱⢹⡸⡩⡘⢌⠜⢬⠺⡸⡨⠪⢍⢢⢩⢎⢎⢎⠫⣚⠪⡫⡊⡣⡉⠪⡁⠅⠅⠅⠣⢁⢑⢐⢁⢑⠈⠌⢌⢌⠱⡈⡣⢣⢳⢘⢌⢆⠬⠬⢕⢕⢭⢜⢜⢜⢜⢜⣜⢼⡲⡳⡵⡫⡳⠳⡹⡙⡪⠪⡊⡪⡸⡘⣄⢇⢕⣌⡮⣞", 25, 34);

        }
        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("새가 짖는 소리가들린다....", 65, 36);
        }
    }
    internal class ForestStartScene : ForestScene
    {
        public override void Init()
        {
            base.Init();
            stopwatch = new Stopwatch();
            trait = PlayerManager.GetInstance().GetPlayer().RandomTrait();

            stopwatch.Start();
        }
        public override void Update()
        {
        }
        public override void Release()
        {
            stopwatch.Stop();
            stopwatch.Reset();
            SoundManager.GetInstance().StopSound("Forest");
        }
        public override void Render()
        {
            base.GetSpecificityEvent();
        }
        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("당신은 어둡고 축축한 숲에서 여정을 시작했다.", 48, 36);
        }
    }
}

/*                                                                                 









*/