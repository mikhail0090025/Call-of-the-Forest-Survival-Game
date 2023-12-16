using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeScript : MonoBehaviour
{
    [SerializeField] DoorScript DoorScript;
    [SerializeField] Transform InsidePoint;
    [SerializeField] Transform OutsidePoint;
    [SerializeField] bool PlayerIsInside = false;
    [SerializeField] GameObject ThingsInside;
    Transform Player;
    void Start()
    {
        DoorScript.DoorClicked += DoorScript_DoorClicked;
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        ThingsInside.SetActive(false);
    }

    private void DoorScript_DoorClicked(object sender, System.EventArgs e)
    {
        PlayerIsInside = !PlayerIsInside;
        if (PlayerIsInside) Player.position = InsidePoint.position;
        else Player.position = OutsidePoint.position;
        ThingsInside.SetActive(PlayerIsInside);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
