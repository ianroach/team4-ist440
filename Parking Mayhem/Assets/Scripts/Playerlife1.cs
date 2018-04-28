using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerlife1 : MonoBehaviour {

    public float maxLife { get; set; }
    public float currentLife { get; set; }
    public Multlvlhealth1 health;

	public GameObject destroyExplosion;
    public Text lifetext;

	void Start () {
        health = GetComponent<Multlvlhealth1>();
        maxLife = 25;
        currentLife = maxLife;
      
	}

   

	void Update () {
		lifetext.text = "X"+ currentLife.ToString();
	}

    public void takeLife()
    {
        
            currentLife--;   
		if (currentLife <= 0) 
		{	
			playExplosion ();
			Destroy (this.gameObject);

			endGame ();
		}
    }
   

    public void endGame()
    {
  
       
			SceneManager.LoadScene ("Player2WinScene");
        
    }
	private void playExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate(destroyExplosion);
		explosion.transform.position = transform.position;

	}
    
}
