using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenShaker : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin perlin;

    private float amplitude => GameManager.Instance.Data.ScreenShakeAmplitude;
    private float frequency => GameManager.Instance.Data.ScreenShakeFrequency;
    private int time => GameManager.Instance.Data.ScreenShakeTimeInMiliseconds;
    private float bigamplitude => GameManager.Instance.Data.BigScreenShakeAmplitude;
    private float bigfrequency => GameManager.Instance.Data.BigScreenShakeFrequency;
    private int bigtime => GameManager.Instance.Data.BigScreenShakeTimeInMiliseconds;

    private void Start()
    {
        perlin = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        GameManager.Instance.HealthManager.onHealthChanged += HealthManager_onHealthChanged;
        GameManager.Instance.HealthManager.onDeath += HealthManager_onDeath;
    }

    private void OnDestroy()
    {
        GameManager.Instance.HealthManager.onHealthChanged -= HealthManager_onHealthChanged;
        GameManager.Instance.HealthManager.onDeath -= HealthManager_onDeath;
    }

    private void HealthManager_onDeath()
    {
        ShakeScreen(bigamplitude, bigfrequency, bigtime);
    }

    private void HealthManager_onHealthChanged(int obj)
    {
        if (obj != 3 && obj != 0)
        {
            ShakeScreen(amplitude, frequency, time);
        }
    }

    private async void ShakeScreen(float amplitude, float frequency, int time)
    {
        perlin.m_AmplitudeGain = amplitude;
        perlin.m_FrequencyGain = frequency;
        await Task.Delay(time);
        perlin.m_AmplitudeGain = 0;
        perlin.m_FrequencyGain = 0;
    }
}
