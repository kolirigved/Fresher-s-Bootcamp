using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public int maxHeatlh = 100;
    public int currentHealth;
    public Text health;
    public GameObject ui_lose;

    void Start()
    {
        currentHealth = maxHeatlh;
    }
    

    public void Damage(Collision2D oth)
    {
        // Debug.Log("It is taking damage");
            currentHealth -= 20;
            health.text = currentHealth.ToString();
        if (currentHealth <= 0)
        {
            ui_lose.SetActive(true);
            if (oth.gameObject.CompareTag("Player"))
            {
                oth.gameObject.SetActive(false);
            }
            else
            {
                Destroy(oth.gameObject);
            }
            //We're dead
            //Play Death animation
        }

    }
}
