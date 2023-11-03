using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Rigidbody2D))]
public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 30f;
    [SerializeField] private float dashDuration = 0.25f;

    private PlayerMovement movement;
    private Rigidbody2D rb;

    private bool isDashing = false;

    private float dashTime = 0f;

    Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                dashDirection = new Vector2(horizontal, vertical).normalized;
                movement.enabled = false;
                dashTime = 0f;
                isDashing = true;
            }
        }

        if (isDashing)
        {
            dashTime += Time.deltaTime;
            if (dashTime > dashDuration)
            {
                isDashing = false;
                movement.enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.MovePosition(rb.position + dashSpeed * Time.fixedDeltaTime * dashDirection);
        }
    }
}
