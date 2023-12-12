using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : Inventory
{
    [Header("Inventory")]
    [SerializeField] List<Image> ImagesCells;
    List<Button> ButtonsOnCells;
    [Header("Gun cell")]
    [SerializeField] InventoryCell GunCell;
    [SerializeField] Button GunCellButton;
    [SerializeField] Image GunCellImage;
    [Header("Left hand")]
    [SerializeField] InventoryCell LeftHandCell;
    [SerializeField] Button LeftHandCellButton;
    [SerializeField] Image LeftHandCellImage;
    void Start()
    {
        if (base.Cells.Count != ImagesCells.Count) Debug.LogError("");
        ButtonsOnCells = new List<Button>();
        for (int i = 0; i < ImagesCells.Count; i++)
        {
            ButtonsOnCells[i] = ImagesCells[i].GetComponentInChildren<Button>();
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
