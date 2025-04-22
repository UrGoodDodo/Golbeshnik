using System.Collections.Generic;
using UnityEngine;

public sealed class CandlePusher : GameMonoBehaviour
{
    [SerializeField] List<TogglePointLight> candles;

    public void PushCandles()
    {
        foreach (var candle in candles)
        {
            //candle.RigidBody.AddForce();  //TODO: свеча должна иметь переменную RigidBody
            //candle.Disable();  //TODO: свеча тухнет и дизейблится для активации
            //SpawnVisibleTrigger(candle.position, CandleDialog)
        }
    }
}