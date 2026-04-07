using ConsoleApp4;

using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    internal class Program
    {
        public static List<CardPrint> allCards;

        public static Dictionary<string, string> AttackNames = new Dictionary<string, string>
        {
            {"JMS", "Jump Scare"},
            {"SFB", "Soft Block"},
            {"HPS", "Hard Pass"},
            {"DLL", "Delulu"},
            {"BRR", "Brain Rot"},
            {"MXS", "Mixed Signal"},
            {"RBD", "Rebound"},
            {"ORB", "Orbiting"},
            {"RLP", "Relapse"},
            {"GHS", "Ghosting"},
            {"HRL", "Hard Launch"},
            {"NCH", "Nonchalant"},
            {"LVB", "Love Bomb"},
            {"AUF", "Aura Farm"},
            {"TRD", "Trauma Dump"}
        };

        static void Main()
        {
            // Load cards
            allCards = DataSource.LoadCards("card.txt");

            // Start menu
            Screen currentScreen = new MainMenu();

            while (currentScreen != null)
            {

                currentScreen.DisplayUI();
                currentScreen = currentScreen.ProcessInput();
            }

            // Shutdown screen
            Console.Clear();
            Screen.InitializeScreen("CREDITS");
            Console.WriteLine("Thank you so much for playing!");

            Console.WriteLine("\nGame made by:");
            Console.WriteLine("De Guzman, Kellie");
            Console.WriteLine("Layugan, Mishael");
            Console.WriteLine("Tee, Xyril");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n[X] Press any key to exit.");
            Console.ResetColor();
            Console.ReadKey(true);
        }
    }
}
