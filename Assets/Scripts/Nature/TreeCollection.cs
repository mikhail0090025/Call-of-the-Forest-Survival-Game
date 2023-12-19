using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollection : CollectableObject
{
    [SerializeField] private float GameMinutesToCollect;
    void Start()
    {
        base.Start();
    }
}
