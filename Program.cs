using System;

class Program
{
    static void Main()
    {
        List<Card> allCards = DataSource.LoadCards(@"C:\Users\admin\Documents\cards.txt"); //i placed the full path; can be changed

        Console.WriteLine("Cards loaded: " + allCards.Count);
    }

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

}
