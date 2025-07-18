
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.SceneManager;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Object.Enemy
{


    public class Slime : Enemy
    {
        //RawText BossText;      //당장은 필요 없음   //릴리즈 > ui매니저 > 클리어 // 씬에서!
        //Text titleText;
        //Text effectText;
        //Text descriptionText;
        //RawText leftText;

        RawText BossText;

        string boss = """     


            """;

        string bossEx = """      
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀

            """;

        //몬스터 위치잡는 로직?
        int x = 0;
        int y = 0;
        string gNum = "";
        string name;
        public Slime(int _x, int _y, string _num) // default는 중앙으로잡고 거기서 위치를잡게끔
        {
            gNum = _num;
            name = " ??? " + gNum;
            x = _x;
            y = _y;
        }

        //fireText = new RawText(fireImage, UIManager.HalfWidth, 2, HorizontalAlign.Center);

        public override void Init()
        {
            //state.name = name;
            //SoundManager.GetInstance().PlaySound("BossmainTheme", 1f); // 몬스터 대신 씬에 넣기
            BossText = new RawText(boss, UIManager.HalfWidth, 2, HorizontalAlign.Center);
        }
        public override void SelectEnemy()
        {
            TextIOManager.GetInstance().OutputText4Byte("▶", 129 + x, 2 + y);
        }

        protected override void DrawImage()
        {
            // 패링페이즈 비활성화 일 경우 아래 이미지, 활성화일경우 else 문으로 가서 패링이미지
            if (base.isExSkill == false)
            {
                BossText.SetText(boss);
            }
            else
            {
                BossText.SetText(bossEx);
            }
        }
        protected override void SettingExSkill()
        {
            base.SettingExSkill();
            SoundManager.GetInstance().PlaySound("..", 0.8f);
        }

        protected override void ExSkill()
        {
            base.ExSkill();
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Object.UI;

namespace TeamRPG.Game.Object.Enemy
{
    public class Slime : Enemy
    {
        RawText nameText;
        RawText imageText;
        string normalImage = """
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⢀⣀⣀⣀⣀⣀⡀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣤⢲⡹⡕⡳⡱⡣⣫⢺⡸⢭⢫⡳⡲⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣔⢾⢹⠸⡘⠌⠌⠨⠨⢈⠢⡑⢕⢕⢕⢕⢝⢜⢝⢦⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣶⣫⢳⢑⢕⠑⡀⠅⠌⠈⠌⠢⡱⡘⠈⠂⢇⢆⠕⢌⠪⡪⡺⣣⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⡤⡲⡱⠹⡱⣓⢦⢄⡀⠀⠀⠀⠀⢀⢀⡠⣰⣼⣳⡳⡑⢕⢐⠐⡀⡂⠄⠸⠷⠀⠨⡢⠀⠻⠇⠀⡕⡍⢆⢕⠸⡸⡸⣪⡳⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⢀⣞⢕⠌⠄⠡⡈⢆⢣⢣⡹⣕⢷⣳⡯⣗⣷⢟⡟⡎⡎⡪⡈⠢⠐⣰⡦⣦⣡⢠⠐⡄⢕⢜⢌⢆⢆⣕⣕⣕⢕⢌⠪⡢⡑⡢⡫⡺⡽⡤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⣀⢮⢮⢣⠡⠁⢅⢐⡐⣕⣕⢗⡽⣝⢵⡫⣗⢝⢕⠕⢕⢐⢐⠠⠁⠅⠄⠛⢯⢿⣽⣟⡾⣷⣻⡾⣽⣟⣾⣽⡾⡣⡱⡑⢔⢌⢢⠱⡱⡱⡹⡕⡯⡷⡶⣔⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⢠⣰⢯⢫⢣⢳⢱⢕⢽⢜⣜⢮⡺⣜⡕⣗⢕⡗⣝⢜⡜⡜⣜⢔⢔⡐⡌⡠⢁⠨⠐⡐⠨⠨⡑⡛⢝⡓⢟⢝⢎⢇⢇⢎⢪⢊⠪⡂⡊⡢⠱⡘⡜⡜⡜⡮⣺⣪⢯⢺⢝⢯⢷⣲⡤⣄⡀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⣯⢞⣎⢎⢎⢮⣪⢷⣽⣕⢗⡗⡽⣸⡪⡮⡳⡹⣜⢮⠺⢉⢊⢪⠣⡫⢮⣊⠢⡢⡁⡢⠡⡑⠌⢜⠰⡘⡌⢎⢪⠪⡊⡎⢆⢣⠱⡨⢌⢪⠪⡪⡪⡪⡮⡫⡓⡑⠡⡢⡣⡣⡳⡹⣝⢗⡻⡳⡦⡀⠀⠀⠀⠀
            ⠀⠀⠑⠻⢮⢯⢯⣻⣞⡿⡳⣕⢯⡪⡫⣎⢮⢺⡸⡕⣕⢧⢣⢢⢢⢣⡣⡣⣣⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢪⢢⢣⢣⢪⢪⢢⢣⢣⢣⢣⢣⢣⢣⢫⢪⠪⡢⡨⡪⡪⡪⡪⡪⠪⡳⡹⡪⡫⡺⣝⣆⠀⠀⠀
            ⠀⠀⠀⠀⠀⢉⣯⣗⢯⢺⡹⡜⡎⡮⡣⡇⡗⡕⡕⡕⡕⡕⡕⢕⢕⢕⢕⢝⢜⢜⢜⢜⢜⢜⢜⢜⡜⣜⢜⢜⢜⡜⡜⡜⡜⡜⡜⡜⡜⡜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢜⢌⠪⡊⡪⡪⡪⡣⡳⣕⢇⠄⠀
            ⠀⠀⠀⠀⠀⣞⡮⣎⢎⡊⡪⢘⢈⠊⠌⡊⠌⢊⠊⡊⠜⠨⢊⢊⢊⠪⡊⢎⠪⠪⡪⢣⠫⡪⡣⡣⡣⡣⡣⡫⡪⡪⡪⡪⡪⡪⡪⡪⢢⢑⢅⢣⢱⢱⢱⢱⢱⢱⢱⢱⢱⢱⢱⢱⢑⢕⢜⢔⢔⣕⡝⢞⠊⠂⠀⠀
            ⠀⠀⠀⠀⠀⠘⠪⢗⢗⣕⢮⢢⡢⡌⡔⡐⢌⢐⢐⠠⠡⡁⠢⡐⡐⡐⡨⠠⠡⡑⢌⠢⡑⢌⢌⢊⢎⢪⢪⢪⢪⢪⢪⠪⡊⢎⠢⡑⣑⢔⢕⢕⣕⣕⣧⡳⣕⣗⢗⡵⡧⡳⠵⠵⠹⠚⠚⢊⠑⠁⠈⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠁⠊⠩⠑⢓⠓⠇⠯⠮⠮⣪⣪⣪⣪⣪⣲⢲⡸⡜⡼⡸⣜⢴⡱⡜⣔⣜⣔⣕⢕⣕⢕⡕⣕⢕⣕⣕⣕⠵⡕⠗⠫⠩⠉⠌⠂⠐⠈⠀⠀⠂⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠈⠀⠀⠠⠀⠂⠂⠨⠁⠍⠩⠉⠍⠊⠃⡋⠍⠃⠃⡃⠋⠃⠋⠃⢋⠑⠉⠂⠂⠂⠁⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            """;

        string parryImage = """
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠠⢀⢂⢐⢀⢂⢂⢂⢐⠠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⠌⢐⢀⢂⠐⠄⡂⡂⠢⡈⠢⠨⠢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠄⠈⠀⠐⠈⠀⡈⠄⡂⡐⠨⡐⡐⢌⠢⡨⡊⡪⡊⢎⢪⢢⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⢐⠠⠀⠄⠂⢐⠈⠄⡂⡐⡀⠄⢁⠢⢈⠢⡑⢌⢪⢘⢜⢜⢜⢜⢜⢆⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠠⡀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠅⡂⠌⠄⠅⠌⡐⠨⢐⢐⠐⢄⢑⠐⢌⢐⢑⢌⠢⡑⡅⡣⡱⡱⡱⡱⡱⡱⣅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠈⢐⠨⠨⠨⠠⡀⠀⠀⠀⠀⠀⠀⠀⡂⠅⡂⠂⠅⠌⡂⢅⠢⡑⡐⢄⢑⠐⠄⡅⠕⢌⠢⡢⢱⠨⡪⡸⡨⡪⡪⡪⡪⡣⣣⢳⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⡐⠄⡕⡕⠅⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠠⠨⠈⠨⢐⢈⠢⡀⠀⠀⠀⠀⡐⠠⢁⠂⠅⠅⢥⠨⠢⣳⡐⢌⢂⠢⠡⡑⢌⢊⢢⣑⢌⢆⢣⢱⢸⢸⢸⢸⢸⢸⢸⢜⢎⢞⡄⠀⠀⠀⠀⠀⠀⠀⡀⡂⠢⠨⢘⢌⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠠⠨⠠⠡⡁⢈⢂⠢⡑⠌⠄⠀⠀⢀⠂⠅⡂⠌⢌⣎⢽⢥⢑⢕⢧⢑⠔⠅⠕⢌⠢⡑⡐⢝⣗⡕⣕⣼⢰⢑⢕⢕⢕⢕⢕⢕⢭⡣⣏⡆⠀⠀⠀⠀⠀⡐⡐⢌⠪⡨⠢⡑⡔⡥⣑⠄⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠁⠈⢐⠐⠐⠄⠕⢌⠪⡨⠀⠀⢐⠨⢐⠠⣱⢱⢕⢕⣗⠐⡝⣎⢢⠡⡡⡡⡑⡕⡔⡜⡜⡼⣪⢺⣺⢸⣝⣎⢎⢎⢎⢎⢎⢎⢞⣜⢮⠄⠀⠀⠀⢀⠢⡣⡣⡣⡪⣱⢸⢌⠈⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠂⠁⠨⡈⡊⡢⡑⢌⢂⠀⠂⠌⡐⡐⡜⡮⣝⢸⡪⠢⡱⢱⢑⢕⢜⢌⢎⢪⢪⢪⢪⢪⢣⢣⢹⢘⢮⢪⢪⢪⢪⢪⢪⢪⡣⣳⢹⢕⠀⠀⡀⡐⠌⢎⢎⢮⢺⡘⠊⠊⠂⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⢂⢂⢊⠢⡑⢕⠔⠄⡁⠅⡂⠢⠱⡕⡵⡱⡝⢌⠪⡢⡱⡑⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡕⡵⡹⡸⣕⢯⣣⠣⠊⢨⢝⢜⢼⡸⣪⠪⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠄⢅⢕⠸⡐⢕⠱⡀⠅⡂⢅⢑⠘⢌⠣⡑⢕⢕⢜⢌⠎⡎⢎⢎⢎⢎⡮⡎⡎⡎⡎⡎⡎⡎⣎⢎⢎⢎⢮⢺⡸⡇⣏⢮⣳⡳⡅⢀⢇⢗⡝⣎⢮⡪⡃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡈⠐⢌⠪⡘⡌⢎⢢⠈⡂⡂⠢⠡⠡⡑⢌⣎⢞⡇⡷⡇⢽⡪⠢⡑⣵⡳⣟⣟⣮⡪⣪⣾⢪⣗⢵⣱⢱⢱⢽⡪⡪⡺⣜⣞⢮⡫⣎⢧⢳⡹⡜⢎⢮⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⡈⡂⡣⡱⡘⡌⡆⡅⡂⠌⢜⡮⢨⣌⢺⡕⡯⣺⢽⢕⢱⣫⢌⠂⣗⡯⣗⣯⢾⢽⡽⣞⣯⡗⣿⣻⡔⡕⣿⡣⡫⣺⢺⣪⡳⡝⣞⢮⡣⠓⠁⡇⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⡐⠄⠕⢌⢪⢘⠔⠅⡂⠅⠅⣟⣞⢞⢘⡎⡯⣺⢵⣻⠌⡾⣇⢅⢳⣻⣻⣞⣯⢿⣝⣷⣳⡏⣿⢽⡇⡭⡻⡸⣪⡳⡝⡖⡵⡹⣪⢳⢝⡦⣺⢨⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠅⠅⠅⠕⢌⠪⡐⠨⢈⠪⠪⡪⣫⢞⢮⢯⣳⣻⣺⢕⠸⡹⡢⡢⡫⡻⡺⢯⢟⡾⣞⣾⡳⡯⡻⡱⡱⡱⡝⣎⢞⢼⢱⢝⢮⡪⡳⣳⢹⡪⣗⡅⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠡⢁⠈⠈⡂⠑⠠⡁⠢⠡⡑⢜⢜⢝⢽⢵⣳⢳⢹⢰⢱⢱⢱⢱⢱⠱⡱⡱⡱⡱⡱⡢⡣⡣⡣⡣⡣⡏⡞⡜⣎⢧⢳⡹⣜⢼⢱⡣⣏⢞⡵⡋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⡂⡀⠀⠅⠅⢌⢘⢜⢜⢔⢥⡑⡅⡕⡌⡌⣆⢥⢣⡪⡲⡕⡵⡹⡪⡺⡸⡪⡺⡸⡪⡺⡸⡪⡣⡫⡪⣣⢣⢳⢱⢕⣕⡕⣇⡧⣳⢽⢝⡶⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡂⠄⠅⢅⢑⢐⢔⠱⡱⡱⡱⡱⡱⡱⡱⡹⡸⡸⡰⣑⢅⣇⣕⢕⣕⣕⣕⣕⢕⣕⢵⡱⡝⣜⢵⡹⣪⡺⣪⡳⣝⡕⡧⣫⢞⢮⡳⣝⢵⡫⣞⡵⡦⣀⡀⠀⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠐⠠⠨⠨⡐⡐⢕⢌⢎⢎⢎⢎⢎⢎⢮⢪⡪⡎⡮⡺⡜⣕⢧⢳⢝⢎⢮⢲⢱⢣⡣⡣⡇⡯⣪⢺⢜⢎⢞⡜⣎⢮⢎⢯⣪⢳⡣⡯⣪⡳⡽⣕⢯⢯⡳⡯⣳⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠨⡐⠨⠨⡨⢪⢨⢪⢪⢪⢪⢪⢪⢪⡪⡣⡣⡇⡧⡳⡱⡣⡫⣪⢪⢎⢎⡇⡗⣕⢝⡜⣜⢕⡝⡼⡸⡪⡎⣗⢵⡹⡜⣎⢗⢧⢳⡳⣹⡪⡳⣝⢮⡳⡯⣳⢯⢯⡻⠀⠀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠌⠌⡂⠌⠌⡌⡪⡢⡣⡣⡣⡣⡣⡣⡳⡱⡱⡹⡸⡸⡸⡸⣸⢸⡱⡱⡱⡹⡸⡜⡎⡮⡪⡎⡮⡪⣎⢮⣣⣫⡺⣜⢎⣞⢮⡪⣳⢹⣪⢺⡪⣞⣝⢮⣳⢽⣝⡾⣽⢽⢶⣢⣀⠀⠀⠀⠀
            ⠀⠀⠀⠀⠀⠀⠠⡐⠡⠡⡑⢌⢪⢂⡂⡪⡘⠜⢜⠜⢜⢸⢸⢸⡸⡸⡜⣎⢮⢳⢝⣎⢧⡫⣞⢝⡵⣝⢮⢺⡸⣪⢺⡪⣏⢮⡳⣕⣗⡽⡮⣻⡪⣗⢯⣳⣻⣪⢟⣞⢷⢽⢽⣺⢽⣺⣝⣗⡯⣟⡾⣵⣳⠀⠀⠀
            ⠀⠀⠑⠨⠠⢁⠑⠄⢅⠑⢌⠢⡑⢕⢕⢕⢎⢮⢲⢹⢸⢱⢱⢕⢕⢕⢇⢇⢧⢳⢱⢕⢇⢯⡪⣳⢹⢪⡫⡳⡝⡮⡳⣝⢮⡳⣫⡳⡵⣹⣪⡳⣝⢮⢯⣺⣪⢞⡽⡮⡯⡯⡯⡾⣽⣺⡺⡮⡯⣗⣯⣗⣧⣤⢤⡀
            ⠀⠀⠀⠀⠀⠀⠁⠁⠂⠁⠠⠡⠨⠂⠑⠑⠑⡑⢕⢕⢕⢕⢕⢕⢕⢕⢕⢵⢱⢱⢕⢇⢏⢎⢮⢪⢎⢇⠗⠝⠜⠱⠙⠘⠕⠽⠜⡞⡮⣳⢵⢝⡮⡯⣳⡳⡵⡯⡯⣫⢯⢯⢯⣻⡺⡮⣯⢿⢽⢯⣾⣺⣊⣊⠉⠀
            ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠑⠘⠈⠂⠃⠑⠑⠑⠑⠑⠑⠑⠑⠑⠑⠑⠕⠕⠵⠱⢅⠄⠀⠀⠤⠢⠲⠒⠦⠢⣀⠠⠫⠚⠑⠙⠈⠉⠈⢈⣉⢝⢾⢽⢽⢝⠓⠳⠫⠿⠵⡻⡳⠥⢦⢤⠀⠀⠀⠀
            """;


        int x = 0;
        int y = 0;
        string gNum = "";
        string name;
        public Slime(int _x, int _y, string _num) // default는 중앙으로잡고 거기서 위치를잡게끔
        {
            gNum = _num;
            name = "슬라임" + gNum;
            x = _x;
            y = _y;
        }
        public override void Init()
        {
            nameText = new RawText("슬라임" + gNum, x, y - 2, HorizontalAlign.Center);
            imageText = new RawText(normalImage, x, y, HorizontalAlign.Center);

            state.name = name;
        }
        public override void SelectEnemy()
        {
            TextIOManager.GetInstance().OutputSmartText("▶", nameText.X - 10, nameText.Y);
        }
        protected override void DrawImage()
        {
            if (isExSkill == false)
            {
                imageText.SetText(normalImage);
            }
            else if (isExSkill == true)
            {
                imageText.SetText(parryImage);
            }
        }

        public override void Release()
        {
            UIManager.GetInstance().RemoveUIElement(nameText);
            UIManager.GetInstance().RemoveUIElement(imageText);
        }
    }
}
