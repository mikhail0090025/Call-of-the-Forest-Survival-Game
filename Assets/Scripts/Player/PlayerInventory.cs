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
[System.Serializable]
public class InventoryCell
{
    public int ID { get; protected set; }
    public int Amount { get; protected set; }
    public bool IsEmpty => Amount <= 0;
    public InventoryCell()
    {
        ID = -1;
        Amount = 0;
    }
    public void Add(int id_item, int amount)
    {
        if (IsEmpty || ID == -1)
        {
            ID = id_item;
            if (Amount < 0) Amount = 0;
            Amount += amount;
        }
    }
    public Image Image;
    public Button Button;
    public TMP_Text Text;
    public void SetUI()
    {
        Text.text = Amount + "x";
        Image.sprite = ItemsManager.IMinstance.FindByID(ID).Sprite;
    }
}