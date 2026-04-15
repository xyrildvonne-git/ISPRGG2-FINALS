namespace UltraMoonTCG;

public class BinderScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("BINDER");

        BinderPrinter.DisplayBinder();

        WriteColorLine("\n[INSTRUCTION] Enter 1-15 to display card information. Press [0] to return to menu...", ConsoleColor.Yellow);
        WriteColorLine("Selection: ", ConsoleColor.Yellow);
    }

    public override ScreenResult ProcessInput()
    {
        while (true)
        {
            if (!int.TryParse(Console.ReadLine(), out int input) || input < 0 || input > 15)
            {
                WriteColorLine("[!] Invalid input. Only numbers 1–15 allowed.", ConsoleColor.Red);
                PromptUser(PromptType.Refresh);
                return ScreenResult.Refresh;

            } 
            if (input == 0) 
            {
                PromptUser(PromptType.ReturnToMenu);
                return ScreenResult.Menu;
            } 
            
            bool showStack = true;
            BinderSystem.ShowCard(input);
            
            Console.WriteLine();

            PromptUser(PromptType.Refresh);
            return ScreenResult.Refresh;
        }
    }

}