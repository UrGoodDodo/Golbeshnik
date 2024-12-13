using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindTriggerScript : MonoBehaviour
{
    public int _triggerValue = 0;
    public string _sound;
    public float _timer = 0f;
    public bool _isSubTrigger = false;

    protected MindController _mindController;
    protected SoundManager _soundManager;
    protected bool _activateOtherTrigger = false;
    protected bool _isActive = false;

    public bool _ActivateOtherTrigger { get => _activateOtherTrigger; }

    public void Start()
    {
        _mindController = GameObject.FindWithTag("MindController").GetComponent<MindController>();
        _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!_isActive)
            {
                _mindController.DecreaseMindStatus(_triggerValue);
                _soundManager.Play(_sound);
                if (_isSubTrigger)
                {
                    _activateOtherTrigger = true;
                    _isActive = true;
                }
                else 
                { 
                    Destroy(gameObject); 
                }
            }
        }
    }


}
