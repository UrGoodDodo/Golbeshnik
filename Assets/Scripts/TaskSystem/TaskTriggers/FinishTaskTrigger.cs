using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FinishTaskTrigger : MonoBehaviour
{
    //public int RoomNumForTask = -1;

    [SerializeField]
    private TaskInfoSO taskInfo;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            //GameEventsManager.instance.roomVisitingEvents.RoomVisit(RoomNumForTask);
            GameEventsManager.instance.taskEvents.FinishTask(taskInfo.id);
            Destroy(gameObject);
        }
    }
}
