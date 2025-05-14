using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System;
using UnityEngine;

public sealed class GameEventSystem : MonoBehaviour
{
    [SerializeField] private QTESystem qteSystem;
    [SerializeField] private ScenariosControll scenarioSystem;

    public async UniTask StartEvent(QTEKey qte, int scenarioNumber)
    {
        if (GameCycle.Instance.MainState == GameState.EVENT)
        {
            return;
        }

        GameCycle.Instance.StartEvent();

        UniTask scenarioEvent = scenarioSystem.StartScenario(scenarioNumber);
        UniTask qteEvent = qteSystem.StartQuickTimeEvent(qte);
        await UniTask.WhenAll(qteEvent, scenarioEvent);

        GameCycle.Instance.FinishEvent();
    }

    #region DEBUG

    [Button("StartHeartBeat without scenario")]
    private void DebugOne()
    {
        StartEvent(QTEKey.HEART_BEAT, 0).Forget();
    }

    [Button("StartHeartBeat with scenario 1")]
    private void DebugTwo()
    {
        StartEvent(QTEKey.HEART_BEAT, 1).Forget();
    }
    #endregion
}