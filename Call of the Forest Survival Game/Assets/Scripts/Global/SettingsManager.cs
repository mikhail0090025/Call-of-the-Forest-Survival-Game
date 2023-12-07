using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SettingsManager
{
    public static Settings CurrentSettings { get; private set; }
    public static void SetSettings(Settings settings) => CurrentSettings = settings;
    public class Settings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool Fullscreen { get; set; }
        public Settings(int w, int h, bool fullscreen)
        {
            Width = w;
            Height = h;
            Fullscreen = fullscreen;
        }
        public void WriteMe()
        {
            Debug.Log($"Width: {Width}, Height: {Height}, fullscreen: {Fullscreen}");
        }
    }
    public static void ApplySettings(Settings settings)
    {
        Screen.SetResolution(settings.Width, settings.Height, settings.Fullscreen);
    }
    public static void ApplySettings()
    {
        if (CurrentSettings != null) ApplySettings(CurrentSettings);
        else Debug.Log("Current settings is not set");
    }
    public static void SaveSettingsToComp()
    {
        PlayerPrefs.SetInt("Width", CurrentSettings.Width);
        PlayerPrefs.SetInt("Height", CurrentSettings.Height);
        if (CurrentSettings.Fullscreen)
            PlayerPrefs.SetInt("Fullscreen", 1);
        else PlayerPrefs.SetInt("Fullscreen", 0);
    }
}
