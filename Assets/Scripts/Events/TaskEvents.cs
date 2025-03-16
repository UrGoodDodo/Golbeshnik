using System;

public class TaskEvents
{
    public event Action<string> onStartTask;
    public void StartTask(string id) 
    {
        if(onStartTask != null)
            onStartTask(id);
    }


    public event Action<string> onAdvanceTask;
    public void AdvanceTask(string id)
    {
        if (onAdvanceTask != null)
            onAdvanceTask(id);
    }


    public event Action<string> onFinishTask;
    public void FinishTask(string id)
    {
        if (onFinishTask != null)
            onFinishTask(id);
    }


    public event Action<Task> onTaskStateChange;
    public void TaskStateChange(Task task)
    {
        if (onTaskStateChange != null)
            onTaskStateChange(task);
    }
}
