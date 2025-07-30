using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensi;

    public Transform playerTransform;

    float xRotation, yRotation;

    public WallRun wallRun;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensi;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensi;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, wallRun.tilt);

        playerTransform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}