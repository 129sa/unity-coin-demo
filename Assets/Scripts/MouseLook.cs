using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    float pitch = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);
        pitch -= mouseY * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -60f, 60f);
        cameraTransform.localEulerAngles = new Vector3(pitch, 0f, 0f);
    }
}
