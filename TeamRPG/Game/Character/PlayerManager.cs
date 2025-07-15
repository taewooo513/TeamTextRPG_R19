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
    {
        Player player;

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
