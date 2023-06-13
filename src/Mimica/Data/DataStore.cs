using Mimica.Models;
using System.Collections.Generic;

namespace Mimica.Data
{
    public static class DataStore
    {
        public static short CurrentRound { get; set; }

        public static Game Game { get; set; }

        public static IReadOnlyDictionary<Level, byte> Scores
            => new Dictionary<Level, byte>
            {
                { Level.Beginner, 1 },
                { Level.Normal, 3 },
                { Level.Hard, 5 }
            };

        public static IReadOnlyDictionary<Level, string[]> Words
            => new Dictionary<Level, string[]>
            {
                { Level.Beginner, new string[] { "Olho", "Língua", "Chinelo", "Milho", "Pênalti", "Bola", "Ping-pong" } },
                {Level.Normal,new string[] { "Carpinteiro", "Amarelo", "Limão", "Abelha" } },
                {Level.Hard,new string[]{ "Cisterna", "Lanterna", "Batman vs Superman", "Notebook" } }
            };
    }
}
