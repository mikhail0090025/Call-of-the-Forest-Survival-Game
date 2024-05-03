using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildsProject : MonoBehaviour
{
    [SerializeField]
    protected List<Item> Materials;
    [SerializeField]
    protected GameObject ResultBuild;
    void Start()
    {
        
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
    [System.Serializable]
    protected class Item
    {
        public int ID;
        public int CountNeeded;
        public int CurrentCount;
        public Item(int id, int needed)
        {
            ID = id;
            CountNeeded = needed;
            CurrentCount = 0;
        }
    }
}
