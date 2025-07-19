using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene.Specificity
{
    internal class WildernessScene : SpecificityScene
    {
        public override void Init()
        {
            base.Init();

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
            TextIOManager.GetInstance().OutputText("⢯⢯⡻⡯⣟⣟⢿⢽⢽⢽⢽⢽⢽⢭⢫⡫⣯⡫⢽⢽⣻⢽⣫⢯⢯⢝⢎⢏⢏⢯⢣⢫⡓⡄⠂⠐⠀⠂⠐⠀⠂⠐⠀⠂⠐⢀⠐⠀⠐⢀⠐⠀⠠⠀⠄⠠⠀⠠⠀⢀⠠⠀⡠⡔⡮⣫⢯⣫⢯⣟⡯⣟⢽⣻⢽⣻⢯⣟⢿⣽⣻⣟⣿⣻⣟⣟⡯⣟⣟⣟⣟⣟⣿⣻⢿⡿⣿⣟⣿⣿  ", 25, 1 + 3);
            TextIOManager.GetInstance().OutputText("⡪⡧⣫⢞⢽⢾⡽⣳⢽⢽⢽⡽⣽⣪⡳⡕⣗⢭⣫⣟⣞⣯⣗⢯⢯⡳⡕⣇⢯⢳⡱⡱⡱⡕⡈⢀⠁⡈⢀⠁⡈⢀⠁⡈⠠⠀⠐⠈⡀⠄⠐⠈⠀⠄⠠⠀⠐⠀⠀⠄⠀⡰⣪⢺⣪⢗⣗⢗⡯⣾⢽⣺⢝⡾⡽⣞⡷⣽⢽⣮⢷⣻⣞⣾⣞⢷⢽⣺⣳⣻⢾⢽⢾⡽⣯⢿⣻⣞⣷⣿ ", 25, 2 + 3);
            TextIOManager.GetInstance().OutputText("⣺⢝⢮⡫⣗⣝⢽⠽⣝⢾⡽⣽⡺⣞⣵⡳⣹⡪⣞⣾⢽⣺⣺⢽⣕⣏⢯⡺⡜⣕⢕⢕⡧⡳⡀⠄⠠⠀⠄⠠⠀⠄⠀⠄⠀⠂⠁⠠⠀⡀⠂⠀⡁⠀⠄⠐⠀⠈⠀⡀⢀⢯⣪⡳⣳⣝⡮⡯⣟⡾⣯⣗⢯⢯⣟⣗⡯⣟⣽⣞⡿⣳⡷⣟⡮⡿⣽⣺⢯⡯⣿⢽⡿⣽⢯⣿⣻⣽⣷⣻  ", 25, 3 + 3);
            TextIOManager.GetInstance().OutputText("⣗⡯⣗⢯⡳⣝⢗⣝⢮⡳⣻⢽⢽⢮⡳⣯⢲⢝⣽⣞⣯⢷⢯⣳⣳⡳⣵⣫⡳⣕⢧⢳⡣⡇⡇⠀⠂⠐⠀⠂⠀⠂⠐⠀⢁⠀⢁⠠⠀⠠⠀⠁⠀⠠⠀⠠⠐⠈⠀⢠⢸⢵⢵⢝⣗⡷⡽⣽⣳⣻⣗⡯⣏⣟⣞⣗⣿⢽⣺⢮⣟⣗⡿⡽⡽⣽⣞⡾⡯⣯⣟⣯⡿⣽⢿⣽⣻⣿⣺⣯  ", 25, 4 + 3);
            TextIOManager.GetInstance().OutputText("⣾⣽⡺⡽⣮⢳⣫⡮⡳⣝⢮⢯⢮⢫⢿⡽⣮⣻⣳⣟⣾⣻⣽⣺⡳⣯⣺⢮⢮⢳⢵⣹⡺⡸⡲⡈⠀⡁⢀⠁⢈⠀⡈⡠⡀⠄⢀⠠⠀⠄⠐⠈⠀⠠⠀⢀⠀⠄⠨⡸⡵⣫⣞⡽⣺⡽⣽⣺⣗⢿⣺⣽⣺⢵⣟⣾⡳⡯⣞⡯⣞⡾⡽⡽⣝⡾⡾⣽⣻⣽⢾⣯⣟⣟⣿⣺⣽⣾⡿⣞ ", 25, 5 + 3);
            TextIOManager.GetInstance().OutputText("⣗⡯⣷⣻⡺⣵⢳⢝⡯⡮⣻⣳⢝⢮⣗⡝⣗⡷⣝⢾⣳⣟⣞⡾⣽⣺⣺⢽⢵⢽⣱⣳⣝⢮⣓⢆⡄⠀⠄⠠⠀⠠⡪⡒⢜⢔⠀⠀⡀⠀⠄⠐⠀⠠⠀⠀⠀⠀⢰⡹⡽⣕⢷⢝⣯⣟⣗⡷⣯⣟⣿⣺⣺⡯⣿⣺⢽⣝⣗⡯⣗⣯⢿⢝⣷⣻⡯⣷⣻⢾⣻⣞⣷⣻⢷⣻⣗⣿⣻⣽  ", 25, 6 + 3);
            TextIOManager.GetInstance().OutputText("⡾⣿⣮⣗⡯⣫⢯⡳⡝⡷⣕⢯⢯⢯⢾⣝⢮⢾⣣⢻⢵⣻⢾⢽⡺⡮⡯⡯⣟⢞⡼⡺⣮⡻⡎⣗⢵⠀⠐⠀⠐⡸⡸⡸⢌⢢⠣⠀⠀⡀⠀⡀⠠⠀⠀⠈⠀⡀⣜⢮⢯⢗⡯⡿⣵⣟⣞⣯⢷⡯⣿⣺⣗⢯⢷⡯⣗⣗⣗⣯⣟⣞⣽⡽⣷⢯⣟⡾⣽⣻⣽⢾⣳⣟⣯⡷⣟⣾⣻⣽ ", 25, 7 + 3);
            TextIOManager.GetInstance().OutputText("⣽⣻⡾⣯⣿⣳⢽⣺⢝⡮⡳⣝⢎⢯⣳⣳⢽⡽⣞⣝⢮⡺⣽⢽⢽⣪⢯⡻⡾⡽⣝⣞⣗⡯⡯⡺⡵⡀⠂⠁⠀⡇⣇⢧⢃⢪⢪⢂⠀⠀⠀⠀⠀⠀⠀⠂⠀⢀⢗⡽⡽⣽⢽⢯⣗⣿⣺⢽⡯⣟⣷⣫⢾⢽⣫⣟⢾⡵⣗⣷⣳⣗⡷⣿⣻⣽⢷⣻⡽⣗⡿⣽⣳⣟⣾⣻⣽⢷⣟⣿  ", 25, 8 + 3);
            TextIOManager.GetInstance().OutputText("⢾⣳⡯⣷⣻⣺⢵⢯⣳⢽⣝⢮⢯⡳⣕⢯⢷⢯⣟⢮⢳⢝⢮⢯⣟⢮⣳⡹⡽⣝⢷⢵⢯⡯⣗⢽⢵⠅⠂⢄⢕⡝⡼⣸⢸⠨⡪⡢⠀⠀⠂⠀⠀⠁⠀⠀⠀⢨⢯⢾⢽⣺⢽⣳⢯⢾⣺⢽⡽⡯⣞⢾⢽⣽⣽⢾⢯⣯⢷⣳⣗⣯⢿⣽⣻⣾⣟⣷⣻⣽⢽⣗⡿⣾⢽⣞⣯⢿⣽⢾ ", 25, 9 + 3);
            TextIOManager.GetInstance().OutputText("⣟⣯⡿⣽⣾⣯⢯⣻⢞⣗⡷⡽⣕⢯⣏⢯⣟⣗⣯⢿⢵⢝⣎⢗⣯⣗⢷⢝⣞⢷⣹⢽⢯⣟⡮⣳⢝⠥⡁⣜⢮⢮⢳⡱⡱⡑⡕⡕⠅⠀⡀⠀⠐⠀⠀⠀⠁⣨⣗⡯⣟⣞⡽⣺⢽⢽⣺⣳⢿⢝⣗⣿⢽⢾⡽⣟⡿⣞⣯⢷⣻⢾⣻⣽⣽⣾⢷⣳⣟⣾⣟⣷⣻⣽⡽⣾⡽⣿⢾⡿ ", 25, 10 + 3);
            TextIOManager.GetInstance().OutputText("⣫⡾⣝⣗⣯⢾⣽⡺⡯⣯⡿⣽⢮⣳⢝⡷⡽⡽⣞⣯⢿⣝⡮⣗⡷⣯⣗⢯⢷⢽⣺⢽⢽⣗⡯⣞⢽⢨⢢⢯⡺⡕⣗⢵⢱⠅⡇⣇⠠⡂⡪⡀⠀⠀⠀⠄⠀⣳⢵⢯⣳⢵⣫⢿⣝⣗⡷⣽⢽⢽⡽⣾⣻⡽⣟⣿⡽⣯⢷⣟⣯⡿⣽⢾⡷⣿⣟⣷⣻⢾⣺⣞⡷⣷⣟⣯⢿⢽⢯⢿ ", 25, 11 + 3);
            TextIOManager.GetInstance().OutputText("⣯⣿⣟⣿⢾⢿⡷⣟⡯⣷⢯⣟⣟⣾⢽⣺⣽⣻⡽⣞⣟⡮⣟⣽⢽⣳⣻⣝⣯⣻⢮⢯⢯⣷⡻⡮⣻⢸⢸⣳⢕⢇⢗⢝⡜⡜⣜⡆⡇⡪⠢⡂⠀⠀⠀⠀⠀⡷⣝⢷⢽⢽⣺⡽⣞⣗⣯⢯⡯⡿⣽⡽⣷⣻⣿⣽⢯⡿⣽⣞⡷⣟⣟⣿⣻⣟⣿⡾⣽⣯⢿⢾⣻⣳⢷⡿⣽⢯⣟⣯ ", 25, 12 + 3);
            TextIOManager.GetInstance().OutputText("⡵⡿⣞⣯⡿⣯⢿⡵⡿⡽⣯⢷⣗⣯⣟⣷⣻⣞⣯⣟⣷⣻⣳⢽⣻⣺⡺⣮⡺⣾⢽⣽⡳⣯⢯⢯⢿⣸⢮⢯⣗⢕⢕⢕⢽⢸⢜⡎⡎⡎⢎⢢⢀⠀⡈⠠⠨⡾⡽⡽⣝⡯⡯⣯⡯⣷⢯⢯⢿⢽⢷⣟⣿⣺⢷⣻⡯⣟⣗⣯⢯⣯⡿⣾⣯⡿⣟⣿⣽⢾⣯⡿⣾⢯⣿⣟⣯⡿⣯⡿", 25, 13 + 3);
            TextIOManager.GetInstance().OutputText("⣟⣿⢽⣺⢽⡯⡿⣽⣻⢯⡿⣽⢞⣷⣳⢷⣳⣟⡾⣞⣾⣺⡽⣵⢳⣳⢯⣗⡯⣯⣟⢾⢽⡽⡯⡯⣿⢽⣽⣻⢮⡳⣹⢜⢜⡎⣗⢽⡪⣪⢪⢢⢣⢑⠌⢌⠢⣻⢽⡽⣯⡿⣽⣳⢿⡽⣽⢯⢿⣽⣻⡽⣗⣯⣿⡽⣿⢽⣳⣯⢿⣳⢿⣻⢾⣻⢷⡿⣾⢿⢷⢿⣻⣻⣗⣯⣷⣟⡿⣾", 25, 14 + 3);
            TextIOManager.GetInstance().OutputText("⢾⢽⣻⢾⢷⣻⣻⢷⣯⣟⣾⣝⣟⡾⣽⢯⡿⣞⣿⢽⣞⣷⣻⣽⣻⣪⢿⡮⡯⣷⣻⢽⡽⣽⢯⢯⡾⣟⡷⣯⢷⢝⣞⢼⢵⢝⡎⣗⢕⢧⡣⡣⡣⡣⡑⡅⡣⡺⣽⢽⡯⣟⣷⣻⣽⢯⡯⡿⣽⣺⣗⡿⣯⢷⣳⡿⣯⣟⣿⣺⢯⣟⣽⣟⡿⣽⢷⣻⢽⢽⣝⣗⣗⢗⣗⣿⣺⣳⣟⡾", 25, 15 + 3);
            TextIOManager.GetInstance().OutputText("⢽⡳⡽⣝⣟⡽⣞⢟⢾⣺⡵⣟⡮⣟⡾⣽⢽⣻⡺⡯⡷⣷⣻⣞⡷⣯⢿⢽⡯⣞⡾⡽⡽⣯⢿⡽⡾⣟⣿⢽⣳⣝⢮⡫⣞⢧⡻⣜⡕⣗⢧⡣⣳⢱⢱⢸⢨⢪⡯⣟⣽⢟⣾⣳⢿⢽⡽⣯⢷⣗⣷⣟⣯⡿⣽⣯⢿⢽⣳⣻⣻⢝⣗⣗⡽⣺⢽⡺⣽⣫⣞⣞⣮⣻⣪⡷⣯⢾⣞⢽", 25, 16 + 3);
            TextIOManager.GetInstance().OutputText("⢽⢽⢝⣞⡼⣪⢯⣫⢗⣕⡯⣮⣫⡫⡯⣻⡻⣽⣻⣻⣟⡷⣷⢯⣿⢽⡯⣷⣻⣽⡽⣽⢽⡽⡯⡯⣿⣻⣽⢯⣗⡷⣳⢝⢮⢗⣽⡺⣜⣞⡵⣝⢼⡱⣣⢣⣣⢿⡽⣯⣯⣟⣷⣻⡽⣯⢿⣽⣻⣞⡷⣽⣺⣽⣳⡽⣯⢿⣞⡷⡯⡿⡾⣺⡺⣝⢵⣫⣯⣟⣾⣻⢾⣞⣷⣻⢵⣻⢮⢯", 25, 17 + 3);
            TextIOManager.GetInstance().OutputText("⣽⡪⣗⢗⢯⢷⡵⣝⣽⣺⣺⣺⢳⣟⣟⣗⡯⣗⡵⣳⣳⡽⡽⡽⣺⣽⢽⣳⣻⡺⡽⡽⡯⣟⣟⣯⡿⣽⣾⣻⣳⣝⡷⡽⡵⣯⣺⣺⢵⢕⡯⡮⡣⡯⡺⣜⡾⣯⣟⡷⣯⢿⣽⣳⣟⡯⣟⣞⡷⣽⡹⣵⡻⣞⣯⣿⣽⢯⢗⣯⢯⢏⡯⡮⣺⢪⣳⢯⢾⣺⣽⢾⣻⢵⣳⢽⣵⣫⡯⣟", 25, 18 + 3);
            TextIOManager.GetInstance().OutputText("⡷⡽⣪⢯⢮⡳⣝⢯⢷⢷⣳⣫⣗⣷⣳⢽⡯⣟⣞⡷⣳⣫⣯⣟⣾⣪⢻⡺⣮⡺⣫⢿⢽⢵⢯⣗⢿⡻⡮⣗⣗⢗⡽⣽⢽⡪⣞⢮⢳⡫⣏⢯⡳⡝⣞⡼⣯⢗⡯⡯⡯⣗⣗⢗⣵⢿⢯⣻⣺⢵⢯⡳⣟⣿⣻⢽⢞⢯⡫⣞⢮⡳⣝⢞⢮⣫⢾⣫⣟⣗⡯⣟⣾⢵⢯⢷⣳⢯⢯⢗", 25, 19 + 3);
            TextIOManager.GetInstance().OutputText("⢝⡟⣗⢝⢮⡺⡪⡮⡳⣕⢧⢳⢕⢗⡝⡗⡿⡽⡽⣝⣟⣞⡮⡿⣞⢾⢵⢝⢮⢺⡫⡯⣫⢯⡻⡺⡽⡽⣹⢪⢞⢽⡚⣎⢏⢟⢎⢇⡇⣏⢎⢦⡣⣳⡳⡽⣳⡫⡯⡫⡯⣺⡺⡽⡽⣝⢗⡟⣎⢯⡺⣞⢯⡳⣕⢯⢳⡳⣝⢮⡳⣝⢮⣫⡳⣕⢯⣞⣞⢮⣟⢷⣳⣯⡯⣟⡾⣽⣽⣽", 25, 20 + 3);
            TextIOManager.GetInstance().OutputText("⡣⡫⡎⣗⢕⢧⡫⣎⢧⢳⡱⡝⣎⢇⢯⢺⢜⢮⢺⡸⡲⡱⣣⢫⢎⢞⢎⢧⢳⢕⢇⢯⡪⣺⢸⢕⡝⣜⢎⢧⢫⢎⢞⡜⡵⡹⡪⣣⢫⡪⡳⡱⣝⢲⡱⣝⢲⡱⡝⡎⣏⢮⢎⢗⡝⣜⢕⡝⣜⢵⢹⢜⢮⢺⡸⣕⢝⢮⡪⣳⢹⢜⢵⢕⢽⡸⣕⢵⢵⡹⣜⢵⢝⢮⡫⣫⢏⣗⢵⢵", 25, 21 + 3);
            TextIOManager.GetInstance().OutputText("⢮⡫⡺⣜⢕⢧⢳⡱⣝⢜⡎⡧⡳⡹⣪⢣⡫⡎⡧⡳⡹⡪⡎⡧⡫⣪⡣⡳⡕⣝⢜⡕⣝⢜⢮⢪⢎⢮⢺⡸⡪⡎⣇⢧⢳⢹⡸⡪⡣⣣⢫⢎⢮⢪⢎⢮⡪⣎⢮⢣⡳⡱⡝⡮⡺⡸⣕⢝⡜⣎⢧⢳⢕⢧⢳⡱⣝⢜⢮⡪⡣⣏⢮⢳⢕⢇⡗⣕⢧⢳⢕⡳⡹⣜⢮⡪⣇⢧⢳⡣", 25, 22 + 3);
            TextIOManager.GetInstance().OutputText("⢧⡫⡞⣎⢗⣝⢮⡺⣜⢵⡹⡪⣝⢮⡪⡧⣳⢹⢜⢵⡹⣪⣣⢳⡹⣜⢼⡱⡝⣜⢵⢱⡣⡫⡮⡳⣹⢪⡣⡇⣗⢵⡱⡕⣇⢧⢣⡫⡺⡸⣪⢺⡸⡱⡕⣇⢧⡣⡳⡕⣇⢯⡪⣳⢹⢝⢼⡱⣝⢜⡎⣗⢝⡎⡧⡳⣕⡝⡮⡪⣏⢞⢼⢕⢽⡱⣝⡜⡮⡳⡵⡹⣕⢧⢳⢕⢧⡫⣇⢯", 25, 23 + 3);
            TextIOManager.GetInstance().OutputText("⣪⢮⡫⡮⡳⣕⢧⡳⣕⢗⡝⣞⢎⢧⡳⣝⢼⡱⣝⢵⡹⣜⢼⡱⣣⡳⣕⢵⢝⣜⢎⢧⡫⡺⣪⢫⢎⢧⡳⡹⡜⣎⢮⢺⢜⢎⢧⢳⡹⣪⢺⢜⢎⢗⡝⣜⢎⢮⢳⡹⡜⣎⢞⣜⢵⡹⡵⡹⡼⡱⣝⢼⡱⡝⣎⢗⢵⡹⡪⣏⢮⡳⣝⢮⡳⣕⢧⡫⡮⡳⣝⢞⢼⣪⡳⣝⡕⡧⡳⣝", 25, 24 + 3);
            TextIOManager.GetInstance().OutputText("⢮⡳⣝⢮⡫⡮⣳⡹⡼⣱⢝⣎⢯⡣⣗⢵⢳⡹⣜⢮⡺⣜⢵⡹⣜⢮⢺⢜⢵⢕⢽⡱⡝⡮⣎⢗⡝⡵⡹⣝⡺⡜⣎⢧⡫⡮⡳⡕⡧⡳⣕⢝⣎⢧⡫⡎⣗⢝⢮⡪⡳⡕⣗⢕⢧⢳⡹⡝⡮⣫⢮⡣⣗⢝⣎⢯⡣⣏⢯⣪⡳⣕⢗⡵⣝⢮⡳⣝⢮⡫⡮⣫⡳⡵⣝⢮⡺⣝⣝⢮", 25, 25 + 3);
            TextIOManager.GetInstance().OutputText("⡳⣝⢮⡳⡝⣞⢮⢮⡫⡮⡳⣕⢗⣝⢮⡳⡝⣞⢎⣗⢵⡳⡵⡝⡮⡺⣕⢏⣗⢝⣕⢗⡝⡮⣪⢧⡫⡮⡫⡮⣪⢯⡪⡧⣳⢹⡪⣳⢹⡪⡮⣣⡳⡕⣗⢝⡎⣗⢵⢝⣎⢯⡪⡳⣝⢵⡹⣪⡫⡮⡳⣝⢮⢳⢕⡗⣝⢮⣣⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢞⢮⡳⣝⢮⢮⡳", 25, 26 + 3);
            TextIOManager.GetInstance().OutputText("⣝⢮⡳⣝⢮⡳⣝⢮⡺⣝⡝⡮⡳⣕⢗⣝⢞⢮⡳⣕⢗⡵⣝⢮⡫⣞⢮⡳⡵⡝⣎⢧⡫⣞⢎⡧⡳⣝⢮⢳⢕⢧⡳⣝⢼⢕⣝⢎⣗⢵⢝⢮⣪⢳⢕⡗⣝⢎⣗⢕⢧⡳⡹⣝⢼⢕⣝⢮⢮⡳⣝⢮⡳⣝⢵⢝⢮⡳⣕⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⣫⡳⣝⢮⡳⣳⢝", 25, 27 + 3);
            TextIOManager.GetInstance().OutputText("⡳⡳⣝⢮⡳⣝⢮⡳⣝⢮⡺⣝⣝⢮⡳⣕⢯⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⡵⣝⢮⡳⡳⣝⢮⡳⣹⢕⡗⣝⣕⢯⡣⣗⢵⢳⡳⡵⡝⡮⡮⣳⣣⡳⣝⢵⢝⢮⣣⡳⣝⢵⢝⣝⢮⡳⣝⢮⡳⡵⣝⢮⡳⣝⢮⡳⣝⢵⢝⢮⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⡵⣝⢮⡳⣝⢮⡳", 25, 28 + 3);
            TextIOManager.GetInstance().OutputText("⢽⢝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⡝⣞⢮⡳⡝⣞⢮⡳⣝⢮⡳⣝⢮⢎⣗⢝⢮⡳⡳⣝⢮⣫⡺⡺⣪⢮⡺⣪⡳⣝⢵⢵⢝⢮⡳⣝⢮⡳⣝⢮⡳⡝⣞⢮⡳⣝⢮⡳⣝⢮⡫⣏⡗⣗⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⣳⡫⡯", 25, 29 + 3);

        }

        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("끝없는 모래빛 속에서, 누군가는 사냥감이 될것 같다.", 52, 36);
        }
    }
    internal class WildernessStartScene : WildernessScene
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
        }
        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("당신은 아무것도 없는 드넓은 황야에서 여정을 시작했다.", 48, 36);
        }
    }
}
