public interface IDayListener : IListener { }; //Marker

/// <summary>
/// ��������� �������, ������� ���������� ��� ������ ��� 1
/// </summary>
public interface IDayOneStartListener : IDayListener
{
    void OnDayOneStart();
};

/// <summary>
/// ��������� �������, ������� ���������� ��� ������ ��� 2
/// </summary>
public interface IDayTwoStartListener : IDayListener
{
    void OnDayTwoStart();
};

/// <summary>
/// ��������� �������, ������� ���������� ��� ������ ��� 3
/// </summary>
public interface IDayThreeStartListener : IDayListener
{
    void OnDayThreeStart();
};