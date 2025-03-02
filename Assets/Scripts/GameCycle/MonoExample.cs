using UnityEngine;

/*
     ПРИМЕР РЕАЛИЗАЦИИ КЛАССА MonoBehaviour
*/
public sealed class MonoExample : GameMonoBehaviour,
    /*
     1. Наследуем от GameMonoBehaviour (вместо MonoBehaviour)
     2. Добавляем все (только те которые хотим реализовать) интерфейсы
    */
    IGameStartListener,
    IGamePauseListener,
    IGameResumeListener,
    IGameFinishListener,
    IGameFixedTickable,
    IGameEventFixedTickable,
    IDayOneFixedTickable,
    IDayTwoFixedTickable,
    IDayThreeFixedTickable,
    IDayOneStartListener,
    IDayTwoStartListener,
    IDayThreeStartListener,
    IEventStartListener,
    IEventFinishListener
{
    /*
     3. Пишем реализацию интерфейсов
    */
    void IGameFixedTickable.FixedTick(float deltaTime)
    {
        Debug.Log("GAME Fixed Update");
    }

    void IGameEventFixedTickable.FixedTick(float deltaTime)
    {
        Debug.Log("GAME EVENT Fixed Update");
    }

    void IDayOneFixedTickable.FixedTick(float deltaTime)
    {
        Debug.Log("DAY ONE Fixed Update");
    }

    void IDayTwoFixedTickable.FixedTick(float deltaTime)
    {
        Debug.Log("DAY TWO Fixed Update");
    }

    void IDayThreeFixedTickable.FixedTick(float deltaTime)
    {
        Debug.Log("DAY THREE Fixed Update");
    }

    void IDayOneStartListener.OnDayOneStart()
    {
        Debug.Log("DAY ONE start!");
    }

    void IDayThreeStartListener.OnDayThreeStart()
    {
        Debug.Log("DAY THREE start!");
    }

    void IDayTwoStartListener.OnDayTwoStart()
    {
        Debug.Log("DAY TWO start!");
    }

    void IEventFinishListener.OnEventFinish()
    {
        Debug.Log("EVENT finish!");
    }

    void IEventStartListener.OnEventStart()
    {
        Debug.Log("EVENT start!");
    }

    void IGameFinishListener.OnGameFinish()
    {
        Debug.Log("GAME finished!");
    }

    void IGamePauseListener.OnGamePause()
    {
        Debug.Log("GAME paused!");
    }

    void IGameResumeListener.OnGameResume()
    {
        Debug.Log("GAME resumed!");
    }

    void IGameStartListener.OnGameStart()
    {
        Debug.Log("GAME start!");
    }

    /*
     4. Если вам нужны методы Awake или OnDestroy:
    */

    protected override void Awake()
    {
        base.Awake();

        //Ваша реализация
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        //Ваша реализация
    }

    /*
     5. Все остальное по вашему желанию как и было до этого.
    */
}