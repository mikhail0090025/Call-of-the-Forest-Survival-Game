using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSettings : MonoBehaviour
{
    private void Awake()
    {
        bool SettingsAreSaved = PlayerPrefs.GetInt("Width") != 0;
        if (SettingsAreSaved)
        {
            var settings = new SettingsManager.Settings(PlayerPrefs.GetInt("Width"), PlayerPrefs.GetInt("Height"), PlayerPrefs.GetInt("Fullscreen") % 2 != 0);
            settings.WriteMe();
            SettingsManager.SetSettings(settings);
            SettingsManager.ApplySettings();
            SettingsManager.SaveSettingsToComp();
        }
        else
        {
            var settings = new SettingsManager.Settings(1920, 1080, true);
            settings.WriteMe();
            SettingsManager.SetSettings(settings);
            SettingsManager.ApplySettings();
            SettingsManager.SaveSettingsToComp();
        }
    }
    void Start()
    {
        
    }
}
