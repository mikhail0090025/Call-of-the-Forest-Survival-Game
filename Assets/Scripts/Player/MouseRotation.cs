using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    public enum RotationAxes { MouseXandY = 0, MouxeX = 1, MouseY = 2 };
    [SerializeField] RotationAxes axes = RotationAxes.MouseXandY;
    [SerializeField] float SensivityX = 2f;
    [SerializeField] float SensivityY = 2f;
    [SerializeField] float MinX = -360f;
    [SerializeField] float MaxX = 360f;
    [SerializeField] float MinY = -360f;
    [SerializeField] float MaxY = 360f;
    [SerializeField] bool RestrictX;
    [SerializeField] bool RestrictY;
    float RotX = 0f;
    float RotY = 0f;
    Quaternion originalRotation;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        originalRotation = transform.localRotation;
    }
    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= -360f;
        return Mathf.Clamp(angle, min, max);
    }
    void Update()
    {
        if (!WindowsManager.WMinstance.NoOpenedWindows) return;
        if (axes == RotationAxes.MouseXandY)
        {
            RotX += Input.GetAxis("Mouse X") * SensivityX;
            RotY += Input.GetAxis("Mouse Y") * SensivityY;
            RotX = RestrictX ? ClampAngle(RotX, MinX, MaxX) : RotX;
            RotY = RestrictY ? ClampAngle(RotY, MinY, MaxY) : RotY;
            Quaternion XQuaternion = Quaternion.AngleAxis(RotX, Vector3.up);
            Quaternion YQuaternion = Quaternion.AngleAxis(RotY, -Vector3.right);
            transform.localRotation = originalRotation * XQuaternion * YQuaternion;
        }
        if (axes == RotationAxes.MouxeX)
        {
            RotX += Input.GetAxis("Mouse X") * SensivityX;
            RotX = RestrictX ? ClampAngle(RotX, MinX, MaxX) : RotX;
            Quaternion XQuaternion = Quaternion.AngleAxis(RotX, Vector3.up);
            transform.localRotation = originalRotation * XQuaternion;
        }
        if (axes == RotationAxes.MouseY)
        {
            RotY += Input.GetAxis("Mouse Y") * SensivityY;
            RotY = RestrictY ? ClampAngle(RotY, MinY, MaxY) : RotY;
            Quaternion YQuaternion = Quaternion.AngleAxis(RotY, -Vector3.right);
            transform.localRotation = originalRotation * YQuaternion;
        }
    }
}
