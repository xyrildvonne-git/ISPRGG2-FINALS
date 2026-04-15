using System;

namespace UltraMoonTCG;

public class BinderScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("BINDER");
        BinderPrinter.DisplayBinder();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n[INSTRUCTION]");
        Console.WriteLine("Enter [1-15] to display card information.");
        Console.WriteLine("Enter [R] to reset saved cards.");
        Console.WriteLine("Enter [0] to return.");
        Console.Write("\nSelection: ");
        Console.ResetColor();
    }

    public override BaseScreen ProcessInput()
    {
        while (true)
        {
            string input = Console.ReadLine().ToUpper();

            // resets saved cards
            if (input == "R")
            {
                CardPuller.ResetSave(Program.allCards);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[RESET] Save file cleared.");
                Console.ResetColor();

                PromptUser(PromptType.Retry);
                return this;
            }

            // validates user input
            if (!int.TryParse(input, out int number) || number < 0 || number > 15)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("[!] Invalid input. Only [1–15], [R], or [0] are allowed.");
                Console.ResetColor();

                PromptUser(PromptType.Retry);
                return this;
            }

            // returns to main menu
            if (number == 0)
            {
                return new MenuScreen();
            }

            // shows card
            BinderSystem.ShowCard(number);

            Console.WriteLine();
            PromptUser(PromptType.Retry);
            return this;
        }
    }
}


public class BinderCardScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("BINDER");

    }

    public override BaseScreen ProcessInput()
    {
        return this;
    }
}
