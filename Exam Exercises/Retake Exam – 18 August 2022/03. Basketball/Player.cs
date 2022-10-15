using System.Text;

namespace Basketball
{
    public class Player
    {
        public Player(double rating, int games)
        {
            Rating = rating;
            Games = games;
            Retired = false;
        }

        public Player(string name, double rating, int games) : this(rating, games)
        {
            Name = name;
        }
        
        public Player(string name, string position, double rating, int games) : this(name,rating,games)
        {
            Position = position;           
        }

        public string Name { get; private set; }
        public string Position { get; private set; }
        public double Rating { get; private set; }
        public int Games { get; private set; }
        public bool Retired { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"-Player: {Name}");
            sb.AppendLine($"--Position: {Position}");
            sb.AppendLine($"--Rating: {Rating}");
            sb.AppendLine($"--Games played: {Games}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
