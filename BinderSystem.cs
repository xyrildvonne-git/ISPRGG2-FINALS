using System;
using System.Collections.Generic;
using System.Linq;

namespace UltraMoonTCG
{
    public static class BinderSystem
    {
        public static List<BaseCard> ownedCards = new List<BaseCard>(); //storage for owned cards

        public static void AddToBinder(BaseCard card) // updates the binder for new cards
        {
            card.PullCount++; // updates how many times the user has obtained a certain card

            if (!ownedCards.Any(c => c.Index == card.Index))
            {
                ownedCards.Add(card);
            }
        }

        public static void DisplayBinder()
        {
            Console.WriteLine("\n+---------------------------------------------------------------------+");

            for (int i = 0; i < 15; i += 5)
            {
                Console.Write("| ");

                for (int j = 1; j <= 5; j++)
                {
                    int index = i + j;
                    BaseCard card = Program.allCards.FirstOrDefault(c => c.Index == index);

                    string display;

                    if (card != null && card.PullCount > 0)
                    {
                        display = card.Name; 
                    }
                    else
                    {
                        display = $"#{index:000}";
                    }

                    Console.Write(display.PadRight(12));
                    Console.Write("| ");
                }

                Console.WriteLine();
                Console.WriteLine("+---------------------------------------------------------------------+");
            }
        }

        public static void ShowCard(int index)
        {
            BaseCard card = Program.allCards.FirstOrDefault(c => c.Index == index); // checks if the card exists and if the user owns it (changed the original code for this)

            if (card == null || card.PullCount == 0) // determines whether a card is locked
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[LOCKED] You have not pulled this card yet.");
                Console.ResetColor();
                return;
            }

            Console.Clear();

            // Border style rarity
            string borderTop = "";
            string borderBottom = "";
            char sideChar = '|';

            switch (card.Rarity)
            {
                case 1:
                    borderTop = "+------------------+";
                    borderBottom = "+------------------+";
                    sideChar = '|';
                    break;
                case 2:
                    borderTop = "+==================+";
                    borderBottom = "+==================+";
                    sideChar = '|';
                    break;
                case 3:
                    borderTop = "********************";
                    borderBottom = "********************";
                    sideChar = '*';
                    break;
                case 4:
                    borderTop = "@@@@@@@@@@@@@@@@@@@@";
                    borderBottom = "@@@@@@@@@@@@@@@@@@@@";
                    sideChar = '@';
                    break;
                case 5:
                    borderTop = "####################";
                    borderBottom = "####################";
                    sideChar = '#';
                    break;
            }

            // Adjusts borders based on pull count
            // Might make some changes on this; unsure how cards with 2-4 pulls and higher rarity should look like
            string rightSide;
            if (card.PullCount == 2)
            {
                borderTop += "+";
                borderBottom += "+";
                rightSide = new string(sideChar, 2);
            }
            else if (card.PullCount == 3)
            {
                borderTop += "++";
                borderBottom += "++";
                rightSide = new string(sideChar, 3);
            }
            else if (card.PullCount == 4)
            {
                borderTop += "+++";
                borderBottom += "+++";
                rightSide = new string(sideChar, 4);
            }
            else if (card.PullCount >= 6)
            {
                borderTop += $" x{card.PullCount}";
                rightSide = new string(sideChar, 1); 
            }
            else
            {
                rightSide = new string(sideChar, 1);
            }

            string attackName = Program.AttackNames.ContainsKey(card.AttackCode)
                ? Program.AttackNames[card.AttackCode]
                : card.AttackCode;

            // Expands the card's right side depending on the pull count
            Console.WriteLine(borderTop);
            Console.WriteLine($"{sideChar} {card.Name.PadRight(10)} HP:{card.HP.ToString().PadLeft(2)} {rightSide}");
            Console.WriteLine($"{sideChar} TYPE: {card.Type.ToString().PadRight(10)} {rightSide}");
            Console.WriteLine($"{sideChar} {attackName.PadRight(13)} {card.Attack.ToString().PadLeft(2)} {rightSide}");
            Console.WriteLine($"{sideChar} {card.SpecialMove.PadRight(16)} {rightSide}");
            Console.WriteLine(borderBottom);
        }

        public static void RunBinder()
        {
            while (true)
            {
                Console.Clear();
 

                Console.WriteLine("\n=== BINDER SYSTEM ===");
                DisplayBinder();
                Console.WriteLine("\n[INSTRUCTION] Enter 1-15 to display card information. Press [0] to return to menu...");
                Console.Write("Selection: ");

                if (!int.TryParse(Console.ReadLine(), out int input) || input < 0 || input > 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("[ERROR] Invalid input. Only numbers 1–15 allowed.");
                    Console.ResetColor();
                    Console.ReadKey();
                    continue;
                }

                if (input == 0)
                    return;


                ShowCard(input);

                Console.WriteLine("\nPress any key to return...");
                Console.ReadKey();
            }
        }
    }
}
