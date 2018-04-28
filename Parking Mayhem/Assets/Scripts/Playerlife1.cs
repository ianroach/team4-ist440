using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Playerlife1 : MonoBehaviour {

    public float maxLife { get; set; }
    public float currentLife { get; set; }
    public Multlvlhealth1 health;

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
    }
   

    public void endGame()
    {
        if (currentLife == 0)
        {
			SceneManager.LoadScene ("Player2WinScene");
        }
    }
    
}
