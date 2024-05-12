using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayersUIupdate : MonoBehaviour
{
    [SerializeField] PlayersNeeds PlayersNeeds;
    [SerializeField] Image HungerImage;
    [SerializeField] Image StaminaImage;
    [SerializeField] Image ThirstyImage;
    [SerializeField] Image SleepImage;
    [SerializeField] Animator HungryLableAnimator;
    [SerializeField] Animator ThirstyLableAnimator;
    [SerializeField] Animator SleepLableAnimator;
    void Start()
    {
        PlayersNeeds = GetComponent<PlayersNeeds>();
    }

    // Update is called once per frame
    void Update()
    {
        HungerImage.fillAmount = PlayersNeeds.Hunger;
        StaminaImage.fillAmount = PlayersNeeds.Stamina;
        ThirstyImage.fillAmount = PlayersNeeds.Thirsty;
        SleepImage.fillAmount = PlayersNeeds.Sleep;
        HungryLableAnimator.SetBool("Shown", PlayersNeeds.Hunger < 0.25f);
        ThirstyLableAnimator.SetBool("Shown", PlayersNeeds.Thirsty < 0.25f);
        SleepLableAnimator.SetBool("Shown", PlayersNeeds.Sleep < 0.25f);
    }
}
