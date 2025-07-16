using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Scene
{
    public class CharInfoScene : Core.SceneManager.Scene
    {
        Player player;
        Status status;

        public void Init()
        {
            player = new Player("asd", (Race)1);
            status = new Status(70, 50, 12, 16, 30, 50, 10, 70, 50);
        }

        public void Release()
        {
            
        }

        public void Render()
        {
            TextIOManager.GetInstance().OutputText4Byte($"이름 : {player.name}({player.race})", 3, 6);
            TextIOManager.GetInstance().OutputText4Byte($"레벨 : {player.level}", 3, 8);
            TextIOManager.GetInstance().OutputText4Byte($"체력 : {status.currentHp} / {status.HP}", 3, 10);
            TextIOManager.GetInstance().OutputText4Byte($"마나 : {status.currentMp} / {status.MP}", 3, 12);
            TextIOManager.GetInstance().OutputText4Byte($"공격력 : {status.MinAttack} ~ {status.MaxAttack}", 3, 14);
            TextIOManager.GetInstance().OutputText4Byte($"재빠름 : {status.Agility}", 3, 16);
            TextIOManager.GetInstance().OutputText4Byte($"강인함 : {status.Tenacity}", 3, 18);
            TextIOManager.GetInstance().OutputText4Byte($"운 : {status.Luck}", 3, 20);
            TextIOManager.GetInstance().OutputText4Byte($"다음 레벨까지 EXP가 {player.expToNextLevel}만큼 필요합니다 ",3, 24);
            //TextIOManager.GetInstance().OutputText4Byte("마나", 3, 8);
            //TextIOManager.GetInstance().OutputText4Byte("공격력", 3, 9);
            //TextIOManager.GetInstance().OutputText4Byte("재빠름", 3, 10);
            //TextIOManager.GetInstance().OutputText4Byte("강인함", 3, 11);
            //TextIOManager.GetInstance().OutputText4Byte("행운", 3, 12);
        }

        public void Update()
        {
            
        }
    }
}
