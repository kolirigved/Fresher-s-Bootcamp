using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f; 
    private Rigidbody2D rb;
    private Transform playerTransform;
    public bool onGround;
    public float minDistance;

    Animator animator;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(playerTransform == null)
        {
            Debug.Log("Shutting Down enemy");
            Destroy(gameObject);
        }
        else
        {
            Vector2 direction = (playerTransform.position - transform.position).normalized;
            if (Mathf.Abs(playerTransform.position.x - transform.position.x) < minDistance) direction = new Vector2(0,0);
            else rb.velocity = new Vector2(moveSpeed * direction.x, rb.velocity.y);
        }
        //Animator and flip the enemy
        if(rb.velocity.x<0) {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if(rb.velocity.x>0) {
            animator.SetBool("isRunning", true);
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else animator.SetBool("isRunning", false);
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
}
