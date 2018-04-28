using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerlife2 : MonoBehaviour {

	public float maxLife { get; set; }
	public float currentLife { get; set; }
	public Multlvlhealth2 health;

	public Text lifetext;

	void Start () {
		health = GetComponent<Multlvlhealth2>();
		maxLife = 25;
		currentLife = maxLife;

	}



	void Update () {
		lifetext.text = "X"+ currentLife.ToString();
	}

	public void takeLife()
	{

		currentLife--;   
	}


	public void endGame()
	{
		if (currentLife == 0)
		{
			SceneManager.LoadScene ("Player1WinScene");
		}
	}
}
