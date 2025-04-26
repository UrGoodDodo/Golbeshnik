using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoreStateManager : MonoBehaviour // ����� ��� ����� ���� (����� 3 �������)
{

    List<LoreState> loreStates;

    GameObject[] stateTransitions;

    public int nightNumber = 1;

    private int curLoreStateNum = -1;
    private LoreState curLoreState = null;

    private void Awake()
    {
        loreStates = CreateLoreStates();
        ConfigureTransitionsOnStage();
        foreach (var state in loreStates)
        {
            Debug.Log(state.GetStateId());
        }
        //curLoreState = loreStates.First();
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
        //curLoreState.Enter(); ���� �� ����� �������� �������� ������� ������� �� ����� ���� ���
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
            tempLoreStatesList.Add(new LoreState(stateInfo));
        }
        return tempLoreStatesList;
    }

    public void TransitionLoreStates() // �������� ����� �� ������ ���� (� �������� �����)
    {
        if (curLoreState != null) 
        {
            curLoreState.Exit();
        }

        stateTransitions[curLoreStateNum + 1].SetActive(false); // �.�. �������������� ��� ������� ����� � ��� ��������� ��� ���� ����� ���������� (�� ���� ��)

        curLoreStateNum++;
        curLoreState = loreStates[curLoreStateNum];
        curLoreState.Enter();

        if (curLoreStateNum + 1 < stateTransitions.Length)
            stateTransitions[curLoreStateNum + 1].SetActive(true); // � ���
    }

    public void ConfigureTransitionsOnStage() 
    {
        stateTransitions = GameObject.FindGameObjectsWithTag("LoreTransition");
        
        Array.Sort(stateTransitions, (a,b) => int.Parse(a.name).CompareTo(int.Parse(b.name))); // ������ ������� ��� � � recources(� ��� ��������) -> ����� ����� �������� ��� ����������

        stateTransitions[0].SetActive(true);
        for (int i = 1; i < stateTransitions.Length; i++) 
        {
            stateTransitions[i].SetActive(false);
        }

    }
}
