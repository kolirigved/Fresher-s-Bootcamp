using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    public Transform GunLocation;
    public GameObject Bullets;
    GameObject player;
    public float speed;

    float direction;

    public float shootingCooldown = 2.0f;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        shootingCooldown -= Time.deltaTime;

        if (shootingCooldown <= 0.0f)
        {
            direction = player.transform.position.x - transform.position.x;
            Debug.Log("player local x  " + player.transform.position.x.ToString() + " local scale x " + transform.position.x.ToString() + " we get direction " + direction.ToString());
            if(direction < 0)
            {
                direction = -1.0f;
            }
            else
            {
                direction = 1.0f;
            }
            transform.localScale = new Vector3(direction * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            GameObject bulletSpawned = Instantiate(Bullets, GunLocation.position, Quaternion.identity);
            bulletSpawned.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * (transform.localScale.x), 0);
            shootingCooldown = 2.0f;
        }
    }
}
