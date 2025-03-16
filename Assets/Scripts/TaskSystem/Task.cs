using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task
{
    public TaskInfoSO info;

    public TaskState state;

    private int currTaskStepInd;

    public Task(TaskInfoSO taskInfo) //Инициализируем тасочку
    {
        info = taskInfo;
        state = TaskState.REQUIREMENTS_NOT_MET;
        currTaskStepInd = 0;
    }

    public void MoveToNextTaskStep() // Двигаемся на след шаг тасочки
    {
        currTaskStepInd++;
    }

    public bool CurrentStepExist() // Проверка на существование текущего шага тасочки
    {
        return currTaskStepInd < info.taskStepPrefabs.Length;
    }

    public void InstantiateCurrTaskStep(Transform parentTransform) 
    {
        GameObject taskStepPrefab = GetCurTaskStepPrefab();
        if (taskStepPrefab != null) 
        {
            TaskStep taskStep = Object.Instantiate(taskStepPrefab, parentTransform).GetComponent<TaskStep>(); // для оптимизации можно поиграться с object pooling
            taskStep.InitializeTaskStep(info.id);
        }
    }

    private GameObject GetCurTaskStepPrefab() // Берем текущий шаг тасочки если можно
    {
        GameObject taskStepPrefab = null;
        if (CurrentStepExist())
        {
            taskStepPrefab = info.taskStepPrefabs[currTaskStepInd];
        }
        else 
        {
            Debug.Log("Вышли за размер!");
        }
        return taskStepPrefab;
    }
}
