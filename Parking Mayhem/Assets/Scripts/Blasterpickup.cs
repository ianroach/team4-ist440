using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blasterpickup : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter ( Collider other) 
	{
		if (other.gameObject.name == "Player1")
		{
			other.gameObject.GetComponent<Player1Controlls> ().typeshot += 1;
			Destroy (this.gameObject);
		}

	}
}
