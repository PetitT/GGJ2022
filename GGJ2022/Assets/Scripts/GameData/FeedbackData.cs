using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="FeedbackData", fileName ="FeedbackData")]
public class FeedbackData : ScriptableObject
{
    [Header("Sound Effects")]
    public AudioClip missileShot;

    public static FeedbackData GetFeedbackData()
    {
        return Resources.Load<FeedbackData>("FeedbackData");
    }
}
