namespace UltraMoonTCG;

public static class TypeAdvantage
{
    public static int GetDamageBonus(CardType attacker, CardType defender)
    {
        //Fire advantage
        if (attacker == CardType.FIRE && defender == CardType.GRASS) return 20;

        //Grass advantage
        if (attacker == CardType.GRASS && defender == CardType.WATER) return 20;

        //Water advantage
        if (attacker == CardType.WATER && defender == CardType.FIRE) return 20;

        return 0;
    }
}