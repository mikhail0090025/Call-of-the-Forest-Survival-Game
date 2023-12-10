using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGame
{
    public List<GameObject> AllObjects;
    public CurrentGame(List<GameObject> gameObjects)
    {
        AllObjects = gameObjects;
    }
    public CurrentGame(params GameObject[] gameObjects)
    {
        AllObjects = new List<GameObject>();
        AllObjects.AddRange(gameObjects);
    }
}
