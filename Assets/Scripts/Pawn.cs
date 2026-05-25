using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [Header("Speed Settings (Units Per Second)")]
    public float maxSpeed = 10f;
    public float boostMultiplier = 2.0f;

    [Header("Movement Settings")]
    public float rotationSpeed = 150f;
    public float screenMargin = 0.05f;

    private Rigidbody2D rb;
    private float thrustIntent;
    private float rotationIntent;
    private Vector2 strafeIntent;
    private Camera mainCamera;

    public bool isBoosting { get; private set; }

    // Calculates your current speed limit based on if you are holding shift
    public float CurrentMaxSpeed => isBoosting ? (maxSpeed * boostMultiplier) : maxSpeed;
    public float CurrentSpeed => rb.linearVelocity.magnitude;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    public void SetLocalThrust(float amount)
    {
        thrustIntent = Mathf.Clamp(amount, -1f, 1f);
    }

    public void SetRotation(float direction)
    {
        rotationIntent = Mathf.Clamp(direction, -1f, 1f);
    }

    public void SetStrafe(Vector2 direction)
    {
        strafeIntent = direction.normalized;
    }

    public void SetBoost(bool active)
    {
        isBoosting = active;
    }

    void FixedUpdate()
    {
        // 1. Handle Rotation
        float rotationAmount = rotationIntent * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation - rotationAmount);

        // 2. Direct Velocity 
        Vector2 targetVelocity = Vector2.zero;

        // Add our local forward/backward movement
        if (thrustIntent != 0)
        {
            targetVelocity += (Vector2)transform.up * thrustIntent;
        }

        // Add our world up/down/left/right strafing
        if (strafeIntent != Vector2.zero)
        {
            targetVelocity += strafeIntent;
        }

        // Apply the velocity directly! 
        // We normalize it so flying diagonally isn't accidentally faster.
        rb.linearVelocity = targetVelocity.normalized * CurrentMaxSpeed;

        HandleScreenWrap();
    }

    private void HandleScreenWrap()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(rb.position);
        bool didWrap = false;

        if (viewportPos.x < -screenMargin)
        {
            viewportPos.x = 1f + screenMargin;
            didWrap = true;
        }
        else if (viewportPos.x > 1f + screenMargin)
        {
            viewportPos.x = -screenMargin;
            didWrap = true;
        }

        if (viewportPos.y < -screenMargin)
        {
            viewportPos.y = 1f + screenMargin;
            didWrap = true;
        }
        else if (viewportPos.y > 1f + screenMargin)
        {
            viewportPos.y = -screenMargin;
            didWrap = true;
        }

        if (didWrap)
        {
            Vector3 worldPos = mainCamera.ViewportToWorldPoint(viewportPos);
            rb.position = new Vector2(worldPos.x, worldPos.y);
        }
    }
}