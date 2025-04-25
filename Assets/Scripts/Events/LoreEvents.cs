using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreEvents
{
    public event Action onLoreStateChange;
    public void MoveToNextState()
    {
        if (onLoreStateChange != null)
            onLoreStateChange();
    }
}
