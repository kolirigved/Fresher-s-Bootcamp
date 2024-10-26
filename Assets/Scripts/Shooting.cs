using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform GunLocation;
    public GameObject Bullets;
    public float speed;
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            GameObject bulletSpawned = Instantiate(Bullets, GunLocation.position, Quaternion.identity);
            bulletSpawned.GetComponent<Rigidbody2D>().velocity = new Vector2(speed*transform.localScale.x, 0);
        }
    }
}
