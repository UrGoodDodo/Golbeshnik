using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIShowEvents
{
    public event Action<string> onPlayDialog;
    public void StartDialog(string dialogTxt)
    {
        if (onPlayDialog != null)
            onPlayDialog(dialogTxt);
    }

    public event Action<string> onStartTask;
    public void ShowTask(string taskTxt)
    {
        if (onStartTask != null)
            onStartTask(taskTxt);
    }

    public event Action onEndTask;
    public void DeleteTask()
    {
        if (onEndTask != null)
            onEndTask();
    }
}
