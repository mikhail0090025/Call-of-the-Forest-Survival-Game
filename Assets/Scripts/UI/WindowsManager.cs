using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] List<Window> Windows;
    public static WindowsManager WMinstance;
    public bool NoOpenedWindows { get {
            foreach (var window in Windows)
            {
                if (window.IsActivated) return false;
            }
            return true;
        } }
    void Start()
    {
        WMinstance = GameObject.FindObjectOfType<WindowsManager>();
        DeactivateAll();
    }
    void SetCursor()
    {
        if (NoOpenedWindows)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void DeactivateAll()
    {
        foreach (var window in Windows)
        {
            window.ChangeState(false);
        }
        SetCursor();
    }
    void Update()
    {
        foreach (var window in Windows)
        {
            if (Input.GetKeyDown(window.KeyToOpenClose))
            {
                window.ChangeState();
            }
        }
    }
    [System.Serializable]
    class Window
    {
        public GameObject WindowObject;
        public KeyCode KeyToOpenClose;
        public bool IsActivated;
        public void ChangeState() => ChangeState(!IsActivated);
        public void ChangeState(bool state) {
            IsActivated = state;
            WindowObject.SetActive(state);
            WindowsManager.WMinstance.SetCursor();
        }
    }
}
