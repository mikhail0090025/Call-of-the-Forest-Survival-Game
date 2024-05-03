using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Build : MonoBehaviour
{
    [SerializeField] protected string Name;
    [SerializeField] protected string Description;
    virtual protected void Start()
    {
        var text = this.gameObject.AddComponent<TextOnWatching>();
        text.distance = 5;
        text.Text = Name + "\n" + Description;
    }

    virtual protected void Update()
    {
        
    }
}
