using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipForQTE : MonoBehaviour
{

    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        HeartBeat.OnQTEFinish += HideTip;
        HeartBeat.OnQTEStarted += ShowTip;
    }

    private void OnDisable()
    {
        HeartBeat.OnQTEFinish -= HideTip;
        HeartBeat.OnQTEStarted -= ShowTip;
    }

    void ShowTip() => canvasGroup.alpha = 1;

    void HideTip() => canvasGroup.alpha = 0;

}
