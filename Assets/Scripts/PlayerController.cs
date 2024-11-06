using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public float rotationSpeed = 100f;
    public float acceleration = 2f;
    public float mouseSensitivity = 1f;
    public float verticalRotationSpeed = 100f;

    private float currentSpeed;
    private Transform cameraTransform;
    private float verticalRotation;
    private Vector2 lastMousePosition; // ������ ���������� ��������� ����

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        // �������� ���� � ����������
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // �������� ������������� �������� ����
        Vector2 mouseDelta = (Vector2)Input.mousePosition - lastMousePosition;
        lastMousePosition = Input.mousePosition; // ��������� ���������� ���������

        // �������� ������ � ������ � ������� ����
        float mouseX = mouseDelta.x * mouseSensitivity; // ���������� ������������� ��������
        float mouseY = mouseDelta.y * mouseSensitivity;

        cameraTransform.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.up * mouseX);

        // �������� ������ �� ���������
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -80f, 80f);
        cameraTransform.localEulerAngles = new Vector3(verticalRotation, cameraTransform.localEulerAngles.y, 0);

        // �������� � �����������, �������� �������
        Vector3 horizontalDirection = cameraTransform.forward; // ���������� ������ �������������� �����������
        horizontalDirection.y = 0; // �������� ������������ ������������
        horizontalDirection.Normalize(); // ����������� ������

        Vector3 movement = horizontalDirection * verticalInput + cameraTransform.right * horizontalInput;
        transform.Translate(movement * speed * Time.deltaTime);

        // ��������� � ������� Shift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed += acceleration * Time.deltaTime * 2f;
        }
        else
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        speed = Mathf.Clamp(currentSpeed, 0f, 10f);
    }
}
    

