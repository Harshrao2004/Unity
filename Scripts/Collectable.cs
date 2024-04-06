using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerMovement controller = other.GetComponent<PlayerMovement>();
        if (controller != null)
        {
            Destroy(gameObject);
            // controller.ChangeScore(1);
            ScoreControl.UpdateScore(1);
            
        }
    }
}

