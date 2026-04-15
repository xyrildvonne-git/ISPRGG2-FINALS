using static UltraMoonTCG.PromptType;
namespace UltraMoonTCG;

public class BattleScreen : BaseScreen
{
    private BattlePhase activePhase = BattlePhase.PlayerNormal;
    private Random _rng = new Random();

    public override void DisplayUI()
    {
        var playerCard = PlayerCardSelector.ActiveSlot;
        var aiCard = AICardSelector.ActiveSlot;

        InitializeScreen("BATTLE ARENA");

        Console.WriteLine("Opponent: \n");
        aiCard.PrintColoredCard();

        Console.WriteLine();

        Console.WriteLine("You:\n");
        playerCard.PrintColoredCard();

        Console.WriteLine($"Current Phase: {activePhase}");
    }

    public override ScreenResult ProcessInput()
    {

        switch (activePhase)
        {
            case BattlePhase.PlayerNormal:
                HandleNormalAttack(PlayerCardSelector.ActiveSlot, AICardSelector.ActiveSlot);
                activePhase = BattlePhase.AINormal;
                break;

            case BattlePhase.AINormal:
                HandleNormalAttack(AICardSelector.ActiveSlot, PlayerCardSelector.ActiveSlot);
                activePhase = BattlePhase.PlayerSpecial;
                break;

            case BattlePhase.PlayerSpecial:
                HandleSpecialTurn("Player", PlayerCardSelector.ActiveSlot, AICardSelector.ActiveSlot);
                activePhase = BattlePhase.AISpecial;
                break;

            case BattlePhase.AISpecial:
                HandleSpecialTurn("AI", AICardSelector.ActiveSlot, PlayerCardSelector.ActiveSlot);
                activePhase = BattlePhase.BattleEnd;
                break;

            case BattlePhase.BattleEnd:
                activePhase = BattlePhase.BattleResult;
                break;

            case BattlePhase.BattleResult:
                DisplayVictoryMessage();
                PromptUser(ReturnToMenu);
                return ScreenResult.BattleResult;
        }

        if (CheckForLoss())
        {
            activePhase = BattlePhase.BattleResult;
        }


        PromptUser(Continue);
        return ScreenResult.Refresh; // Loops back to the same BattleScreen for the next phase
    }

    private void HandleNormalAttack(BaseCard attacker, BaseCard defender)
    {
        //Type Advantage for Screen
        int bonus = TypeAdvantage.GetDamageBonus(attacker.Type, defender.Type);
        int totalDamage = attacker.Attack + bonus;

        if (bonus > 0)
        {
            WriteColorLine($"[TYPE ADVANTAGE] {attacker.Name} deals +{bonus} extra damage!",ConsoleColor.Green);
        }

        Console.WriteLine($"{attacker.Name} attacks for {totalDamage} damage!");
        defender.HP -= totalDamage;

    }

    private void HandleSpecialTurn(string name, BaseCard attacker, BaseCard defender)
    {
        Console.Write($"{name} attempts a Special Move... ");

        // 0 = Heads (Success), 1 = Tails (Failure)
        bool isHeads = _rng.Next(0, 2) == 0;

        if (isHeads)
        {
            WriteColorLine("HEADS! Special Move Successful!", ConsoleColor.Cyan);

            attacker.UseSpecialMove(defender);
        }
        else
        {
            WriteColorLine("TAILS! The move failed.", ConsoleColor.Red);
        }
    }

    private bool CheckForLoss()
    {
        // Return true if either card is at 0 HP
        return PlayerCardSelector.ActiveSlot.HP <= 0 || AICardSelector.ActiveSlot.HP <= 0;
    }

    private void DisplayVictoryMessage()
    {
        // Clean the screen as requested
        InitializeScreen("BATTLE RESULTS");

        var player = PlayerCardSelector.ActiveSlot;
        var ai = AICardSelector.ActiveSlot;

        if (player.HP <= 0)
        {
            Console.WriteLine($"\n[!] {player.Name} has fainted! YOU LOSE.");
        }
        else if (ai.HP <= 0)
        {
            Console.WriteLine($"\n[!] {ai.Name} has fainted! VICTORY IS YOURS!");
        }
        else
        {
            Console.WriteLine("\n[!] The battle ended in a draw or time-out.");
        }

        Console.ResetColor();
    }
}
