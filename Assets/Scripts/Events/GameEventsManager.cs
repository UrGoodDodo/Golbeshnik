using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public TaskEvents taskEvents;

    public DialogEvents dialogEvents;

    public LoreEvents loreEvents;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.Log("Больше одного ивент менеджера!");
        }
        instance = this;

        taskEvents = new TaskEvents();
        dialogEvents = new DialogEvents();
        loreEvents = new LoreEvents();
    }
}
