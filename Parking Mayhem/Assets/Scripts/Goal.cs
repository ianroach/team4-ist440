using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour {

    // Use this for initialization
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Gsol" && )
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
