using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreState
{
    private LoreStateInfoSO loreStateInfo;

    public LoreState(LoreStateInfoSO loreStateInfo)
    {
        this.loreStateInfo = loreStateInfo;
    }

    public void Enter() 
    {
        // ���-�� ������ ��� ������ � �����
    }

    public void Exit() 
    {
        // ���-�� ������ �� ������ ���� ����
    }

    public string GetStateId() 
    {
        return loreStateInfo.loreStateId;
    }

}
