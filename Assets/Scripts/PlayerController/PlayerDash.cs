using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
[RequireComponent(typeof(PlayerMovement), typeof(Rigidbody2D))]
public class PlayerDash : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float dashSpeed = 30f;
    [SerializeField] private float dashDuration = 0.25f;
    [SerializeField] private float dashDelay = 1f;
    [Header("Damage")]
    [SerializeField] private int dashDamage = 25;
    [Header("Trails")]
    [SerializeField] private List<TrailHandler> trailHandlers = new List<TrailHandler>();

    private PlayerMovement movement;
    private Rigidbody2D rb;

    private bool isDashing = false;

    private float dashTime = 0f;
    private float sinceDashed = 0f;

    Vector2 dashDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && sinceDashed >= dashDelay)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            if (horizontal != 0 || vertical != 0)
            {
                dashDirection = new Vector2(horizontal, vertical).normalized;
                movement.enabled = false;
                dashTime = 0f;
                isDashing = true;
                AudioManager.instance.PlaySFX(0);
                ScreenShake.Singleton.ShakeCamera(5f, 0.25f);

                foreach (TrailHandler trailHandler in trailHandlers)
                {
                    trailHandler.EnableTrail();
                }
            }
        }

        if (isDashing)
        {
            dashTime += Time.deltaTime;
            if (dashTime > dashDuration)
            {
                isDashing = false;
                movement.enabled = true;
                sinceDashed = 0f;

                foreach (TrailHandler trailHandler in trailHandlers)
                {
                    trailHandler.DisableTrail();
                }
            }
        }else
        {
            sinceDashed += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            rb.MovePosition(rb.position + dashSpeed * Time.fixedDeltaTime * dashDirection);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (isDashing && health)
        {
            health.Damage(dashDamage);
        }
    }

    public bool GetIsDashing()
    {
        return isDashing;
    }

    public float GetDashLength()
    {
        return dashDuration;
    }
}
