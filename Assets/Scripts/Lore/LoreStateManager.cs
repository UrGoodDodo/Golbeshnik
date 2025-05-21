using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LoreStateManager : MonoBehaviour // ����� ��� ����� ���� (����� 3 �������)
{

    List<LoreState> loreStates;

    GameObject[] stateTransitions;

    public int nightNumber;

    private int curLoreStateNum = -1;
    private LoreState curLoreState = null;

    private void Awake()
    {
        loreStates = CreateLoreStates();
        ConfigureTransitionsOnStage();
        if (nightNumber != 1)
            foreach (var state in stateTransitions)
                state.SetActive(false);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.loreEvents.onLoreStateChange += TransitionLoreStates;
        GameEventsManager.instance.loreEvents.onDayStateChange += SetActiveDay;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.loreEvents.onLoreStateChange -= TransitionLoreStates;
        GameEventsManager.instance.loreEvents.onDayStateChange -= SetActiveDay;
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
        if (((int)GameCycle.Instance.SubState) == nightNumber) 
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

            if (curLoreStateNum + 1 == stateTransitions.Length) // ����� ������ ������
            {
                switch (nightNumber)
                {
                    case 1:
                        GameCycle.Instance.StartDay(GameSubState.DAY_TWO);
                        GameEventsManager.instance.loreEvents.MoveToNextDay(2);
                        Destroy(gameObject);
                        break;
                    case 2:
                        GameCycle.Instance.StartDay(GameSubState.DAY_THREE);
                        GameEventsManager.instance.loreEvents.MoveToNextDay(3);
                        Destroy(gameObject);
                        break;
                    default: break;
                }
            }

        }

    }

    void SetActiveDay(int num) 
    {
        if (num == nightNumber)
            stateTransitions[0].SetActive(true);
    }

    public void ConfigureTransitionsOnStage() 
    {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform t in transform) 
        {
            children.Add(t.gameObject);
        }

        stateTransitions = children.ToArray();
        
        Array.Sort(stateTransitions, (a,b) => int.Parse(a.name).CompareTo(int.Parse(b.name))); // ������ ������� ��� � � recources(� ��� ��������) -> ����� ����� �������� ��� ����������

        stateTransitions[0].SetActive(true);
        for (int i = 1; i < stateTransitions.Length; i++) 
        {
            stateTransitions[i].SetActive(false);
        }

    }
}
