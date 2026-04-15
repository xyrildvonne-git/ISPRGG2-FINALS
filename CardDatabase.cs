using static UltraMoonTCG.BaseScreen;
namespace UltraMoonTCG;

public class CardDatabase
{
    public static List<BaseCard> LoadCards(string path) // Must return a list of cards
    {
        List<BaseCard> cardList = new List<BaseCard>(); // Creates a list called "cardList" that can only hold BaseCards
        HashSet<string> addedNames = new HashSet<string>(); // Seen cards list, disregards repeats

        if (!File.Exists(path)) // Checks if file exists at the end of "path"
        {
            WriteColorLine("[!] 'cards.txt' not found.",ConsoleColor.Red);
            return cardList; // Fulfills the return promise
        }

        string[] allRows = File.ReadAllLines(path); // Opens the file at the end of "path", reads every line, closes it

        foreach (string currentRow in allRows)
        {
            string[] parts = currentRow.Split(','); // Divides the row at every comma and assigns a part number to each

            string name = parts[0]; // Assigns every first part to "name"

            // Skips duplicates
            if (addedNames.Contains(name)) // Checks HashSet to check for duplicate cards
                continue; // If duplicate found, skip to next row
            addedNames.Add(name); // Saves the currentRow card into HashSet

            string type = parts[1].ToUpper(); // Assings every second part to "type" and makes ALL CAPS

            BaseCard card; // Declares variable "card", any type of BaseCard

            if (type == "FIRE")
                card = new FireCard();
            else if (type == "WATER")
                card = new WaterCard();
            else
                card = new GrassCard();

            card.Name = name;
            card.Type = Enum.Parse<CardType>(type);
            card.Rarity = (RarityLevel)int.Parse(parts[2]);
            card.HP = int.Parse(parts[3]);
            card.AttackCode = parts[4];
            card.Attack = int.Parse(parts[5]);
            card.SpecialMove = parts[6];
            card.Index = cardList.Count + 1;

            cardList.Add(card); // Takes the complete "card" and adds to cardList

            if (cardList.Count == 15)
                break;
        }

        return cardList;
    }
}
