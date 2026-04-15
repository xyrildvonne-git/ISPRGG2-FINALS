using static UltraMoonTCG.BinderSystem;
using static UltraMoonTCG.Program;
using static UltraMoonTCG.CardPuller;
using static UltraMoonTCG.PromptType;
namespace UltraMoonTCG;

public class PullCardScreen : BaseScreen
{
    public override void DisplayUI()
    {
        InitializeScreen("PULL CARDS");
    }

    public override ScreenResult ProcessInput()
    {
        // Failsafe for invalid number of cards
        if (allCards == null || allCards.Count == 0)
        {
            WriteColorLine("[!] No cards loaded!", ConsoleColor.Red);
            PromptUser(Refresh);
            return ScreenResult.Refresh;
        }

        // Pulls 5 random cards
        Random rng = new Random();

        for (int i = 0; i < 5; i++)
        {
            int index = rng.Next(allCards.Count);
            BaseCard pulledCard = allCards[index];
            pulledCard.PrintColoredCard();
            pulledCard.PullCount++;
            AddToBinder(pulledCard);
            Console.WriteLine();
        }

        // Saves pulled cards
        SavePulls(allCards);

        // Prompts to return to menu
        PromptUser(ReturnToMenu);
        return ScreenResult.Menu;

    }
}
