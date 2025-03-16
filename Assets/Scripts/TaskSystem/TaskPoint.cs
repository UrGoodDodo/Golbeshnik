using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshCollider), typeof(BoxCollider), typeof(SphereCollider))]
public class TaskPoint : MonoBehaviour
{
    private bool playerIsIn = false;

    [Header("Тасочка")]
    [SerializeField] private TaskInfoSO taskInfoForPoint;

    [Header("Настройки")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;
    
    private string taskId;
    private TaskState curTaskState;

    private void Awake()
    {
        taskId = taskInfoForPoint.id;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.taskEvents.onTaskStateChange += TaskStateChange;
        //еще какое-то условие чтобы прокнуть начало/изменнение/конец квеста
    }

    private void OnDisable()
    {
        GameEventsManager.instance.taskEvents.onTaskStateChange -= TaskStateChange;
        //еще какое-то условие чтобы прокнуть начало/изменнение/конец квеста
    }

    //Пример функции для начала и завершения тасочки
    private void SubmitPressed() 
    {
        if (!playerIsIn)
            return;

        if (curTaskState.Equals(TaskState.CAN_START) && startPoint)
            GameEventsManager.instance.taskEvents.StartTask(taskId);
        else if (curTaskState.Equals(TaskState.CAN_FINISH) && finishPoint)
            GameEventsManager.instance.taskEvents.FinishTask(taskId);
    }

    private void TaskStateChange(Task task) 
    {
        if (task.info.id.Equals(taskId)) 
        {
            curTaskState = task.state;

        }
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            playerIsIn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerIsIn = false;
    }
}
