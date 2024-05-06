using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.UI;

public class WorkingWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public WorkingTableRecipes WorkingTableRecipes;
    [SerializeField]
    private TMPro.TMP_Dropdown ReceipesDropdown;
    [SerializeField]
    private GameObject ReceipeCell;
    const int OffsetX = 60;
    const int OffsetY = 90;
    const int StartX = -150;
    const int StartY = 100;
    const int IconsInRow = 5;
    [SerializeField]
    private GameObject Viewport;
    void Start()
    {
        //WorkingTableRecipes = GameObject.FindObjectOfType<WorkingTableRecipes>();
        ShowReceipes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowReceipes()
    {
        while (Viewport.transform.childCount > 0)
        {
            Destroy(Viewport.transform.GetChild(0).gameObject);
        }
        if (ReceipesDropdown.value == 0)
        {
            for (int i = 0; i < WorkingTableRecipes.WorkingTableRecipesList.Count; i++)
            {
                var recipe = WorkingTableRecipes.WorkingTableRecipesList[i];
                var id = recipe.Result.ID;
                var count = recipe.Result.Count;
                //var Icon = Instantiate(ReceipeCell, Viewport.transform.position + new Vector3((i * OffsetX) + StartX, StartY, 0), Quaternion.identity, Viewport.transform);
                var Icon = Instantiate(ReceipeCell, Viewport.transform.position, Quaternion.identity, Viewport.transform);
                Icon.transform.position = Viewport.transform.position;
                Icon.transform.Find("ItemIcon").gameObject.GetComponent<Image>().sprite = ItemsManager.IMinstance.FindByID(id).Sprite;
                Icon.GetComponentInChildren<TMPro.TMP_Text>().text = $"{count}X";
            }
        }
    }
}
