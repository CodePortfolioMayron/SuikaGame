using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public delegate void OnScoreChangeAction(int newScore);
    public static event OnScoreChangeAction OnScoreChange;
    int score = 0;
    public void OnEnable()
    {
        player.OnDrop += AddScore;
        FruitCombiner.OnCombine += MergeScore;
    }
    public void OnDisable()
    {
        player.OnDrop -= AddScore;
        FruitCombiner.OnCombine -= MergeScore;
    }
    public void AddScore(int ID)
    {
        score += ID;
        OnScoreChange?.Invoke(score);
        Debug.Log(score);
    }

    public void MergeScore(int mergeScore)
    {
        score += mergeScore;
        OnScoreChange?.Invoke(score);
        Debug.Log(score);
    }
}
