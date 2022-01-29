using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpriteDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] float speed = 10;
    private SpriteRenderer spriteRenderer;

    float currentSpriteValue = 3;
    float targetSpriteValue = 3;

    int lastSpriteValue;


    private void Start()
    {
        spriteRenderer = GameManager.Instance.Character.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        float targetX = GameManager.Instance.MovementManager.targetDirection.x;

        if (targetX == 0)
        {
            targetSpriteValue = 3;
        }
        else if (targetX < 0)
        {
            targetSpriteValue = 0;
        }
        else if (targetX > 0)
        {
            targetSpriteValue = 6;
        }

        currentSpriteValue = Mathf.MoveTowards(currentSpriteValue, targetSpriteValue, speed * Time.deltaTime);

        if (Mathf.RoundToInt(currentSpriteValue) != lastSpriteValue)
        {
            lastSpriteValue = Mathf.RoundToInt(currentSpriteValue);
            spriteRenderer.sprite = sprites[lastSpriteValue];
        }

    }
}
