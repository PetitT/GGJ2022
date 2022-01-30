using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimedAnim : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;
    [SerializeField] private float playbackSpeed = 1;
    private float time;
    private void OnEnable()
    {
        time = clip.length / playbackSpeed;
    }

    private void Update()
    {
        Timer.CountDown(ref time, () => gameObject.SetActive(false));
    }
}
