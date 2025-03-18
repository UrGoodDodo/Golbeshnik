using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskStep : MonoBehaviour
{
    private bool isFinished = false;

    private string taskId;

    public void InitializeTaskStep(string taskId) 
    {
        this.taskId = taskId;
    }

    protected void FinishTaskStep() // завершаем шаг тасочки
    {
        if (!isFinished) 
        {
            isFinished = true;

            GameEventsManager.instance.taskEvents.AdvanceTask(taskId);

            Destroy(gameObject);
        }
    }
}
