using UnityEngine;

public class BearAI : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public float attackRange = 2f;
    private Transform player;
    private Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRange)
            {
                MoveTowardsPlayer();

                if (distanceToPlayer <= attackRange)
                {
                    AttackPlayer();
                }
            }
            else
            {
                Wander();
            }
        }
    }

    void MoveTowardsPlayer()
    {
        Vector2 direction = player.position - transform.position;
        rb2D.velocity = direction.normalized * moveSpeed;
    }

    void Wander()
    {
        // Implement wandering behavior here
        // For simplicity, let's make the bear stop moving when the player is out of range
        rb2D.velocity = Vector2.zero;
    }

    public void AttackPlayer()
    {
        // Implement attack logic here
        Debug.Log("Bear attacks player!");
        // Example: Deal damage to the player
    }
}