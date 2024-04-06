using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public float runSpeed = 40f;
    public Animator animator;
    public TMP_Text scoreDisplay;

    private float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;



    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public int score;

    public void ChangeScore(int scored)
    {
        score = score + scored;
        string scoreText = "Score: " + score.ToString();
        scoreDisplay.text = scoreText;
        // Debug.Log("Score" + score);
    }
    public int lives;
    public void ChangeHealth(int life)
    {
        Debug.Log("Hit in player movement");
        lives = lives + life;
        Health.p_lives = lives;
    }

    /*  if (movement.y < 0)
      {
          animator.Play(down);
          if (Input.GetKeyDown(KeyCode.C))
          {
              GameObject bullet_down = (GameObject)Instantiate(bullet_down_ref);
              bullet_down.transform.position = new Vector2(transform.position.x, transform.position.y);
          }
      } */


    /* public GameObject bullet_left_ref;
    public GameObject bullet_right_ref;
    public GameObject bullet_up_ref;'
    public GameObject bullet_down_ref; */

    AudioSource audioSource;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public AudioClip collectedClip;

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
}

