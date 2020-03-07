using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator animator;

    public float moveSpeed = 6f;
    public float sprintSpeed = 10f;
    float xMove = 0f;

    public float jumpVelocity = 7f;
    public float fallMultiplier = 2f;
    public float lowJumpMultiplier = 2f;

    bool isGrounded;
    bool facingRight = true;

    [SerializeField] LayerMask ground = default;
    [SerializeField] Transform groundCheck = default;

    public UnityEvent OnLandEvent;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    // Update is called once per frame
    void Update()
    {
        // Set horizontal movement
        if (Input.GetButton("Shift"))
            xMove = Input.GetAxisRaw("Horizontal") * sprintSpeed;
        else
            xMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(xMove));

        // Flip the player
        if ((xMove > 0 && !facingRight) || (xMove < 0 && facingRight))
            Flip();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = Vector2.up * jumpVelocity;
            animator.SetBool("isJumping", true);
        }
    }

    void FixedUpdate()
    {
        // Physics to control jump height depending on how long the Jump button is pressed
        if (rb.velocity.y < 0)
            rb.velocity += Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            rb.velocity += Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        animator.SetFloat("yVelocity", rb.velocity.y);

        // Checking if player is grounded or not
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .2f, ground);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        // Left-right movement & increasing move speed with shift
        Vector3 movement = new Vector3(xMove, 0, 0);
        transform.Translate(movement * Time.deltaTime);
    }

    public void onLanding()
    {
        animator.SetBool("isJumping", false);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
