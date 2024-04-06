using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public static int p_lives = 5;

    Text player_lives;

    // Use this for initialization
    void Start()
    {
        player_lives = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        player_lives.text = "Lives :" + p_lives;
        HealthBar.current_lives = p_lives;
    }
}
