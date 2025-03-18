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
    IEventFixedTickable,
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

    void IEventFixedTickable.FixedTick(float deltaTime)
    {
        Debug.Log("EVENT Fixed Update");
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

    void IEventStartListener.OnEventStart(EventType eventType)
    {
        Debug.Log("EVENT start!");
        Debug.Log(eventType);
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
     4. Если нам нужны методы Awake или OnDestroy:
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
     6. Если нам нужно из нашего класса сказать что вызвалось определенное событие, например Начало второго дня:
    */
    private void DayTwoStart()
    {
        GameCycle.Instance.StartDayTwo();
    }

    /*
     7. Если нам нужно в нашем классе проверить текущее состояние игры: 
    */
    private void YourFunction()
    {
        if (GameCycle.Instance.MainState == GameState.PLAY)
        {
            //Реализация если состояние == PLAY

            if (GameCycle.Instance.SubState == GameSubState.DAY_THREE)
            {
                //Реализация если саб-состояние == DAY_THREE
            }
        }
    }

    /*
     8. Остальное по вашему желанию как оно и было до этого.
    */
}