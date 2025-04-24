using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScenario  
{
    /// <summary>
    /// ������� ������ �������� � ������� scenarioNumber.
    /// </summary>
    /// 
    public void StartScenario(int scenarioNumber);

    /// <summary>
    /// ������� ��������� ��������.
    /// </summary>
    /// 
    public void EndScenario();

}
