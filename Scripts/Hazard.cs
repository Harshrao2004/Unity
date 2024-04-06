using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement controller = other.GetComponent<PlayerMovement>();

        if (controller != null)
        {
            controller.ChangeHealth(-1);
        }
    }
}