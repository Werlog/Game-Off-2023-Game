using System;
using UnityEngine;

public class TrailHandler : MonoBehaviour
{
    [SerializeField] private PlayerDash playerDashingScript;
    [SerializeField] private TrailRenderer trailRenderer;

    private void Start()
    {
        trailRenderer.enabled = false;
    }

    private void Update()
    {
        trailRenderer.enabled = playerDashingScript.GetIsDashing();
    }
}
