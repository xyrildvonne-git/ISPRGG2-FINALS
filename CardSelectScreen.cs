using static UltraMoonTCG.PromptType;
using static UltraMoonTCG.PlayerCardSelector;
using static UltraMoonTCG.AICardSelector;
using static UltraMoonTCG.BinderPrinter;
namespace UltraMoonTCG;

// Player card select screen
public class PlayerCardSelectScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("PLAYER CARD SELECT");

        DisplayBinder();

        WriteColorLine("\n[!] Type the NAME of the card to place in the Active Slot.",ConsoleColor.Yellow);
        WriteColorLine("\nSelection: ", ConsoleColor.Yellow);
    }

    public override ScreenResult ProcessInput()
    {
        bool success = SelectPlayerCard();

        if (success)
        {
            DisplayPlayerCard();
            PromptUser(Continue);
            return ScreenResult.AICardSelect;
        }
        else
        {
            WriteColorLine("\n[X] Selection failed. You either don't own this card or mistyped the name.\n\n", ConsoleColor.Red);
            PromptUser(Refresh);
            return ScreenResult.Refresh;
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
        DisplayAICard();
        Console.WriteLine();
    }

    public override ScreenResult ProcessInput()
    {
        PromptUser(BattleStart);
        return ScreenResult.Battle;
    }
}