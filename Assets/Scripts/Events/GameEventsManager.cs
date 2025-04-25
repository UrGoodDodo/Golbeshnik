using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public TaskEvents taskEvents;

    public UIShowEvents uishowEvents;

    public LoreEvents loreEvents;

    public RoomVisitingEvents roomVisitingEvents;

    private void Awake()
    {
        if (instance != null) 
        {
            Debug.Log("Больше одного ивент менеджера!");
        }
        instance = this;

        taskEvents = new TaskEvents();
        uishowEvents = new UIShowEvents();
        loreEvents = new LoreEvents();
        roomVisitingEvents = new RoomVisitingEvents();
    }
}
