using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

    public float spawnDelay = 0.3f;

    float nextTimeToSpawn = 0f;

    public GameObject[] Meteor;

    public Transform[] spawnPoints;

    void Start()
    {

    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {

        if (nextTimeToSpawn <= Time.time)
        {
            SpawnMeteor();
            nextTimeToSpawn = Time.time + spawnDelay;
        }
    }

    void SpawnMeteor()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(Meteor[Random.Range(0, Meteor.Length)], spawnPoint.position, spawnPoint.rotation);
    }
}

