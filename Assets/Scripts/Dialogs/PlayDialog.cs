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

    private void Awake()
    {
        uiText = GetComponentInChildren<TextMeshProUGUI>();
        cnGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.dialogEvents.onPlayDialog += PlayingDialog;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.dialogEvents.onPlayDialog -= PlayingDialog;
    }

    public void PlayingDialog(string text)
    {
        //Debug.Log("Попал");
        StartCoroutine(PrintDialog(text));
    }

    IEnumerator PrintDialog(string text) 
    {
        cnGroup.alpha = 1.0f;

        var time = text.Length * 0.05f + 2f;
        StartCoroutine(PrintText(text, 0.05f));
        yield return new WaitForSeconds(time);

        cnGroup.alpha = 0.0f;
    }

    IEnumerator PrintText(string str, float delay)
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
}
