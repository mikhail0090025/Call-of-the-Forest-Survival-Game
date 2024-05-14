using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDistance : MonoBehaviour
{
    // Destroys object if player is very far from it
    Transform Player;
    [SerializeField] public float distance;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Player.position, transform.position) > distance)
        {
            Destroy(this.gameObject);
        }
    }
}
