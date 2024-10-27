using System.Collections;
using UnityEngine;

public class Shooot : MonoBehaviour
{

    public GameObject bulletPrefab;  
    public float shoottime = 1.5f; 
    public float speeed = 5f; 

    void Start()
    {
        InvokeRepeating(nameof(Shoot), shoottime, shoottime);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();


        rb.velocity = -transform.right * speeed; 
    }
}
