using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsManager : MonoBehaviour
{
    [SerializeField] List<Window> Windows;
    public List<Window> windows => Windows;
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
    public void DeactivateAll()
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
    public class Window
    {
        public GameObject WindowObject;
        public KeyCode KeyToOpenClose;
        public bool IsActivated;
        public void ChangeState() => ChangeState(!IsActivated);
        public void ChangeState(bool state) {
            if (!WindowsManager.WMinstance.NoOpenedWindows && state) return;
            IsActivated = state;
            WindowObject.SetActive(state);
            WindowsManager.WMinstance.SetCursor();
        }
    }
}
