using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IdAmountItem
{
    public int ID;
    public int Count;
    public IdAmountItem(int id, int count)
    {
        ID = id;
        Count = count;
    }
}
