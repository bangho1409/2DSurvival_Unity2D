using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPref;
    public GameObject Boss;
    public int spawnCount = 0;
    public int MaxSpawnCount = 10;


    public int MaxSpawnBoss = 1;

    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTime;
    [SerializeField] GameObject Player;

    EnemyFireBall fireball;

    float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f && spawnCount < MaxSpawnCount)
        {
            SpawnEnemy();
            timer = spawnTime;
        }

        if ( spawnCount == MaxSpawnCount && MaxSpawnBoss == 1)
        {
            MaxSpawnBoss++;
            StartCoroutine(SpawnBoss()); 
        }
    }

    private void SpawnEnemy()
    {
        Vector3 position = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y, spawnArea.y), 0f
            );

        GameObject newEnemyspawn = Instantiate(enemyPref);
        newEnemyspawn.transform.position = position;
        newEnemyspawn.GetComponent<Enemy>().SetTarget(Player);
        spawnCount++;
    }


    IEnumerator SpawnBoss()
{
        yield return new WaitForSeconds(10);
        Vector3 position = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y, spawnArea.y), 0f
            );

        GameObject newBossSpawn = Instantiate(Boss);
        newBossSpawn.transform.position = position;
        newBossSpawn.GetComponent<EnemyRange>().SetTarget(Player);   
        spawnCount++;
    }
}
