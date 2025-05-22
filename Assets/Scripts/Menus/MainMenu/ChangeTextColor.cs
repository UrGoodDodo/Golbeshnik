using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTextColor : MonoBehaviour
{
    private TextMeshProUGUI txtMeshpro;

    private Color mainColor;

    private void Awake()
    {
        txtMeshpro = GetComponent<TextMeshProUGUI>();
        mainColor = txtMeshpro.color;
    }

    public void HoverEnter() 
    {
        Debug.Log("Is hover");
        txtMeshpro.color = Color.red;
    }

    public void HoverExit() 
    {
        Debug.Log("Is hover exit");
        txtMeshpro.color = mainColor;
    }
}
