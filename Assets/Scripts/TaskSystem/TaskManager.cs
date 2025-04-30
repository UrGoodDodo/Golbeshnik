using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private Dictionary<string, Task> taskMap;

    private void Awake()
    {
        taskMap = CreateTaskMap();

        foreach (var item in taskMap)
        {
            Debug.Log(item.Value.info.TaskName);
        }
    }

    private void OnEnable()
    {
        GameEventsManager.instance.taskEvents.onStartTask += StartTask;
        GameEventsManager.instance.taskEvents.onAdvanceTask += AdvanceTask;
        GameEventsManager.instance.taskEvents.onFinishTask += FinishTask;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.taskEvents.onStartTask -= StartTask;
        GameEventsManager.instance.taskEvents.onAdvanceTask -= AdvanceTask;
        GameEventsManager.instance.taskEvents.onFinishTask -= FinishTask;
    }

    private void Start()
    {
        foreach (var task in taskMap.Values) // проходимся в начале и говорим всем что с тасочками и в каком они состоянии
        {
            GameEventsManager.instance.taskEvents.TaskStateChange(task);
        }
    }

    private void ChangeTaskState(string id, TaskState state) 
    {
        Task task = GetTaskById(id);
        task.state = state;
        GameEventsManager.instance.taskEvents.TaskStateChange(task);
    }

    private bool CheckRequirements(Task task) // Надо подумать и доработать чтобы свои условия начала были (пока тут легко сделать константые внутри самого класса и обновлять их)
    {
        bool meetsRequirements = true;

        foreach (TaskInfoSO prerequisiteTaskInfo in task.info.taskPrerequisites) 
        {
            if (GetTaskById(prerequisiteTaskInfo.id).state != TaskState.FINISHED)
                meetsRequirements = false;
        }

        return meetsRequirements;
        
    }

    private void Update()
    {
        foreach (var task in taskMap.Values) 
        {
            if (task.state.Equals(TaskState.REQUIREMENTS_NOT_MET) && CheckRequirements(task)) // Бегаем по тасочкам и смотрим можно ли их начать, ес да то обновляем их статус
                ChangeTaskState(task.info.id, TaskState.CAN_START);
        }
    }

    private void StartTask(string id) 
    {
        Task task = GetTaskById(id);

        task.InstantiateCurrTaskStep(transform);

        GameEventsManager.instance.uishowEvents.ShowTask(task.info.TaskName);

        ChangeTaskState(id, TaskState.IN_PROGRESS);
    }

    private void AdvanceTask(string id) 
    {
        Task task = GetTaskById(id);

        task.MoveToNextTaskStep();

        if (task.CurrentStepExist())
        {
            task.InstantiateCurrTaskStep(transform);
        }
        else
        {
            ChangeTaskState(id, TaskState.CAN_FINISH);
        }
    }

    private void FinishTask(string id) 
    {
        Task task = GetTaskById(id);
        ChangeTaskState(id, TaskState.FINISHED);
        GameEventsManager.instance.uishowEvents.DeleteTask();
    }


    private Dictionary<string, Task> CreateTaskMap() // Создаем хранилище всех квестов
    {
        TaskInfoSO[] allTasks = Resources.LoadAll<TaskInfoSO>("Tasks"); // Подгружаем из папки  (Важен нейминг пути!)
        Dictionary<string, Task> idToTaskMap = new Dictionary<string, Task>();
        foreach (TaskInfoSO taskInfo in allTasks) 
        {
            if (idToTaskMap.ContainsKey(taskInfo.id)) 
            {
                Debug.Log("Такое уже было в карте!");
            }
            idToTaskMap.Add(taskInfo.id, new Task(taskInfo));
        }
        return idToTaskMap;
    }

    private Task GetTaskById(string id) 
    {
        Task task = taskMap[id];
        if (task == null) 
        {
            Debug.Log("Не нашли тасочку!");
        }
        return task;
    }
}
