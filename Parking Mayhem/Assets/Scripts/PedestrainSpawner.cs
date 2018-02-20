using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrainSpawner : MonoBehaviour {

	public float spawnDelay = 1.5f;
	float nextTimeToSpawn = 0f;

	public GameObject[]  pedestrian;

	public Transform[] spawnPoints;

	void Start () {
		
	}

	void Update () {
		if (nextTimeToSpawn <= Time.time) {
			SpawnPedestrian ();
			nextTimeToSpawn = Time.time + spawnDelay;
		}
	}
	void SpawnPedestrian()
	{
		int randomIndex = Random.Range (0, spawnPoints.Length);
		Transform spawnPoint = spawnPoints[randomIndex];
		Instantiate (pedestrian[Random.Range(0, pedestrian.Length)], spawnPoint.position, spawnPoint.rotation);
	}

}
