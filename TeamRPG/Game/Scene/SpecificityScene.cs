using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene
{
    internal class SpecificityScene : Core.SceneManager.Scene
    {
        public int selectNum = 0;
        protected Stopwatch stopwatch;
        Trait trait;
        public virtual void Init()
        {
            trait = PlayerManager.GetInstance().GetPlayer().RandomTrait();

            selectNum = 0;
        }


        public virtual void Release()
        {
        }

        public virtual void Render()
        {
            DrawMap();

            TextIOManager.GetInstance().OutputSmartText("휴식", 35, 38);
            TextIOManager.GetInstance().OutputSmartText("상인", 55, 38);
            TextIOManager.GetInstance().OutputSmartText("탐색", 75, 38);
            TextIOManager.GetInstance().OutputSmartText("이동", 95, 38);
            TextIOManager.GetInstance().OutputSmartText("상태", 115, 38);

            TextIOManager.GetInstance().OutputText4Byte("▶", 32 + selectNum * 20, 38);
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.Enter))
            {
                switch (selectNum)
                {
                    case 0:
                        SceneManager.GetInstance().ChangeScene("RestScene");
                        break;
                    case 1:
                        SceneManager.GetInstance().ChangeScene("ShopScene");
                        break;
                    case 2:
                        SceneManager.GetInstance().ChangeScene("EncounterScene");
                        break;
                    case 3:
                        SceneManager.GetInstance().ChangeScene("GameScene");
                        break;
                    case 4:
                        SceneManager.GetInstance().ChangeScene("CharInfoScene");
                        break;
                }
            }
        }
        protected virtual void DrawText()
        {

        }
        protected void GetSpecificityEvent()
        {
            if (stopwatch.ElapsedMilliseconds < 8000)
            {
                DrawMap();
                DrawText();
            }
            else if (stopwatch.ElapsedMilliseconds < 14000)
            {
                DrawSpecificity();
                TextIOManager.GetInstance().OutputSmartText($"당신의 특성은 ' {trait.name} ' 입니다.", 48, 36);
            }
            else if (stopwatch.ElapsedMilliseconds < 14500)
            {
                SceneManager.GetInstance().ChangeScene("GameScene");
            }
        }

        private void DrawSpecificity()
        {
            TextIOManager.GetInstance().OutputText("⢌⠢⡁⡢⢂⠌⡐⡐⡐⡐⡐⢐⠐⡀⢂⢐⠐⠄⠅⡂⢐⠐⠐⡀⢂⠂⡁⡂⠅⡂⠅⠂⢌⢐⠨⢐⠨⡐⠨⢐⠨⢐⠨⢐⠌⠢⡑⢌⢌⠪⡨⠪⡨", 48, 1);
            TextIOManager.GetInstance().OutputText("⠢⡑⡐⡐⡐⠨⢐⠠⠂⡀⢂⢐⢀⠂⢂⠀⡂⢁⠂⠂⢂⠨⠐⡀⡂⢂⠂⡂⠅⡐⠈⠌⠄⡂⠌⠄⡂⠌⠌⠄⠌⡐⠨⡐⠌⢌⢐⠔⡠⡑⢌⢊⠢", 48, 2);
            TextIOManager.GetInstance().OutputText("⢅⢂⠢⢂⠌⠨⢀⠂⠡⠐⡀⠂⠄⠨⠀⡂⢐⠠⠈⠌⡀⢂⠁⠄⡐⢀⠂⡐⢀⢂⠡⢁⢂⠢⠨⢐⠠⢁⠊⠌⠢⠨⢂⠢⢑⢐⠄⢅⠢⠨⢂⠌⢌", 48, 3);
            TextIOManager.GetInstance().OutputText("⢐⠠⢑⠐⡈⡐⢐⠈⠄⠅⢂⠡⠈⠄⠡⠐⡀⠄⡁⢂⠐⠠⠈⠄⢂⠐⡀⢂⠐⡀⠂⡂⠄⠂⠌⠄⠌⡐⠨⠨⠨⡈⠢⡈⡂⡂⠪⡐⠌⢌⢂⠪⢐", 48, 4);
            TextIOManager.GetInstance().OutputText("⠢⠨⢐⠐⡐⡈⡐⡈⠌⢐⠀⡂⠡⠈⠄⠡⠀⡂⢐⠠⠈⠄⠡⠈⠄⢂⠐⡀⢂⠂⠡⢐⠈⠌⡐⠡⠡⠨⠨⢈⠢⢈⢂⢂⢂⠪⢐⢐⠡⢂⠢⠑⢄", 48, 5);
            TextIOManager.GetInstance().OutputText("⠨⢐⠐⡈⠄⡂⡐⠠⠈⠄⢂⠐⡈⠠⠁⠂⡁⠄⠂⠠⠁⠌⠄⠡⠈⠄⢂⠐⡠⠨⠈⠄⠌⡐⠄⡑⠨⢈⠌⡐⠨⢐⢐⠐⢄⢑⠐⢄⢑⠐⠌⢌⢐", 48, 6);
            TextIOManager.GetInstance().OutputText("⠈⠄⡂⠄⠡⢀⠂⠌⠠⢁⠐⠠⠐⡀⢁⠂⠄⠂⡁⠌⠐⡀⠅⠨⢈⠐⡐⢐⠐⡈⠌⠨⢐⠠⢁⠂⠅⡂⠢⠨⢈⢐⢐⠨⢐⠠⢑⠐⠄⢅⢑⢐⢐", 48, 7);
            TextIOManager.GetInstance().OutputText("⢈⠐⠠⢈⠈⠄⠂⠡⠈⠄⠨⠐⠐⡀⢂⠐⠠⠁⠄⠂⡁⠄⠨⠐⠐⡐⠐⡐⢐⠠⠁⠅⡂⠌⡐⠨⢐⠠⠡⡁⡂⡂⠢⡈⠢⡈⡂⠅⡑⢐⢐⠐⡐", 48, 8);
            TextIOManager.GetInstance().OutputText("⡂⠨⠐⢐⠈⠄⠡⠈⠄⡁⢂⠁⡂⢐⠠⠈⠄⡁⠂⡁⠄⠨⢀⢁⠡⠐⢐⢀⠂⢄⢑⠐⡐⡐⠄⠅⡂⠌⡐⡐⠠⠂⠅⡂⠅⡂⢂⠅⡂⠅⡂⠌⠄", 48, 9);
            TextIOManager.GetInstance().OutputText("⠠⠁⠌⡀⢂⠁⡁⡁⠡⠐⡀⢂⢐⢀⠂⠅⡂⠄⠡⠐⡈⢐⢀⠂⠄⠅⢂⢐⠨⢀⠂⠌⠄⡂⠌⡐⠄⠅⡂⢂⠅⠅⠅⡂⠅⡂⠅⡂⡂⠅⡂⠅⡑", 48, 10);
            TextIOManager.GetInstance().OutputText("⠌⠄⠅⡐⡀⠢⢐⠠⠨⢀⠂⠔⡀⠢⡈⠢⠨⠨⡊⠔⡀⡂⢐⠈⠄⡁⢂⢐⠈⠄⠌⢂⠡⠠⢁⠂⡁⠢⠈⠄⡂⠅⡊⠄⠅⡂⠅⡂⠄⠅⡂⡁⡂", 48, 11);
            TextIOManager.GetInstance().OutputText("⠅⠅⡊⠄⡂⡑⡐⠨⠠⡁⡊⠔⡈⠢⠨⠨⡈⡂⠢⢑⢐⠨⡀⡂⡡⡰⣔⢤⠈⠄⡁⡂⠄⠅⠂⠌⠄⠅⠅⠅⡢⡁⡂⠅⡂⡂⠅⡂⠅⡡⢂⠐⠄", 48, 12);
            TextIOManager.GetInstance().OutputText("⡅⡅⡂⠅⡂⠔⠠⡁⡂⢂⠂⠅⠌⡨⠈⠔⡐⠨⢈⠐⠄⡂⡂⡂⡂⢳⢱⠫⠨⢐⢀⠂⠌⠄⡑⢈⠄⠅⠌⡐⠔⢌⠢⡁⡂⠄⠅⡂⠅⢂⠂⠅⡁", 48, 13);
            TextIOManager.GetInstance().OutputText("⢣⢣⢣⢣⢣⢪⢢⢢⢢⢡⢌⢐⠡⠠⠡⢁⠂⠅⡂⢅⠑⠌⡂⢆⣪⡮⣯⢷⣥⣂⠂⠌⠄⠅⢂⠂⠌⠄⠅⠢⠡⡑⠨⡐⢄⠅⢅⢢⢸⢰⢸⢸⢰", 48, 14);
            TextIOManager.GetInstance().OutputText("⢊⢂⠣⡑⢅⠣⠱⡑⢕⠱⡡⢣⢙⠜⡸⡐⢅⢕⢐⠄⠅⠅⢌⣯⣗⣯⢿⡽⣞⣞⣇⠅⠅⠡⡂⠌⡌⢔⢅⢣⢱⢘⢜⢌⢆⢇⢇⢇⠣⡣⠣⡣⠣", 48, 15);
            TextIOManager.GetInstance().OutputText("⢐⠄⢕⠐⡄⢅⠕⡨⠠⠡⠨⡐⡐⠡⢂⠌⡂⢂⠢⡁⠣⡉⢲⣻⢾⡽⣯⣟⣯⢻⣞⣎⠌⡊⢌⠪⠨⠢⢑⠡⠡⡡⠡⡡⢑⠌⠢⠨⡨⢂⠕⡨⠨", 48, 16);
            TextIOManager.GetInstance().OutputText("⡑⡌⠢⡑⠌⡎⡪⡢⡡⢃⠕⡐⠌⢌⢂⢂⢂⢂⢂⢊⠌⠌⣞⣯⡿⣽⢷⣻⣮⢂⣿⡺⠐⠨⢐⠨⠨⡈⡂⠅⢅⠢⡑⠄⢕⠨⡘⡨⡐⢔⠡⡂⡑", 48, 17);
            TextIOManager.GetInstance().OutputText("⠣⡊⢌⢢⢣⢣⠪⡘⢔⡁⡂⡂⢅⢂⠢⡁⡂⡊⡐⡐⢨⠨⡾⣯⡿⣯⢿⣳⣯⣟⠞⡠⠡⡑⡐⡕⡕⡢⡪⡊⣆⢕⡅⢕⢐⢅⠢⡂⡪⢠⢑⠰⡐", 48, 18);
            TextIOManager.GetInstance().OutputText("⢃⡪⡸⡸⡸⡰⣑⢮⣳⡳⡴⡸⡐⡥⡕⡔⡕⡌⡂⡪⡂⣇⣿⢿⣽⣟⣯⡿⣞⣷⢁⢪⢨⢢⢣⢣⢣⢳⢸⢪⡺⡸⣪⢲⠰⡘⡜⡌⡪⡢⡑⢌⠢", 48, 19);
            TextIOManager.GetInstance().OutputText("⡗⡜⡜⡔⡱⡸⡮⡯⣺⣝⣞⡇⣇⡯⡯⣎⣞⢮⡊⡆⡕⡼⣾⢿⡷⣟⣷⣟⣯⣿⡕⢅⠣⡊⢎⢎⢎⢞⢜⢕⢕⠝⡜⡜⡕⣕⢕⢅⢃⠢⢊⠐⠄", 48, 20);
            TextIOManager.GetInstance().OutputText("⡇⡇⡇⡇⣗⢯⣻⡺⣳⡣⣗⢽⣺⡺⡝⢎⢪⡳⡕⡜⣜⢮⡿⣯⡻⠫⡓⣿⣽⠞⠩⡂⢕⠨⢂⢑⢌⠪⡨⢂⠅⠕⢌⢊⠪⡂⠇⡅⠕⠨⢐⠈⠄", 48, 21);
            TextIOManager.GetInstance().OutputText("⡇⣇⢧⡳⡽⣝⢞⢮⢳⢙⢎⢣⢳⠹⡈⡢⢃⠇⡗⡝⡎⡗⣿⣟⠜⣬⢮⣿⢾⡬⣌⠎⡂⢅⢑⢐⠐⠅⡊⠔⡁⡣⢑⠄⠕⡨⢊⠔⡡⢑⠐⠌⠄", 48, 22);
            TextIOManager.GetInstance().OutputText("⡝⢜⠢⡣⠫⡪⠪⡑⢌⠆⡢⢑⠐⢅⡂⡪⣐⣅⣂⡪⣌⣊⣿⡇⢥⣿⣻⣽⡿⣯⡿⣽⢦⡂⡢⢂⠅⠅⡂⢅⠢⡊⡂⡪⢐⢐⠅⡪⢐⠅⡪⡘⡌", 48, 23);
            TextIOManager.GetInstance().OutputText("⢌⠢⡃⡪⠨⡂⢕⠨⡂⠕⡠⢑⢨⣞⣮⢷⣳⣗⡷⣽⣺⣳⢿⣶⣽⡷⣟⣿⣽⡷⣿⢯⣿⡽⡶⣔⢨⠨⡢⡡⡑⡌⢆⢊⢢⢑⢌⠢⡱⢨⠢⡑⢌", 48, 24);
            TextIOManager.GetInstance().OutputText("⡢⢣⠱⡘⢌⠢⡑⢌⠢⢑⠌⡂⡻⣽⣟⣿⣽⣾⣟⣿⣽⣯⢿⣾⢷⣿⢿⣟⣷⢿⣻⣯⢷⡿⣿⣳⣥⡣⡣⡱⡸⡌⡎⡎⡢⡣⡢⢃⠪⡂⢕⠰⡐", 48, 25);
            TextIOManager.GetInstance().OutputText("⢘⢔⡑⢜⢨⠨⡨⡢⡱⡱⡨⣢⡱⣹⣯⣿⣽⣾⣿⣽⣾⣟⣿⣽⣿⢽⡿⣟⣿⣻⣿⣾⢿⣟⣿⣻⣽⣮⡳⣝⠼⡸⡈⡢⢊⠔⡨⡘⡜⡎⡮⡪⡸", 48, 26);
            TextIOManager.GetInstance().OutputText("⢇⢕⡜⣆⡣⢅⢣⠎⡞⡝⡝⡎⡏⣧⣻⣽⣯⣷⣿⣯⣷⣿⣯⣷⡿⣯⣿⣽⣯⣿⣷⣿⣿⣟⣯⣿⣽⣯⣷⢵⢵⣔⣌⣢⢑⢌⠢⡪⡘⡜⡪⡪⡣", 48, 27);
            TextIOManager.GetInstance().OutputText("⡕⡇⡗⣕⢕⢅⢕⠌⡆⢕⢅⢕⢌⣿⣯⣷⣿⢿⣽⣯⣿⣾⣯⣷⣿⣿⡾⣿⣾⢿⣯⣿⣷⣿⣿⢿⣯⣿⣯⣿⣿⣽⣿⢾⣷⢌⡪⣆⡣⡣⡣⡕⡜", 48, 28);
            TextIOManager.GetInstance().OutputText("⡣⡳⡱⡱⡕⣕⣵⣻⣞⣿⢦⣳⣼⣾⣯⣿⢿⣿⢿⣿⣽⣾⣿⣯⣷⣿⣿⡿⣿⡿⣿⣽⣾⣷⣿⣿⢿⣟⣿⣿⣽⣷⣿⢿⣻⢤⣟⣯⢿⣺⢾⡜⡜", 48, 29);
            TextIOManager.GetInstance().OutputText("⢣⡣⣣⣿⣽⣯⣿⣽⣯⣿⢿⣻⣯⣷⣿⢿⣿⣻⣿⣟⣯⣿⣷⡿⣯⣷⣿⣿⣿⢿⣟⣿⣽⣿⣷⣿⣿⢿⡿⣾⣿⣻⣽⣿⣟⣯⣷⣟⣯⣿⡽⣧⣷", 48, 30);
            TextIOManager.GetInstance().OutputText("⣜⣼⣺⣽⣾⡿⣾⡿⣾⡿⣿⣿⣻⣽⣿⣻⣽⣿⣯⣿⣿⣿⣽⣿⣿⣿⡿⣿⣾⣿⣿⣿⣟⣯⣿⣾⣿⣻⣿⣻⣾⣿⣻⣷⢿⣻⣽⣿⣽⡾⣟⣿⣽", 48, 31);
            TextIOManager.GetInstance().OutputText("⣾⣻⣟⣿⣽⣿⣟⣿⡿⣿⣟⣯⣿⣟⣯⣿⣟⣯⣿⣯⣷⣿⣿⣯⣿⣾⣿⣿⣿⣻⣽⣾⣿⣿⣿⣻⣽⣿⣻⣿⣽⣾⣿⢿⡿⣟⣿⣽⢷⣿⣟⣯⣿", 48, 32);
            TextIOManager.GetInstance().OutputText("⣾⣟⣿⣻⣽⣾⣿⣽⣿⣟⣿⡿⣟⣿⣿⢿⣿⢿⣻⣽⣿⣻⣾⣿⣟⣿⣿⣽⣾⣿⣿⣿⡿⣷⣿⢿⣟⣯⣿⣿⣻⣯⣿⣟⣿⣟⣿⡾⣿⣷⡿⣿⣽", 48, 33);
            TextIOManager.GetInstance().OutputText("⣽⣯⣿⢿⡿⣟⣯⣿⣾⣿⡿⣿⣿⢿⣻⣿⣿⣿⣿⣿⣟⣿⣿⣷⣿⣿⣾⣿⣻⣽⣿⣾⣿⣿⡿⣿⡿⣿⣻⣽⣿⣯⣷⣿⣯⣿⣟⣿⣿⣷⣿⣿⣿", 48, 34);


        }

        public virtual void Update()
        {
            if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.LeftArrow) && selectNum > 0)
            {
                selectNum--;
            }
            else if (KeyInputManager.GetInstance().GetKeyDown(ConsoleKey.RightArrow) && selectNum < 4)
            {
                selectNum++;
            }
        }

        protected virtual void DrawMap()
        {

        }

    }
}
