
public interface ITickable { } //Marker

/*
    Интерфейсы, которые реализуют методы Update, FixedUpdate и LateUpdate только во время определенных событий.
    Если нужно чтобы метод срабатывал ВСЕГДА - реализовывать обычные юнитовские методы Update, FixedUpdate, LateUpdate.
*/

// Только во время игрового процесса, не включая Ивенты (т.е. во время Паузы и QTE работать не будут)
// (состояние = PLAY)
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

// Только во время игрового процесса, включая Ивенты (т.е. во время Паузы работать не будут)
// (состояние = PLAY || состояние = EVENT)
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

// Только во время дня 1
// (состояние = PLAY && саб-состояние = DAY_ONE)
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

// Только во время дня 2
// (состояние = PLAY && саб-состояние = DAY_TWO)
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

// Только во время дня 3
// (состояние = PLAY && саб-состояние = DAY_THREE)
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