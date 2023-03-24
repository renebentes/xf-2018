namespace Mimica.Models
{
    public class Game
    {
        public Level Level { get; set; }

        public short Matches { get; set; }

        public Player PlayerOne { get; set; }

        public Player PlayerTwo { get; set; }

        public short WordTimeInSeconds { get; set; }
    }
}
