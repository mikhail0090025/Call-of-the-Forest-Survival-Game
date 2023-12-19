using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    // IDs of objects that will be collected on click
    [SerializeField] protected int[] IDs;
    // Amounts of objects that will be collected on click
    [SerializeField] protected int[] Amounts;
    [SerializeField] protected int DistanceToCollect = 2;
    protected virtual void Start()
    {
        // Throwing exceptions on errors
        if(IDs.Length != Amounts.Length || IDs.Length == 0) Debug.LogException(new System.Exception("ID or amount are invalid"));
        foreach (var ID in IDs)
        {
            if (ID < 0) Debug.LogException(new System.Exception("some ID(s) is(are) invalid"));
        }
        foreach (var Amount in Amounts)
        {
            if (Amount <= 0) Debug.LogException(new System.Exception("Some amount(s) is(are) invalid"));
        }
    }
    // Collecting
    protected virtual void OnMouseDown()
    {
        var inventory = GameObject.FindObjectOfType<PlayerInventory>();
        if (Vector3.Distance(inventory.gameObject.transform.position, transform.position) > DistanceToCollect) return;
        for (int i = 0; i < IDs.Length; i++)
        {
            inventory.AddItem(IDs[i], Amounts[i]);
        }
        Destroy(gameObject);
    }
}
