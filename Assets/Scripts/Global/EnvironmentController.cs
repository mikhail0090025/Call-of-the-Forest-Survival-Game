using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnvironmentController : MonoBehaviour
{
    public GameTime DateTime;
    public static EnvironmentController CurrentInstance;
    [SerializeField] TMP_Text TimeLable;
    void Start()
    {
        DateTime = new GameTime(0,8);
        CurrentInstance = this;
    }
    void Save()
    {
        //UnityEditor.SceneManagement.EditorSceneManager.SaveScene(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene(), "Assets/Scenes/MyScene.unity");
    }
    void Update()
    {
        TimeLable.text = $"{DateTime.day} days, {DateTime.hour.ToString("D2")}:{DateTime.minute.ToString("D2")}";
        Debug.Log(DateTime.getDayProgress());
        DateTime.UpdTicks(Time.deltaTime);
    }
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
    const int RealSecondsInGameHour = 30;
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
