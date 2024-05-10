using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppedItem : MonoBehaviour
{
    [SerializeField]
    CollectableObject CollectableObjectScript;
    public int ItemId;
    public int Amount;
    const int distance = 4;
    void Start()
    {
        CollectableObjectScript = gameObject.AddComponent<CollectableObject>();
        CollectableObjectScript.AddPair(ItemId, Amount);
        CollectableObjectScript.SetDistance(distance);
        CollectableObjectScript.SetText(ItemsManager.IMinstance.FindByID(ItemId).Name + " X" + Amount);
        GetComponent<MeshRenderer>().material.mainTexture = ItemsManager.IMinstance.FindByID(ItemId).Sprite.texture;
        Debug.Log("Dropped item initialized");
        Debug.Log(CollectableObjectScript);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
