using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Animal : MonoBehaviour
{
    [Header("Set in inspector")]
    [SerializeField] protected string Name; // Name of the animal
    [SerializeField] protected float MaxHP; // Max hitpoints
    [SerializeField, Range(0.5f, 5f)] protected float Speed; // Meters in second
    [SerializeField, Range(0.5f, 5f)] protected float SpeedIfPoisoned; // Meters in second if poisoned
    [SerializeField] protected GameObject DeadPrefab;
    [Header("Defines in game")]
    [SerializeField] protected float CurrentHP;
    [Header("Poison")]
    [SerializeField] protected bool IsPoisoned;
    [SerializeField] protected float PoisonStrength;
    [SerializeField] protected float SecondsToFinishPoison;
    [Header("Bleeding")]
    [SerializeField] protected float Bleeding;
    [Header("Technical components (set automatically)")]
    [SerializeField] protected NavMeshAgent agent;
    protected virtual void Start()
    {
        CurrentHP = MaxHP;
        agent = GetComponent<NavMeshAgent>();
        ResetPoison();
    }

    protected virtual void Update()
    {
        if (IsPoisoned)
        {
            if (SecondsToFinishPoison <= 0)
            {
                ResetPoison();
            }
            CurrentHP -= Time.deltaTime * PoisonStrength;
            SecondsToFinishPoison -= Time.deltaTime;
        }
        CurrentHP -= Time.deltaTime * Bleeding;
        if(CurrentHP <= 0) {
            Dead();
        }
    }
    protected virtual void Poison(float strength, float seconds)
    {
        if (IsPoisoned)
        {
            PoisonStrength = PoisonStrength > strength ? PoisonStrength : strength;
            SecondsToFinishPoison = SecondsToFinishPoison < 0 ? 0 : SecondsToFinishPoison;
            SecondsToFinishPoison += seconds;
        }
        else
        {
            PoisonStrength = strength;
            SecondsToFinishPoison = seconds;
        }
        IsPoisoned = true;
    }
    protected virtual void AddBleeding(float bleeding)
    {
        Bleeding += bleeding;
    }
    protected virtual void RecoverBleeding(float recover)
    {
        Bleeding -= recover;
        Bleeding = Bleeding < 0 ? 0 : Bleeding;
    }
    protected virtual void RecoverBleeding()
    {
        Bleeding = 0f;
    }
    protected virtual void ResetPoison()
    {
        PoisonStrength = 0f;
        SecondsToFinishPoison = 0f;
        IsPoisoned = false;
    }
    protected virtual void Dead()
    {
        Instantiate(DeadPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
    protected virtual void GoToPoint(Vector3 point)
    {
        agent.Move(point);
    }
}
