using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMindTriggerScript : MindTriggerScript
{
    [SerializeField] MindTriggerScript _subTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (_dayNumber == GameCycle.Instance.SubState)
            if (_subTrigger != null)
                {
                if (_subTrigger._ActivateOtherTrigger && !_isActive)
                {
                    if (other.gameObject.tag == "Player")
                    {
                        _mindController.DecreaseMindStatus(_triggerValue);
                        if(_sound != null)
                            _soundManager.Play(_sound);
                        Destroy(_subTrigger.gameObject);
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
