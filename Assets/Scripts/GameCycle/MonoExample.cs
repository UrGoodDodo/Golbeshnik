using UnityEngine;

/*
     ������ ���������� ������ MonoBehaviour
*/
public sealed class MonoExample : GameMonoBehaviour,
    /*
     1. ��������� �� GameMonoBehaviour (������ MonoBehaviour)
     2. ��������� ��� (������ �� ������� ����� �����������) ����������
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
    IDayStartListener,
    IEventStartListener,
    IEventFinishListener
{
    /*
     3. ����� ���������� �����������
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

    void IDayStartListener.OnDayStart(GameSubState state)
    {
        Debug.Log(state);
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
     4. ���� ��� ����� ������ Awake ��� OnDestroy:
    */
  
    protected override void Awake()
    {
        base.Awake();

        //���� ����������
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        //���� ����������
    }

    /*
     6. ���� ��� ����� �� ������ ������ ������� ��� ��������� ������������ �������, �������� ������ ������� ���:
    */
    private void DayTwoStart()
    {
        GameCycle.Instance.StartDay(GameSubState.DAY_TWO);
    }

    /*
     7. ���� ��� ����� � ����� ������ ��������� ������� ��������� ����: 
    */
    private void YourFunction()
    {
        if (GameCycle.Instance.MainState == GameState.PLAY)
        {
            //���������� ���� ��������� == PLAY

            if (GameCycle.Instance.SubState == GameSubState.DAY_THREE)
            {
                //���������� ���� ���-��������� == DAY_THREE
            }
        }
    }

    /*
     8. ��������� �� ������ ������� ��� ��� � ���� �� �����.
    */
}