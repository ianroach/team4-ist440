using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour {

	public float spawnDelay = 0.3f;

	float nextTimeToSpawn = 0f;

	public GameObject car;

	void Start () {
		
	}
	

	void Update () {
		if (nextTimeToSpawn <= Time.time) {
			SpawnCar ();
			nextTimeToSpawn = Time.time + spawnDelay;
		}
	}

	void SpawnCar()
	{
		Instantiate (car);
	}
}
