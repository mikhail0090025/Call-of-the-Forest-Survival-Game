using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkingWindow : MonoBehaviour
{
    // Start is called before the first frame update
    public WorkingTableRecipes WorkingTableRecipes;
    [SerializeField]
    private Dropdown AllReceipesDropdown;
    [SerializeField]
    private GameObject ReceipeCell;
    void Start()
    {
        WorkingTableRecipes = GameObject.FindObjectOfType<WorkingTableRecipes>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowReceipes()
    {

    }
}
