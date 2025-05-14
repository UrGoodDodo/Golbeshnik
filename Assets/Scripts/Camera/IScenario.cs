using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScenario  
{
    /// <summary>
    /// ������� ������ �������� � ������� scenarioNumber.
    /// </summary>
    /// 
    UniTask StartScenario(int scenarioNumber);

    /// <summary>
    /// ������� ��������� ��������.
    /// </summary>
    /// 
    void StopScenario();

}
