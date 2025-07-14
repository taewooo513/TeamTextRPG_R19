using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG.Core;
using TeamRPG.Game.Character;

namespace TeamRPG.Game.Character
{
    public class PlayerManager : Singleton<PlayerManager>
    {
        private Dictionary<string, Player> players = new Dictionary<string, Player>();

        public bool AddPlayer(Player player)
        {
            if (players.ContainsKey(player.Name))
                return false;

            players.Add(player.Name, player);
            return true;
        }

        public bool RemovePlayer(string name)
        {
            return players.Remove(name);
        }

        public Player GetPlayer(string name)
        {
            players.TryGetValue(name, out Player player);
            return player;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return players.Values;
        }
    }
}
