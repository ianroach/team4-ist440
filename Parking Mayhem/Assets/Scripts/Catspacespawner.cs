using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catspacespawner : MonoBehaviour {

    public float timer;                //Time after which spawn time will decrease. In your case '10 s'.
    public float spawnTimer;            //Time after which Object spawns. In your case '1.5 s'
    public float decreasedSpawnTimer;     //Time which we will decrease to speed up Spawn. In your case '0.1 s'

    public GameObject[] Yoda;

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
            SpawnYoda();    //Spawn command here
        }

        if (timer < 0)    //TIme when spawn time decreases
        {
            timer = 10;
            decreasedSpawnTimer -= 0.1f;    //Time by which spawn time is reduced.
        }

        Destroyyoda();
    }

    void SpawnYoda()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];
        Instantiate(Yoda[Random.Range(0, Yoda.Length)], spawnPoint.position, spawnPoint.rotation);
    }

    void Destroyyoda()
    {
        if (timer == 40)    //TIme when spawner is destroyed
        {
            Destroy(gameObject);
        }

    }
}
