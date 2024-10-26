using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool onGround; //To check if player is on ground
    Rigidbody2D rb;
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
        if(Input.GetKey("right")||Input.GetKey("d"))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(speed, 0)+rb.velocity;           
        }
        else if(Input.GetKey("left")||Input.GetKey("a"))
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(-speed, 0)+rb.velocity;
        }
        if(onGround && Input.GetKeyDown("up")||Input.GetKeyDown("w"))
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}
