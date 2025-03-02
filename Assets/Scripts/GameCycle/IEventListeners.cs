public interface IEventListener : IListener { }; //Marker


/// <summary>
/// ��������� �������, ������� ���������� ��� ������ ������-���� ������� (�������� QTE)
/// </summary>
public interface IEventStartListener : IEventListener
{
    void OnEventStart();
};
/// <summary>
/// ��������� �������, ������� ���������� ��� ���������� ������-���� ������� (�������� QTE)
/// </summary>
public interface IEventFinishListener : IEventListener
{
    void OnEventFinish();
};