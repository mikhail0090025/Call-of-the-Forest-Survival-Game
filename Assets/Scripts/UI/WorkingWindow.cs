using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkingWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public WorkingTableRecipes WorkingTableRecipes;
    [SerializeField]
    private TMPro.TMP_Dropdown ReceipesDropdown;
    [SerializeField]
    private GameObject RecipeCell;
    [SerializeField]
    private List<GameObject> RecipeCells;
    private List<ButtonAndRecipe> ButtonRecipePair;
    const int OffsetX = 60;
    const int OffsetY = 90;
    const int StartOffsetX = -120;
    const int StartOffsetY = -100;
    [SerializeField] private Transform StartReceipesPoint;
    const int IconsInRow = 5;
    [SerializeField]
    private GameObject Viewport;
    [SerializeField]
    private TMPro.TMP_Text ReceipeDescription;
    [SerializeField]
    private Button CreateButton;
    [SerializeField]
    private Button CloseButton;
    private WorkingTableRecipe SelectedRecipe;
    void Start()
    {
        ButtonRecipePair = new List<ButtonAndRecipe>();
        //WorkingTableRecipes = GameObject.FindObjectOfType<WorkingTableRecipes>();
        ShowRecipes();
        CloseButton.onClick.AddListener(delegate
        {
            WindowsManager.WMinstance.windows[WorkingTable.WindowIndex_].ChangeState(false);
        });
        CreateButton.onClick.AddListener(delegate
        {
            if(SelectedRecipe != null)
            {
                var playersInventory = FindObjectOfType<PlayerInventory>();
                foreach (var item in SelectedRecipe.NeededItems)
                {
                    if(!playersInventory.IsItem(item.ID, item.Count))
                    {
                        Debug.LogError("Not enough items");
                        return;
                    }
                }

                foreach (var item in SelectedRecipe.NeededItems)
                {
                    playersInventory.RemoveItem(item.ID, item.Count, out bool WasRemoved);
                    Debug.Log(WasRemoved);
                }

                playersInventory.AddItem(SelectedRecipe.Result.ID, SelectedRecipe.Result.Count);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowRecipes()
    {
        while (Viewport.transform.childCount > 0)
        {
            Destroy(Viewport.transform.GetChild(0).gameObject);
        }
        RecipeCells = new List<GameObject>();
        if (ReceipesDropdown.value == 0)
        {
            for (int i = 0; i < WorkingTableRecipes.WorkingTableRecipesList.Count; i++)
            {
                var recipe = WorkingTableRecipes.WorkingTableRecipesList[i];
                var id = recipe.Result.ID;
                var count = recipe.Result.Count;
                var Icon = Instantiate(RecipeCell, Viewport.transform.position, Quaternion.identity);
                Icon.transform.SetParent(Viewport.transform);
                Icon.transform.localPosition = new Vector3(StartOffsetX,StartOffsetY,0);
                Icon.transform.Find("ItemIcon").gameObject.GetComponent<Image>().sprite = ItemsManager.IMinstance.FindByID(id).Sprite;
                Icon.GetComponentInChildren<TMPro.TMP_Text>().text = $"{count}X";
                RecipeCells.Add(Icon);
                Icon.GetComponentInChildren<Button>().onClick.AddListener(() =>
                {
                    SelectedRecipe = recipe;
                    ShowRecipe(recipe);
                });
                ButtonRecipePair.Add(new ButtonAndRecipe(Icon.GetComponentInChildren<Button>(), recipe));
            }
        }
    }
    void ShowRecipe(WorkingTableRecipe recipe)
    {
        ReceipeDescription.text = "Need:\n";
        foreach (var item in recipe.NeededItems)
        {
            ReceipeDescription.text += ItemsManager.IMinstance.FindByID(item.ID).Name + ": " + item.Count + '\n';
        }
        ReceipeDescription.text += "Result:\n";
        ReceipeDescription.text += ItemsManager.IMinstance.FindByID(recipe.Result.ID).Name + ": " + recipe.Result.Count;
    }
}
class ButtonAndRecipe
{
    public Button Button;
    public WorkingTableRecipe Recipe;
    public ButtonAndRecipe(Button button, WorkingTableRecipe recipe)
    {
        Button = button;
        Recipe = recipe;
    }
}