using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalInit : MonoBehaviour
{
    void Awake()
    {
        LanguageManager.Init();
    }
}
