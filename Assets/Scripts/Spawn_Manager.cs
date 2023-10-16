using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int enemyCount;
    private int waveNumber = 1;
    public GameObject powerupPrefab;
    
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-9, 9);
        float spawnPosZ = Random.Range(-9, 9);

        Vector3 randomPos = new Vector3 (spawnPosX, 0, spawnPosZ);

        return randomPos;
    }
}
