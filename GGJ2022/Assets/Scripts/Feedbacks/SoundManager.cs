using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    private AudioSource src;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    public void PlayClip(AudioClip clip)
    {
        src.PlayOneShot(clip);
    }
}
