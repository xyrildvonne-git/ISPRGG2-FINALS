using static UltraMoonTCG.BaseScreen;
namespace UltraMoonTCG;

public class AICardSelector
{

    public static BaseCard ActiveSlot { get; set; }

    public static void SelectAICard()
    {

        if (Program.allCards.Count == 0) // Checks if the AI has the list
        {
            WriteColorLine("[!] No cards available for the AI to select.", ConsoleColor.Red);
            return;
        }

        Random rng = new Random();
        int randomIndex = rng.Next(Program.allCards.Count); //randomly select one card from the master list


        ActiveSlot = Program.allCards[randomIndex]; //places the random card to the ai active slot
    }

    public static void DisplayAICard()
    {
        Console.WriteLine("Your opponent has chosen!\n");
        ActiveSlot.PrintColoredCard();
        Console.WriteLine($"\nAI will battle with {ActiveSlot.Name}!");
    }
}
