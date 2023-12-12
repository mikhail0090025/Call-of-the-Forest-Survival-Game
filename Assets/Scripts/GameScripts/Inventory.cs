using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] static int h;
    [SerializeField] protected int size;
    public int Size { get => size; }
    protected List<InventoryCell> Cells;
    void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        Cells = new List<InventoryCell>();
        for (int i = 0; i < size; i++)
        {
            Cells.Add(new InventoryCell());
        }
    }
    void Update()
    {
        
    }
}
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
    public virtual void Add(int id_item, int amount)
    {
        if(IsEmpty || ID == -1)
        {
            ID = id_item;
            if (Amount < 0) Amount = 0;
            Amount += amount;
        }
    }
}