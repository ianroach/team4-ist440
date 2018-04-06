using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class HealthControl : MonoBehaviour {
    
	public GameObject healthCanvas;
    public GameObject Health1, Health2, Health3, Health4, Health5;
    public static int health;

	void Start () {
       
        health = 5;
        Health1.gameObject.SetActive(true);
        Health2.gameObject.SetActive(true);
        Health3.gameObject.SetActive(true);
		Health4.gameObject.SetActive(true);
		Health5.gameObject.SetActive(true);
       
    }
	
	// Update is called once per frame
	void Update () {
        
        if (health > 5)
            health = 5;
        switch (health)
        {
			case 5:
				Health1.gameObject.SetActive(true);
				Health2.gameObject.SetActive(true);
				Health3.gameObject.SetActive(true);
				Health4.gameObject.SetActive(true);
				Health5.gameObject.SetActive(true);
				break;
			case 4:
				Health1.gameObject.SetActive(true);
				Health2.gameObject.SetActive(true);
				Health3.gameObject.SetActive(true);
				Health4.gameObject.SetActive(true);
				Health5.gameObject.SetActive(false);
				break;
            case 3:
                Health1.gameObject.SetActive(true);
                Health2.gameObject.SetActive(true);
                Health3.gameObject.SetActive(true);
				Health4.gameObject.SetActive(false);
				Health5.gameObject.SetActive(false);
                break;
            case 2:
                Health1.gameObject.SetActive(true);
                Health2.gameObject.SetActive(true);
                Health3.gameObject.SetActive(false);
				Health4.gameObject.SetActive(false);
				Health5.gameObject.SetActive(false);
                break;
            case 1:
                Health1.gameObject.SetActive(true);
                Health2.gameObject.SetActive(false);
                Health3.gameObject.SetActive(false);
				Health4.gameObject.SetActive(false);
				Health5.gameObject.SetActive(false);
                break;
            case 0:
                Health1.gameObject.SetActive(false);
                Health2.gameObject.SetActive(false);
                Health3.gameObject.SetActive(false);
				Health4.gameObject.SetActive(false);
				Health5.gameObject.SetActive(false);
                SceneManager.LoadScene("GameOver");
                break;
        }
	}
}
