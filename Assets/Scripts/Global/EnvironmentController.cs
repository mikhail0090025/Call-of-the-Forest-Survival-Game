using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnvironmentController : MonoBehaviour
{
    public GameTime DateTime;
    public static EnvironmentController CurrentInstance;
    [SerializeField] TMP_Text TimeLable;
    [SerializeField] Light MainLight;
    const float MinExposure = 0.1f;
    void Start()
    {
        DateTime = new GameTime(0,7);
        CurrentInstance = this;
    }
    void Save()
    {
        //UnityEditor.SceneManagement.EditorSceneManager.SaveScene(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene(), "Assets/Scenes/MyScene.unity");
    }
    void Update()
    {
        TimeLable.text = $"{DateTime.day} days, {DateTime.hour.ToString("D2")}:{DateTime.minute.ToString("D2")}";
        DateTime.UpdTicks(Time.deltaTime);
        var dayProgress = DateTime.getDayProgress();
        if (dayProgress < (4f / 24f) || dayProgress > (22f / 24f))
        {
            MainLight.intensity = 0;
            RenderSettings.skybox.SetFloat("_Exposure", 0);
        }
        else if (dayProgress > (4f / 24f) && dayProgress < (8f / 24f))
        {
            MainLight.intensity = (dayProgress - (4f / 24f)) / (4f / 24f);
            RenderSettings.skybox.SetFloat("_Exposure", MainLight.intensity);
        }
        else if (dayProgress > (19f / 24f) && dayProgress < (23f / 24f))
        {
            MainLight.intensity = 1f - ((dayProgress - (19f / 24f)) / (4f / 24f));
            RenderSettings.skybox.SetFloat("_Exposure", MainLight.intensity);
        }
        else
        {
            MainLight.intensity = 1f;
            RenderSettings.skybox.SetFloat("_Exposure", 1);
        }
        if (RenderSettings.skybox.GetFloat("_Exposure") < MinExposure) RenderSettings.skybox.SetFloat("_Exposure", MinExposure);
    }
    public static float HoursPassedPerFrame() => Time.deltaTime / GameTime.RealSecondsInGameHour;
}
[System.Serializable]
public class GameTime
{
    public int hour => (int)Mathf.Floor(ticks / RealSecondsInGameHour) % 24;
    public int minute => (int)Mathf.Floor(((ticks % RealSecondsInGameHour) / RealSecondsInGameHour) * 60);
    public int day => (int)Mathf.Floor(ticks / (RealSecondsInGameHour * 24));
    [SerializeField]
    private float ticks;
    public float Ticks { get => ticks; }
    public const int RealSecondsInGameHour = 30;
    public void UpdTicks(float ticksToAdd)
    {
        ticks += ticksToAdd;
    }
    public GameTime(int d, int h)
    {
        ticks = (h * RealSecondsInGameHour) + (d * 24 * RealSecondsInGameHour);
    }
    public GameTime()
    {
        ticks = 0f;
    }
    public void AddHours(float hours)
    {
        ticks += hours * RealSecondsInGameHour;
    }
    // Returns 0 when time is 00:00, and 1 when time is 24:00
    public float getDayProgress()
    {
        float ticksInDay = RealSecondsInGameHour * 24;
        return (ticks % ticksInDay) / ticksInDay;
    }
}
