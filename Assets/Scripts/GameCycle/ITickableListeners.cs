
public interface ITickable { } //Marker

/*
    ����������, ������� ��������� ������ Update, FixedUpdate � LateUpdate ������ �� ����� ������������ �������.
    ���� ����� ����� ����� ���������� ������ - ������������� ������� ���������� ������ Update, FixedUpdate, LateUpdate.
*/

// ������ �� ����� �������� ��������, �� ������� ������ (�.�. �� ����� ����� � QTE �������� �� �����)
// (��������� = PLAY)
#region GAME
public interface IGameTickable : ITickable
{
    void Tick(float deltaTime);
}

public interface IGameFixedTickable : ITickable
{
    void FixedTick(float deltaTime);
}

public interface IGameLateTickable : ITickable
{
    void LateTick(float deltaTime);
}
#endregion

// ������ �� ����� �������� ��������, ������� ������ (�.�. �� ����� ����� �������� �� �����)
// (��������� = PLAY || ��������� = EVENT)
#region GAME AND EVENT
public interface IGameEventTickable : ITickable
{
    void Tick(float deltaTime);
}

public interface IGameEventFixedTickable : ITickable
{
    void FixedTick(float deltaTime);
}

public interface IGameEventLateTickable : ITickable
{
    void LateTick(float deltaTime);
}
#endregion

// ������ �� ����� ��� 1
// (��������� = PLAY && ���-��������� = DAY_ONE)
#region DAY ONE
public interface IDayOneTickable : ITickable
{
    void Tick(float deltaTime);
}

public interface IDayOneFixedTickable : ITickable
{
    void FixedTick(float deltaTime);
}

public interface IDayOneLateTickable : ITickable
{
    void LateTick(float deltaTime);
}
#endregion

// ������ �� ����� ��� 2
// (��������� = PLAY && ���-��������� = DAY_TWO)
#region DAY TWO
public interface IDayTwoTickable : ITickable
{
    void Tick(float deltaTime);
}

public interface IDayTwoFixedTickable : ITickable
{
    void FixedTick(float deltaTime);
}

public interface IDayTwoLateTickable : ITickable
{
    void LateTick(float deltaTime);
}
#endregion

// ������ �� ����� ��� 3
// (��������� = PLAY && ���-��������� = DAY_THREE)
#region DAY THREE
public interface IDayThreeTickable : ITickable
{
    void Tick(float deltaTime);
}

public interface IDayThreeFixedTickable : ITickable
{
    void FixedTick(float deltaTime);
}

public interface IDayThreeLateTickable : ITickable
{
    void LateTick(float deltaTime);
}
#endregion