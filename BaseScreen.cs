namespace UltraMoonTCG;

public abstract class BaseScreen
{
    // Every screen must clear console and display game header 
    public const string GameTitle = "Ultra Moon TCG";
    public static void InitializeScreen(string screenName)
    {
        Console.Clear();
        Console.WriteLine($"=== {GameTitle} | {screenName} ===\n");
    }

    // Every screen must display UI
    public abstract void DisplayUI();

    // Every screen must process input
    public abstract ScreenResult ProcessInput();

    // User prompts to progress
    public void PromptUser(PromptType type)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        switch (type)
        {
            case PromptType.Choose:
                Console.Write("\n[^] Choose an option: ");
                break;
            case PromptType.Continue:
                Console.WriteLine("[>] Press any key to continue.");
                Console.ReadKey();
                break;
            case PromptType.Refresh:
                Console.WriteLine("[<] Press any key to refresh.");
                Console.ReadKey();
                break;
            case PromptType.ReturnToMenu:
                Console.WriteLine("[<] Press any key to return to main menu.");
                Console.ReadKey();
                break;
            case PromptType.BattleStart:
                Console.WriteLine("[>] Press any key to start the battle.");
                Console.ReadKey();
                break;
            case PromptType.Exit:
                Console.WriteLine("[X] Press any key to close the program.");
                Console.ReadKey();
                break;
        }
        Console.ResetColor();
    }


    public static void WriteColorLine(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(message);
        Console.ResetColor();
    }
}