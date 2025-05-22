using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressKeyToMenu : MonoBehaviour
{
    private void Update()
    {
        if (GameCycle.Instance.MainState == GameState.FINISH)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
