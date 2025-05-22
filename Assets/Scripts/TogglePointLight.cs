using UnityEngine;

public class TogglePointLight : GameMonoBehaviour, IDayStartListener
{
    public Light pointLight;
    bool isLightOn = false;
    private SoundManager soundManager;

    [SerializeField] bool _isLightOff;
    [SerializeField] bool _isLightOn;
    [SerializeField] GameSubState _dayNumber;

    public bool Condition
    {
        get { return isLightOn; }
        set
        {
            isLightOn = value;
        }
    }


    void Start()
    {
        soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
        if (pointLight == null)
        {
            Debug.LogError("Point Light component not assigned to this object!");
            return;
        }
        pointLight.enabled = false;

    }

    public void ToggleLightOn()
    {
        Debug.Log(isLightOn);
        isLightOn = true;
        pointLight.enabled = isLightOn;
        TurnOnSound();
        soundManager.PlayRandomCandleLightUp();
    }
    public void ToggleLightOff()
    {
        isLightOn = false;
        pointLight.enabled = isLightOn;
        TurnOffSound();
    }
    void TurnOnSound()
    {
       AudioSource candleSource = gameObject.GetComponentInParent<AudioSource>();
        candleSource.Play();
    }
    void TurnOffSound()
    {
        AudioSource candleSource = gameObject.GetComponentInParent<AudioSource>();
        candleSource.Stop();
    }

    public void OnDayStart(GameSubState day)
    {
        if (day == _dayNumber)
            if (_isLightOff)
                ToggleLightOff();
            else if (_isLightOn)
                ToggleLightOn();
    }
}