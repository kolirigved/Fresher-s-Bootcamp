using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    bool onGround;
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
    void Update()
    {
        if(Input.GetKey("right"))
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(speed, 0)+rb.velocity;           
        }
        else if(Input.GetKey("left"))
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            rb.velocity = new Vector2(-speed, 0)+rb.velocity;
        }
        if(onGround && Input.GetKey("space"))
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }
    }
}
