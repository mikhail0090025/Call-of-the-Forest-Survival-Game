using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    CollectableObject CollectableObjectScript;
    public int ItemId;
    public int Amount;
    const int distance = 4;
    void Start()
    {
        CollectableObjectScript = gameObject.AddComponent<CollectableObject>();
        CollectableObjectScript.AddPair(new CollectableObject.IdAmountPair(ItemId, Amount));
        CollectableObjectScript.SetDistance(distance);
        GetComponent<MeshRenderer>().material.mainTexture = ItemsManager.IMinstance.FindByID(ItemId).Sprite.texture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
