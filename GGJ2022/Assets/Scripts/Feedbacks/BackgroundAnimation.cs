using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private float offsetSpeed;
    private float currentTexXOffset;

    private void Update()
    {
        currentTexXOffset += Time.deltaTime * offsetSpeed;
        meshRenderer.material.mainTextureOffset = new Vector2(0, currentTexXOffset);
    }
}
