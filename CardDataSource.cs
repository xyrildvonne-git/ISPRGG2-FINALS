using System;
using System.Collections.Generic;
using System.IO;

namespace UltraMoonTCG
{
    public class DataSource
    {
        public static List<BaseCard> LoadCards(string path)
        {
            List<BaseCard> cardList = new List<BaseCard>();
            HashSet<string> addedNames = new HashSet<string>(); // Ensures each card is only added once

            if (!File.Exists(path))
            {
                Console.WriteLine("Error: cards.txt not found.");
                return cardList;
            }

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                string name = parts[0];

                // Skips duplicates
                if (addedNames.Contains(name))
                    continue;

                addedNames.Add(name);

                string type = parts[1].ToUpper();

                BaseCard card;

                if (type == "FIRE")
                    card = new FireCard();
                else if (type == "WATER")
                    card = new WaterCard();
                else
                    card = new GrassCard();

                card.Name = name;
                card.Type = Enum.Parse<CardType>(type);
                card.Rarity = int.Parse(parts[2]);
                card.HP = int.Parse(parts[3]);
                card.AttackCode = parts[4];
                card.Attack = int.Parse(parts[5]);
                card.SpecialMove = parts[6];
                card.Index = cardList.Count + 1;

                cardList.Add(card);

                // Stops once the list has 15 cards to match binder size
                if (cardList.Count == 15)
                    break;
            }

            return cardList;
        }
    }
}
