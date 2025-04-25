using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTheNurseryTaskStep : TaskStep
{

    private int roomNum = 1;

    private void OnEnable()
    {
        GameEventsManager.instance.roomVisitingEvents.onRoomVisit += NurseryVisited;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.roomVisitingEvents.onRoomVisit -= NurseryVisited;
    }

    private void NurseryVisited(int num) 
    {
        if (roomNum == num)
            FinishTaskStep();
    }

}
