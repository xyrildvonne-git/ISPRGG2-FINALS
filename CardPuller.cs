namespace UltraMoonTCG;

public static class CardPuller
{
    // file path where pull data is stored
    private static string path = "pulls.txt";

   // loads saved cards
    public static void Load(List<BaseCard> cards)
    {
        if (!File.Exists(path)) // exit if save file does not exist
            return;

        string[] lines = File.ReadAllLines(path); // read all lines from save file

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');

            // convert text into integers
            int index = int.Parse(parts[0]);
            int pulls = int.Parse(parts[1]);

            BaseCard card = cards.Find(c => c.Index == index); // find matching card in memory using index

           // if cards exist, restore its pull count
            if (card != null)
                card.PullCount = pulls;
        }
    }
   
    // saves pulled cards
    public static void Save(List<BaseCard> cards)
    {
        using (StreamWriter writer = new StreamWriter(path)) // create or overwrite saved data
        {
            for (int i = 1; i <= 15; i++)
            {
                BaseCard card = cards.Find(c => c.Index == i);

                int pulls = (card != null) ? card.PullCount : 0;

                writer.WriteLine($"{i},{pulls}");
            }
        }
    }
   
    // deletes pulls.txt
    public static void ResetSave(List<BaseCard> cards)
    {
        if (File.Exists(path))
            File.Delete(path);

        foreach (var card in cards)
            card.PullCount = 0;
    }
}
