namespace UltraMoonTCG;

public enum MenuOption
{
    PullCard = '1',
    Battle = '2',
    DisplayBinder = '3',
    Exit = '4'
}

public enum ScreenResult
{
    Refresh,
    Menu,
    Battle,
    BattleResult,
    PlayerCardSelect,
    AICardSelect,
    DisplayBinder,
    PullCard,
    Credits,
    Exit
}

public enum PromptType
{
    Choose, 
    Continue,
    Refresh,
    ReturnToMenu,
    BattleStart,
    Exit
}


public enum CardType
{
    FIRE,
    WATER,
    GRASS
}

public enum RarityLevel
{
    Common = 1,
    Uncommon = 2,
    Rare = 3,
    Epic = 4,
    Legendary = 5
}

public enum BattlePhase
{
    PlayerNormal,
    AINormal,
    PlayerSpecial,
    AISpecial,
    BattleEnd,
    BattleResult
}

public enum StatusEffect
{
    None,
    Burned,
    Confused,
    Poisoned
}
