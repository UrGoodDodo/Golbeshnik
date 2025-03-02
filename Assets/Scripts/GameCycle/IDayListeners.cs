public interface IDayListener : IListener { }; //Marker

/// <summary>
/// Реализует функцию, которая вызывается при старте Дня 1
/// </summary>
public interface IDayOneStartListener : IDayListener
{
    void OnDayOneStart();
};

/// <summary>
/// Реализует функцию, которая вызывается при старте Дня 2
/// </summary>
public interface IDayTwoStartListener : IDayListener
{
    void OnDayTwoStart();
};

/// <summary>
/// Реализует функцию, которая вызывается при старте Дня 3
/// </summary>
public interface IDayThreeStartListener : IDayListener
{
    void OnDayThreeStart();
};