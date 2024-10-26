using System.Collections;
using UnityEngine;

public class Spawnn : MonoBehaviour
{
    public GameObject enemy; 
    public Transform spawnPoint; 
    public float spawnInterval = 5.0f; 

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
