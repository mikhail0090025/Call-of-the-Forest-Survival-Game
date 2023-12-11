using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] Button ButtonSave;
    [SerializeField] Button ButtonGoToMenu;
    void Update()
    {
        ButtonGoToMenu.onClick.AddListener(delegate
        {
            SceneLoader.LoadScene("MainMenu");
        });
    }
}
