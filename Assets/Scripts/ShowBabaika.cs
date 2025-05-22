using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBabaika : MonoBehaviour
{
    [SerializeField] public BabaikaScript _babaika;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            _babaika.ChangeMat();
        }
    }
}
