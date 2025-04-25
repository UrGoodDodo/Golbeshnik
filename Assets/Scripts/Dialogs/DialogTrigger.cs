using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [TextArea]
    public string DialogText = "����� ����� ������ �������";

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("�����");
        GameEventsManager.instance.uishowEvents.StartDialog(DialogText);
    }
}
