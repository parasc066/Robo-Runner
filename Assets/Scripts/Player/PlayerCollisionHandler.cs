using UnityEngine;
using System.Collections;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    const string ANIMATOR_TRIGGER_HIT = "Hit";
    float cooldownTimer = 0f;

    void Update()
    {
        cooldownTimer += Time.deltaTime;//CooldownTimer = CooldownTimer + Time.deltaTime;
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (cooldownTimer < collisionCooldown) return;

        animator.SetTrigger(ANIMATOR_TRIGGER_HIT);
        cooldownTimer = 0f;
    }
}
