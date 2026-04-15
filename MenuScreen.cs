namespace UltraMoonTCG;

public class MenuScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("MENU");

        Console.WriteLine("[1] Pull cards");
        Console.WriteLine("[2] Battle");
        Console.WriteLine("[3] Display binder");
        Console.WriteLine("[4] Exit\n");
    }

    public override ScreenResult ProcessInput()
    {
        // Prompts user to choose and awaits input
        PromptUser(PromptType.Choose);
        string? input = Console.ReadLine();

        // Failsafe for invalid input
        if (string.IsNullOrWhiteSpace(input))
        {
            return ScreenResult.Refresh;
        }

        // Takes first character of input and references enum
        char firstChar = input[0];
        MenuOption choice = (MenuOption)firstChar;

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
                WriteColorLine($"\n\n[!] '{input}' is not a valid menu choice.", ConsoleColor.Red);

                PromptUser(PromptType.Refresh);
                return ScreenResult.Refresh;
        }
    }
}
