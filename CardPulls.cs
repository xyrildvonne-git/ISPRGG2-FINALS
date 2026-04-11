using System;
using System.Collections.Generic;
using System.IO;

namespace UltraMoonTCG
{
    public static class CardPulls
    {
        private static string path = "pulls.txt";

// Loads card pulls ->

        public static void Load(List<BaseCard> cards)
        {
            if (!File.Exists(path))
                return;

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                int index = int.Parse(parts[0]);
                int pulls = int.Parse(parts[1]);

                BaseCard card = cards.Find(c => c.Index == index);

                if (card != null)
                    card.PullCount = pulls;
            }
        }

// Saves card pulls ->

        public static void Save(List<BaseCard> cards)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                for (int i = 1; i <= 15; i++)
                {
                    BaseCard card = cards.Find(c => c.Index == i);

                    int pulls = (card != null) ? card.PullCount : 0;

                    writer.WriteLine($"{i},{pulls}");
                }
            }
        }
    }
}
