using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvents
{
    public event Action<string> onPlayDialog;
    public void StartTask(string dialogTxt)
    {
        if (onPlayDialog != null)
            onPlayDialog(dialogTxt);
    }
}
