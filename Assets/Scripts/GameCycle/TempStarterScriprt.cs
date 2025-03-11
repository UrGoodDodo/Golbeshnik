using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempStarterScriprt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameCycle.Instance.StartGame();
    }
}
