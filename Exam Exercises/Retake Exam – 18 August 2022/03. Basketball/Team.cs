using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        private List<Player> players;

        public Team(string name, int openPositions, char group)
        {
            Name = name;
            OpenPositions = openPositions;
            Group = group;
            this.players = new List<Player>();
        }

        public string Name { get; private set; }
        public int OpenPositions { get; private set; }
        public char Group { get; private set; }
        public int Count { get { return players.Count; } }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }

            if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            players.Add(player);
            OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            var player = players.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                players.Remove(player);
                OpenPositions++;

                return true;
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int removedPlayers = players.RemoveAll(p => p.Position == position);
            OpenPositions -= removedPlayers;

            return removedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            Player player = players.FirstOrDefault(p => p.Name == name);

            if (player != null)
            {
                player.Retired = true;
            }

            return player;
        }

        public List<Player> AwardPlayers(int games) => players.FindAll(p => p.Games >= games);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {Name} from Group {Group}:");

            foreach (var player in players.Where(p => p.Retired == false))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
