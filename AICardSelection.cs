using System;
using Card_Model;

namespace ConsoleApp4
{
    public class AICardSelection
    {
        
        public static BaseCard AIActiveSlot { get; set; }

        public static void RunAISelection()
        {
            
            if (Program.allCards.Count == 0) //cchecks if the AI has the list
            {
                Console.WriteLine("Error: No cards available for AI to select.");
                return;
            }

            
            Random rng = new Random(); 
            int randomIndex = rng.Next(Program.allCards.Count); //randomly select one card from the master list

            
            AIActiveSlot = Program.allCards[randomIndex]; //places the random card to the ai active slot

            //Requirement: "Display before battle begins"
            Console.WriteLine("\n=== OPPONENT HAS CHOSEN ===");
            AIActiveSlot.PrintCard();                                  //Temporary method for Xy's code as of now.
            Console.WriteLine($"The AI will battle with {AIActiveSlot.Name}!");
        }
    }
}