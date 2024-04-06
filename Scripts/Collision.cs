using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public AudioClip collectedclip;

void OnTriggerEnter2D(Collider2D other)
{
    PlayerMovement controller = other.GetComponent<PlayerMovement>();
    if (controller != null)
    {

        controller.ChangeScore(1);
        Destroy(gameObject);

        controller.PlaySound(collectedClip);
    }
}
