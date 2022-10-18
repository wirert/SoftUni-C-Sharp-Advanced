using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public int Count => roster.Count;

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name) => roster.Remove(roster.Find(p => p.Name == name));

        public void PromotePlayer(string name) => roster.First(p => p.Name == name).Rank = "Member";

        public void DemotePlayer(string name) => roster.First(p => p.Name == name).Rank = "Trial";

        public Player[] KickPlayersByClass(string @class)
        {
            var removed = roster.Where(p => p.Class == @class).ToArray();

            roster.RemoveAll(p => p.Class == @class);

            return removed;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
