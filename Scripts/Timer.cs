using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeValue;
    Text timer_display;
    ScoreControl reset_score;

    void Start()
    {
        timer_display = GetComponent<Text>();
        reset_score = GameObject.FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
            timer_display.text = "Time left: " + (timeValue).ToString("0");
        }
        else
        {
            reset_score.Restart_score(0);
            SceneManager.LoadScene("Level_1");
        }
    }
}
