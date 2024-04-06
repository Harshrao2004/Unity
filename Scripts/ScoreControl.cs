using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreControl : MonoBehaviour
{
    public TMP_Text canvasText;
    public TMP_Text scoreText;
    static int currentScore = 0;

    // static int currentScore = 0;
    public static void UpdateScore(int increment)
    {
        currentScore += increment;
        //        string scoreDisplay = "Score: " + currentScore.ToString(); 
    }
    void Update()
    {
        string scoreDisplay = "Score: " + currentScore.ToString();
        scoreText.text = scoreDisplay;
    }

    // Start is calles before the first frame update
    void Start()
    {
        UpdateScore(0);
    }
}