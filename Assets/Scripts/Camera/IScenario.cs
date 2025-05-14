using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScenario  
{
    /// <summary>
    /// Функция старта сценария с номером scenarioNumber.
    /// </summary>
    /// 
    UniTask StartScenario(int scenarioNumber);

    /// <summary>
    /// Функция остановки сценария.
    /// </summary>
    /// 
    void StopScenario();

}
