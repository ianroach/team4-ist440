using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenButton : MonoBehaviour {

    public string mainMenu;

    // Update is called once per frame
    void Update () {
        Resume();

    }
    public void Resume()
    {
        SceneManager.LoadScene(1);
    }
}
