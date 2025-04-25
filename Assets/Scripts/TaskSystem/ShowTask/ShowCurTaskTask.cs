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

    public float delay = 0.05f;

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
        smallTaskTxt.text = taskText;
        StartCoroutine(ShowTaskWindow(taskName));
    }

    IEnumerator ShowTaskWindow(string text) //поменять на плавное появление и исчезновения
    {
        bigTaskWindowGroup.alpha = 1.0f;

        var time = text.Length * 0.05f + 2f;
        StartCoroutine(PrintTaskText(text));
        yield return new WaitForSeconds(time);

        bigTaskWindowGroup.alpha = 0.0f;
    }

    IEnumerator PrintTaskText(string str)
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
