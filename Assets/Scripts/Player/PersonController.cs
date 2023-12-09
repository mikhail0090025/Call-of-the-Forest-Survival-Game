using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField] float WalkSpeed;
    [SerializeField] float RunSpeed;
    [SerializeField] float JumpHeight;
    [SerializeField] Transform ForwardPoint;
    [SerializeField] Transform RightPoint;
    [SerializeField] Transform UpPoint;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = Vector3.MoveTowards(transform.position, ForwardPoint.position + new Vector3(0, ForwardPoint.position.y - transform.position.y, 0), Time.deltaTime * CurrentSpeed());
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position = Vector3.MoveTowards(transform.position, ForwardPoint.position + new Vector3(0, ForwardPoint.position.y - transform.position.y, 0), Time.deltaTime * -CurrentSpeed());
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = Vector3.MoveTowards(transform.position, RightPoint.position, Time.deltaTime * -CurrentSpeed());
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.position = Vector3.MoveTowards(transform.position, RightPoint.position, Time.deltaTime * CurrentSpeed());
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = Vector3.MoveTowards(transform.position, UpPoint.position, Time.deltaTime * JumpHeight);
        }
        float CurrentSpeed()
        {
            if (Input.GetKey(KeyCode.LeftShift)) return RunSpeed;
            else return WalkSpeed;
        }
    }
}
