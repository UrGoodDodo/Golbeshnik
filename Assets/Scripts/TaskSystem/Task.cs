using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public TaskInfoSO info;

    public TaskState state;

    private int currTaskStepInd;

    public Task(TaskInfoSO taskInfo) //�������������� �������
    {
        info = taskInfo;
        state = TaskState.REQUIREMENTS_NOT_MET;
        currTaskStepInd = 0;
    }

    public void MoveToNextTaskStep() // ��������� �� ���� ��� �������
    {
        currTaskStepInd++;
    }

    public bool CurrentStepExist() // �������� �� ������������� �������� ���� �������
    {
        return currTaskStepInd < info.taskStepPrefabs.Length;
    }

    public void InstantiateCurrTaskStep(Transform parentTransform) 
    {
        GameObject taskStepPrefab = GetCurTaskStepPrefab();
        if (taskStepPrefab != null) 
        {
            TaskStep taskStep = Object.Instantiate(taskStepPrefab, parentTransform).GetComponent<TaskStep>(); // ��� ����������� ����� ���������� � object pooling
            taskStep.InitializeTaskStep(info.id);
        }
    }

    private GameObject GetCurTaskStepPrefab() // ����� ������� ��� ������� ���� �����
    {
        GameObject taskStepPrefab = null;
        if (CurrentStepExist())
        {
            taskStepPrefab = info.taskStepPrefabs[currTaskStepInd];
        }
        else 
        {
            Debug.Log("����� �� ������!");
        }
        return taskStepPrefab;
    }
}
