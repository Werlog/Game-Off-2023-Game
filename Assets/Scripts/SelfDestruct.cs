using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    [SerializeField] private float delay = 1f;

    private void Start()
    {
        Destroy(gameObject, delay);
    }
}
