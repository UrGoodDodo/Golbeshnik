using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneQTETrigger : MonoBehaviour
{
    [SerializeField] IScenario _curScenario;
    [SerializeField] int _sceneNumber;
    [SerializeField] GameObject _cutscene;
    [SerializeField] Camera _mainCamera;
    [SerializeField] Camera _cutsceneCamera;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
<<<<<<< HEAD
            if(_curScenario != null)
            {
                _curScenario.StartScenario();
                //спавын QTE
            }
=======
            _cutsceneCamera.gameObject.SetActive(true);
            _mainCamera.gameObject.SetActive(false);
            Debug.Log("Camera");
            //передавать номер сцены тригеру сценариев
            //инвокать событие и передавать параметр номера сцены
            //Action(sceneNum)
>>>>>>> 4f56c712688540b904cdcbd710c5f48b0bc7c5c7
        }
    }


    
}
