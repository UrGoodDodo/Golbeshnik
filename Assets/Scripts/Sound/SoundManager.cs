using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class SoundManager : MonoBehaviour
{
    public Sound[] sounds;

    private bool isCoroutine;
    private MindController mindController;
    private bool stage2Playing;
    private bool stage3Playing;
    private bool stage4Playing;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

    }
    private void Start()
    {
        mindController = GameObject.FindGameObjectWithTag("MindController").GetComponent<MindController>();
    }
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)))
        {
            FootstepsCoroutine();
        }
        else
        {
            Stop("Walk");
            StopCoroutine("FootstepsCoroutine");
            isCoroutine = false;
        }

        //добавить условия, когда рассудок наоборот повышается

        //Тоже самое с шагами, сделать, чтобы звуки менее резкие были
        if (mindController.mindStatus == 6)
        {
            TurnOffAmbient();
            stage3Playing = false;
            stage2Playing = false;
            stage4Playing = false;
        }
        if ((mindController.mindStatus == 5 || mindController.mindStatus == 4) && !stage2Playing)
        {
            AudioSource s = GetSource("Ambient_stage2");
            s.Play();
            s.volume = 0f;
            StartCoroutine(VolumeIncrease(s));
            stage2Playing = true;
        }
        if ((mindController.mindStatus == 3 || mindController.mindStatus == 2) && !stage3Playing)
        {
            AudioSource s = GetSource("Ambient_stage3");
            s.Play();
            s.volume = 0f;
            StartCoroutine(VolumeIncrease(s));
            stage3Playing = true;
        }
        if ((mindController.mindStatus == 0 || mindController.mindStatus == 1) && !stage4Playing)
        {
            AudioSource s = GetSource("Ambient_stage4");
            s.Play();
            s.volume = 0f;
            StartCoroutine(VolumeIncrease(s));
            stage4Playing = true;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return;
        s.source.Stop();
    }
    public void PlayButtonSound()
    {
        Sound s = Array.Find(sounds, sound => sound.name == "ButtonClick");
        if (s == null)
            return;
        s.source.Play();
    }
    private AudioSource PlayWalk()
    {

        string name = GetRandomFootstep();
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return null;
        s.source.pitch = UnityEngine.Random.Range(0.7f, 1.3f);
        s.source.Play();
        return s.source;
    }
    private void FootstepsCoroutine()
    {
        if (!isCoroutine)
            StartCoroutine(FootstepSound());
    }
    IEnumerator FootstepSound()
    {
        isCoroutine = true;
        AudioSource s = PlayWalk();
        yield return new WaitForSeconds(1.2f);
        isCoroutine = false;
    }

    private string GetRandomFootstep()
    {
        int n = UnityEngine.Random.Range(1, 11);
        switch (n)
        {
            case 1:
                return "Footstep1";
            case 2:
                return "Footstep2";
            case 3:
                return "Footstep3";
            case 4:
                return "Footstep4";
            case 5:
                return "Footstep5";
            case 6:
                return "Footstep6";
            case 7:
                return "Footstep7";
            case 8:
                return "Footstep8";
            case 9:
                return "Footstep9";
            case 10:
                return "Footstep10";
            default:
                return null;
        }


    }

    public void TurnOffAmbient()
    {
        Stop("Ambient_stage2");
        Stop("Ambient_stage3");
        Stop("Ambient_stage4");
    }
    private AudioSource GetSource(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
            return null;
        return s.source;
    }
    IEnumerator VolumeIncrease(AudioSource source)
    {
        float timeToFade = 5f;
        float timeElapsed = 0;
        while (timeElapsed < timeToFade)
        {
            source.volume = Mathf.Lerp(0, 0.7f, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    private void LoadSounds()
    {
        //возможно потом пригодится, когда добавится саундтрек
    }
}
