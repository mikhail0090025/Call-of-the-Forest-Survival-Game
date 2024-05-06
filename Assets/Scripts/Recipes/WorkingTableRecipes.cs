using System;
using System.Collections.Generic;
using UnityEngine;

public class WorkingTableRecipes : MonoBehaviour
{
    public List<WorkingTableRecipe> WorkingTableRecipesList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[Serializable]
public class WorkingTableRecipe
{
    [SerializeField]
    protected List<OneItem> neededItems;
    [SerializeField]
    protected OneItem result;
    public List<OneItem> NeededItems => neededItems;
    public OneItem Result => result;
    [Serializable]
    public class OneItem
    {
        public int ID;
        public int Count;
        public OneItem(int id, int count)
        {
            ID = id;
            Count = count;
        }
    }
}