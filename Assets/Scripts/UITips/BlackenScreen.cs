using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackenScreen : MonoBehaviour
{
    CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.uishowEvents.onEndingDay += ScreenDarkening;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.uishowEvents.onEndingDay -= ScreenDarkening;
    }

    void ScreenDarkening() 
    {
        StartCoroutine(BlackeningScreen());
    }

    IEnumerator BlackeningScreen() 
    {
        for (float i = 0.0f; i < 1.0; i += 0.1f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForSeconds(0.1f);
        }

        canvasGroup.alpha = 1.0f;
        yield return new WaitForSeconds(6f);

        for (float i = 1.0f; i >= 0.0; i -= 0.1f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForSeconds(0.1f);
        }
        canvasGroup.alpha = 0.0f;
    }
}
