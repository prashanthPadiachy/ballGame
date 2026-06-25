using UnityEngine;

public class BallPlayerAnimation : MonoBehaviour
{
    public Rigidbody ballRb;
    public Animator animator;

    [Header("Speed Thresholds")]
    public float idleThreshold = 0.15f;
    public float runThreshold = 4.0f;

    [Header("Animation Smoothing")]
    public float animationDampTime = 0.12f;

    void Awake()
    {
        if (!animator)
            animator = GetComponent<Animator>();

        if (animator)
            animator.applyRootMotion = false;
    }

    void Update()
    {
        if (!ballRb || !animator) return;

        Vector3 vel = ballRb.linearVelocity;
        vel.y = 0f;

        float speed = vel.magnitude;

        // Optional: clean tiny values so idle triggers properly
        if (speed < idleThreshold)
            speed = 0f;

        animator.SetFloat("Speed", speed, animationDampTime, Time.deltaTime);
    }
}