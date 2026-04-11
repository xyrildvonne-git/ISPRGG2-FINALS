using System;
using System.Collections.Generic;

namespace UltraMoonTCG;

internal class Program
{
    public static List<BaseCard> allCards;

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
        // Loads cards.txt
        allCards = DataSource.LoadCards("cards.txt");

        // Loads pulled cards
        CardPulls.Load(allCards);


        GameScreen currentScreen = new MainMenu();

        while (currentScreen != null)
        {
            currentScreen.DisplayUI();
            currentScreen = currentScreen.ProcessInput();
        }

        // Saves cards before exit
        CardPulls.Save(allCards);


        // Shutdown screen
        Console.Clear();
        GameScreen.InitializeScreen("CREDITS");

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
