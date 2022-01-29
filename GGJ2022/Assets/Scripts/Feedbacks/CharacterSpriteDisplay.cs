using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterSpriteDisplay : MonoBehaviour
{
    [SerializeField] private Sprite[] blueSprites;
    [SerializeField] private Sprite[] redSprites;
    [SerializeField] float speed = 10;
    [SerializeField] private float transitionSpeed = 10;
    private SpriteRenderer spriteRenderer;

    float currentSpriteValue = 3;
    float targetSpriteValue = 3;

    int lastSpriteValue;
    bool isInTransition = false;

    private void Start()
    {
        spriteRenderer = GameManager.Instance.Character.GetComponent<SpriteRenderer>();
        GameManager.Instance.TeamManager.onTeamChanged += TeamManager_onTeamChanged;
    }

    private void OnDestroy()
    {
        GameManager.Instance.TeamManager.onTeamChanged -= TeamManager_onTeamChanged;
    }

    private void TeamManager_onTeamChanged(Team obj)
    {
        if(obj == Team.Red)
        {
            AnimToRed();
        }
        else
        {
            AnimToBlue();
        }
    }

    private void Update()
    {
        if (isInTransition) { return; }
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
            spriteRenderer.sprite = GetCurrentSprites()[lastSpriteValue];
        }
    }

    private Sprite[] GetCurrentSprites()
    {
        Team currentTeam = GameManager.Instance.TeamManager.currentTeam;
        Sprite[] sprites = currentTeam == Team.Red ? redSprites : blueSprites;
        return sprites;
    }

    private async void AnimToBlue()
    {
        isInTransition = true;
        GameManager.Instance.TeamManager.ToggleCanChangeTeam(false);
        while (currentSpriteValue < 6f)
        {
            currentSpriteValue += Time.deltaTime * transitionSpeed;
            spriteRenderer.sprite = redSprites[Mathf.FloorToInt(currentSpriteValue)];
            await Task.Yield();
        }
        currentSpriteValue = 0;
        while(currentSpriteValue < 3)
        {
            currentSpriteValue += Time.deltaTime * transitionSpeed;
            spriteRenderer.sprite = blueSprites[Mathf.RoundToInt(currentSpriteValue)];
            await Task.Yield();
        }

        targetSpriteValue = currentSpriteValue;
        isInTransition = false;
        GameManager.Instance.TeamManager.ToggleCanChangeTeam(true);
    }

    private async void AnimToRed()
    {
        isInTransition = true;
        GameManager.Instance.TeamManager.ToggleCanChangeTeam(false);
        while (currentSpriteValue > 0f)
        {
            spriteRenderer.sprite = blueSprites[Mathf.FloorToInt(currentSpriteValue)];
            currentSpriteValue -= Time.deltaTime * transitionSpeed;
            await Task.Yield();
        }
        currentSpriteValue = 6;
        while (currentSpriteValue > 3)
        {
            currentSpriteValue -= Time.deltaTime * transitionSpeed;
            spriteRenderer.sprite = redSprites[Mathf.RoundToInt(currentSpriteValue)];
            await Task.Yield();
        }

        targetSpriteValue = currentSpriteValue;
        isInTransition = false;
        GameManager.Instance.TeamManager.ToggleCanChangeTeam(true);
    }
}
