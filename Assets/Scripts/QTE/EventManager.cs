using UnityEngine;

public sealed class EventManager : GameMonoBehaviour,
    IEventStartListener,
    IEventFinishListener,
    IEventTickable
{
    [SerializeField]
    private HeartBeat heartBeatQTE;

    [SerializeField]
    private DefaultQTE defaultQTE;

    private EventType currentEvent;

    private bool qteFinished = false;

    private delegate void ActionDelegate(float deltaTime);
    private ActionDelegate onUpdateAction;

    private void Start()
    {
        heartBeatQTE.OnQTEFinish += OnQTEFinish;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        heartBeatQTE.OnQTEFinish -= OnQTEFinish;
    }

    void IEventStartListener.OnEventStart(EventType eventType)
    {
        qteFinished = false;
        currentEvent = eventType;
        onUpdateAction = null;
        switch (eventType)
        {
            case EventType.HEARTH_BEAT:
                if (heartBeatQTE != null)
                {
                    heartBeatQTE.OnEventStart();
                    onUpdateAction = heartBeatQTE.OnUpdate;
                }
                break;
            case EventType.DEFAULT_QTE:
                if (defaultQTE != null)
                {

                }
                break;
        }
    }

    void IEventTickable.Tick(float deltaTime)
    {
        onUpdateAction?.Invoke(deltaTime);
    }

    void IEventFinishListener.OnEventFinish()
    {
        switch (currentEvent)
        {
            case EventType.HEARTH_BEAT:
                if (heartBeatQTE != null)
                {
                    heartBeatQTE.OnEventFinish();
                }
                break;
            case EventType.DEFAULT_QTE:
                if (defaultQTE != null)
                {

                }
                break;
        }
    }

    private void OnQTEFinish()
    {
        qteFinished = true;
        //  TODO
        GameCycle.Instance.FinishEvent();
    }
}