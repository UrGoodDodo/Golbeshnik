using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRightRoomTaskStep : TaskStep
{
    private int roomId = 0; // Константо или нет пока хз

    private void OnEnable()
    {
        // подписываемся на событие что посетили
    }

    private void OnDisable()
    {
        // отписываемся на событие что посетили
    }

    private void RoomVisited(int num) 
    {
        if (roomId == num)
            FinishTaskStep();
    }

}
