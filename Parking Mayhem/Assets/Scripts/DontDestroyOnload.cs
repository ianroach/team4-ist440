using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnload : MonoBehaviour {

	public GameObject instance = null;

	void Awake()
	{
		if (instance == null)
			instance = this.gameObject;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
	}
}
