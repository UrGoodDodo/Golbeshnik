using Cysharp.Threading.Tasks;
using UnityEngine;

public sealed class QTESystem : MonoBehaviour
{
    [SerializeField] private HeartBeat heartBeat;

    public async UniTask StartQuickTimeEvent(QTEKey key)
    {
        switch(key)
        {
            case QTEKey.DEFAULT:
                //Debug.Log("default qte");
                break;
            case QTEKey.HEART_BEAT:
                await heartBeat.StartEvent();
                break;
        }
    }
}