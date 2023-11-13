using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleController : MonoBehaviour
{
    [Header("Scale Limitation")]
    [SerializeField] private float minScale = 0.25f;
    [SerializeField] private float maxScale = 3f;
    [Header("Controlls")]
    [SerializeField] private float scrollSensitivity = 1f;
    [SerializeField] private float sizeChangeSpeed = 3f;

    private float targetScale;

    private void Start()
    {
        targetScale = minScale;
    }

    void Update()
    {
        float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
        if (scroll != 0)
        {
            targetScale += scroll * scrollSensitivity;
            targetScale = Mathf.Clamp(targetScale, minScale, maxScale);
        }

        transform.localScale = Vector3.one * Mathf.Lerp(transform.localScale.x, targetScale, Time.deltaTime * sizeChangeSpeed);
    }
}
