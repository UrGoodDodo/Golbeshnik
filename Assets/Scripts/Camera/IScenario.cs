using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScenario  
{
    /// <summary>
    /// Функция старта сценария с номером scenarioNumber.
    /// </summary>
    /// 
    public void StartScenario(int scenarioNumber);

    /// <summary>
    /// Функция остановки сценария.
    /// </summary>
    /// 
    public void EndScenario();

}
