using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVisitingEvents 
{
    public event Action<int> onRoomVisit;
    public void RoomVisit(int id)
    {
        if (onRoomVisit != null)
            onRoomVisit(id);
    }
}
