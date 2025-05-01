using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowTask : MonoBehaviour
{

    private string taskText;

    private CanvasGroup bigTaskWindowGroup;
    private TextMeshProUGUI bigTaskTxt;

    private TextMeshProUGUI smallTaskTxt;

    public float delay = 0.1f;

    private void Awake()
    {
        smallTaskTxt = GameObject.FindWithTag("TaskWindow").GetComponentInChildren<TextMeshProUGUI>();
        bigTaskTxt = GetComponentInChildren<TextMeshProUGUI>();
        bigTaskWindowGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.uishowEvents.onStartTask += ShowNewTask;
        GameEventsManager.instance.uishowEvents.onEndTask += DeleteInfoAboutOldTask;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.uishowEvents.onStartTask -= ShowNewTask;
        GameEventsManager.instance.uishowEvents.onEndTask -= DeleteInfoAboutOldTask;
    }



    void ShowNewTask(string taskName) 
    {
        taskText = taskName;
        smallTaskTxt.text = taskName;
        //StartCoroutine(ShowTaskWindowPerSymbol(taskName));
        StartCoroutine(ShowTaskWindowWithAlpha(taskName));
    }

    

    IEnumerator ShowTaskWindowWithAlpha(string text) 
    {
        yield return new WaitForSeconds(2);
        StartCoroutine(PrintTaskTextWithAlpha(text));

    }

    IEnumerator PrintTaskTextWithAlpha(string text) 
    {
        bigTaskTxt.text = text;
        for (float i = 0.0f; i < 1.0; i += 0.1f) 
        {
            bigTaskWindowGroup.alpha = i;
            yield return new WaitForSeconds(delay);
        }
        bigTaskWindowGroup.alpha = 1.0f;
        yield return new WaitForSeconds(1f);
        for (float i = 1.0f; i >= 0.0; i -= 0.1f)
        {
            bigTaskWindowGroup.alpha = i;
            yield return new WaitForSeconds(delay);
        }
        bigTaskWindowGroup.alpha = 0.0f;
    }

    IEnumerator ShowTaskWindowPerSymbol(string text) //поменять на плавное появление и исчезновения
    {
        yield return new WaitForSeconds(2);
        bigTaskWindowGroup.alpha = 1.0f;

        var time = text.Length * 0.05f + 2f;
        StartCoroutine(PrintTaskTextPerSymbol(text));
        yield return new WaitForSeconds(time);

        bigTaskWindowGroup.alpha = 0.0f;
    }

    IEnumerator PrintTaskTextPerSymbol(string str)
    {
        var tt = bigTaskTxt;
        var tts = "";
        foreach (var sym in str)
        {
            tts += sym;
            tt.text = tts;
            yield return new WaitForSeconds(delay);
        }
    }

    void DeleteInfoAboutOldTask()
    {
        taskText = "";
        smallTaskTxt.text = taskText;
    }

}
