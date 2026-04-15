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
        aiCard.PrintCard();
        Console.WriteLine();
        Console.WriteLine("You:\n");
        playerCard.PrintCard();
        Console.WriteLine($"Current Phase: {activePhase}");
    }

    public override ScreenResult ProcessInput()
    {
        if (CheckForLoss())
        {
            activePhase = BattlePhase.BattleResult;
        }

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
                PromptUser(PromptType.ReturnToMenu);
                return ScreenResult.BattleResult;
        }

        PromptUser(PromptType.Continue);
        return ScreenResult.Refresh; // Loops back to the same BattleScreen for the next phase
    }

    private void HandleNormalAttack(BaseCard attacker, BaseCard defender)
    {
        Console.WriteLine($"{attacker.Name} attacks for {attacker.Attack} damage!");
        defender.HP -= attacker.Attack;
    }

    private void HandleSpecialTurn(string name, BaseCard attacker, BaseCard defender)
    {
        Console.Write($"{name} attempts a Special Move... ");

        // INSERT COINFLIP SPECIAL MOVE LOGIC HERE

        // PLACEHOLDER CODE
        Console.WriteLine("HEADS! Special Move Successful!");
        attacker.UseSpecialMove(); // UNFINISHED IN CARD MODEL
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