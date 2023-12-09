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
    Rigidbody PlayersRigidbody;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(GetComponent<Rigidbody>()) PlayersRigidbody = GetComponent<Rigidbody>();
        else PlayersRigidbody = gameObject.AddComponent<Rigidbody>();
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
        if (Input.GetKey(KeyCode.Space) && IsOnSurface())
        {
            //transform.position = Vector3.MoveTowards(transform.position, UpPoint.position, Time.deltaTime * JumpHeight);
            Debug.Log("Jump");
            PlayersRigidbody.AddForce(Vector3.up * JumpHeight);
        }
        float CurrentSpeed()
        {
            if (Input.GetKey(KeyCode.LeftShift)) return RunSpeed;
            else return WalkSpeed;
        }
    }
    bool IsOnSurface()
    {
        if(Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit hit))
        {
            if(Mathf.Abs(transform.position.y - hit.point.y) <= 1.1f) return true;
            else return false;
        }
        return false;
    }
}
