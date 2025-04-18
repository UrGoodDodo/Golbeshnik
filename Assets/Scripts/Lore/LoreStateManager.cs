using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoreStateManager : MonoBehaviour // ����� ��� ����� ���� (����� 3 �������)
{

    List<LoreState> loreStates;

    public int nightNumber = 1;

    private int curLoreStateNum = 0;
    private LoreState curLoreState;

    private void Awake()
    {
        loreStates = CreateLoreStates();
        curLoreState = loreStates.First();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.loreEvents.onLoreStateChange += TransitionLoreStates;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.loreEvents.onLoreStateChange -= TransitionLoreStates;
    }

    void Start()
    {
        curLoreState.Enter(); // ���� �� ����� �������� �������� ������� ������� �� ����� ���� ���
    }

    // Update is called once per frame
    void Update()
    {
        //if (curLoreState != null)
        //    curLoreState.UpdateState(Time.deltaTime);
    }

    public List<LoreState> CreateLoreStates() 
    {

        LoreStateInfoSO[] allStates = Resources.LoadAll<LoreStateInfoSO>("LoreStates" + nightNumber);
        List<LoreState> tempLoreStatesList = new List<LoreState>();
        foreach (LoreStateInfoSO stateInfo in allStates)
        {
            tempLoreStatesList.Append(new LoreState(stateInfo));
        }

        return tempLoreStatesList;
    }

    public void TransitionLoreStates() // �������� ����� �� ������ ���� (� �������� �����)
    {
        curLoreState.Exit();
        curLoreStateNum++;
        curLoreState = loreStates[curLoreStateNum];
        curLoreState.Enter();
    }
}
