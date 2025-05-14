using System;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using Cinemachine;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using Cysharp.Threading.Tasks;

public class ScenariosControll : GameMonoBehaviour, IScenario
{
    [SerializeField] PlayableDirector _director;
    [SerializeField] CinemachineBrain _scenarioCamera;
    [SerializeField] GameObject _mainCamera;

    private TimelineAsset _timelineAsset;
    private UniTaskCompletionSource _completionSource = new();

    public static ScenariosControll Instance { get; private set; }

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

    }

    public async UniTask StartScenario(int scenarioNumber)
    {
        if (scenarioNumber == 0)
        {
            return;
        }

        _completionSource = new();
        _timelineAsset = _director.playableAsset as TimelineAsset;
        MuteAllScenarios(_timelineAsset);

        foreach (var track in _timelineAsset.GetOutputTracks())
        {
            if (track.GetGroup().name == $"Scenario{scenarioNumber}")
            {
                _director.SetGenericBinding(track, _scenarioCamera);
                track.GetGroup().muted = false;
                _mainCamera.SetActive(false);
                _scenarioCamera.gameObject.SetActive(true);
                _director.Play();
                _director.stopped += this.OnScenarioStopped;
            } 
        }
        await _completionSource.Task;
    }

    private void OnScenarioStopped(PlayableDirector _)
    {
        _director.stopped -= this.OnScenarioStopped;
        _mainCamera.SetActive(true);
        _scenarioCamera.gameObject.SetActive(false);
        MuteAllScenarios(_timelineAsset);

        _completionSource.TrySetResult();
    }

    public void StopScenario()
    {
        _director.Stop();   
    }

    private void MuteAllScenarios(TimelineAsset timelineAsset)
    {
        foreach (var track in timelineAsset.GetOutputTracks())
        {
            track.GetGroup().muted = true;
        }
    }

}
