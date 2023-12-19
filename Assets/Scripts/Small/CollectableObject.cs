using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] protected int ID;
    [SerializeField] protected int Amount;
    protected virtual void Start()
    {
        if (ID < 0 || Amount <= 0) Debug.LogException(new System.Exception("ID or amount are invalid"));
    }
    protected virtual void OnMouseDown()
    {
        var inventory = GameObject.FindObjectOfType<PlayerInventory>();
        inventory.AddItem(ID, Amount);
        Destroy(gameObject);
    }
}
