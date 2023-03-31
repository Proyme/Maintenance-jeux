using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Mobs;
    public float spawnRadius = 10f;
    public float spawnInterval = 2f;

    private float spawnTimer;

    private Transform Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnMob();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnMob()
    {
        Vector3 randomPosition = Player.position + Random.insideUnitSphere * spawnRadius;
        //Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject mobObject = Instantiate(Mobs, randomPosition, Quaternion.identity);
    }
}