using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using DG.Tweening;

public class ScoreNumberDisplay : MonoBehaviour
{
    public void Init(int score)
    {
        GetComponent<TMP_Text>().text = score.ToString();
        transform.DOMoveY(transform.position.y + 1, 1);
        transform.DOScale(1.25f, 1).OnComplete(() => gameObject.SetActive(false));
    }
}
