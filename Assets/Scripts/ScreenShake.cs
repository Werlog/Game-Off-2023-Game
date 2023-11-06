using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShake : MonoBehaviour
{
    private static ScreenShake _singleton;

    public static ScreenShake Singleton
    {
        get
        {
            return _singleton;
        }
        set
        {
            if (_singleton != null)
            {
                Debug.LogWarning($"{nameof(ScreenShake)}: Instance already exists, destroying duplicate");
                Destroy(value);
            }else
            {
                _singleton = value;
            }
        }
    }

    [SerializeField] private CinemachineVirtualCamera _camera;

    private CinemachineBasicMultiChannelPerlin perlin;

    private float shakeTime = 0f;
    private float initialShakeTime = 0f;
    private float initialInstensity = 0f;

    private void Awake()
    {
        Singleton = this;
        perlin = _camera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensity, float time)
    {
        perlin.m_AmplitudeGain = intensity;

        shakeTime = time;
        initialShakeTime = time;
        initialInstensity = intensity;
    }

    private void Update()
    {
        if (shakeTime > 0f)
        {
            perlin.m_AmplitudeGain = Mathf.Lerp(initialInstensity, 0f, 1 - (shakeTime / initialShakeTime));
            shakeTime -= Time.deltaTime;
        }
    }
}
