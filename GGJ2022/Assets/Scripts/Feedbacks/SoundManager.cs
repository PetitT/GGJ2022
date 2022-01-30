using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource src;

    private int SoundsPerSecond = 30;
    private int remainingSoundsPerSecond;
    private float remainingTimeToSecond;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Timer.LoopedCountDown(ref remainingTimeToSecond, 1, () => remainingSoundsPerSecond = SoundsPerSecond);
    }

    public void PlayClip(AudioClip clip)
    {
        if (remainingSoundsPerSecond > 0)
        {
            src.PlayOneShot(clip);
            remainingSoundsPerSecond--;
        }
    }
}
