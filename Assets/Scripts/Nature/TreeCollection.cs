using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollection : CollectableObject
{
    [SerializeField] private float GameMinutesToCollect;
    const int real_seconds_to_cut = 2;
    // Spawns as tree is cut
    [SerializeField] GameObject TreeStump;
    protected override void Start()
    {
        base.IdAmountPairs = new List<IdAmountPair> ();
        base.IdAmountPairs.Add(new IdAmountPair(0, Random.Range(5, 12)));
        base.IdAmountPairs.Add(new IdAmountPair(1, Random.Range(20, 45)));
        base.IdAmountPairs.Add(new IdAmountPair(2, Random.Range(2, 5)));
        base.Start();
    }
    protected override void OnMouseDown()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (Vector3.Distance(player.transform.position, transform.position) > DistanceToCollect) return;
        WaitingWindowController.Instance.Wait(GameMinutesToCollect, "Cutting...", real_seconds_to_cut);
        var stump = Instantiate(TreeStump, transform.position, Quaternion.identity);
        stump.transform.SetParent(GameObject.Find("SpawnedObjects").transform);
        base.OnMouseDown();
    }
}
