using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D oth)
    {
        if (oth.gameObject.CompareTag("Enemy"))
        {
            Destroy(oth.gameObject);
        }
        if (oth.gameObject.CompareTag("Player"))
        {
            Destroy(oth.gameObject);
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }
        Destroy(gameObject);
        
    }
}
