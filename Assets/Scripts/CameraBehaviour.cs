using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraBehaviour : MonoBehaviour
{
    
    public Transform _mainCamera;

    private Volume _postProcessingVolume;
    private Vignette _vignette;
    private ChromaticAberration _chromaticAberration;
    private Coroutine vignetteCoroutine;


    
    void Start()
    {
        _postProcessingVolume = GetComponent<Volume>();
        Vignette vgt;
        ChromaticAberration chrmtcA;
        if (_postProcessingVolume.profile.TryGet(out vgt))
            _vignette = vgt;
        if (_postProcessingVolume.profile.TryGet(out chrmtcA))
            _chromaticAberration = chrmtcA;

    }

    //
    
    void FixedUpdate()
    {
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    if(!_isStartCotoutine)
        //        ChangeVignette();
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    if(!_isStartCotoutine)
        //        ChangeVignette(1, 0);
        //}
        //if (Input.GetKey(KeyCode.R))
        //{
        //    PulseVignette(0.00005f);
        //}
    }

    public void ChangeVignette(float _startValue = 0, float _endValue = 1f, float _duration = 3f)
    {
        if (vignetteCoroutine != null)
        {
            StopCoroutine(vignetteCoroutine);
            _startValue = _vignette.intensity.value; 
        }
        vignetteCoroutine = StartCoroutine(ChangeCoroutineValue(_startValue, _endValue, _duration));
    }

    public void ChangeChromaticA(float _value = 0)
    {
        if (_chromaticAberration != null)
        {
            _chromaticAberration.intensity.value = _value;
        }
    }


    public void PulseVignette(float vignetteSpeed, float value_max = 1f, float value_min = 0)
    {
       if(value_max > 1f) { value_max = 1f; }
       if(value_max < 0) { value_max = 0; }

       if(_vignette.intensity.value <= value_max)
        {
            if(_vignette.intensity.value >= value_min)
            {
                _vignette.intensity.value = Mathf.Sin(Time.realtimeSinceStartup);
            }
        }
    }

    private IEnumerator ChangeCoroutineValue(float start, float end, float duration)
    {
        float elapsedTime = 0f;
        _vignette.intensity.value = start;
        while (elapsedTime < duration)
        {
            _vignette.intensity.value = Mathf.Lerp(start, end, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _vignette.intensity.value = end;
    }

}
