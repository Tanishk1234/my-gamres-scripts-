using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class SquareController : MonoBehaviour
{
    public float speed;
    public float JumpForce;
    private float moveInput;

    private bool FacingRight = true;

    private Rigidbody2D rb;

    [Header("Jump Values")]
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WhatIsGround;

    [Header("ExtraJumps")]
    public int extraJumps;
    public int extraJumpsValue;


     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
     void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WhatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if(FacingRight == false && moveInput > 0)
        {
            flip();
        }
        else if(FacingRight == true &&  moveInput < 0)
        {
            flip();
        }
      
    }

    public void Jump()
    {
        if(isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * JumpForce;
            extraJumps--;
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * JumpForce;
        }
    }

    void flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
