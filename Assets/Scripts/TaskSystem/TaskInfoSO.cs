using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TaskInfoSO", menuName ="ScriptableObjects/TaskInfoSO", order = 1)]
public class TaskInfoSO : ScriptableObject
{
    [field:SerializeField]
    public string id { get; private set; }

    [Header("Основная")]
    public string TaskName;

    [Header("Требования")]
    public TaskInfoSO[] taskPrerequisites;

    [Header("Шаги Тасочки")]
    public GameObject[] taskStepPrefabs;


    private void OnValidate() //ID всегда того же вида = имени объекта
    {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
