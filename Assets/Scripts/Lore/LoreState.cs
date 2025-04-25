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
        if (loreStateInfo.DialogText != "")
            GameEventsManager.instance.uishowEvents.StartDialog(loreStateInfo.DialogText);
        if (loreStateInfo.StartingTaskId != "")
            GameEventsManager.instance.taskEvents.StartTask(loreStateInfo.StartingTaskId);
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
