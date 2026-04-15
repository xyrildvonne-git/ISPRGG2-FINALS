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

    public static void ShowCard(int index)
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


        // Adjusts borders based on pull count
        if (card.PullCount == 2)
        {
            borderTop += new string(borderTop.Last(), 1);
            borderBottom += new string(borderBottom.Last(), 1);
            rightSide = new string(sideChar, 2);
        }
        else if (card.PullCount == 3)
        {
            borderTop += new string(borderTop.Last(), 2);
            borderBottom += new string(borderBottom.Last(), 2);
            rightSide = new string(sideChar, 3);
        }
        else if (card.PullCount == 4)
        {
            borderTop += new string(borderTop.Last(), 3);
            borderBottom += new string(borderBottom.Last(), 3);
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

    }
}
