using System.Collections;
using UnityEngine;

public class Spawnn : MonoBehaviour
{
    public GameObject enemy; 
    public float spawnInterval = 5.0f; 

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
