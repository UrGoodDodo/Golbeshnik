using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("�����");
        GameEventsManager.instance.dialogEvents.StartDialog("����� ��� ������� ���");
    }
}
