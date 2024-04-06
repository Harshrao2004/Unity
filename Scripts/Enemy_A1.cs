using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A1 : MonoBehaviour
{
    public float speed;
    public Transform target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            player.ChangeHealth(-1);
            Debug.Log("Hit by enemy");
        }
    }
}
