using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlaceTaskStep : TaskStep
{
    private void OnEnable()
    {
        GameEventsManager.instance.roomVisitingEvents.onRoomVisit += VisitPlace;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.roomVisitingEvents.onRoomVisit -= VisitPlace;
    }

    void VisitPlace(int num) //число опционально wharever
    {
        FinishTaskStep();
    }
}
