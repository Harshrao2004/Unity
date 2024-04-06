using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Down : MonoBehaviour
{

    Rigidbody2D rdb2;

    // Start is called before the first frame update
    void Start()
    {
        rdb2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rdb2.velocity = new Vector2(-20, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.compareTag("Tilemap"))
        {
            Destroy(gameObject);
        }
    }
}
