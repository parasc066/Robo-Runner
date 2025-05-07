using UnityEngine;
using System.Collections;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;

    const string ANIMATOR_TRIGGER_HIT = "Hit";
    const string ANIMATOR_TRIGGER_JUMP = "Jump";
    float cooldownTimer = 0f;

    LevelGenerator levelGenerator;

    CapsuleCollider capsuleCollider;


    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;//CooldownTimer = CooldownTimer + Time.deltaTime;
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            capsuleCollider.enabled = false;
            animator.SetTrigger(ANIMATOR_TRIGGER_JUMP);
            capsuleCollider.enabled = true;
            cooldownTimer = 0f;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(ANIMATOR_TRIGGER_HIT);
        cooldownTimer = 0f;
    }
}
