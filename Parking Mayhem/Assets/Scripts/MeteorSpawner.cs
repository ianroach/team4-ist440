using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour {

    public float timer;                
    public float spawnTimer;            
    public float decreasedSpawnTimer;     

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
        timer -= Time.deltaTime;    //Decreases time
        spawnTimer -= Time.deltaTime;    //Decreases time

        if (spawnTimer < 0)    //Time when spawn happens
        {
            spawnTimer = decreasedSpawnTimer;    //Assigns the modified spawn time
            SpawnMeteor();    //Spawn command here
        }

        if (timer < 0)    //TIme when spawn time decreases
        {
            timer = 10;
            decreasedSpawnTimer -= 0.1f;    //Time by which spawn time is reduced.
        }

        Destroymeteor();
    }

    void SpawnMeteor()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(Meteor[Random.Range(0, Meteor.Length)], spawnPoint.position, spawnPoint.rotation);
    }

    void Destroymeteor()
    {
        if (timer == 40)    //TIme when spawner is destroyed
        {
            Destroy(gameObject);
        }

    }
}

