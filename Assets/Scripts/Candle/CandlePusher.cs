using System.Collections.Generic;
using UnityEngine;

public sealed class CandlePusher : GameMonoBehaviour
{
    [SerializeField] List<TogglePointLight> candles;

    public void PushCandles()
    {
        foreach (var candle in candles)
        {
            //candle.RigidBody.AddForce();  //TODO: ����� ������ ����� ���������� RigidBody
            //candle.Disable();  //TODO: ����� ������ � ����������� ��� ���������
            //SpawnVisibleTrigger(candle.position, CandleDialog)
        }
    }
}