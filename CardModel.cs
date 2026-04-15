namespace UltraMoonTCG;

public interface ICard
{
    string Name { get; }
}

public abstract class BaseCard : ICard
{
    private string name = "Unknown Card";
    private int hp;
    private int attack;

    public string Name
    {
        get => name;
        set => name = ValidateName(value);
    }
    public int HP
    {
        get => hp;
        set => hp = PreventNegative(value);
    }
    public int Attack
    {
        get => attack;
        set => attack = PreventNegative(value);
    }

    private int PreventNegative(int input) => Math.Max(0, input);
    private string ValidateName(string input) => string.IsNullOrWhiteSpace(input) ? "Unknown Card" : input;

    public CardType Type { get; set; }
    public RarityLevel Rarity { get; set; }
    public abstract ConsoleColor ElementColor { get; }

    public string AttackCode = default!;
    public string SpecialMove { get; set; } = default!;

    public int Index { get; set; }
    public int PullCount { get; set; }

    public void UseSpecialMove(BaseCard opponent)
    {
        if (MoveLibrary.Spells.TryGetValue(this.Type, out var spell))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine($"\n[SPECIAL] {this.Name} uses {spell.name}!");

            Console.WriteLine($"\n[EFFECT] {opponent.Name} is now {spell.effect}!");

            Console.ResetColor();
        }
    }


    public virtual void PrintCard()
    {
        Console.ForegroundColor = ElementColor;
        CardPrinter.PrintCard(this);
        Console.ResetColor();
    }
}

public class FireCard : BaseCard
{
    public FireCard() => Type = CardType.FIRE;
    public override ConsoleColor ElementColor => ConsoleColor.Red;

}

public class WaterCard : BaseCard
{
    public WaterCard() => Type = CardType.WATER;
    public override ConsoleColor ElementColor => ConsoleColor.Blue;
}

public class GrassCard : BaseCard
{
    public GrassCard() => Type = CardType.GRASS;
    public override ConsoleColor ElementColor => ConsoleColor.Green;
}
