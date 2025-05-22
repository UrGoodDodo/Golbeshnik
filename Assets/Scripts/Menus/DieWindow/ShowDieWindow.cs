using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDieWindow : MonoBehaviour
{
    CanvasGroup mainCanvasGroup;

    CanvasGroup childCanvasGroup;

    private void Awake()
    {
        mainCanvasGroup = GetComponent<CanvasGroup>();

        Transform child = transform.Find("TextNButtons");
        childCanvasGroup = child.GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        HeartBeat.OnGameOver += StartShowingDieWindow;
    }

    private void OnDisable()
    {
        HeartBeat.OnGameOver -= StartShowingDieWindow;
    }

    void StartShowingDieWindow() => StartCoroutine(ShowingDieScreen());

    IEnumerator ShowingDieScreen()
    {
        for (float i = 0.0f; i < 1.0; i += 0.1f)
        {
            mainCanvasGroup.alpha = i;
            yield return new WaitForSeconds(0.1f);
        }
        mainCanvasGroup.alpha = 1.0f;
        yield return new WaitForSeconds(0.2f);

        for (float i = 0.0f; i < 1.0; i += 0.1f)
        {
            childCanvasGroup.alpha = i;
            yield return new WaitForSeconds(0.1f);
        }
        childCanvasGroup.alpha = 1.0f;
        childCanvasGroup.interactable = true;
        mainCanvasGroup.interactable = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameCycle.Instance.FinishGame();
    }
}
