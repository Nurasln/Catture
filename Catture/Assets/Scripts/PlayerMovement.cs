using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;
    [SerializeField] GameObject cloudEffect;

    Health health;

    Vector2 moveInput;

    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float jumpSpeed = 1f;
    [SerializeField] float runSpeed = 1f;
    float initialPlayerSpeed = 1f;

    public bool canPlayerJump = false;
    public bool canPlayerMove = true;
    public bool isDead = false;
    public bool isCaptured = false;
    bool isJumping = false;
    bool canJump = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        health = GetComponent<Health>();
        initialPlayerSpeed = playerSpeed;
    }

    void Update()
    {
        Move();
        FlipSprite();

        if (health.isDead)
        {
            Die();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerSpeed = runSpeed;
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", true);
        }
        else
        {
            playerSpeed = initialPlayerSpeed;
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            Debug.Log(canJump);
            Jump();
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    

    void Jump()
    {
        if (canJump && canPlayerJump)
        {
            animator.SetTrigger("Jump");
            canJump = false;

            rb2d.velocity = new Vector2(0f, jumpSpeed);
        }
        
    }

    void Move()
    {
        if (canPlayerMove == false)
        {
            Vector2 playerVelocity = new Vector2(0f, 0f);
            rb2d.velocity = playerVelocity;
            animator.SetBool("isWalking", false);
        }

        else
        {
            Vector2 playerVelocity = new Vector2(moveInput.x * playerSpeed, rb2d.velocity.y);
            rb2d.velocity = playerVelocity;

            bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
            animator.SetBool("isWalking", playerHasHorizontalSpeed);
        }
    }

    public void Die()
    {
        canPlayerMove = false;
        animator.SetBool("isWalking", false);
        animator.SetBool("isDead", true);
        isDead = true;
    }

    public void TakeDamage()
    {
        health.health -= 1;
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf .Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb2d.velocity.x), transform.localScale.y);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "BossDamageRange")
        {
            TakeDamage();
        }

        if (other.tag == "CapturePoint")
        {
            cloudEffect.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        if (other.tag == "LastCorridorTrigger")
        {
            SceneManager.LoadScene(7);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }
}