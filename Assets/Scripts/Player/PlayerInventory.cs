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
        AddItem(1, 45);
        AddItem(2, 5);
        RefreshInventoryUI();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) RefreshInventoryUI();     
    }
    // Adding item to inventory
    public void AddItem(int id, int amount)
    {
        var cell = FindCell(id);
        if(cell != null)
        {
            cell.Add(id, amount);
        }
        else
        {
            var emptyCell = FindEmptyCell();
            emptyCell.Add(id, amount);
        }
    }
    // Find cell with item
    InventoryCell FindCell(int id)
    {
        foreach (var cell in Cells)
        {
            if (cell.ID == id) return cell;
        }
        return FindEmptyCell();
    }
    // Searches empty cell, if doesnt exist, throws an exception
    InventoryCell FindEmptyCell()
    {
        foreach (var cell in Cells)
        {
            if (cell.ID <= -1) return cell;
        }
        Debug.LogException(new System.Exception($"There is no empty cells"));
        return null;
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