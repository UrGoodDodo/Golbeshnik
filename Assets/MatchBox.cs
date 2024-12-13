using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchBox : MonoBehaviour
{
    [SerializeField] int matchesInBox = 5;
    private bool isLookingAtObject = false;

    void Update()
    {
        //Проверка на наведение на объект
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log("Имя объекта: " + hit.transform.name);

            if (hit.transform == transform)
            {
                isLookingAtObject = true;
            }
            else
            {
                isLookingAtObject = false;
            }
        }
        else
        {
            isLookingAtObject = false;
        }

        if (isLookingAtObject && Input.GetKeyDown(KeyCode.E))
        {
            PlayerController.matches += matchesInBox;
            Destroy(gameObject);
        }
    }
}
