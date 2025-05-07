using System;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;

public class ScenariosControll : GameMonoBehaviour, IScenario
{
    [SerializeField] PlayableDirector _director;
    [SerializeField] CinemachineBrain _scenarioCamera;
    [SerializeField] GameObject _mainCamera;

    private TimelineAsset _timelineAsset;

    public static ScenariosControll Instance { get; private set; }

    private void Awake()
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

    public void StartScenario(int scenarioNumber)
    {
        _timelineAsset = _director.playableAsset as TimelineAsset;

        foreach (var track in _timelineAsset.GetOutputTracks())
        {
            if (track.GetGroup().name == $"Scenario{scenarioNumber}")
            {
                _director.SetGenericBinding(track, _scenarioCamera);
                track.GetGroup().muted = false;
                _mainCamera.SetActive(false);
                _scenarioCamera.gameObject.SetActive(true);
                _director.Play();
                break;
            } 
        }
    }

    public void EndScenario()
    {
        _mainCamera.SetActive(true);
        _scenarioCamera.gameObject.SetActive(false);
        _director.Stop();   
        MuteAllScenarios(_timelineAsset);
    }

    private void MuteAllScenarios(TimelineAsset timelineAsset)
    {
        foreach (var track in timelineAsset.GetOutputTracks())
        {
            track.GetGroup().muted = true;
        }
    }

}
