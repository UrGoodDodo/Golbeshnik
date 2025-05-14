using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public enum ZoneState
{
    POSITIVE = 0,
    NEGATIVE = 1
}


public class HeartBeat : MonoBehaviour
{
    [SerializeField]
    public List<float> scenarioOne;

    [SerializeField]
    public List<float> scenarioTwo;

    [SerializeField]
    private readonly int MIND_STATUS_UP = 4;

    private List<float> scenario;

    public event Action OnQTEFinish;
    public event Action OnQTEStarted;

    private float secondSpeed = 100f;
    private float heartBeatTime = 58f;
    private ZoneState currentZoneState = ZoneState.POSITIVE;
    private float currentPosition = 0f;
    private float endPosition;
    private int currentIndex = 0;

    private bool passZone = true;
    private bool doubleClick = false;

    private int passCount = 0;
    private int mistakeCount = 0;

    private SoundManager _soundManager;
    private MindController _mindController;

    private void Start()
    {
        _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        _mindController = MindController.Instance;
    }

    public async UniTask StartEvent()
    {
        this.OnQTEStarted?.Invoke();
        GetNewScenario();
        GetNewSettings();
        _soundManager.Play("HeartPulsBreath");
        PlayBeatEnviroment();
        await this.HeartBeatAction();
        OnEventFinish();
        this.OnQTEFinish?.Invoke();
    }

    private void GetNewScenario()
    {
        float currentInterval = heartBeatTime;
        scenario = new();
        scenario.Add(currentInterval);
        List<float> currentScenario = new();
        int k = UnityEngine.Random.Range(1, 3);
        switch (k)
        {
            case 1:
                currentScenario = scenarioOne;
                break;
            case 2:
                currentScenario = scenarioTwo;
                break;
        }
        foreach (float interval in currentScenario)
        {
            currentInterval += interval;
            scenario.Add(currentInterval);
            currentInterval += heartBeatTime;
            scenario.Add(currentInterval);
        }
        endPosition = currentInterval;
    }

    private void GetNewSettings()
    {
        currentPosition = 0;
        currentIndex = 0;
        passCount = 0;
        mistakeCount = 0;
        passZone = true;
        doubleClick = false;
        currentZoneState = ZoneState.POSITIVE;
    }
    private void PlayBeatEnviroment()
    {
        int k = UnityEngine.Random.Range(1, 4);
        _soundManager.Play($"HearthBeat{k}");
        _mindController.HearthPuls();
    }

    public async UniTask HeartBeatAction()
    {
        while (currentPosition <= endPosition)
        {
            currentPosition = currentPosition + secondSpeed * Time.deltaTime;
            if (currentPosition > scenario[currentIndex])
            {
                if (scenario[currentIndex] != endPosition) { currentIndex += 1; }
                CheckZoneOnPass();
                if (currentZoneState == ZoneState.POSITIVE)
                {
                    currentZoneState = ZoneState.NEGATIVE;
                    passZone = true;
                }
                else
                {
                    currentZoneState = ZoneState.POSITIVE;
                    passZone = false;
                    PlayBeatEnviroment();
                }
                doubleClick = false;
            }
            await UniTask.Yield();
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("CKey") || Input.GetButtonDown("VKey") || Input.GetButtonDown("UKey"))
        {
            if (currentZoneState == ZoneState.NEGATIVE)
            {
                passZone = false;
            }
            else
            {
                if (passZone == false)
                {
                    passZone = true;
                }
                else
                {
                    doubleClick = true;
                }
            }
        }
    }

    private void CheckZoneOnPass()
    {
        if (passZone && !doubleClick && currentZoneState == ZoneState.POSITIVE)
        {
            passCount++;
        }
        else if (!passZone && currentZoneState == ZoneState.NEGATIVE)
        {
            mistakeCount++;
        }
    }
    private void OnEventFinish()
    {
        if ((int)(scenario.Count / 2) + 1 - passCount + mistakeCount <= 2)
        {
            _mindController.IncreaseMindStatus(MIND_STATUS_UP);
        }
        else
        {
            Debug.Log("GAME OVER");
        }
        _soundManager.Stop("HeartPulsBreath");
    }
    
}

