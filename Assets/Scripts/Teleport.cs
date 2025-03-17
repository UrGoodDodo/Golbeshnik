using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : GameMonoBehaviour
{
    [SerializeField] GameObject _tpPoint;

    public void Interact(GameObject _player)
    {
        Vector3 targetPosition = _tpPoint.transform.position;
        // ������������� ������� ������ �� ������� �������
        _player.transform.position = targetPosition;
    }
}
