namespace UltraMoonTCG;

public class CardPrinter
{

    public static void PrintCard(BaseCard card, bool showStack = false)
    {
        Console.ForegroundColor = card.ElementColor;
        string borderTop = "";
        string borderBottom = "";
        char sideChar = '|';

        switch (card.Rarity)
        {
            case RarityLevel.Common:
                borderTop = borderBottom = "+------------------+";
                sideChar = '|';
                break;

            case RarityLevel.Uncommon:
                borderTop = borderBottom = "+==================+";
                sideChar = '|';
                break;

            case RarityLevel.Rare:
                borderTop = borderBottom = "********************";
                sideChar = '*';
                break;

            case RarityLevel.Epic:
                borderTop = borderBottom = "@@@@@@@@@@@@@@@@@@@@";
                sideChar = '@';
                break;

            case RarityLevel.Legendary:
                borderTop = borderBottom = "####################";
                sideChar = '#';
                break;
        }

        string rightSide = sideChar.ToString();

        // Adjusts borders based on pull count
        if (showStack == true)
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
            else
            {
                rightSide = new string(sideChar, 1);
            }
        }

        string attackName = MoveLibrary.AttackNames.ContainsKey(card.AttackCode)
            ? MoveLibrary.AttackNames[card.AttackCode]
            : card.AttackCode;

        Console.WriteLine(borderTop);
        Console.WriteLine($"{sideChar} {card.Name.PadRight(9)} HP:{card.HP.ToString().PadLeft(3)} {rightSide}");
        Console.WriteLine($"{sideChar} TYPE: {card.Type.ToString().PadRight(11)}{rightSide}");
        string attackLine = $"{attackName}:";
        Console.WriteLine($"{sideChar} {attackLine.PadRight(12)} {card.Attack.ToString().PadLeft(3)} {rightSide}");
        Console.WriteLine($"{sideChar} {card.SpecialMove.PadRight(17)}{rightSide}");
        Console.WriteLine(borderBottom);
        Console.ResetColor();
    }
}
