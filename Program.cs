using static UltraMoonTCG.CardDatabase;
using static UltraMoonTCG.CardPuller;
namespace UltraMoonTCG;

internal class Program
{
    public static List<BaseCard> allCards { get; private set; } = default!;

    static void Main()
    {

        // Loads cards
        allCards = LoadCards("cards.txt");

        // Loads pulls
        CardPuller.Load(allCards);

        // Creates screen variables
        BaseScreen activeScreen = new MenuScreen();
        BaseScreen nextScreen; 

        // Game loop logic
        while (activeScreen != null)
        {
            activeScreen.DisplayUI();

            switch (activeScreen.ProcessInput())
            {
                case ScreenResult.PullCard:
                    nextScreen = new PullCardScreen();
                    break;

                case ScreenResult.Battle:
                    nextScreen = new BattleScreen();
                    break;

                case ScreenResult.PlayerCardSelect:
                    nextScreen = new PlayerCardSelectScreen();
                    break;

                case ScreenResult.AICardSelect:
                    nextScreen = new AICardSelectScreen();
                    break;

                case ScreenResult.DisplayBinder:
                    nextScreen = new BinderScreen();
                    break;

                case ScreenResult.Refresh:
                    nextScreen = activeScreen;
                    break;

                case ScreenResult.Credits:
                    nextScreen = new CreditsScreen();
                    break;

                case ScreenResult.Exit:
                    nextScreen = null!; 
                    break;

                default:
                    nextScreen = new MenuScreen();
                    break;
            }

            activeScreen = nextScreen; // Updates the screen according to input
        }

        // Saves cards upon exit
        Save(allCards);

    }
}
