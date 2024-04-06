using UnityEngine;

public class BearMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float detectionRange = 5f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
    private Transform player;
    private bool isAttacking = false;
    private float lastAttackTime = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (!isAttacking)
        {
            // Move towards the player if within detection range
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= detectionRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
            }

            // Check if within attack range and cooldown time has passed
            if (distanceToPlayer <= attackRange && Time.time - lastAttackTime > attackCooldown)
            {
                AttackPlayer();
            }
        }
    }

    void AttackPlayer()
    {
        // Perform attack action here (e.g., play attack animation, deal damage to player)
        Debug.Log("Bear attacks the player!");
        lastAttackTime = Time.time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Start attacking when player enters detection range
            isAttacking = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop attacking when player exits detection range
            isAttacking = false;
        }
    }
}