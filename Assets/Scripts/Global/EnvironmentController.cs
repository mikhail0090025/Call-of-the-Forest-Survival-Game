using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentController : MonoBehaviour
{
    public GameTime DateTime;
    public static EnvironmentController CurrentInstance;
    void Start()
    {
        if (DateTime == null) DateTime = new GameTime();
        CurrentInstance = this;
    }
    void Save()
    {
        UnityEditor.SceneManagement.EditorSceneManager.SaveScene(UnityEditor.SceneManagement.EditorSceneManager.GetActiveScene(), "Assets/Scenes/MyScene.unity");
    }
    void Update()
    {
        
    }
}
[System.Serializable]
public class GameTime
{
    public int hour { get => (int)Mathf.Round(ticks / RealSecondsInGameHour) % 24; }
    public int day { get => (int)Mathf.Round(ticks / (RealSecondsInGameHour * 24)); }
    private float ticks;
    public float Ticks { get => ticks; }
    const int RealSecondsInGameHour = 60;
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
}
