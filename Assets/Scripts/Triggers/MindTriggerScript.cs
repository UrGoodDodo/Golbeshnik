using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class MindTriggerScript : GameMonoBehaviour
{
    [SerializeField] protected int _triggerValue = 0;
    [SerializeField] protected string _sound = null;
    [SerializeField] protected float _timer = 0f;
    [SerializeField] protected bool _isSubTrigger = false;
    [SerializeField] protected GameSubState _dayNumber;
    [SerializeField] protected QTEKey _qteKey = QTEKey.HEART_BEAT;
    [SerializeField] protected int _scenarioNumber;
    [SerializeField] protected bool _isCutscene = false;

    protected MindController _mindController;
    protected SoundManager _soundManager;
    protected bool _activateOtherTrigger = false;
    protected bool _isActive = false;

    public bool IsActive
    {
        get { return _isActive; }
    }

    public bool _ActivateOtherTrigger { get => _activateOtherTrigger; }

    public void Start()
    {
        _mindController = MindController.Instance;
        _soundManager = GameObject.FindWithTag("SoundManager").GetComponent<SoundManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(_dayNumber == GameCycle.Instance.SubState)
        {
            if (other.gameObject.tag == "Player")
            {
                if (_isCutscene)
                {
                    GameEventSystem.Instance.StartEvent(_qteKey, _scenarioNumber).Forget();
                }
                if (!_isActive)
                {
                    _mindController.DecreaseMindStatus(_triggerValue);
                    if (_sound != null)
                        _soundManager.PlayTrigger(_sound);
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


}
