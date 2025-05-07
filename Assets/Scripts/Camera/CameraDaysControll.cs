using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDaysControll : MonoBehaviour
{

    [SerializeField] protected GameSubState _dayNumber;

    void Update()
    {
        if (_dayNumber == GameCycle.Instance.SubState)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
