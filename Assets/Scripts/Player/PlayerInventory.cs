using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory")]
    [SerializeField] protected int size;
    public int Size => size;
    [SerializeField]
    protected List<InventoryCell> Cells = new List<InventoryCell>();
    [Header("Gun cell")]
    [SerializeField] InventoryCell GunCell;
    [Header("Left hand")]
    [SerializeField] InventoryCell LeftHandCell;
    void Start()
    {

    }
    private void RefreshInventoryUI()
    {
        GunCell.SetUI();
        LeftHandCell.SetUI();
        foreach (var cell in Cells)
        {
            ((InventoryCell)cell).SetUI();
        }
    }
}