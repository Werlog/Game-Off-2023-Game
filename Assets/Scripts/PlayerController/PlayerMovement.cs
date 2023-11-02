using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 20f;

    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movementDirection = new Vector2(horizontal, vertical).normalized;
        movement = movementSpeed * Time.deltaTime * movementDirection;
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement);
    }
}
