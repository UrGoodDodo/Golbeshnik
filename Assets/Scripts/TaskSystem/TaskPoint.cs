using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TaskPoint : MonoBehaviour
{
    private bool playerIsIn = false;

    [Header("�������")]
    [SerializeField] private TaskInfoSO taskInfoForPoint;

    [Header("���������")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;
    
    private string taskId;
    private TaskState curTaskState;

    private void Awake()
    {
        taskId = taskInfoForPoint.id;
    }

    private void Update()
    {
       // Debug.Log(Time.timeScale);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.taskEvents.onTaskStateChange += TaskStateChange;
        //��� �����-�� ������� ����� �������� ������/����������/����� ������
    }

    private void OnDisable()
    {
        GameEventsManager.instance.taskEvents.onTaskStateChange -= TaskStateChange;
        //��� �����-�� ������� ����� �������� ������/����������/����� ������
    }

    //������ ������� ��� ������ � ���������� �������
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
        Debug.Log("���-��");
        
        if (other.CompareTag("Player"))
            playerIsIn = true;


        if (!playerIsIn)
            return;

        if (curTaskState.Equals(TaskState.CAN_START) && startPoint)
            GameEventsManager.instance.taskEvents.StartTask(taskId);
        else if (curTaskState.Equals(TaskState.CAN_FINISH) && finishPoint)
            GameEventsManager.instance.taskEvents.FinishTask(taskId);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.tag);

        if (other.CompareTag("Player"))
            playerIsIn = false;
    }
}
