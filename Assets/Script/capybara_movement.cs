using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAPYBARA_MOVEMENT : MonoBehaviour
{
    float HorizontalInput;
    float moveSpeed = 5f;
    bool isFacingLeft = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        FlipSprite();
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
}