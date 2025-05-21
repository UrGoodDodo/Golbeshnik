using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTestScenarioStart : MonoBehaviour
{

    public int _number;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Is Triggered");
            ScenariosControll.Instance.StartScenario(_number); 
        }
    }
}
