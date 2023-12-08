using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    // Start is called before the first frame update
    public enum RotationAxes { MouseXandY = 0, MouxeX = 1, MouseY = 2 };
    [SerializeField] RotationAxes axes = RotationAxes.MouseXandY;
    [SerializeField] float SensivityX = 2f;
    [SerializeField] float SensivityY = 2f;
    [SerializeField] float MinX = -360f;
    [SerializeField] float MaxX = 360f;
    [SerializeField] float MinY = -360f;
    [SerializeField] float MaxY = 360f;
    float RotX = 0f;
    float RotY = 0f;
    [SerializeField] Transform player;
    [SerializeField] Rigidbody PlayerRigidbody;
    [SerializeField] float speed;
    Quaternion originalRotation;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerRigidbody.freezeRotation = true;
        originalRotation = transform.localRotation;
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= -360f;
        return Mathf.Clamp(angle, min, max);
    }
    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseXandY)
        {
            RotX += Input.GetAxis("Mouse X") * SensivityX;
            RotY += Input.GetAxis("Mouse Y") * SensivityY;
            RotX = ClampAngle(RotX, MinX, MaxX);
            RotY = ClampAngle(RotY, MinY, MaxY);
            Quaternion XQuaternion = Quaternion.AngleAxis(RotX, Vector3.up);
            Quaternion YQuaternion = Quaternion.AngleAxis(RotY, -Vector3.right);
            transform.localRotation = originalRotation * XQuaternion * YQuaternion;
        }
        if (axes == RotationAxes.MouxeX)
        {
            RotX += Input.GetAxis("Mouse X") * SensivityX;
            RotX = ClampAngle(RotX, MinX, MaxX);
            Quaternion XQuaternion = Quaternion.AngleAxis(RotX, Vector3.up);
            transform.localRotation = originalRotation * XQuaternion;
        }
        if (axes == RotationAxes.MouseY)
        {
            RotY += Input.GetAxis("Mouse Y") * SensivityY;
            RotY = ClampAngle(RotY, MinY, MaxY);
            Quaternion YQuaternion = Quaternion.AngleAxis(RotY, -Vector3.right);
            transform.localRotation = originalRotation * YQuaternion;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.forward, Time.deltaTime * speed);
        }
    }
}
