using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Inventory
{
    [SerializeField] List<Image> ImagesCells;
    void Start()
    {
        if (base.Cells.Count != ImagesCells.Count) Debug.LogError("");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
