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
        if(ID <= -1)
        {
            Text.text = "none";
            Image.sprite = null;
            return;
        }
        Text.text = Amount + "x";
        if(ItemsManager.IMinstance.FindByID(ID).Sprite != null)
        Image.sprite = ItemsManager.IMinstance.FindByID(ID).Sprite;
    }
    void Start()
    {
        Image = GetComponentInChildren<Image>();
        Button = GetComponentInChildren<Button>();
        Text = GetComponentInChildren<TMP_Text>();
    }
}
