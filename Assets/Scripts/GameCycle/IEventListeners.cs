public interface IEventListener : IListener { }; //Marker


/// <summary>
/// Реализует функцию, которая вызывается при начале какого-либо события (например QTE)
/// </summary>
public interface IEventStartListener : IEventListener
{
    void OnEventStart();
};
/// <summary>
/// Реализует функцию, которая вызывается при завершении какого-либо события (например QTE)
/// </summary>
public interface IEventFinishListener : IEventListener
{
    void OnEventFinish();
};