using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    private float getAxisX;
    public float jumpForce;
    public bool onGround; //To check if player is on ground
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    void Update()//Using old input system
    {
        Move();
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
        }
        else if (Input.GetKey("left") || Input.GetKey("a"))
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            
        }
        
        if((Input.GetKeyDown("up")||Input.GetKeyDown("w")))
        {
            Jump();
        }
    }
    void Move()
    {
        getAxisX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveSpeed * getAxisX, rb.velocity.y);
        
    }
    void Jump()
    {
        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
