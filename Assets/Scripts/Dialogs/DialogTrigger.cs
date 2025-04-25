using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [TextArea]
    public string DialogText = "Здесь текст вашего диалога";

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Зашел");
        GameEventsManager.instance.uishowEvents.StartDialog(DialogText);
    }
}
