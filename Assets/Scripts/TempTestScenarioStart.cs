using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempTestScenarioStart : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Is Triggered");
            ScenariosControll.Instance.StartScenario(1); 
        }
    }
}
