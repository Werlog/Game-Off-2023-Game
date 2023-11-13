using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    /*
     * Makes the player look at the mouse cursor
    */

    [SerializeField] private float rotationZOffeset = 0f;
    [SerializeField] private float flipRotation = 90f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg + rotationZOffeset;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);

        if (Mathf.Abs(rotationZ) > flipRotation && !spriteRenderer.flipY)
        {
            spriteRenderer.flipY = true;
        }else if (Mathf.Abs(rotationZ) < flipRotation)
        {
            spriteRenderer.flipY = false;
        }
    }
}
