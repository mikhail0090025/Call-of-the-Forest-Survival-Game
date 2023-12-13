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
    [SerializeField] TMP_Text Text;
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
        Debug.Log("SetUI start");
        if (ID <= -1)
        {
            Debug.Log("ID <= -1");
            Text.text = "none";
            Image.sprite = null;
            return;
        }
        Debug.Log("ID > -1");
        Text.text = Amount + "x";
        Debug.Log(ItemsManager.IMinstance);
        var item = ItemsManager.IMinstance.FindByID(ID);
        if (item != null)
        {
            Debug.Log("Item found");
            Image.sprite = item.Sprite;
        }
        else
        {
            Debug.Log("Item not found");
        }
        Debug.Log("SetUI end");
    }
    void Start()
    {
        
    }
    public void Init()
    {
        Image = GetComponentInChildren<Image>();
        Button = GetComponentInChildren<Button>();
        Text = GetComponentInChildren<TMP_Text>();
    }
}
