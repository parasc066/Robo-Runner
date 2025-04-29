using UnityEngine;

public class Apple : Pickup
{
    LevelGenerator levelGenerator;
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        Debug.Log("Power Up !");
    }

}
