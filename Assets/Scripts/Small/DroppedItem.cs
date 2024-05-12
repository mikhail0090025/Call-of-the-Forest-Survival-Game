using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        GetComponent<MeshRenderer>().material.SetFloat("Smoothness", 0f);
        Debug.Log("Dropped item initialized");
        Debug.Log(CollectableObjectScript);
    }
    public static void DropItem(int id, int count, Vector3 position)
    {
        var item = GameObject.CreatePrimitive(PrimitiveType.Cube);
        item.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        item.transform.position = position;
        var droppedItemComponent = item.AddComponent<DroppedItem>();
        droppedItemComponent.Amount = count;
        droppedItemComponent.ItemId = id;
        droppedItemComponent.AddComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
