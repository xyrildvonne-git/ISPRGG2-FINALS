using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using static ConsoleApp4.Card_Model;

namespace ConsoleApp4
{
    public class MainMenu : Screen
    {
        public override void DisplayUI()
        {
            // MAIN MENU SCREEN
            InitializeScreen("MENU");
            Console.WriteLine("[1] Pull cards");
            Console.WriteLine("[2] Battle");
            Console.WriteLine("[3] Display binder");
            Console.WriteLine("[4] Exit");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n[^] Choose an option: ");
            Console.ResetColor();
        }

        public enum MainMenuOption
        {
            PullCard = '1',
            Battle = '2',
            DisplayBinder = '3',
            Exit = '4'
        }

        public override Screen ProcessInput()
        {
            // Read user input
            char input = Console.ReadKey(false).KeyChar;
            Thread.Sleep(100); // Lets choice appear for a quick moment

            MainMenuOption choice = (MainMenuOption)input;

            switch (choice)
            {
                case MainMenuOption.PullCard:
                    InitializeScreen("PULL CARDS");

                   // Pull 5 random cards
                    Random rng = new Random();

                    for (int i = 0; i < 5; i++)
                    {
                        int index = rng.Next(Program.allCards.Count);
                        CardPrint pulledCard = Program.allCards[index];

                        pulledCard.PrintCard();
                        Console.WriteLine();
                    }
            

                    PromptUser(isError: false);
                    return this;

                case MainMenuOption.Battle:
                    // PLACEHOLDER CODE \/
                    InitializeScreen("BATTLE");
                    PromptUser(isError: false);
                    return this;

                case MainMenuOption.DisplayBinder:
                    // PLACEHOLDER CODE \/
                    InitializeScreen("BINDER");
                    PromptUser(isError: false);
                    return this;

                case MainMenuOption.Exit:
                    Console.WriteLine("\n\nCLOSING GAME...");
                    Thread.Sleep(1000); // Gives user time to read exit message
                    return null; // Tells game to stop

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\n[!] '{input}' is not a valid menu choice.");
                    Console.ResetColor();
                    PromptUser(isError: true);
                    return this; // <- Stays in menu
            }
        }
    }
}
