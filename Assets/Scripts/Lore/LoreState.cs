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
        // что-то делаем при заходе в стейт
    }

    public void Exit() 
    {
        // что-то делаем на выходе если надо
    }

    public string GetStateId() 
    {
        return loreStateInfo.loreStateId;
    }

}
