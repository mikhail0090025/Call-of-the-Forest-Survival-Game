using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemsOnPlayersHit : ReactOnPlayersHit
{
    [SerializeField] List<DropItem> dropItems;

    public override void OnPlayersHit()
    {
        foreach (var item in dropItems)
        {
            DroppedItem.DropItem(item.ID, item.Amount, transform.position);
        }
        Destroy(gameObject);
    }

    public override void Start()
    {
        if (dropItems == null) Debug.LogException(new System.Exception("List of items is empty"));
        if (dropItems.Count == 0) Debug.LogException(new System.Exception("List of items is empty"));
    }

    [System.Serializable]
    public class DropItem
    {
        public int ID;
        public int Amount;
    }
}
