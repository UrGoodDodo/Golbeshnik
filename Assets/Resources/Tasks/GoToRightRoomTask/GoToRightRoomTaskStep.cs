using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToRightRoomTaskStep : TaskStep
{
    private int roomId = 0; // ��������� ��� ��� ���� ��

    private void OnEnable()
    {
        // ������������� �� ������� ��� ��������
    }

    private void OnDisable()
    {
        // ������������ �� ������� ��� ��������
    }

    private void RoomVisited(int num) 
    {
        if (roomId == num)
            FinishTaskStep();
    }

}
