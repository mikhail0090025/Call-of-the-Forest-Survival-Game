using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    static string SceneName;
    public static void LoadScene(string sceneName)
    {
        SceneName = sceneName;
        SceneManager.LoadScene("LoadingScene");
    }
}
