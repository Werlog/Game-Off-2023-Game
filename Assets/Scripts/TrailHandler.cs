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

    public void EnableTrail()
    {
        trailRenderer.enabled = true;
    }

    public void DisableTrail()
    {
        trailRenderer.enabled = false;
    }
}
