/// <summary>
/// Основное состояние игры
/// </summary>
public enum GameState
{
    OFF = 0,
    PLAY = 1,
    EVENT = 2,
    PAUSE = 3,
    FINISH = 4
}

/// <summary>
/// Дополнительное состояние игры
/// </summary>
public enum GameSubState
{
    NONE = 0,
    DAY_ONE = 1,
    DAY_TWO = 2,
    DAY_THREE = 3
}