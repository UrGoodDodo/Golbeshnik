using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LoreStateTransitionPoint : MonoBehaviour
{
    [Header("�������� � ����")]
    [SerializeField] private LoreStateInfoSO loreInfoForPoint;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) // �������� �������� �� ��� ���������� � ��� ��� ��� ������ ����
    {
        //if(startPoint)

    }
}
