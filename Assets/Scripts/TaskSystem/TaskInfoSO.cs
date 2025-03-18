using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="TaskInfoSO", menuName ="ScriptableObjects/TaskInfoSO", order = 1)]
public class TaskInfoSO : ScriptableObject
{
    [field:SerializeField]
    public string id { get; private set; }

    [Header("��������")]
    public string TaskName;

    [Header("����������")]
    public TaskInfoSO[] taskPrerequisites;

    [Header("���� �������")]
    public GameObject[] taskStepPrefabs;


    private void OnValidate() //ID ������ ���� �� ���� = ����� �������
    {
        #if UNITY_EDITOR
        id = this.name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
