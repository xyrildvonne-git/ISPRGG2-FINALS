using static UltraMoonTCG.BinderPrinter;
using static UltraMoonTCG.CardPuller;
using static UltraMoonTCG.Program;
using static UltraMoonTCG.PromptType;
using static UltraMoonTCG.BinderSystem;
namespace UltraMoonTCG;

public class BinderScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("BINDER");
        DisplayBinder();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n[INSTRUCTION]");
        Console.WriteLine("Enter [1-15] to display card information.");
        Console.WriteLine("Enter [R] to reset saved cards.");
        Console.WriteLine("Enter [0] to return.");
        Console.Write("\nSelection: ");
        Console.ResetColor();
    }

    public override ScreenResult ProcessInput()
    {
        while (true)
        {
            string input = Console.ReadLine().ToUpper();

            // resets saved cards
            if (input == "R")
            {
                ResetSavedPulls(allCards);
                WriteColorLine("\n[!] Save file cleared.\n\n",ConsoleColor.Green);
                PromptUser(Refresh);
                return ScreenResult.Refresh;
            }

            // validates user input
            if (!int.TryParse(input, out int number) || number < 0 || number > 15)
            {
                WriteColorLine("\n[X] Invalid input. Only [1–15], [R], or [0] are allowed.\n\n",ConsoleColor.Red);
                PromptUser(Refresh);
                return ScreenResult.Refresh;
            }

            // returns to main menu
            if (number == 0)
            {
                return ScreenResult.Menu;
            }

            // shows card
            DisplayBinderCard(number);
            Console.WriteLine();
            PromptUser(Refresh);
            return ScreenResult.Refresh;
        }
    }
}