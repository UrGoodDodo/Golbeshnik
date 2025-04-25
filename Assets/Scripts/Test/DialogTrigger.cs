using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Зашел");
        GameEventsManager.instance.dialogEvents.StartDialog("Текст для диалога уау");
    }
}
