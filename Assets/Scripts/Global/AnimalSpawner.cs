using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] List<Transform> Spawnpoints;
    [SerializeField] List<GameObject> spawnedAnimals;
    [SerializeField] public List <GameObject> SpawnedAnimals => spawnedAnimals;
    [SerializeField] List<GameObject> AnimalsPrefabs;
    [SerializeField] float MaxDistanceFromPlayer;
    [SerializeField] int MaxAnimalsCount;
    const string SpawnpointTagName = "AnimalSpawnpoint";
    void Start()
    {
        Spawnpoints = new List<Transform>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        foreach (var item in GameObject.FindGameObjectsWithTag(SpawnpointTagName))
        {
            Spawnpoints.Add(item.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnedAnimals.Count < MaxAnimalsCount)
        {
            SpawnAnimal(RandomSpawnpoint());
        }
    }
    void SpawnAnimal(GameObject animal, Vector3 position)
    {
        var spawned = Instantiate(animal, position, Quaternion.identity, transform);
        spawnedAnimals.Add(spawned);
    }
    void SpawnAnimal(GameObject animal)
    {
        var spawned = Instantiate(animal, Spawnpoints.RandomItem().position, Quaternion.identity, transform);
        spawnedAnimals.Add(spawned);
    }
    void SpawnAnimal(Vector3 position)
    {
        var spawned = Instantiate(AnimalsPrefabs.RandomItem(), position, Quaternion.identity, transform);
        spawnedAnimals.Add(spawned);
    }
    void SpawnAnimal()
    {
        var spawned = Instantiate(AnimalsPrefabs.RandomItem(), Spawnpoints.RandomItem().position, Quaternion.identity, transform);
        spawnedAnimals.Add(spawned);
    }
    Vector3 RandomSpawnpoint()
    {
        float factor = Mathf.Sqrt(2f) / 2f;
        float OffsetX = Random.Range(-1f, 1f) * MaxDistanceFromPlayer * factor;
        float OffsetZ = Random.Range(-1f, 1f) * MaxDistanceFromPlayer * factor;
        Ray ray = new Ray(new Vector3(Player.position.x + OffsetX, 400, Player.position.z + OffsetZ), Vector3.down);
        RaycastHit hit;
        while (!Physics.Raycast(ray, out hit))
        {
            OffsetX = Random.Range(-1f, 1f) * MaxDistanceFromPlayer * factor;
            OffsetZ = Random.Range(-1f, 1f) * MaxDistanceFromPlayer * factor;
            ray = new Ray(new Vector3(Player.position.x + OffsetX, 400, Player.position.z + OffsetZ), Vector3.down);
        }
        return hit.point;
    }
}
