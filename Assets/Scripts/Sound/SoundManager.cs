using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Rendering;
using static Unity.VisualScripting.Member;

public class SoundManager : GameMonoBehaviour,
    IGameTickable
{

    public Sound[] sounds;

    private bool isCoroutine;
    private MindController mindController;
    private bool stage2Playing;
    private bool stage3Playing;
    private bool stage4Playing;
    PlayerController player;
    public GameObject antagonistMoving;
    public GameObject windDraft;

    protected override void Awake()
    {
        base.Awake();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        LoadSounds();

    }
    private void Start()
    {
        mindController = MindController.Instance;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void IGameTickable.Tick(float deltaTime)
    {
        if (player.characterController.velocity.magnitude > 0.5f
            /*(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))*/)
        {
            FootstepsCoroutine();
        }
        else
        {
            // Stop("Walk");
            //StopCoroutine("FootstepsCoroutine");
            //isCoroutine = false;
        }

        //добавить условия, когда рассудок наоборот повышается

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
        s.volume = 0f;
        StartCoroutine(VolumeDecrease(s, 0.2f, 0.5f));
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
    IEnumerator VolumeIncrease(AudioSource source, float timeToFade = 5f, float volume = 0.1f)
    {
        float timeElapsed = 0;
        while (timeElapsed < timeToFade)
        {
            source.volume = Mathf.Lerp(0, volume, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator VolumeDecrease(AudioSource source, float timeToFade = 5f, float volume = 0.3f, float endVolume = 0.1f)
    {
        float timeElapsed = 0;
        while (timeElapsed < timeToFade)
        {
            source.volume = Mathf.Lerp(volume, endVolume, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void PlayRandomCandleLightUp()
    {
        int n = UnityEngine.Random.Range(1, 3);
        string name = "";
        switch (n)
        {
            case 1:
                name = "LightingUpCandle1";
                break;
            case 2:
                name = "LightingUpCandle2";
                break;
        }
        Play(name);
    }
    public void PlayRandomMatchPickUp()
    {
        int n = UnityEngine.Random.Range(1, 4);
        string name = "";
        switch (n)
        {
            case 1:
                name = "MatchesPickUp1";
                break;
            case 2:
                name = "MatchesPickUp2";
                break;
            case 3:
                name = "MatchesPickUp3";
                break;
        }
        Play(name);
    }
    void PlayAntagonist()
    {
        antagonistMoving.SetActive(true);
    }
    void PlayWindDraft()
    {
        windDraft.SetActive(true);
    }
    public void PlayTrigger(string name)
    {
        if (name == "AntagonistSteps")
            PlayAntagonist();
        else if (name == "DoorCreakingShort1")
            PlayWindDraft();
        else
            Play(name);
    }
    private void LoadSounds()
    {
        foreach(Sound s in sounds)
        {
            AudioSource source = GetSource(s.name);
            float v = source.volume;
            source.volume = 0f;
            source.Play();
            source.Stop();
            source.volume = v;
        }
    }
}
