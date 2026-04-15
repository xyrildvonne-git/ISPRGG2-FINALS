using static UltraMoonTCG.BaseScreen;
namespace UltraMoonTCG;

public class PlayerCardSelector
{
    public static BaseCard ActiveSlot { get; set; } // From sir, creates a type of BaseCard called an ActiveSlot 

    public static bool SelectPlayerCard()
    {
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

        if (foundCard != null) // updates the ActiveSlot based on search result
        {
            ActiveSlot = foundCard;
            return true;
        }

        return false;
    }

    public static void DisplayPlayerCard()
    {
        if (ActiveSlot == null)
        {
            WriteColorLine("\n[!] Selection failed. You either don't own this card or mistyped the name.", ConsoleColor.Red);
        }

        Console.WriteLine($"\n[✓] {ActiveSlot.Name} is currently in the Active Slot!\n");
        ActiveSlot.PrintColoredCard();
        Console.WriteLine();
    }
}
