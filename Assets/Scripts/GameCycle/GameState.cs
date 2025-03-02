/// <summary>
/// Основное состояние игры
/// </summary>
public enum GameState
{
    OFF = 0, //Игровой процесс выключен
    PLAY = 1, //Игровой процесс идет
    EVENT = 2, //Идет ивент (например QTE)
    PAUSE = 3, //Пауза
    FINISH = 4 //Игровой процесс завершен
}

/// <summary>
/// Дополнительное состояние игры
/// </summary>
public enum GameSubState
{
    NONE = 0, 
    DAY_ONE = 1, //День первый
    DAY_TWO = 2, //День второй
    DAY_THREE = 3 //День третий
}