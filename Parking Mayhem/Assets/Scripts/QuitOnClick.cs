using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnClick : MonoBehaviour {

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false; /* Checks Application is running to false */
        Application.Quit(); /* Quits Application*/
    }
}
