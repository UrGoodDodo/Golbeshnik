using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraBehaviour : MonoBehaviour
{
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
        if (this.gameObject.tag == "CutSceneCamera")
            this.gameObject.SetActive(false);
    }

    public void ChangeVignette(float _startValue = 0, float _endValue = 1f, float _duration = 3f)
    {
        Debug.Log(_vignette);
        if (vignetteCoroutine != null)
        {
            StopCoroutine(vignetteCoroutine);
            _startValue = _vignette.intensity.value; 
        }
        if (!this.gameObject.activeSelf)
        {
            _vignette.intensity.value = _endValue;
            return;
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
