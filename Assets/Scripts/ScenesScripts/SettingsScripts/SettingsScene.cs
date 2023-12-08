using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingsScene : MonoBehaviour
{
    [SerializeField] TMP_Dropdown ResolutionDropdown;
    [SerializeField] Toggle FullscreenToggle;
    [SerializeField] Button SaveAndQuitButton;
    private int TimeSinceClick;
    Dictionary<int, (int, int)> Resolutions = new Dictionary<int, (int, int)>
    {
        {0, (1920, 1080) },
        {1, (1280, 768) },
        {2, (800, 600) },
        {3, (600, 450) },
        {4, (128, 96) }
    };
    Dictionary<(int, int), int> ResolutionsR = new Dictionary<(int, int), int>
    {
        {(1920, 1080), 0 },
        {(1280, 768),1 },
        {(800, 600),2 },
        {(600, 450),3 },
        {(128, 96),4 }
    };
    void Start()
    {
        TimeSinceClick = 5;
        SetUI();
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceClick++;
        SaveAndQuitButton.onClick.AddListener(delegate
        {
            if (TimeSinceClick < 5) return;
            SettingsManager.SetSettings(CurrentSet());
            SettingsManager.SaveSettingsToComp();
            SettingsManager.ApplySettings();
            SceneLoader.LoadScene("MainMenu");
            TimeSinceClick = 0;
        });
    }
    SettingsManager.Settings CurrentSet()
    {
        var resolutions = Resolutions[ResolutionDropdown.value];
        return new SettingsManager.Settings(resolutions.Item1, resolutions.Item2, FullscreenToggle.isOn);
    }
    void SetUI()
    {
        ResolutionDropdown.value = ResolutionsR[(Screen.width, Screen.height)];
        FullscreenToggle.isOn = Screen.fullScreen;
    }
}
