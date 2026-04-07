using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp4
{
    public class DataSource
    {
        public static List<CardPrint> LoadCards(string path)
        {
            List<CardPrint> cardList = new List<CardPrint>();

            if (!File.Exists(path))
            {
                Console.WriteLine("Error: cards.txt not found.");
                return cardList;
            }

            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                CardPrint card = new CardPrint
                {
                    Name = parts[0],
                    Type = Enum.Parse<CardType>(parts[1].ToUpper()),
                    Rarity = int.Parse(parts[2]),
                    HP = int.Parse(parts[3]),
                    AttackCode = parts[4],
                    Attack = int.Parse(parts[5]),
                    SpecialMove = parts[6]
                };

                cardList.Add(card);
            }

            return cardList;
        }
    }
}
