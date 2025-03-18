using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneQTETrigger : MonoBehaviour
{
    [SerializeField] IScenario _curScenario;
    [SerializeField] int _sceneNumber;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "player")
        {
            if(_curScenario != null)
            {
                _curScenario.StartScenario();
                //спавын QTE
            }
        }
    }


    
}
