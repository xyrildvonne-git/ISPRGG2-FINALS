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
        if (Program.allCards == null || Program.allCards.Count == 0)
        {
            WriteColorLine("[!] No cards loaded!", ConsoleColor.Red);

            PromptUser(PromptType.Refresh);
            return ScreenResult.Refresh;
        }

        // Pulls 5 random cards
        Random rng = new Random();

        for (int i = 0; i < 5; i++)
        {
            int index = rng.Next(Program.allCards.Count);

            BaseCard pulledCard = Program.allCards[index];

            pulledCard.PrintCard();
            pulledCard.PullCount++;
            BinderSystem.AddToBinder(pulledCard);

            Console.WriteLine();
        }

        // Saves pulled cards
        CardPuller.Save(Program.allCards);

        // Prompts to return to menu
        PromptUser(PromptType.ReturnToMenu);
        return ScreenResult.Menu;

    }
}