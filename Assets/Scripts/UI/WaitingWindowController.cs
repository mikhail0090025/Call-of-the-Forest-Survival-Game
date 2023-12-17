using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WaitingWindowController : MonoBehaviour
{
    [SerializeField] GameObject Window;
    [SerializeField] Animator CircleAnimator;
    [SerializeField] TMP_Text Label;
    public static WaitingWindowController Instance;
    void Start()
    {
        Instance = this;
        Window.SetActive(false);
    }
    public void Wait(float game_minutes, string Text, int real_seconds)
    {
        StartCoroutine(WaitingCoroutine(game_minutes, Text, real_seconds));
    }
    IEnumerator WaitingCoroutine(float game_minutes, string Text, int real_seconds)
    {
        Window.SetActive(true);
        Label.text = Text;
        CircleAnimator.Play("CircleUI", 0, 0f);
        CircleAnimator.speed = 1f / real_seconds;
        Time.timeScale = 0f;

        yield return new WaitForSeconds(real_seconds);

        Time.timeScale = 1f;
        EnvironmentController.CurrentInstance.DateTime.AddHours(game_minutes / 60f);
        Window.SetActive(false);
    }
}
