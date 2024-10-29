using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public bool onGround; //To check if player is on ground

    private Rigidbody2D rb;
    private float getAxisX;
    private float getAxisY;
    
    private Animator animator;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround=true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround=false;
        }
    }
    void Update()
    {
        Move();
        Jump();
        if(!onGround)
        {
            animator.SetBool("isJumping", true);
            animator.SetBool("isRunning", false);
        }
        else
        {
            animator.SetBool("isJumping", false);
        }
    }
    void Move()
    {
        getAxisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * getAxisX, rb.velocity.y);
        if(getAxisX > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRunning", true);
        }
        else if (getAxisX < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }
    void Jump()
    {
        getAxisY = Input.GetAxisRaw("Vertical");
        if (onGround && getAxisY > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce * getAxisY);
        }
    }
}
