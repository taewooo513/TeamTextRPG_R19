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
    internal class DevildomScene : SpecificityScene
    {
        public override void Init()
        {
            base.Init();
            SoundManager.GetInstance().PlaySound("DevildomBGM", 0.5f);

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
            SoundManager.GetInstance().StopSound("DevildomBGM");
        }
        protected override void DrawMap()
        {

            TextIOManager.GetInstance().OutputText("⢝⡝⣝⢝⣝⢝⣝⢝⣝⢝⣝⢝⣝⢝⡝⣝⢝⡝⣝⢝⡝⣝⢝⡝⣝⢝⢝⢝⢝⢝⢝⢭⢫⢝⢭⢫⢝⢝⢝⢝⢝⡝⣝⢝⡝⣝⢝⣝⢝⣝⢝⣝⢝⣝⢽⡹⣝⢝⢽⡹⣝⢝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹⣝⢽⡹", 25, 1);
            TextIOManager.GetInstance().OutputText("⣕⢽⡸⣕⢕⢧⢳⢕⢧⢳⢕⢧⢳⢕⢽⡸⡕⣝⢜⢵⢹⢜⢎⢞⢜⢎⢇⢏⢎⢇⢏⢮⢪⢺⢸⢱⢕⢝⢜⢕⢇⢗⢕⢇⢗⡕⣇⢗⢵⢕⢧⡳⣕⢧⡳⡕⡧⣫⢳⢝⡎⡯⡺⣜⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝⢮⡳⣝", 25, 2);
            TextIOManager.GetInstance().OutputText("⢪⢇⢯⡪⡳⡝⡮⡳⡝⡎⡗⣝⢎⢗⡕⣇⢯⢪⡣⡫⡎⡮⡣⡳⡹⡸⡱⡹⡸⡱⡱⡱⡱⡱⡱⡱⡱⡕⡝⡜⣕⢝⢜⡕⡇⣗⢵⡹⣜⢕⢧⢳⢕⢧⡳⡝⡮⣪⢳⢕⡝⡮⡳⣕⢧⡫⣎⢗⡝⡮⡳⣝⢮⡳⣹⢪⡳⣕⢧⡳⣝⢎⢧⡫⡮⡳⣝⢮⡳⣝⢮⢳⢝⢾", 25, 3);
            TextIOManager.GetInstance().OutputText("⢵⢝⢮⣪⢳⢝⡎⣗⢝⢮⢺⡸⣕⢧⡫⣎⢮⢣⡳⡹⡜⡎⣎⢮⢺⢸⢪⢪⠪⡪⠪⡊⡪⠪⡪⡪⡪⡪⡪⡪⡪⡪⡣⣣⢫⢎⢮⢺⡸⡕⣝⢮⡳⡕⣗⢝⢮⡪⡳⡵⣹⢪⡳⣕⢵⢕⢧⡳⣝⢎⢯⡪⡳⣝⢮⢳⢝⢮⡳⣝⢎⢯⡳⣝⢮⡫⡮⡳⣝⢮⡳⣝⢮⣿", 25, 4);
            TextIOManager.GetInstance().OutputText("⡪⡳⣕⢵⢝⢮⡺⣜⢵⡹⣪⢺⢜⢮⢺⡸⣪⢣⡳⡱⡣⡫⡪⡪⡪⡪⡪⠨⡨⡨⡨⡢⡪⡪⡲⡨⡪⡪⡪⡪⡪⡪⡣⡣⡳⡱⣣⢳⢕⡝⡮⡷⡕⣝⢮⡳⣕⢝⢮⢺⡪⡳⡝⡮⣪⢳⢕⢧⢳⡹⣕⢽⡱⡣⣏⢮⡳⡵⣹⡪⣏⢗⣝⢮⡳⣝⢮⡫⡮⡳⣝⢮⡿⣾", 25, 5);
            TextIOManager.GetInstance().OutputText("⢮⡫⣎⢮⡳⣕⢧⡳⣕⢽⡸⣕⢝⡎⡧⡫⡎⡧⡳⡹⡸⡱⡹⡸⡸⡨⠨⢨⢪⢪⣪⢺⢜⢮⡺⣜⢜⢜⢜⢜⢜⢜⢜⢜⢕⡝⣜⢎⢧⢳⡹⣻⣜⢜⢮⡺⣜⢵⡹⣕⢝⢎⠣⡹⡸⡱⡝⣎⢗⢝⢎⢳⢹⡺⣜⢕⡗⣝⢮⡺⣪⡳⣕⢇⢯⣪⢳⢝⢮⡫⡮⣳⣟⣯", 25, 6);
            TextIOManager.GetInstance().OutputText("⢕⢽⡸⣕⢽⢜⢮⡺⣜⢵⡹⣜⢵⢹⡪⡇⡯⡺⣸⢱⡹⡸⡪⡪⡪⠨⠨⡪⡪⡧⡳⣝⢮⡳⣝⢮⡣⡇⡇⡇⡇⡇⡇⡏⡮⡪⣎⢮⢳⢕⢽⢽⣮⢳⢕⢧⡳⣕⢽⢸⢘⢐⢕⢕⢕⢕⢕⢅⢕⢕⢕⢕⢕⢝⢮⢳⡹⡪⣇⢯⣪⡺⣜⡕⣗⢵⢝⣕⢗⣝⢮⣻⣽⣻", 25, 7);
            TextIOManager.GetInstance().OutputText("⡹⣕⢝⢮⡳⣝⢮⡺⣜⢕⡇⣗⢝⡎⣞⢜⡎⡧⡳⡱⡱⡕⣕⢕⠅⠅⢕⢕⢝⢮⡫⣎⢗⡝⡮⡳⣝⢼⢸⢸⢸⢸⢸⢪⢺⢸⡪⡎⣗⢝⢮⢿⣻⣜⢕⢧⡳⡑⡑⡐⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢕⢝⢕⢝⢜⢜⢜⢜⢮⡪⣞⢮⡳⣕⢗⣕⢗⣕⢿⣞⡿", 25, 8);
            TextIOManager.GetInstance().OutputText("⢹⡪⣫⡺⣜⢮⡳⣕⢧⡳⣝⢎⢧⡫⣎⢧⢳⡹⡸⡕⡵⡱⡱⡱⡱⡑⡐⢕⢝⢜⢞⢼⢕⣝⢮⢳⡱⡕⡕⡕⡕⡕⣕⢵⢹⡸⡜⡮⣪⢳⢽⣟⣿⣎⢯⢺⢜⢆⢊⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢺⢜⢵⢝⢮⡳⣕⢗⢵⣻⣽⢿", 25, 9);
            TextIOManager.GetInstance().OutputText("⢕⢝⢜⢮⡪⡳⣝⢮⡳⡹⣜⢕⢧⡳⣕⢽⢸⡪⣣⢳⢱⡹⡸⡪⡪⡪⡌⠢⡑⢕⢝⢜⢕⢵⢹⢸⢸⢸⢸⢸⢸⢸⢸⡸⡜⣜⢎⢞⡜⣎⢿⣽⡿⣮⢣⢣⢣⡑⡕⡕⡕⡕⣕⢕⡕⣕⢕⡕⣕⢵⢱⢕⢵⢱⡱⡱⣱⢱⢱⢱⢱⢱⢱⢱⡱⣯⢣⡫⡎⡯⣺⣺⣽⢿", 25, 10);
            TextIOManager.GetInstance().OutputText("⢕⢧⢳⢕⡝⣞⢼⡱⡝⣞⢼⡹⣪⢺⢜⡎⡧⡳⡱⡱⡣⡣⡳⡱⡱⡱⡱⡱⡌⡆⡢⡁⡷⡅⡕⡕⡕⡕⡕⡕⡕⣕⢕⡕⡵⡱⡣⡇⣗⢕⢿⣽⢿⣻⡵⣹⢪⢎⡗⣝⢮⡣⡳⣕⢝⢮⢳⡹⣜⢮⢳⡹⣪⢳⡹⡪⡪⡪⡪⣪⢮⢪⢪⢪⡿⣯⣗⢝⢮⡳⣯⡿⣾⣿", 25, 11);
            TextIOManager.GetInstance().OutputText("⢎⢗⡝⡮⡺⡪⣇⢯⡺⣜⢵⡹⡜⣎⢧⢳⡹⡜⣕⢕⢕⢝⢜⢎⢮⢪⢪⢪⢪⢪⢪⣪⣿⣗⢕⢕⢕⢕⢕⢕⢝⢜⡜⡜⣎⢮⢣⡫⣎⢮⣻⣽⡿⣿⡕⡧⡫⣎⢎⢎⢮⡪⣳⢱⡝⡮⡳⣹⢪⢎⢗⢝⢜⢜⢜⢜⢜⢜⢜⢜⣿⢸⢸⣺⣟⣿⢮⢪⢳⢿⣽⣟⣿⣾", 25, 12);
            TextIOManager.GetInstance().OutputText("⡪⣳⢹⡪⣫⡺⣜⢕⢧⢳⢕⢇⢯⢪⢎⢧⢳⢹⡸⡜⣕⢝⢜⢎⢎⢎⢇⢇⢇⢇⢇⣿⢾⣽⡪⡪⡪⡪⡪⡪⡣⡣⡣⣫⢪⢎⢇⢧⢣⡳⣽⢷⣿⣻⣗⢝⢮⢪⡳⡹⡜⡎⡎⣾⡇⡇⡏⡎⡎⡇⡏⡎⢎⢎⢎⢎⢎⢎⢎⢗⣽⢪⢪⣾⣯⡿⣯⢪⣺⣟⣾⢯⣷⡿", 25, 13);
            TextIOManager.GetInstance().OutputText("⢝⡜⡵⡹⡜⣎⢮⢳⡹⡜⡵⡹⡜⡕⡇⡗⣕⢵⢱⢱⢱⢕⢇⢗⢕⢇⢗⢕⢝⢜⢼⣯⡿⣯⣿⡪⡪⡪⡪⡣⡫⡪⡣⡣⡣⡳⡹⡸⡱⡕⣿⣻⡾⣯⣿⢜⢕⢇⢗⢝⢜⢜⢜⣿⢷⣕⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢎⢎⢗⣯⢎⢞⣾⢷⣿⣻⣼⢾⣻⣾⢿⣯⣿", 25, 14);
            TextIOManager.GetInstance().OutputText("⡪⡺⡸⡱⡹⡘⢎⢧⢳⡱⡝⡜⡎⡇⣏⢮⢪⢪⢮⢪⢎⢎⢮⢪⡪⡎⡮⡪⡣⣳⣽⢿⣽⡿⣽⣇⢇⢧⢳⢱⢹⢸⢪⢣⢫⡪⡎⡇⡗⣕⣯⣷⢿⣯⡿⣇⢏⡎⡇⡣⡑⢕⢿⣻⡿⣽⡜⡜⡜⡜⡜⡜⡜⡜⡜⡕⡕⡕⡕⡽⣾⡘⣼⣟⣿⢾⣯⢿⣻⣯⣿⣻⣽⣾", 25, 15);
            TextIOManager.GetInstance().OutputText("⢸⠸⡸⡨⡪⡪⡘⡜⣜⢜⢜⢜⢎⢎⢎⢎⢎⢎⣷⢱⢱⢱⢱⢱⢱⢱⢱⢱⢱⢽⣾⡿⣷⢿⣻⣗⢕⢕⢽⣇⢇⢧⢣⡣⡣⡣⡣⡣⡓⢔⡿⣾⣟⣷⡿⣿⢸⡸⡸⡨⡪⡪⣿⣯⡿⣯⣗⢕⢽⡜⡜⣜⢜⢎⢎⢎⢎⢎⢎⢯⣗⣗⣯⢿⡾⣿⣽⢿⣯⣷⢿⣽⣯⣿", 25, 16);
            TextIOManager.GetInstance().OutputText("⢸⢸⢸⢸⢸⢸⢨⠪⡪⡪⡪⡪⡪⡪⡪⡪⡪⣪⣿⡜⡜⡜⡜⡜⡜⡜⣮⢣⣓⣿⣻⣽⣟⣿⣻⣯⢪⢪⣺⡷⡱⡱⡱⡱⠱⡱⡱⡱⡱⡱⣿⣻⡾⣯⣿⢿⡕⡕⡕⢕⢌⠪⣷⢿⣽⢿⣽⢮⣿⣻⢜⢜⢜⢜⢜⢜⢜⢜⢜⣽⣺⡳⣯⢫⢿⢽⢾⣻⡷⣿⣻⣟⣾⢿", 25, 17);
            TextIOManager.GetInstance().OutputText("⢵⢱⢱⢱⢱⢱⢱⢱⢸⢸⢸⢸⢸⢸⢸⢸⠸⣼⢷⡏⡎⡎⡎⣮⢪⢪⣺⡷⣵⡿⣽⡳⣯⣷⢿⣾⣻⣼⡾⣿⡸⡸⡸⡨⡪⡪⡪⡾⣎⢮⣟⣷⢿⣻⣽⡿⣯⢪⢪⢢⢣⢝⣾⢿⣻⡿⣽⢿⣽⣟⡎⣎⢾⣜⢜⢜⢜⢜⢜⣞⡾⣽⣺⢕⢽⣝⡯⣷⣟⣿⣽⢿⣽⣿", 25, 18);
            TextIOManager.GetInstance().OutputText("⢽⡎⡎⡎⡎⡎⡎⡎⡎⡎⡎⡮⡪⡎⡇⡗⣝⣽⡿⡕⡕⣕⣽⣿⡘⣖⣯⡿⣯⢟⣽⡯⡷⣟⣿⣳⣟⡷⣿⢿⡎⡎⡎⡎⡎⡎⣮⡿⣯⣺⣾⣻⣟⣯⣷⣿⢿⡕⢕⢕⢕⢵⣻⣿⣻⣟⣿⣻⡷⣿⡎⡮⣳⡽⣳⡕⡝⡮⣟⡾⣝⡷⣽⢕⡯⡾⡽⣕⢯⣷⢿⣻⡷⣿", 25, 19);
            TextIOManager.GetInstance().OutputText("⢽⢎⢾⢘⢜⢜⢜⢜⢼⢸⢸⡸⣸⢜⢜⢜⢔⣯⣿⡣⡣⣳⡿⣾⢧⣿⢿⣽⣯⣯⣷⣿⣽⣟⣯⣷⣯⢿⣽⢿⡯⡪⡪⡪⡪⡪⣺⣟⣿⣽⣾⣽⢾⣻⣾⣽⢿⣯⡎⣎⢾⣯⣿⢾⣯⡿⣾⣯⢿⣯⣷⣫⢷⣻⡳⣯⡪⡯⣗⡯⣗⡿⡽⡽⡽⡽⡽⣎⣟⣾⢿⣻⣟⣿", 25, 20);
            TextIOManager.GetInstance().OutputText("⣽⢸⡽⡸⡰⡑⢕⢕⡯⡪⡪⡮⣿⢜⢜⢜⢜⣷⢿⡪⣪⣿⣻⣟⣿⣽⢿⣻⣾⣯⣿⢾⣳⡿⣯⣷⣟⣿⣻⣟⣿⡸⡸⡸⡸⣸⡽⣯⣷⢿⡾⣾⣟⡿⣞⣯⣿⢷⣿⢼⡿⣷⢿⣻⣽⣟⣿⢾⣟⣷⢿⣺⣻⣳⢽⣺⢮⢯⣗⢯⣗⡯⣟⡽⡽⡽⣽⡺⡼⣾⣿⣻⣽⣟", 25, 21);
            TextIOManager.GetInstance().OutputText("⢵⡳⡽⡸⡸⡸⡰⣹⣗⢕⣽⣟⡿⣇⢇⢇⢽⣽⡿⣇⣿⣽⣯⡿⣞⣯⣿⣟⣷⢿⣾⣿⣻⣟⣿⣞⣯⣿⡽⣯⣿⡪⡪⡪⡪⣺⣽⣻⡾⣟⣿⣗⣿⣻⢿⣽⣾⢿⣯⣿⣻⣟⣿⣻⣯⣿⣽⢿⣽⡾⣟⣯⣿⣪⢟⡾⣝⣗⡽⣳⡳⣽⣳⣫⢯⡻⡮⡯⣟⣷⢿⣽⣯⣿", 25, 22);
            TextIOManager.GetInstance().OutputText("⢷⡹⡇⡇⡇⡇⢇⡿⣗⢕⢷⣟⣿⣻⢜⢜⣼⣯⡿⣯⣿⢾⡷⣿⣟⣿⢾⣻⣾⣟⣷⣿⣽⣯⣷⢿⣻⣾⣽⢷⣻⡷⡕⡕⡕⣟⣾⣯⡿⣟⣷⣟⡾⣯⣿⣳⢿⣽⢷⡿⣽⣯⣿⣽⢷⡿⣾⢿⣽⢿⡽⣟⣾⣪⢟⣞⣵⡳⣝⢷⢽⣺⣺⣪⢯⢯⣟⣿⣻⣽⣿⣻⡾⣷", 25, 23);
            TextIOManager.GetInstance().OutputText("⣗⡯⣗⢕⢕⢕⢵⣿⢿⢸⣽⡿⣽⣯⡇⣇⣷⣿⣻⣟⣾⣿⣻⣟⣾⣻⣽⢿⡾⣯⣿⢾⡷⣿⢾⡿⣯⣷⢿⣻⣯⢿⣇⢇⢽⡽⣞⣷⡿⣟⣷⣟⣿⣽⢾⣯⣿⡾⣿⣻⡿⣾⢷⣟⣿⣻⣟⣯⣿⣻⣽⣟⡾⡮⣻⣺⡺⣺⢽⣯⢗⣗⣗⢗⡯⣗⣿⣳⣿⣽⣾⣻⣟⣯", 25, 24);
            TextIOManager.GetInstance().OutputText("⢵⢯⢗⢕⢕⢕⣽⣟⣿⣞⣯⣿⣟⣾⡗⣼⣟⣾⣯⡿⣷⢿⣽⣯⢿⣽⢾⣻⣟⣿⡾⣿⣻⣟⣿⣻⣯⣿⣻⣯⡿⣯⣷⠱⣽⢽⡽⣷⡿⣟⣯⣿⣳⣿⣻⣷⣻⣽⡿⣽⢿⣽⡿⣽⣯⣿⡽⣟⣾⣯⡷⣷⣻⢽⣕⢷⢝⣗⡿⣾⣝⣞⢮⢯⣺⡳⣯⡿⣾⢷⣿⣽⣯⣿", 25, 25);
            TextIOManager.GetInstance().OutputText("⢯⢯⢇⢇⢿⢜⣾⣟⣷⣟⣯⣷⢿⣳⡿⣞⣯⣿⢾⣟⣿⣻⡷⣟⣿⣽⢯⣿⣽⡷⣿⣻⣽⣾⣯⡿⣾⣯⡿⣾⣻⣟⣾⡽⣽⢽⡯⣿⣻⣟⣯⣿⣽⡾⣟⣾⣯⣷⡿⣿⣻⣷⢿⣟⣷⢿⣽⣟⣷⢯⢟⣗⣯⢷⣳⡫⡯⣞⣯⢷⣳⡳⣝⢗⢕⢝⣷⣟⣿⣻⡷⣿⢾⣷", 25, 26);
            TextIOManager.GetInstance().OutputText("⢽⣝⢧⢫⢯⣟⣯⣿⢷⣟⣯⣿⣻⣟⣿⣻⣽⣟⣿⣽⣯⣷⡿⣟⣷⣟⣿⣞⣷⢿⣟⣯⣿⢾⡷⣿⢿⣾⣻⣯⣿⢽⣯⡯⣯⢯⣟⣯⣿⡽⣿⢾⡷⣿⣟⣿⢾⡷⣿⣻⣽⣾⢿⣻⣽⣿⣻⡺⣪⢗⡽⣺⡪⣟⣞⡮⡯⡷⡯⣟⡞⡎⡇⡧⣳⡽⣾⢯⣿⡽⣟⣯⣿⣾", 25, 27);
            TextIOManager.GetInstance().OutputText("⢵⣫⣗⢯⣗⣿⣯⣿⣻⣽⣯⣿⣽⣻⣾⣻⡷⣿⣽⣾⢷⣟⣿⣻⣽⣾⢷⡿⣽⢿⣽⢿⡾⣟⣿⣻⣯⣷⡿⣷⣟⣿⣳⣿⢽⡽⣾⣻⣾⣻⣟⣯⣿⣯⢿⡾⣟⣿⢯⣿⣽⣾⢿⣿⣽⡾⣗⢽⡪⣗⡝⡮⡺⡪⣞⣽⡽⣯⡯⡷⣝⣜⣮⣾⣳⣿⣻⣯⣷⡿⣟⣯⣷⢿", 25, 28);
            TextIOManager.GetInstance().OutputText("⣻⣺⣪⣗⣗⣿⣞⣷⣻⣽⣾⢷⡿⣽⣾⢿⣽⢿⣾⣻⡿⣽⣯⣿⣻⡾⣟⣿⣟⣿⣽⣟⣿⣻⣯⡿⣾⣯⣿⣻⣾⣯⡿⣾⢿⣽⢿⣽⣾⣯⣿⣽⡾⣯⡿⣟⣿⣽⣿⣽⣾⣻⣯⣷⡯⣟⢮⣳⢝⢮⡪⣇⢯⡪⣺⣺⣻⡽⣯⢿⣯⢿⡾⣷⢿⣾⣻⡾⣷⢿⣟⣯⣿⣻", 25, 29);
            TextIOManager.GetInstance().OutputText("⣽⣺⡺⣪⢾⣳⣯⣷⢿⣻⣾⢿⣻⣿⣽⣟⣿⣻⣽⡷⣿⣟⣷⢿⣽⣟⣿⣽⣯⣿⢾⣯⣿⣽⣾⣟⣿⢾⡷⣟⣷⣯⣿⣻⡿⣽⣿⣽⡾⣷⣻⡾⣟⣯⣿⢿⣽⡾⣷⢿⣾⣻⡾⣷⢿⢽⢕⣗⢯⡳⣝⢮⡳⣹⣺⡽⣯⢿⡽⣿⡽⣟⣿⣽⢿⡾⣯⣿⣻⡿⣽⣟⣾⣟", 25, 30);
            TextIOManager.GetInstance().OutputText("⣻⡸⡸⣸⡿⣽⡷⣿⣻⡿⣽⣿⣻⡷⣯⣿⡽⣯⣷⡿⣿⡽⣟⣿⣽⣾⢿⡾⣷⣟⣿⢷⡿⣾⢷⣿⣽⣟⣿⣻⣽⣾⣯⣷⡿⣿⢾⡷⣿⣻⣽⣟⣿⢯⣿⣻⡷⣿⣟⣿⢷⣟⣿⣻⡿⡽⣕⢯⡳⣝⢮⡳⡕⣕⢮⢾⣻⣽⢿⣽⣟⣯⣷⣟⣿⣻⣯⣿⣳⣿⣻⣽⢷⣻", 25, 31);
            TextIOManager.GetInstance().OutputText("⣯⢎⢮⣷⢿⣯⡿⣯⣿⣻⢿⡾⣯⣿⢿⣾⣻⣯⣷⡿⣟⣿⣻⣽⡷⣟⣿⣻⣽⣾⣟⣯⣿⣟⣿⣳⡿⣾⢯⣿⣽⡾⣷⣻⣽⣟⣯⣿⢯⡿⣷⢿⣽⢿⣽⢷⣿⣻⣽⣯⡿⣯⣿⡽⣿⣝⢮⢗⡽⡪⣇⢗⣝⢮⣳⣟⣯⣿⣻⢷⣻⣽⣾⣻⡾⣯⣷⣿⣽⡾⣯⣿⣻⣯", 25, 32);
            TextIOManager.GetInstance().OutputText("⢯⡳⣽⣾⣟⣷⢿⣻⣾⣻⣟⣿⣻⣾⣟⣷⣟⣷⢿⣽⢿⣯⣿⣽⣟⣿⣽⣯⡿⣞⣯⡿⣾⢯⣿⡽⣿⡽⣟⣷⢿⣽⢿⣽⢷⡿⣽⣾⢿⣻⣟⣯⣿⣻⣽⣿⣽⣯⣷⣟⣿⣻⣾⣻⣟⡾⣝⡵⣫⣳⣕⣯⡺⡵⣳⣯⡷⣿⡽⣟⣯⡿⣞⣯⡿⣯⣷⡿⣞⣿⣽⣾⣻⢾", 25, 33);
            TextIOManager.GetInstance().OutputText("⣟⣾⣻⣾⣻⡾⣟⣿⢾⣯⢿⣾⣻⣾⣻⣾⣻⡾⣟⣯⣿⢷⡿⣞⣯⣷⢿⣞⣿⣻⣽⣟⣿⣻⡷⣿⣯⢿⣻⣽⢿⣽⢿⡽⣟⣟⣯⣿⣻⣯⢿⣽⡾⣟⣷⢿⣞⣷⢿⣽⣯⢿⡾⣯⣿⣽⣺⣺⣗⡿⣾⣗⡯⡯⣞⣷⣟⣯⣿⣻⣽⣟⣿⡽⣟⣯⣷⣿⢿⣽⡾⣷⣻⣟", 25, 34);
        }

        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("끝없는 혼돈의 땅, 공포라는 말이 실체화 된듯 공기마서 서늘하며 뜨겁다.", 42, 36);
        }
    }
    internal class DevildomStartScene : DevildomScene
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
            SoundManager.GetInstance().StopSound("DevildomBGM");

        }
        public override void Render()
        {
            base.GetSpecificityEvent();
        }
        protected override void DrawText()
        {
            TextIOManager.GetInstance().OutputSmartText("당신은 스산한 기운이 감도는 마계에서 여정을 시작했다.", 48, 36);

        }
    }

}
