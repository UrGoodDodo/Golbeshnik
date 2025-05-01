using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeState : MenusState
{

    public ResumeState() 
    {

    }

    public override void Enter()
    {
        GameCycle.Instance.ResumeGame();
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public override void Exit()
    {
        GameCycle.Instance.PauseGame();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
