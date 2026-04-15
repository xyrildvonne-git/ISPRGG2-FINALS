namespace UltraMoonTCG;

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

    public static void DisplayBinderCard(int index)
    {
        BaseCard card = Program.allCards.FirstOrDefault(c => c.Index == index); // checks if the card exists and if the user owns it

        if (card == null || card.PullCount == 0) // determines whether a card is locked
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n[LOCKED] You have not pulled this card yet.");
            Console.ResetColor();
            return;
        }

        // Removed console clear
        Console.WriteLine();
        // calls method in CardPrinter to print the card format in BinderSystem
        var (borderTop, borderBottom, sideChar, rightSide) = CardPrinter.GetBorders(card, showStack: true);
        CardPrinter.PrintCard(card, showStack: true);

    }
}

