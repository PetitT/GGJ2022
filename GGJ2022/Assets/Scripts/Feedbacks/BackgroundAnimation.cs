using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAnimation : MonoBehaviour
{
    [SerializeField] private MeshRenderer backgroundMesh;
    [SerializeField] private float offsetSpeed;

    [SerializeField] private MeshRenderer gridMesh;
    [SerializeField] private float gridOffsetSpeed;

    private float currentTexXOffset;

    private void Update()
    {
        currentTexXOffset += Time.deltaTime;
        backgroundMesh.material.mainTextureOffset = new Vector2(0, currentTexXOffset * offsetSpeed);
        gridMesh.material.mainTextureOffset = new Vector2(0, currentTexXOffset * gridOffsetSpeed);
    }
}
