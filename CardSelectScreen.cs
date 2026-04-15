namespace UltraMoonTCG;

// Player card select screen
public class PlayerCardSelectScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("PLAYER CARD SELECT");

        BinderPrinter.DisplayBinder();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n[INSTRUCTION] Type the NAME of the card to place in the Active Slot.");
        Console.Write("Selection: ");
        Console.ResetColor();
    }

    public override ScreenResult ProcessInput()
    {
        bool success = PlayerCardSelector.SelectCard();

        if (success)
        {
            PlayerCardSelector.DisplayCard();

            PromptUser(PromptType.Continue);
            return ScreenResult.AICardSelect;
        }
        else
        {
            PromptUser(PromptType.Refresh);
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
        AICardSelector.SelectCard();
        AICardSelector.DisplayCard();
        Console.WriteLine();
    }

    public override ScreenResult ProcessInput()
    {
        PromptUser(PromptType.BattleStart);
        return ScreenResult.Battle;
    }
}