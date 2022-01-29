using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileBehaviour : MonoBehaviour
{
    private float Speed => GameManager.Instance.Data.MissilesSpeed;

    private void Update()
    {
        transform.Translate(Speed * Time.deltaTime * Vector2.up);

        if (!GameManager.Instance.CameraBordermanager.IsWithinScreenBounds(transform.position))
        {
            gameObject.SetActive(false);
        }
    }
}
