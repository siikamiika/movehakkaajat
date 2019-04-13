
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public float spawnRate;
    public GameObject[] Enemies;
    public float[] Rarities;
    private float zSpawnLocation = 24;
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
            jump:
            var rand = Mathf.Min((int)(Random.value * Enemies.Length), Enemies.Length-1);

            var enemy = Enemies[rand];
            if (Random.value > Rarities[rand]) {
                goto jump;
            }
            enemy = Instantiate(enemy);
            enemy.transform.position = new Vector3(
                xMin + Random.value * (xMax - xMin), 0, zSpawnLocation);
         }

    }
}
