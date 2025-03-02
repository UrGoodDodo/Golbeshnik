using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Method)]
public class ButtonAttribute : Attribute
{
    public string ButtonName { get; private set; }

    public ButtonAttribute(string buttonName)
    {
        ButtonName = buttonName;
    }
}
