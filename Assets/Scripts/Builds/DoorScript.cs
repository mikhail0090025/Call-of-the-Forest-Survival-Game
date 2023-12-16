using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public event System.EventHandler DoorClicked;
    [SerializeField]
    float Distance = 3;
    Transform Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        if(!GetComponent<TextOnWatching>())
        {
            var TOW = gameObject.AddComponent<TextOnWatching>();
            TOW.distance = 2;
            TOW.Text = "Door\nClick to open";
        }
    }
    private void OnMouseDown()
    {
        if(Vector3.Distance(Player.transform.position, transform.position) < Distance)
        {
            DoorClicked.Invoke(this, null);
        }
    }
}
