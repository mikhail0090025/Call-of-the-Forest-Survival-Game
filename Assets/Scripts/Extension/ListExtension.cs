using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class ListExtension
{
    public static T RandomItem<T>(this List<T> list){
        return list[Random.Range(0, list.Count - 1)];
    }
}