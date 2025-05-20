using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstFloorUnlock : GameMonoBehaviour, IDayStartListener
{
    [SerializeField] public GameSubState _dayNumber;

    public void OnDayStart(GameSubState day)
    {
        Debug.Log("Asshole");
        if(day == _dayNumber)
        {
            Destroy(gameObject);
        }
    }

}
