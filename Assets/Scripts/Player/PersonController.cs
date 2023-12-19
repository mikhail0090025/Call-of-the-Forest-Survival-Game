using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonController : MonoBehaviour
{
    [SerializeField] float WalkSpeed;
    [SerializeField] float RunSpeed;
    [SerializeField] float CrouchSpeed;
    [SerializeField] float JumpHeight;
    [SerializeField] Transform ForwardPoint;
    [SerializeField] Transform RightPoint;
    [SerializeField] Transform UpPoint;
    [SerializeField] Camera PlayerCamera;
    Animator cam_anim;
    Rigidbody PlayersRigidbody;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if(GetComponent<Rigidbody>()) PlayersRigidbody = GetComponent<Rigidbody>();
        else PlayersRigidbody = gameObject.AddComponent<Rigidbody>();
        cam_anim = PlayerCamera.gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        cam_anim.speed = 1f;
        if (!WindowsManager.WMinstance.NoOpenedWindows) return;

        transform.position = Vector3.MoveTowards(transform.position, ForwardPoint.position + new Vector3(0, ForwardPoint.position.y - transform.position.y, 0), Time.deltaTime * CurrentSpeed() * Input.GetAxis("Vertical"));
        transform.position = Vector3.MoveTowards(transform.position, RightPoint.position, Time.deltaTime * CurrentSpeed() * Input.GetAxis("Horizontal"));
        if (Input.GetKey(KeyCode.Space) && IsOnSurface())
        {
            PlayersRigidbody.AddForce(Vector3.up * JumpHeight);
        }
        if (Input.GetButton("Jump") && IsOnSurface())
        {
            Debug.Log("Button for jump works");
            PlayersRigidbody.AddForce(Vector3.up * JumpHeight);
        }
        float CurrentSpeed()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                cam_anim.speed = 3f;
                return RunSpeed;
            }
            else if (Input.GetKey(KeyCode.LeftControl))
            {
                cam_anim.speed = 0.5f;
                return CrouchSpeed;
            }
            else
            {
                cam_anim.speed = 3f;
                return WalkSpeed;
            }
        }
        if(!Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl)) transform.localScale = new Vector3(1, 0.5f, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }
    bool IsOnSurface()
    {
        if(Physics.Raycast(new Ray(transform.position, Vector3.down), out RaycastHit hit))
        {
            if(Mathf.Abs(transform.position.y - hit.point.y) <= 1.5f) return true;
            else return false;
        }
        return false;
    }
}
