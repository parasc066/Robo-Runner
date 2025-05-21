using System;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] float checkpointTimeExtension = 5f;

    GameManager gameManager;

    const string playerString = "Player";


    void Start() {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            Debug.Log("player Enter");
            gameManager.IncreaseTime(checkpointTimeExtension);
        }
    }
}
