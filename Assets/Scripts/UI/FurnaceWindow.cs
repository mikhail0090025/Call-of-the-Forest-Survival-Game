using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurnaceWindow : MonoBehaviour
{
    [SerializeField] GameObject ItemListPrefab;
    [SerializeField] FurnaceRecipes FurnaceRecipes;
    [SerializeField] Toggle OnlyAvailableRecipes;
    [SerializeField] TMPro.TextMeshPro RecipeData;
    Furnace currentFurnace;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SetCurrentFurnace(Furnace furnace)
    {
        currentFurnace = furnace;
        RefreshUI();
    }
    void RefreshUI()
    {

    }
}