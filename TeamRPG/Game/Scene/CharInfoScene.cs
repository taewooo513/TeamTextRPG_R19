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
        public void Init()
        {
            
        }

        public void Release()
        {
            
        }

        public void Render()
        {
            TextIOManager.GetInstance().OutputText4Byte($"{player.name}({player.race})", 3, 5);
            TextIOManager.GetInstance().OutputText4Byte($"{player.baseStatus}", 3, 7);
            TextIOManager.GetInstance().OutputText4Byte("마나", 3, 8);
            TextIOManager.GetInstance().OutputText4Byte("공격력", 3, 9);
            TextIOManager.GetInstance().OutputText4Byte("재빠름", 3, 10);
            TextIOManager.GetInstance().OutputText4Byte("강인함", 3, 11);
            TextIOManager.GetInstance().OutputText4Byte("행운", 3, 12);
        }

        public void Update()
        {
            
        }
    }
}
