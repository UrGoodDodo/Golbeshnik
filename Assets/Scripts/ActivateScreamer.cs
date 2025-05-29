using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateScreamer : MonoBehaviour
{
    [SerializeField] BabaikaScreamer _screamer;
    [SerializeField] MindTriggerScript _activeTrigger;
    [SerializeField] bool _activated = false;
    [SerializeField] bool _goScreamer = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _activeTrigger.IsActive)
        {
            Debug.Log("Screamers");
            if (_activated)
            {
                _screamer.ActivateBabaika();
            }

            if (_goScreamer)
            {
                _screamer.PlayScreamerAnim();
            }
        }
    }
}
