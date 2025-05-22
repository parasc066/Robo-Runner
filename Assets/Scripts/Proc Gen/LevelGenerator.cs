using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] CameraController cameraController;
    [SerializeField] GameObject[] chunkPrefabs;
    [SerializeField] GameObject checkpointChunkPrefab;
    [SerializeField] Transform chunkParent;
    [SerializeField] ScoreManager scoreManager;

    [Header("Level Settings")]
    [Tooltip("Amount of Chunks we start with")]
    [SerializeField] int startingChunksAmount = 12;
    [SerializeField] int checkpointChunkInterval = 8;
    [Tooltip("Don't change chunk length unless chunk prefab size reflects change")]
    [SerializeField] float chunkLength = 10f;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float minMoveSpeed = 3f;
    [SerializeField] float maxMoveSpeed = 15f;
    [SerializeField] float minGravityZ = -22f;
    [SerializeField] float maxGravityZ = -2f;

    List<GameObject> chunks = new List<GameObject>();
    int chunksSpawned = 0;

    void Start()
    {
        SpawnStartingChunks();
    }
    void Update()
    {
        MoveChunks();
    }


    public void ChangeChunkMoveSpeed(float speedAmount)
    {
        float newMoveSpeed = moveSpeed + speedAmount;
        newMoveSpeed = Mathf.Clamp(newMoveSpeed, minMoveSpeed, maxMoveSpeed);

        if (newMoveSpeed != moveSpeed)
        {
            moveSpeed = newMoveSpeed;

            float newGravityZ = Physics.gravity.z + speedAmount;
            newGravityZ = Mathf.Clamp(newGravityZ, minGravityZ, maxGravityZ);

            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.y, newGravityZ);
            
            cameraController.ChangeCameraFOV(speedAmount);
        }
    }

    void SpawnStartingChunks()
    {
        for (int i = 0; i < startingChunksAmount; i++)
        {
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        float spawnPositionZ = CalculateSpawnPositionZ();

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPositionZ);

        GameObject chunkToSpawn = ChooseChunkToSpawn();

        GameObject newChunkGO = Instantiate(chunkToSpawn, chunkSpawnPos, Quaternion.identity, chunkParent);// prefab , position, rotation, parent

        chunks.Add(newChunkGO);
        Chunk newChunk = newChunkGO.GetComponent<Chunk>();
        newChunk.Init(this, scoreManager);

        chunksSpawned++;
        // Instantiate(chunkPrefab, new Vector3(0, 0, i * chunkLength), Quaternion.identity, chunkParent);// this will spawn chunks relative to world position
    }

    private GameObject ChooseChunkToSpawn()
    {
        GameObject chunkToSpawn;

        if (chunksSpawned % checkpointChunkInterval == 0 && chunksSpawned != 0)
        {
            chunkToSpawn = checkpointChunkPrefab;
        }
        else
        {
            chunkToSpawn = chunkPrefabs[Random.Range(0, chunkPrefabs.Length)];
        }

        return chunkToSpawn;
    }
    
    float CalculateSpawnPositionZ()
    {
        float spawnPositionZ;
        if (chunks.Count == 0)
        {
            spawnPositionZ = transform.position.z;
        }
        else
        {
            // spawnPositionZ = transform.position.z + (i * chunkLength);
            spawnPositionZ = chunks[chunks.Count - 1].transform.position.z + chunkLength; // spawn new chunk at the end of the last chunk
        }
        return spawnPositionZ;
    }

    void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; i++)
        {
            GameObject chunk = chunks[i];
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLength)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }
}