using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public List<Item> Items;
    public static ItemsManager IMinstance;
    void Start()
    {
        IMinstance = this;
    }
    //Binary searching of item by ID
    public Item FindByID(int id)
    {
        int start = 0;
        int end = Items.Count - 1;
        int index = 0;
        while (start <= end)
        {
            index = ((end - start) / 2) + start;
            if (Items[index].ID == id) return Items[index];
            else if (Items[index].ID < id) start = index;
            else end = index;
        }
        Debug.LogError($"Item with ID {id} was not found");
        return null;
    }
}
[System.Flags]
public enum ItemType { None = 0, Food = 1, Gun = 2, Other = 4, Nature = 8}
[System.Serializable]
public class Item
{
    [SerializeField]
    int id;
    [SerializeField]
    string name;
    [SerializeField]
    Sprite sprite;
    [SerializeField]
    ItemType type;
    public int ID => id;
    public string Name => name;
    public Sprite Sprite => sprite;
    public ItemType ItemType => type;
}