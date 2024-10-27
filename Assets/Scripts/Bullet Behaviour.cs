using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public GameObject player;
    healthBar health;

    void Start()
    {
        player = GameObject.Find("Player");
        health = player.GetComponent<healthBar>();
    }
    void OnCollisionEnter2D(Collision2D oth)
    {
        if (oth.gameObject.CompareTag("Enemy"))
        {
            //Destrotying enemy on colliding with the bullet
            Destroy(oth.gameObject);
        }
        if (oth.gameObject.CompareTag("Player"))
        {
            health.Damage(oth);
            Destroy(gameObject);
            //Destroy(oth.gameObject);
        }
        //Destroying the bullet
        if(!oth.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
