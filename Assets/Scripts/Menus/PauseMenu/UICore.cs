using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Windows;

public class UICore : MonoBehaviour
{

    private UIInput uiInput;

    private MenusState curmenusState;

    [SerializeField]
    GameObject pauseMenu;
    CanvasGroup pauseGroup;

    [SerializeField]
    GameObject settingsMenu;
    CanvasGroup settingsGroup;

    private void Start()
    {
        uiInput = GetComponent<UIInput>();
        pauseGroup = pauseMenu.GetComponent<CanvasGroup>();
        settingsGroup = settingsMenu.GetComponent<CanvasGroup>();
        MenusTransitionToState(typeof(ResumeState));
    }

    private void Update()
    {
        if (curmenusState != null)
            curmenusState.UpdateState(Time.deltaTime);
    }

    private MenusState MenusStateFactory(Type menusstateType)
    {
        MenusState newState = null;

        if (menusstateType == typeof(ResumeState))
        {
            newState = new ResumeState();
            newState.AddTransition(new PauseGameTransition(uiInput));

        }
        else if (menusstateType == typeof(PauseState))
        {
            newState = new PauseState(pauseGroup);
            newState.AddTransition(new ResumeMenuTransition(uiInput));
            newState.AddTransition(new OpenSettingsMenuTransition(uiInput));
        }
        else if (menusstateType == typeof(SettingsState)) 
        {
            newState = new SettingsState(settingsGroup);
            newState.AddTransition(new CloseSettingsMenuTransition(uiInput));
        }
        else
        {
            throw new Exception($"Type not handled {menusstateType}");
        }

        return newState;
    }

    private void MenusTransitionToState(Type menusstateType)
    {
        MenusState newState = MenusStateFactory(menusstateType);
        if (curmenusState != null)
        {
            curmenusState.Exit();
            curmenusState.OnTransition -= MenusTransitionToState;
        }
        curmenusState = newState;
        curmenusState.OnTransition += MenusTransitionToState;
        curmenusState.Enter();
    }

}
