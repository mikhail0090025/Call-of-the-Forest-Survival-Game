using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonSceneLoad : MonoBehaviour
{
    Button btn;
    [SerializeField] string SceneName;
    private void Start()
    {
        btn = GetComponent<Button>();
    }
    void Update()
    {
        btn.onClick.AddListener(delegate
        {
            SceneLoader.LoadScene(SceneName);
        });
    }
}
