using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerlife2 : MonoBehaviour {

	public float maxLife { get; set; }
	public float currentLife { get; set; }
	public Multlvlhealth2 health;
	public GameObject destroyExplosion;
	public Text lifetext;

	void Start () {
		health = GetComponent<Multlvlhealth2>();
		maxLife = 15;
		currentLife = maxLife;

	}



	void Update () {
		lifetext.text = "X"+ currentLife.ToString();
	}

	public void takeLife()
	{

		currentLife--;   
		playExplosion ();
		if (currentLife <= 0) 
		{	
			playExplosion ();
			Destroy (this.gameObject);

			endGame ();
		}
	}


	public void endGame()
	{


			SceneManager.LoadScene ("Player1WinScene");

	}
	private void playExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate(destroyExplosion);
		explosion.transform.position = transform.position;

	}
}
