using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);

        if (!GameManager.Instance.CameraBordermanager.IsWithinScreenBounds(transform.position))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out CharacterCollision characterCollision))
            gameObject.SetActive(false);
    }
}
