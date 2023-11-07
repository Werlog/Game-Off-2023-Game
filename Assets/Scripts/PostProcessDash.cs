using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessDash : MonoBehaviour
{
    [SerializeField] private AnimationCurve distortionCurve;
    [SerializeField] private Volume postProcessVolume;
    [SerializeField] private PlayerDash playerDashScript;
    private LensDistortion lensDistortion;
    private bool isAnimating;
    private void Start()
    {
        postProcessVolume.profile.TryGet(out lensDistortion);
    }

    private void Update()
    {
        if (playerDashScript.GetIsDashing() && !isAnimating)
        {
            animate();
        }
    }

    private void animate()
    {
        isAnimating = true;
        StartCoroutine(startAnimation(playerDashScript.GetDashLength()));
    }

    private IEnumerator startAnimation(float delay)
    {
        float time = 0;
        while (time < delay)
        {
            float percentage = time / delay;
            lensDistortion.intensity.value = -distortionCurve.Evaluate(percentage);
            time = time + Time.deltaTime;
            yield return null;
        }

        isAnimating = false;
    }
}