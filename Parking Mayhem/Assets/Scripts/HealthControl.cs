using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class HealthControl : MonoBehaviour {

    public GameObject Health1, Health2, Health3;
    public static int health;
	void Start () {
        health = 3;
        Health1.gameObject.SetActive(true);
        Health2.gameObject.SetActive(true);
        Health3.gameObject.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (health > 3)
            health = 3;
        switch (health)
        {
            case 3:
                Health1.gameObject.SetActive(true);
                Health2.gameObject.SetActive(true);
                Health3.gameObject.SetActive(true);
                break;
            case 2:
                Health1.gameObject.SetActive(true);
                Health2.gameObject.SetActive(true);
                Health3.gameObject.SetActive(false);
                break;
            case 1:
                Health1.gameObject.SetActive(true);
                Health2.gameObject.SetActive(false);
                Health3.gameObject.SetActive(false);
                break;
            case 0:
                Health1.gameObject.SetActive(false);
                Health2.gameObject.SetActive(false);
                Health3.gameObject.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
        }
	}
}
