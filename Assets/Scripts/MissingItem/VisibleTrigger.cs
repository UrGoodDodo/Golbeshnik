using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleTrigger : MonoBehaviour
{
    [Header("Visible Trigger Settings")]
    [SerializeField] private float distanceToActivate;
    [SerializeField, Range(0f, 1f)] private float partOfScreenHeight;
    [SerializeField, Range(0f, 1f)] private float partOfScreenWidth;

    private CapsuleCollider capsuleCollider;
    private Transform cameraTransform;
    private Camera mainCamera;
    private LayerMask playerTriggerMask;
    private float fieldOfView;
    // field of view axis in camera settings must be Vertical
    void Start()
    {
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.direction = 0;
        gameObject.layer = LayerMask.NameToLayer("VisibleTrigger");
        playerTriggerMask = LayerMask.GetMask("Wall", "Player");
        cameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();  //TODO: оптимизация
        mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();  //TODO: оптимизация
        fieldOfView = mainCamera.fieldOfView / 2;
    }

    private void Update()
    {
        Vector3 targetDirection = cameraTransform.position - transform.position;
        transform.LookAt(transform.position + targetDirection);

        float distanceToCamera = targetDirection.magnitude;
        if (distanceToCamera <= distanceToActivate)
        {
            float height = Mathf.Tan(fieldOfView * Mathf.Deg2Rad) * distanceToCamera;
            float colliderRadius = height * partOfScreenHeight;
            float width = height * 8 / 4.5f;
            float colliderHeight = 2 * width * partOfScreenWidth;

            capsuleCollider.radius = colliderRadius;
            capsuleCollider.height = colliderHeight;
        }
    }

    public bool CheckConditions()
    {
        float distanceToCamera = (cameraTransform.position - transform.position).magnitude;
        if (distanceToCamera <= distanceToActivate)
        {
            Ray ray = new Ray(transform.position, (mainCamera.transform.position - transform.position).normalized);
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * 100f, Color.white, 0.02f);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, playerTriggerMask))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
                return false;
            }
        }
        return false;
    }

    public virtual void ActivateTrigger()
    {
        Debug.Log("Visual Trigger Activate!");
        Destroy(gameObject);
    }
}
