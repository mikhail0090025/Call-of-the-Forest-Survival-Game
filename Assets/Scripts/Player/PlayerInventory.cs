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
    public InventoryCell GunCell_ => GunCell;
    public InventoryCell LeftHandCell_ => LeftHandCell;
    public List<InventoryCell> Cells_ => Cells;
    void Start()
    {
        foreach (var cell in Cells)
        {
            cell.Init();
            cell.Button_.onClick.AddListener(delegate
            {
                // GETTING GUN TO GUNS CELL
                if(GunCell.ID == -1 && ItemsManager.IMinstance.FindByID(cell.ID).ItemType == ItemType.Gun)
                {
                    GunCell.Add(cell.ID, 1);
                    var playersGunScript = FindObjectOfType<PlayersGun>();
                    playersGunScript.TakeGun(cell.ID, false);
                    playersGunScript.ActivateCurrentGunObject();
                    cell.Reset();
                }
                RefreshInventoryUI();
            });
        }
        AddItem(1, 45);
        AddItem(0, 5);
        //RefreshInventoryUI();
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

    public bool IsCellWithID(int id)
    {
        foreach (var cell in Cells)
        {
            if (cell.ID == id) return true;
        }
        return false;
    }

    private void RemoveItem(int id, int count)
    {
        if (!IsCellWithID(id))
        {
            Debug.LogException(new System.Exception($"In inventory is not item with ID {id}"));
        }
        FindCell(id).Remove(count);
    }
    public void RemoveItem(int id, int count, out bool WasRemoved)
    {
        if (!IsCellWithID(id))
        {
            WasRemoved = false;
            return;
        }
        try
        {
            FindCell(id).Remove(count);
            WasRemoved = true;
        }
        catch (System.Exception)
        {
            WasRemoved = false;
            throw;
        }
    }

    public bool IsItem(int id, int count)
    {
        if (IsCellWithID((int)id))
        {
            if (FindCell(id).Amount >= count) return true;
        }
        return false;
    }
    public void RefreshInventoryUI()
    {
        GunCell.SetUI();
        LeftHandCell.SetUI();
        foreach (var cell in Cells)
        {
            ((InventoryCell)cell).SetUI();
        }
    }
}