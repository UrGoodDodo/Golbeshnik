using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissingItemTrigger : VisibleTrigger
{
    [Header("Missing Item Settings")]
    [SerializeField] private int decreaseMindValue = 1;
    public override void ActivateTrigger()
    {
        ActivateDialog();
        DecreaseMindStatus();
        base.ActivateTrigger();
    }

    private void DecreaseMindStatus()
    {
        GameObject.FindWithTag("MindController").GetComponent<MindController>().DecreaseMindStatus(decreaseMindValue);
    }

    private void ActivateDialog()
    {
        
    }

}
