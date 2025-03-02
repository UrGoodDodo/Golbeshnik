
public interface IListener { }; //Marker
public interface IGameListener : IListener { }; //Marker

/// <summary>
/// Реализует функцию, которая вызывается при старте игрового процесса
/// </summary>
public interface IGameStartListener : IGameListener
{
    void OnGameStart();
};

/// <summary>
/// Реализует функцию, которая вызывается при нажатии паузы
/// </summary>
public interface IGamePauseListener : IGameListener
{
    void OnGamePause();
};

/// <summary>
/// Реализует функцию, которая вызывается при отжатии паузы
/// </summary>
public interface IGameResumeListener : IGameListener
{
    void OnGameResume();
};

/// <summary>
/// Реализует функцию, которая вызывается при окончании игрового процесса
/// </summary>
public interface IGameFinishListener : IGameListener
{
    void OnGameFinish();
};
