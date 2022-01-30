using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Image fade;
    [SerializeField] private AudioClip bip;

    public void BeginGame()
    {
        fade.DOColor(new Color(fade.color.r, fade.color.g, fade.color.b, 1), 1f).OnComplete(() => SceneManager.LoadScene("SampleScene"));
        SoundManager.Instance.PlayClip(bip);
    }
}
