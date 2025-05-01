using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayDialog : MonoBehaviour
{

    private TextMeshProUGUI uiText;

    private CanvasGroup cnGroup;

    public float delay = 0.1f;

    private void Awake()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        cnGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.uishowEvents.onPlayDialog += PlayingDialog;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.uishowEvents.onPlayDialog -= PlayingDialog;
    }

    public void PlayingDialog(string text)
    {
        //StartCoroutine(PrintDialog(text));
        StartCoroutine(PrintDialogTextWithAlpha(text));
    }

    IEnumerator PrintDialog(string text) 
    {
        cnGroup.alpha = 1.0f;

        var time = text.Length * 0.05f + 2f;
        StartCoroutine(PrintText(text));
        yield return new WaitForSeconds(time);

        cnGroup.alpha = 0.0f;
    }

    IEnumerator PrintText(string str)
    {
        var tt = uiText;
        var tts = "";
        foreach (var sym in str)
        {
            tts += sym;
            tt.text = tts;
            yield return new WaitForSeconds(delay);
        }

    }

    IEnumerator PrintDialogTextWithAlpha(string text)
    {
        uiText.text = text;
        for (float i = 0.0f; i < 1.0; i += 0.1f)
        {
            cnGroup.alpha = i;
            yield return new WaitForSeconds(delay);
        }
        cnGroup.alpha = 1.0f;
        yield return new WaitForSeconds(1f);

        for (float i = 1.0f; i >= 0.0; i -= 0.1f)
        {
            cnGroup.alpha = i;
            yield return new WaitForSeconds(delay);
        }
        cnGroup.alpha = 0.0f;

    }
}
