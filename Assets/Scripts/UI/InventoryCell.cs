using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public int ID { get; protected set; }
    public int Amount { get; protected set; }
    public bool IsEmpty => Amount <= 0;
    [SerializeField] Image Image;
    [SerializeField] Button Button;
    [SerializeField] TMP_Text CellBottomText;
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
        else if (ID == id_item) Amount += amount;
        else Debug.Log("This cell already contains element with other id!");
    }
    public void SetUI()
    {
        if (ID <= -1)
        {
            CellBottomText.text = "none";
            Image.sprite = null;
            return;
        }
        CellBottomText.text = Amount + "x";
        var item = ItemsManager.IMinstance.FindByID(ID);
        if (item != null)
        {
            Image.sprite = item.Sprite;
        }
        else
        {
            Debug.Log("Item not found");
        }
    }
    void Start()
    {
        
    }
    public void Init()
    {
        Image = GetComponentInChildren<Image>();
        Button = GetComponentInChildren<Button>();
        CellBottomText = GetComponentInChildren<TMP_Text>();
        CellBottomText.fontSize = 18;
        CellBottomText.color = Color.white;
    }
}
