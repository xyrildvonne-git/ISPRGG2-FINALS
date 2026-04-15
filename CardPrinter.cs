namespace UltraMoonTCG;

public class CardPrinter
{
    // new method so BinderSystem can call the borders (card format) to avoid redundancy
    public static (string borderTop, string borderBottom, char sideChar, string rightSide)
        GetBorders(BaseCard card, bool showStack)
    {
        string borderTop = "";
        string borderBottom = "";
        char sideChar = '|';

        switch (card.Rarity)
        {
            case RarityLevel.Common:
                borderTop = borderBottom = "+-------------------+";
                sideChar = '|';
                break;
            case RarityLevel.Uncommon:
                borderTop = borderBottom = "+===================+";
                sideChar = '|';
                break;
            case RarityLevel.Rare:
                borderTop = borderBottom = "*********************";
                sideChar = '*';
                break;
            case RarityLevel.Epic:
                borderTop = borderBottom = "@@@@@@@@@@@@@@@@@@@@@";
                sideChar = '@';
                break;
            case RarityLevel.Legendary:
                borderTop = borderBottom = "#####################";
                sideChar = '#';
                break;
        }

        string rightSide = sideChar.ToString();

        if (showStack) // true = show card pull count (in binder system) / false = show single card count only (in pull system)
        {
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
        }

        return (borderTop, borderBottom, sideChar, rightSide);
    }

    public static void PrintCard(BaseCard card, bool showStack = false)
    {
        Console.ForegroundColor = card.ElementColor;

        var (borderTop, borderBottom, sideChar, rightSide) = GetBorders(card, showStack);

        string attackName = MoveLibrary.AttackNames.ContainsKey(card.AttackCode)
            ? MoveLibrary.AttackNames[card.AttackCode]
            : card.AttackCode;

        Console.WriteLine(borderTop);
        Console.WriteLine($"{sideChar} {card.Name.PadRight(10)} HP:{card.HP.ToString().PadLeft(3)} {rightSide}");
        Console.WriteLine($"{sideChar} TYPE: {card.Type.ToString().PadRight(12)}{rightSide}");

        string attackLine = $"{attackName}:";
        Console.WriteLine($"{sideChar} {attackLine.PadRight(13)} {card.Attack.ToString().PadLeft(3)} {rightSide}");

        Console.WriteLine($"{sideChar} {card.SpecialMove.PadRight(18)}{rightSide}");
        Console.WriteLine(borderBottom);

        Console.ResetColor();
    }
}
