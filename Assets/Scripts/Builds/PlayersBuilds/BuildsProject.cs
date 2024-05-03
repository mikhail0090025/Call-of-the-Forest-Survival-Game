using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsProject : MonoBehaviour
{
    [SerializeField]
    protected List<Item_> Materials;
    public List<Item_> materials => Materials;
    [SerializeField]
    protected GameObject ResultBuild;
    [SerializeField]
    protected TextOnWatching TextOnWatching;
    public const int DistanceToContact = 5; // Distance, which is neccessary to contact with project
    void Start()
    {
        TextOnWatching = this.gameObject.AddComponent<TextOnWatching>();
        TextOnWatching.distance = DistanceToContact;
        Refresh();
    }

    public void Refresh()
    {
        TextOnWatching.Text = "";
        foreach (var item in Materials)
        {
            TextOnWatching.Text += ItemsManager.IMinstance.FindByID(item.ID).Name + ": " + item.CurrentCount + " / " + item.CountNeeded + "\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool EnoughMaterials()
    {
        foreach (var item in Materials)
        {
            if(item.CountNeeded > item.CurrentCount) return false;
        }
        return true;
    }

    public void Check()
    {
        if (EnoughMaterials())
        {
            Instantiate(ResultBuild, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("Not enough items!");
        }
    }
}
[System.Serializable]
public class Item_ {
    public int ID;
    public int CountNeeded;
    public int CurrentCount;
    public Item_(int id, int needed)
    {
        ID = id;
        CountNeeded = needed;
        CurrentCount = 0;
    }
}