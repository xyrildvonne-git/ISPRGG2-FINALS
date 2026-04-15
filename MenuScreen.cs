using static UltraMoonTCG.PromptType;
namespace UltraMoonTCG;

public class MenuScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("MENU");

        Console.WriteLine("[1] Pull cards");
        Console.WriteLine("[2] Battle");
        Console.WriteLine("[3] Display binder");
        Console.WriteLine("[4] Exit");
    }

    public override ScreenResult ProcessInput()
    {
        // Prompts user to choose and awaits input
        PromptUser(Choose);
        string? input = Console.ReadLine();

        // Failsafe for invalid input
        if (string.IsNullOrWhiteSpace(input))
        {
            return ScreenResult.Refresh;
        }

        if (Enum.TryParse(input, out MenuOption choice))
        {
            switch (choice)
            {
                case MenuOption.PullCard:
                    return ScreenResult.PullCard;

                case MenuOption.Battle:
                    if (Program.allCards.Any(c => c.PullCount > 0))
                    {
                        return ScreenResult.PlayerCardSelect;
                    }
                    else
                    {
                        // Block entry and explain why
                        WriteColorLine("\n[!] You cannot battle yet. Visit 'Pull Cards' to get your first card!\n\n", ConsoleColor.Red);
                        PromptUser(Refresh);
                        return ScreenResult.Refresh;
                    }

                case MenuOption.DisplayBinder:
                    return ScreenResult.DisplayBinder;

                case MenuOption.Exit:
                    return ScreenResult.Credits;

                default:
                    break;
            }
        }

        WriteColorLine($"\n[X] '{input}' is not a valid menu choice.\n\n", ConsoleColor.Red);
        PromptUser(Refresh);
        return ScreenResult.Refresh;
    }
}