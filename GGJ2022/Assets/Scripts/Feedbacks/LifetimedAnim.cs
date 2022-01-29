using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifetimedAnim : MonoBehaviour
{
    [SerializeField] private AnimationClip clip;
    private float time;
    private void OnEnable()
    {
        time = clip.length;
    }

    private void Update()
    {
        Timer.CountDown(ref time, () => gameObject.SetActive(false));
    }
}
