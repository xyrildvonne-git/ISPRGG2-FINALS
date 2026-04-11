using System;
using System.Collections.Generic;

namespace UltraMoonTCG
{
    public class UserCardSelection
    {

        public static BaseCard ActiveSlot { get; set; } //From sir. it also makes ActiveSlot a Basecard so we can use Print methods

        public static void RunSelection()
        {
            Console.Clear();
            Console.WriteLine("=== USER CARD SELECTION ===");

            BinderSystem.DisplayBinder(); // Calls BinderSystem

            Console.WriteLine("\n[INSTRUCTION] Type the NAME of the card to place in the Active Slot.");
            Console.Write("Selection: ");
            string choice = Console.ReadLine().Trim().ToUpper();

            BaseCard foundCard = null;

            foreach (BaseCard card in Program.allCards) // loops through the list of cards that are already pulled (Program now holds the cards to prevent mismatch and duplication; can be changed if needed/preferred)
            {
                if (card.Name.ToUpper() == choice && card.PullCount > 0)
                {
                    foundCard = card;
                    break;
                }
            }

            if (foundCard != null) //updates the ActiveSlot based on search result
            {
                ActiveSlot = foundCard;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[SUCCESS] {ActiveSlot.Name} has been moved to the Active Slot!");
                Console.ResetColor();

                ActiveSlot.PrintCard(); //prints the card that was picked using the Print Card Method
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n[ERROR] Selection failed. You either don't own this card or mistyped the name.");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
