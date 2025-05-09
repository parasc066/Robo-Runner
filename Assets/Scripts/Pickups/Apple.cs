using UnityEngine;

public class Apple : Pickup
{
    LevelGenerator levelGenerator;
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;

    public void Init(LevelGenerator levelGen)
    {
        this.levelGenerator = levelGen;
    }

    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        Debug.Log("Power Up !");
    }

}
