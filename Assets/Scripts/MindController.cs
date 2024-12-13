using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MindController : MonoBehaviour
{
    public GameObject hearthBeatQTE;
    [SerializeField] public int mindStatus;
    [SerializeField] int maxMindStatus;
    [SerializeField, Range(0f, 0.7f)] float vignetteMax = 0.75f;
    [SerializeField, Range(0f, 0.7f)] float vignetteMedium = 0.60f;
    [SerializeField, Range(0f, 0.7f)] float vignetteLow = 0.45f;
    private float currentVignette = 0f;
    private CameraBehaviour _cameraBehaviour;
    public bool isQTE = false;
    public event Action DeactivatePlayer;
    public event Action ActivatePlayer;

    private void Start()
    {
        _cameraBehaviour = GameObject.FindWithTag("MainCamera").GetComponent<CameraBehaviour>();
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
            _cameraBehaviour.ChangeVignette(currentVignette, vignetteMedium, 2f);
            _cameraBehaviour.ChangeChromaticA(1);
            currentVignette = vignetteMedium;
            StartQTE();
        }
        if (mindStatus == 1 || mindStatus == 2)
        {
            _cameraBehaviour.ChangeVignette(currentVignette, vignetteMedium, 2f);
            _cameraBehaviour.ChangeChromaticA(1);
            currentVignette = vignetteMedium;
        }
        if (mindStatus == 3 || mindStatus == 4)
        {
            _cameraBehaviour.ChangeVignette(currentVignette, vignetteLow, 2f);
            _cameraBehaviour.ChangeChromaticA(0.5f);
            currentVignette = vignetteLow;
        }
        if (mindStatus == 5 || mindStatus == 6)
        {
            _cameraBehaviour.ChangeVignette(currentVignette, 0f, 2f);
            _cameraBehaviour.ChangeChromaticA(0);
            currentVignette = 0f;
        }
    }
    public void HearthPuls()
    {
        StartCoroutine(CoroutineHearthPuls());
    }
    private IEnumerator CoroutineHearthPuls()
    {
        _cameraBehaviour.ChangeVignette(currentVignette, vignetteMax, 0.25f);
       yield return new WaitForSeconds(0.25f);
        _cameraBehaviour.ChangeVignette(currentVignette, vignetteMedium, 0.25f);
    }
    private void StartQTE()
    {
        isQTE = true;
        Instantiate(hearthBeatQTE, new Vector3(0, 0, 0), Quaternion.identity);
        DeactivatePlayer?.Invoke();
    }

    public void StopQTE()
    {
        isQTE = false;
        ActivatePlayer?.Invoke();
    }
}
