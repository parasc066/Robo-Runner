using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int coinValue = 100;
    ScoreManager scoreManager;

    void Awake()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }

    protected override void OnPickup()
    {
        scoreManager.UpdateScore(coinValue);
    }
}
