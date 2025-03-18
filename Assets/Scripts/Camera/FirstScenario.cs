using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstScenario : MonoBehaviour, IScenario
{

    [SerializeField] Transform[] _markers;
    [SerializeField] Camera _camera;

    public void StartScenario()
    {
        //берем центр камеры 
        //смотрим, есть ли маркеры
        //если нет, то просто приблизить камеру + эффекты
        //если да, то смотреть, какой маркер ближе к лучу из камеры
        //поворачиваться медленно к маркеру 
        //+зум на маркере
    }
    public void EndScenario()
    {

    }



}
