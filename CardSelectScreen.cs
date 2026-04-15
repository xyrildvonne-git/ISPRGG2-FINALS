using static UltraMoonTCG.PromptType;
using static UltraMoonTCG.PlayerCardSelector;
using static UltraMoonTCG.AICardSelector;
using static UltraMoonTCG.BinderPrinter;
namespace UltraMoonTCG;

// Player card select screen
public class PlayerCardSelectScreen : BaseScreen
{
    private bool isCardSelected = false;
    public override void DisplayUI()
    {
        InitializeScreen("PLAYER CARD SELECT");

        DisplayBinder();

        if (!isCardSelected)
        {
            WriteColorLine("\n[!] Type the NAME of the card to place in the Active Slot.", ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nSelection: ");
            Console.ResetColor();
        }
        else
        {
            DisplayPlayerCard();
        }
    }

    public override ScreenResult ProcessInput()
    {

        if (isCardSelected) // Checks if a card is in the active slot
        {
            PromptUser(Continue);
            isCardSelected = false;
            return ScreenResult.AICardSelect;
        }
        else
        {

            if (SelectPlayerCard()) // Checks if player has selected a valid card
            {
                isCardSelected = true;
                return ScreenResult.Refresh;
            }
            else
            {
                WriteColorLine("\n[X] Selection failed. You either don't own this card or mistyped the name.\n\n", ConsoleColor.Red);
                PromptUser(Refresh);
                return ScreenResult.Refresh;
            }
        }
    }
}


// AI card select screen
public class AICardSelectScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("AI CARD SELECT");
        SelectAICard();
        Console.WriteLine($"AI has put {AICardSelector.ActiveSlot.Name} in their Active Slot!\n");
        DisplayAICard();
        Console.WriteLine();
    }

    public override ScreenResult ProcessInput()
    {
        PromptUser(BattleStart);
        return ScreenResult.Battle;
    }
}