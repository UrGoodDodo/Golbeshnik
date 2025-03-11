using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneQTETrigger : MonoBehaviour
{
    
    [SerializeField] int _sceneNumber;
    [SerializeField] GameObject _cutscene;
    [SerializeField] Camera _mainCamera;
    [SerializeField] Camera _cutsceneCamera;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _cutsceneCamera.gameObject.SetActive(true);
            _mainCamera.gameObject.SetActive(false);
            Debug.Log("Camera");
            //передавать номер сцены тригеру сценариев
            //инвокать событие и передавать параметр номера сцены
            //Action(sceneNum)
        }
    }


    
}
