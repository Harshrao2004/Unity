using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public float speed;
    public float changeTime = 1.0f;
    float timer;
    int direction = 1;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }
    new Rigidbody2D rigidbody2D;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 2)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2.position = rigidbody2D.position;
        position.y = position.y + timer.deltaTime * speed * direction;
        rigidbody2D.MovePosition(position);
    }
}
    
