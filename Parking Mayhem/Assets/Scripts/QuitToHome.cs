using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitToHome : MonoBehaviour
{
   


    // Update is called once per frame
    public void Quit()
    { 
        SceneManager.LoadScene("Parking_Mayhem_Menu");
    }
}