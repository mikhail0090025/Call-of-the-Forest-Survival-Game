using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Build
{
    FurnaceRecipes FurnaceRecipes;
    protected override void Start()
    {
        FurnaceRecipes = FindObjectOfType<FurnaceRecipes>();
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    [Serializable]
    public class FurnaceRecipe
    {
        public IdAmountItem GivenItems;
        public IdAmountItem ReturnedItems;
        public float GameHours;
    }
}
