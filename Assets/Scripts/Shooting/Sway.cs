using UnityEngine;

public class Sway : MonoBehaviour
{
    [SerializeField] float amount = 0.02f;
    [SerializeField] float maxAmount = 0.06f;
    [SerializeField] float smoothAmount = 6f;

    [SerializeField] float rotationAmount = 8f;
    [SerializeField] float maxRot = 5f;
    [SerializeField] float smoothRot = 12f;

    Vector3 pos;
    Quaternion rot;

    float movementX, movementY;

    [SerializeField] bool rotX = true;
    [SerializeField] bool rotY = true;
    [SerializeField] bool rotZ = true;

    private void Start()
    {
        pos = transform.localPosition;
        rot = transform.localRotation;
    }

    private void Update()
    {
        movementX = Input.GetAxis("Mouse X");
        movementY = Input.GetAxis("Mouse Y");

        float moveX = Mathf.Clamp(movementX * amount, -maxAmount, maxAmount);
        float moveY = Mathf.Clamp(movementY * amount, -maxAmount, maxAmount);

        Vector3 finalPos = new Vector3(moveX, moveY, 0);

        transform.localPosition = Vector3.Lerp(transform.localPosition, finalPos + pos,  Time.deltaTime * smoothAmount);

        float tiltY = Mathf.Clamp(movementX * rotationAmount, -maxRot, maxRot);
        float tiltX = Mathf.Clamp(movementY * rotationAmount, -maxRot, maxRot);

        Quaternion finalRot = Quaternion.Euler(new Vector3(rotX ? -tiltX : 0f, rotY ? tiltY : 0f, rotZ ? tiltY : 0));

        transform.localRotation = Quaternion.Slerp(transform.localRotation, finalRot * rot, Time.deltaTime * smoothRot);
    }
}