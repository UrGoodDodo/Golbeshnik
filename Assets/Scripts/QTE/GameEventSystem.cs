using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System;
using UnityEngine;

public sealed class GameEventSystem : MonoBehaviour
{
    [SerializeField] private QTESystem qteSystem;

    public async UniTask StartEvent(QTEKey qte)
    {
        if (GameCycle.Instance.MainState == GameState.EVENT)
        {
            return;
        }

        GameCycle.Instance.StartEvent();

        UniTask qteEvent = qteSystem.StartQuickTimeEvent(qte);
        await UniTask.WhenAll(qteEvent);

        GameCycle.Instance.FinishEvent();
    }

    #region DEBUG

    [Button("StartHeartBeat without scenario")]
    private void DebugOne()
    {
        StartEvent(QTEKey.HEART_BEAT).Forget();
    }
    #endregion
}