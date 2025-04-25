using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LoreStateTransitionPoint : MonoBehaviour
{
    [Header("������� � ����")]
    [SerializeField] private LoreStateInfoSO loreInfoForPoint;


    private void OnTriggerEnter(Collider other) // �������� �������� �� ��� ���������� � ��� ��� ��� ������ ����
    {
        if (other.CompareTag("Player")) 
        {
            GameEventsManager.instance.loreEvents.MoveToNextState();
        }

    }
}
