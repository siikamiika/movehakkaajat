using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] Enemies;
    private float zSpawnLocation = 30;
    private float xMin = -10;
    private float xMax = 10;


    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1f/spawnRate);
            var rand = Mathf.Min((int)(Random.value * Enemies.Length), Enemies.Length-1);
            var enemy = Instantiate(Enemies[rand]);
            enemy.transform.position = new Vector3(
                xMin + Random.value * (xMax - xMin), 0, zSpawnLocation);
         }

    }
}
