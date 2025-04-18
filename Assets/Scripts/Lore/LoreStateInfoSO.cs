using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "LoreStateInfoSO", menuName = "ScriptableObjects/LoreStateInfoSO", order = 1)]
public class LoreStateInfoSO : ScriptableObject
{
    [field: SerializeField]
    public string loreStateId { get; private set; }

    [Header("��������")]
    public string StateName; // ������������ ��������� (������ ��� ����)
    
    [TextArea]
    public string DialogText; // ������� ��� ����� ���������

    [Header("�������")]
    public string StartingTaskId = null; // ���� ���� ������ ����� �� ���� �� ��������
    public string FinishingTaskId = null;

    //����� �������� (������������/ id / � �.�.) ����� ����� ���� ��� ���������� � ������ ��� ������� ��� � �����

    private void OnValidate() //ID ������ ���� �� ���� = ����� �������
    {
        #if UNITY_EDITOR
        loreStateId = name;
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
}
