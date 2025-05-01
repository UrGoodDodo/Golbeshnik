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
        txtMeshpro.color = Color.red;
    }

    public void HoverExit() 
    {
        txtMeshpro.color = mainColor;
    }
}
