using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class RoomVisitingTrigger : MonoBehaviour
{
    public int RoomNumForTask = -1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameEventsManager.instance.roomVisitingEvents.RoomVisit(RoomNumForTask);
            Destroy(gameObject);
        }
    }
}
