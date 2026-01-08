using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : Build
{
    FurnaceRecipes FurnaceRecipes;
    FurnaceRecipe currentRecipe;
    bool IsCooking;
    float TicksWhenStarted;
    protected override void Start()
    {
        FurnaceRecipes = FindObjectOfType<FurnaceRecipes>();
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (IsCooking)
        {
            if(TicksWhenStarted + (currentRecipe.GameHours * GameTime.RealSecondsInGameHour) < EnvironmentController.CurrentInstance.DateTime.Ticks)
            {

            }
        }
        base.Update();
    }
    [Serializable]
    public class FurnaceRecipe
    {
        public IdAmountItem GivenItems;
        public IdAmountItem ReturnedItems;
        public float GameHours;
    }
    public void StartCook(FurnaceRecipe recipe)
    {
        if (IsCooking) Debug.LogException(new Exception("Furnace is cooking now"));
        IsCooking = true;
        TicksWhenStarted = EnvironmentController.CurrentInstance.DateTime.Ticks;
        currentRecipe = recipe;
    }
}
