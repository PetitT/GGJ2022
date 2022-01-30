using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    public float lifeTime = 1;

    private void OnEnable()
    {
        lifeTime = 1;
    }

    private void Update()
    {
        Timer.CountDown(ref lifeTime, () => gameObject.SetActive(false));
    }
}
