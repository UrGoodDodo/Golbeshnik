
using UnityEngine;

//Это знать не нужно.
public class GameMonoBehaviour: MonoBehaviour
{
    protected virtual void Awake()
    {
        if (this is IListener listener)
        {
            GameCycle.Instance.AddListener(listener);
        }
        if (this is ITickable tickableListener)
        {
            GameCycle.Instance.AddTickableListener(tickableListener);
        }
    }

    protected virtual void OnDestroy()
    {
        if (this is IListener listener)
        {
            GameCycle.Instance.RemoveListener(listener);
        }
        if (this is ITickable tickableListener)
        {
            GameCycle.Instance.RemoveTickableListener(tickableListener);
        }
    }
}