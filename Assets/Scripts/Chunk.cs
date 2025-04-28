using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject fencePrefab;
    [SerializeField] GameObject applePrefab;
    [SerializeField] GameObject coinPrefab;


    [Header(" ")]
    [SerializeField] float appleSpawnChance = .3f;
    [SerializeField] float coinSpawnChance = .5f;
    [SerializeField] float coinSeperationLength = 2f;


    [Header("  ")]
    [SerializeField] float[] lanes = { -2.5f, 0f, 2.5f };
    List<int> availableLanes = new List<int> { 0, 1, 2 };


    void Start()
    {
        SpawnFence();
        SpawnApple();
        SpawnCoins();
    }

    void SpawnFence()
    {
        int fencesToSpawn = Random.Range(0, lanes.Length);

        for (int i = 0; i < fencesToSpawn; i++)
        {
            if (availableLanes.Count <= 0) break;
            int selectedLane = SelectLane();
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(fencePrefab, spawnPos, Quaternion.identity, this.transform);
        }
    }


    void SpawnApple()
    {
        if (Random.value > appleSpawnChance || availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();
        Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
        Instantiate(applePrefab, spawnPos, Quaternion.identity, this.transform);
    }

    void SpawnCoins()
    {
        if (Random.value > coinSpawnChance || availableLanes.Count <= 0) return;

        int selectedLane = SelectLane();

        int maxCoinsToSpawn = 6;
        int coinsToSpawn = Random.Range(1, maxCoinsToSpawn);

        float topOfChunkZPos = transform.position.z + (coinSeperationLength * 2f);

        for (int i = 0; i < coinsToSpawn; i++)
        {
            float spawnPosZ = topOfChunkZPos - (i * coinSeperationLength);
            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, spawnPosZ);
            Instantiate(coinPrefab, spawnPos, Quaternion.identity, this.transform);
        }
    }


    int SelectLane()
    {
        int randomLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randomLaneIndex];
        availableLanes.RemoveAt(randomLaneIndex);
        return selectedLane;
    }
}
