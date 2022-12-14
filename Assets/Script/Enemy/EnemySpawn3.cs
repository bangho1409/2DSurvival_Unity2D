using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn3 : MonoBehaviour
{
    public GameObject enemyPref;
    public int spawnCount = 0;
    public int MaxSpawnCount = 10;


    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTime;
    [SerializeField] GameObject Player;

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
    }

    private void SpawnEnemy()
    {
        Vector3 position = new Vector3(
            UnityEngine.Random.Range(-spawnArea.x, spawnArea.x),
            UnityEngine.Random.Range(-spawnArea.y, spawnArea.y), 0f
            );

        GameObject newEnemyspawn = Instantiate(enemyPref);
        newEnemyspawn.transform.position = position;
        newEnemyspawn.GetComponent<EnemyBoss>().SetTarget(Player);
        spawnCount++;
    }


}
