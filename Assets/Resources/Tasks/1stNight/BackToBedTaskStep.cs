using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToBedTaskStep : TaskStep
{
    private int roomNum = 3;

    private void OnEnable()
    {
        GameEventsManager.instance.roomVisitingEvents.onRoomVisit += ApproachedBed;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.roomVisitingEvents.onRoomVisit -= ApproachedBed;
    }

    private void ApproachedBed(int num)
    {
        if (roomNum == num)
            FinishTaskStep();
    }
}
