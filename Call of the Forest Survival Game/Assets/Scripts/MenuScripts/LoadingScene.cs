using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text Label;
    [SerializeField] Image ProgressBar;
    void Start()
    {
        StartCoroutine(LoadingOperation());
    }
    IEnumerator LoadingOperation()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneLoader.SceneName);
        while (!operation.isDone)
        {
            Label.text = $"Loading... {(operation.progress * 100f).ToString("F1")}%";
            ProgressBar.fillAmount = operation.progress / 0.9f;
            yield return null;
        }
    }
}
