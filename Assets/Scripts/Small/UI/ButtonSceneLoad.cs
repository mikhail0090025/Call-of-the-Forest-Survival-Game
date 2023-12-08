using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSceneLoad : MonoBehaviour
{
    Button btn;
    [SerializeField] string SceneName;
    private int TimeSinceClick;
    private void Start()
    {
        btn = GetComponent<Button>();
        TimeSinceClick = 10;
    }
    void Update()
    {
        TimeSinceClick++;
        btn.onClick.AddListener(delegate
        {
            if (TimeSinceClick < 5) return;
            SceneLoader.LoadScene(SceneName);
            TimeSinceClick = 0;
        });
    }
}
