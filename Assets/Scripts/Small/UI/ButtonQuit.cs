using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour
{
    Button btn;
    private int TimeSinceClick;
    void Start()
    {
        btn = GetComponent<Button>();
        TimeSinceClick = 10;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceClick++;
        btn.onClick.AddListener(delegate
        {
            if (TimeSinceClick < 5) return;
            Application.Quit();
            TimeSinceClick = 0;
        });
    }
}
