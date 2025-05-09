using UnityEngine;

public class Coin : Pickup
{
    [SerializeField] int coinValue = 100;
    ScoreManager scoreManager;

    public void Init(ScoreManager scoreMan)
    {
        this.scoreManager = scoreMan;
    }

    protected override void OnPickup()
    {
        scoreManager.UpdateScore(coinValue);
    }
}
