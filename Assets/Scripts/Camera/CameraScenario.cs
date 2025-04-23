using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class FirstScenario : GameMonoBehaviour, IScenario
{
    [SerializeField] PlayableDirector _director;
    [SerializeField] TimelineAsset _timeLine;
    [SerializeField] int _scenarioNumber = 1;
    [SerializeField] GameObject _mainCamera;
    [SerializeField] GameObject _scenarioCamera;
    [SerializeField] float _endPosition = 0f;
    [SerializeField] float _secondSpeed = 200f;

    private float _currentPosition = 0f;
    private bool _isTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
       {
            _isTriggered = true;
            StartScenario();
       }
    }

    private void Update()
    {
        if (_isTriggered)
        {
            if(_currentPosition < _endPosition)
            {
                _currentPosition = _currentPosition + _secondSpeed * Time.deltaTime;
            }
            else
            {
                EndScenario();
            }
        }
            
    }

    public void StartScenario()
    {
        _mainCamera.SetActive(false);
        _scenarioCamera.SetActive(true);
        _director.Play(_timeLine);
    }

    public void EndScenario()
    {
        _mainCamera.SetActive(true);
        _scenarioCamera.SetActive(false);
        _isTriggered = false;
    }
}
