using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameCycle.Instance.StartGame();
        GameCycle.Instance.StartDay(GameSubState.DAY_ONE);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
