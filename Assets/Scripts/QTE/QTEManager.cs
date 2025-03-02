using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class QTEManager : MonoBehaviour
{
    public static QTEManager Instance { get; private set; }

    public event Action StartQTEEvent;
    public event Action EndQTEEvent;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartQTE()
    {
        StartQTEEvent?.Invoke();
    }

    public void StopQTE()
    {
        EndQTEEvent?.Invoke();
    }
}
