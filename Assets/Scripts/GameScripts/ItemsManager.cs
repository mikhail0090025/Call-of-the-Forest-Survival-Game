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
}
public enum ItemType { Food, Gun, Other}
[System.Serializable]
public class Item
{
    [SerializeField]
    int id;
    [SerializeField]
    string name;
    [SerializeField]
    Texture texture;
    [SerializeField]
    ItemType type;
    public int ID => id;
    public string Name => name;
    public Texture Texture => texture;
    public ItemType ItemType => type;
}