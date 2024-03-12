using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAPYBARA_MOVEMENT : MonoBehaviour
{
    float HorizontalInput;
    float moveSpeed = 5f;
    bool isFacingLeft = false;
    float jumpPower = 4f;
    bool isJumping = false;
    float coyoteTime = 0.1f; // Adjust this value to change coyote time duration
    float coyoteTimer = 0f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isJumping = true;
            coyoteTimer = coyoteTime; // Set coyote timer when the jump button is pressed
        }

        // Check for coyote time
        if (coyoteTimer > 0f)
        {
            coyoteTimer -= Time.deltaTime;
        }
        else
        {
            isJumping = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(HorizontalInput * moveSpeed, rb.velocity.y);
    }

    void FlipSprite()
    {
        if ((isFacingLeft && HorizontalInput < 0f) || (!isFacingLeft && HorizontalInput > 0f))
        {
            isFacingLeft = !isFacingLeft;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
