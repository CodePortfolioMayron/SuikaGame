using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI Score;
    // Start is called before the first frame update
    private void OnEnable()
    {
        ScoreSystem.OnScoreChange += UpdateScore;
    }
    private void OnDisable()
    {
        ScoreSystem.OnScoreChange -= UpdateScore;
    }
    void UpdateScore(int newScore)
    {
        string scoreString = $"Score: {newScore}";
        Score.text = scoreString;
    }
}
