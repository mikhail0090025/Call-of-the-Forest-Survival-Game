using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneController : MonoBehaviour
{
    WindZone windZone;
    System.Random rand;
    void Start()
    {
        windZone = GetComponent<WindZone>();
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate((float)rand.NextDouble() * Time.deltaTime, (float)rand.NextDouble() * Time.deltaTime, (float)rand.NextDouble() * Time.deltaTime);
    }
}
