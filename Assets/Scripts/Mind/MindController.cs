using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;
using Cysharp.Threading.Tasks;
using UnityEngine.Rendering;

public sealed class MindController : GameMonoBehaviour,
    IDayStartListener,
    IEventFinishListener,
    IEventStartListener
{
    [SerializeField]
    public int mindStatus;

    [SerializeField]
    int maxMindStatus;

    [SerializeField, Range(0f, 0.7f)]
    float vignetteMax = 0.75f;

    [SerializeField, Range(0f, 0.7f)]
    float vignetteMedium = 0.60f;

    [SerializeField, Range(0f, 0.7f)]
    float vignetteLow = 0.45f;

    private float currentVignette = 0f;

    //[SerializeField] private CameraBehaviour _mainCamera;
    //[SerializeField] private CameraBehaviour _cutsceneCamera;
    private List<CameraBehaviour> _cameras = new();

    public bool isQTE = false;

    public static MindController Instance;

    [SerializeField] private GameEventSystem gameEventSystem;

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _cameras = new List<CameraBehaviour>(FindObjectsOfType<CameraBehaviour>());
    }

    public void IncreaseMindStatus(int value)
    {
        mindStatus = Mathf.Min(maxMindStatus, mindStatus + value);
        CheckMindStatus();
    }

    public void DecreaseMindStatus(int value)
    {
        mindStatus = Mathf.Max(0, mindStatus - value);
        CheckMindStatus();
    }
    private void CheckMindStatus()
    {
        Debug.Log(mindStatus);
        if (mindStatus == 0 && !isQTE)
        {
            foreach (var camera in _cameras)
            {
                this.ChangeVignette(camera, currentVignette, vignetteMedium, 2f, 1);
            }
            //this.ChangeVignette(_mainCamera, currentVignette, vignetteMedium, 2f, 1);
            //this.ChangeVignette(_cutsceneCamera, currentVignette, vignetteMedium, 2f, 1);
            currentVignette = vignetteMedium;
            StartHeartBeatEvent();
        }
        if (mindStatus == 1 || mindStatus == 2)
        {
            foreach (var camera in _cameras)
            {
                this.ChangeVignette(camera, currentVignette, vignetteMedium, 2f, 1);
            }
            //this.ChangeVignette(_mainCamera, currentVignette, vignetteMedium, 2f, 1);
            //this.ChangeVignette(_cutsceneCamera, currentVignette, vignetteMedium, 2f, 1);
            currentVignette = vignetteMedium;
        }
        if (mindStatus == 3 || mindStatus == 4)
        {
            foreach (var camera in _cameras)
            {
                this.ChangeVignette(camera, currentVignette, vignetteLow, 2f, 0.5f);
            }
            //this.ChangeVignette(_mainCamera, currentVignette, vignetteLow, 2f, 0.5f);
            //this.ChangeVignette(_cutsceneCamera, currentVignette, vignetteLow, 2f, 0.5f);
            currentVignette = vignetteLow;
        }
        if (mindStatus == 5 || mindStatus == 6)
        {
            foreach (var camera in _cameras)
            {
                this.ChangeVignette(camera, currentVignette, 0f, 2f, 0);
            }
            //this.ChangeVignette(_mainCamera, currentVignette, 0f, 2f, 0);
            //this.ChangeVignette(_cutsceneCamera, currentVignette, 0f, 2f, 0);
            currentVignette = 0f;
        }
    }

    private void ChangeVignette(CameraBehaviour camera, float start, float end, float duration, float chromatica)
    {
        camera.ChangeVignette(start, end, duration);
        camera.ChangeChromaticA(chromatica);
    }

    public void HearthPuls()
    {
        StartCoroutine(CoroutineHearthPuls());
    }

    private IEnumerator CoroutineHearthPuls()
    {
        foreach (var camera in _cameras)
        {
            this.ChangeVignette(camera, currentVignette, vignetteMax, 0.25f, 1);
        }
        //this.ChangeVignette(_mainCamera, currentVignette, vignetteMax, 0.25f, 1);
        //this.ChangeVignette(_cutsceneCamera, currentVignette, vignetteMax, 0.25f, 1);
        yield return new WaitForSeconds(0.25f);
        foreach (var camera in _cameras)
        {
            this.ChangeVignette(camera, currentVignette, vignetteMedium, 0.25f, 1);
        }
        //this.ChangeVignette(_mainCamera, currentVignette, vignetteMedium, 0.25f, 1);
        //this.ChangeVignette(_cutsceneCamera, currentVignette, vignetteMedium, 0.25f, 1);
    }

    private void StartHeartBeatEvent()
    {
        gameEventSystem.StartEvent(QTEKey.HEART_BEAT, 0).Forget();
    }

    void IDayStartListener.OnDayStart(GameSubState _)
    {
        mindStatus = 6;
    }

    void IEventFinishListener.OnEventFinish()
    {
        isQTE = false;
    }

    void IEventStartListener.OnEventStart()
    {
        isQTE = true;
    }
}
