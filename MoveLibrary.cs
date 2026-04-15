namespace UltraMoonTCG;

public static class MoveLibrary
{
    public static Dictionary<string, string> AttackNames = new Dictionary<string, string>
        {
            { "JMS", "Jump Scare" },
            { "SFB", "Soft Block" },
            { "HPS", "Hard Pass" },
            { "DLL", "Delulu" },
            { "BRR", "Brain Rot" },
            { "MXS", "Mixed Signal" },
            { "RBD", "Rebound" },
            { "ORB", "Orbiting" },
            { "RLP", "Relapse" },
            { "GHS", "Ghosting" },
            { "HRL", "Hard Launch" },
            { "NCH", "Nonchalant" },
            { "LVB", "Love Bomb" },
            { "AUF", "Aura Farm" },
            { "TRD", "Trauma Dump" }
        };

    public static readonly Dictionary<CardType, (string name, StatusEffect effect)> Spells = new()
    {
        { CardType.FIRE, ("Burn", StatusEffect.Burned) },
        { CardType.WATER, ("Scald", StatusEffect.Confused) },
        { CardType.GRASS, ("Poison", StatusEffect.Poisoned) }
    };
}
