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
                    return ScreenResult.PlayerCardSelect;

                case MenuOption.DisplayBinder:
                    return ScreenResult.DisplayBinder;

                case MenuOption.Exit:
                    return ScreenResult.Credits;

                default:
                    break;
            }
        }

        WriteColorLine($"\n[!] '{input}' is not a valid menu choice.\n", ConsoleColor.Red);
        PromptUser(Refresh);
        return ScreenResult.Refresh;
    }
}
