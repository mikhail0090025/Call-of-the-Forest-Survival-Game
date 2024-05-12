using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersNeeds : MonoBehaviour
{
    [SerializeField] private float hunger;
    [SerializeField] private float stamina;
    [SerializeField] private float thirsty;
    [SerializeField] private float sleep;
    [SerializeField] private PersonController personController;
    public float Hunger
    {
        get => hunger; set
        {
            if (value > 1f) hunger = 1f;
            else if (value < 0f) hunger = 0f;
            else hunger = value;
        }
    }
    public float Stamina
    {
        get => stamina; set
        {
            if (value > 1f) stamina = 1f;
            else if (value < 0f) stamina = 0f;
            else stamina = value;
        }
    }
    public float Thirsty
    {
        get => thirsty; set
        {
            if (value > 1f) thirsty = 1f;
            else if (value < 0f) thirsty = 0f;
            else thirsty = value;
        }
    }
    public float Sleep
    {
        get => sleep; set
        {
            if (value > 1f) sleep = 1f;
            else if (value < 0f) sleep = 0f;
            else sleep = value;
        }
    }
    // CONSTANTS
    const float HoursToHungerGets0 = 20f;
    const float HoursToThirstyGets0 = 10f;
    const float HoursToSleepGets0 = 24f;
    const float HoursToStaminaGets0 = 0.3f; // IN HOW MANY HOURS PLAYER LOSES ALL STAMINA
    const float HoursToStaminaGets1 = 0.3f; // IN HOW MANY HOURS PLAYER RECOVERS ALL STAMINA
    void Start()
    {
        hunger = 1f;
        stamina = 1f;
        thirsty = 1f;
        sleep = 1f;
    }

    void Update()
    {
        var HoursForFramePassed = EnvironmentController.HoursPassedPerFrame();
        hunger -= HoursForFramePassed / HoursToHungerGets0;
        thirsty -= HoursForFramePassed / HoursToThirstyGets0;
        sleep -= HoursForFramePassed / HoursToSleepGets0;
        if (personController.IsRunning())
        {
            stamina -= HoursForFramePassed / HoursToStaminaGets0;
        }
        else if (personController.IsWalking()) { }
        else stamina += HoursForFramePassed / HoursToStaminaGets1;
    }
}
