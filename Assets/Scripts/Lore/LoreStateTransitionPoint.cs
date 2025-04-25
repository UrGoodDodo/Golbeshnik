using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LoreStateTransitionPoint : MonoBehaviour
{
    [Header("Событие в Лоре")]
    [SerializeField] private LoreStateInfoSO loreInfoForPoint;


    private void OnTriggerEnter(Collider other) // Подумать начинаем мы или оканизчаем и что тут нам вообще надо
    {
        if (other.CompareTag("Player")) 
        {
            GameEventsManager.instance.loreEvents.MoveToNextState();
        }

    }
}
