using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(string GOname)
    {
        switch (GOname)
        {
            case "Cherry":
                score += 1;
                break;
            case "Strawberry":
                score += 3;
                break;
            case "Grape":
                score += 6;
                break;
            case "Orange":
                score += 10;
                break;
            case "Persimmon":
                score += 15;
                break;
            case "Apple":
                score += 21;
                break;
            case "Pear":
                score += 28;
                break;
            case "Peach":
                score += 36;
                break;
            case "Pineapple":
                score += 45;
                break;

            case "Melon":
                score += 55;
                break;
            case "Watermelon":
                score += 66;
                break;
        }
    }
}
