using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamRPG.Core;
using TeamRPG.Core.UtilManager;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Character
{
    public class PlayerManager : Singleton<PlayerManager>
    { // 플레이어 매니저가 있으니까 그냥 플레이어 매니저를 게임매니저 처럼 사용합시다
        public String environment = "";
        public String gameMsg = "";
        Player player;
        public bool isBoss = false;

        public void Init(String _name, Race _race)
        {
            player = new Player(_name, _race);
        }

        public Player GetPlayer()
        {
            return player;
        }


    }
}
