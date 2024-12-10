using UnityEngine;

public class TogglePointLight : MonoBehaviour
{
    public Light pointLight;
    private bool isLookingAtObject = false;
    private bool isLightOn = false;


    void Start()
    {
        if (pointLight == null)
        {
            Debug.LogError("Point Light component not assigned to this object!");
            return;
        }
    }


    void Update()
    {
        //Проверка на наведение на объект
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.Log(isLookingAtObject);
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

        if (isLookingAtObject && Input.GetKeyDown(KeyCode.Y))
        {
            ToggleLight();
        }
    }

    void ToggleLight()
    {
        isLightOn = !isLightOn;
        pointLight.enabled = isLightOn;
    }
}