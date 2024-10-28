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
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        rb = GetComponent<Rigidbody2D>();
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
            else if(!onGround)   rb.AddForce(new Vector2(direction.x * moveSpeed,0), ForceMode2D.Impulse);
            else            rb.AddForce(direction * moveSpeed, ForceMode2D.Impulse);
        }
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
