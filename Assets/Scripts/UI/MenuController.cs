using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using System.Xml.Serialization;

public class MenuController : MonoBehaviour
{
    bool IsActivated;
    [SerializeField] GameObject Menu;
    [SerializeField] Button ButtonSave;
    void Start()
    {
        Menu.SetActive(false);
        IsActivated = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            IsActivated = !IsActivated;
            Menu.SetActive(IsActivated);
            if (IsActivated) Cursor.lockState = CursorLockMode.None;
            else Cursor.lockState = CursorLockMode.Locked;
        }
        ButtonSave.onClick.AddListener(delegate
        {
            string dir = Directory.GetCurrentDirectory() + @"\Saves";
            if (Directory.Exists(dir)){
                using (FileStream str = new FileStream(dir, FileMode.OpenOrCreate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(CurrentGame));
                }
            }
        });
    }
}
