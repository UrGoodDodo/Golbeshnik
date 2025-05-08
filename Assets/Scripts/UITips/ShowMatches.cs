using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ShowMatches : MonoBehaviour
{
    private TextMeshProUGUI matchCounttxt;

    private int matchcount = 0;

    private void Awake()
    {
        matchCounttxt = GetComponentInChildren<TextMeshProUGUI>();
        ReDrawUi();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.uishowEvents.onPickingMatchBox += AddFullMatchBox;
        GameEventsManager.instance.uishowEvents.onUsingMatch += DeleteOneMatch;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.uishowEvents.onPickingMatchBox -= AddFullMatchBox;
        GameEventsManager.instance.uishowEvents.onUsingMatch -= DeleteOneMatch;
    }

    void AddFullMatchBox() { matchcount += 5; ReDrawUi(); }

    void DeleteOneMatch() { matchcount--; ReDrawUi(); }

    void ReDrawUi() => matchCounttxt.text = matchcount.ToString();

}
