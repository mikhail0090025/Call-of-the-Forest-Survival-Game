using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour
{
    [SerializeField] protected List<IdAmountPair> IdAmountPairs;
    [SerializeField] protected int DistanceToCollect = 2;
    protected TextOnWatching TextOnWatching;
    [SerializeField] protected string Text_;
    protected virtual void Start()
    {
        // Throwing exceptions on errors
        foreach (var item in IdAmountPairs)
        {
            if (item.ID < 0) Debug.LogException(new Exception("some ID(s) is(are) invalid"));
            if (item.Amount <= 0) Debug.LogException(new System.Exception("Some amount(s) is(are) invalid"));
        }
        TextOnWatching = gameObject.AddComponent<TextOnWatching>();
        TextOnWatching.distance = DistanceToCollect;
        TextOnWatching.Text = Text_;
    }
    // Collecting
    protected virtual void OnMouseDown()
    {
        var inventory = FindObjectOfType<PlayerInventory>();
        if (Vector3.Distance(inventory.gameObject.transform.position, transform.position) > DistanceToCollect) return;
        foreach (var item in IdAmountPairs)
        {
            inventory.AddItem(item.ID, item.Amount);
        }
        Destroy(gameObject);
    }

    public void AddPair(IdAmountPair idAmountPair)
    {
        IdAmountPairs.Add(idAmountPair);
    }

    public void SetDistance(int distance)
    {
        DistanceToCollect = distance;
    }

    public void SetText(string text)
    {
        Text_ = text;
    }
    [Serializable]
    public class IdAmountPair
    {
        public int ID; public int Amount;
        public IdAmountPair(int id, int amount)
        {
            ID = id;
            Amount = amount;
        }
    }
}
