using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Start : MonoBehaviour {

    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

        // get the float value of SliderVolumeLevel if it has been saved with PlayerPrefs.SetFloat()
        // else use defult value of audioSource.volume
        audioSource.volume = PlayerPrefs.GetFloat("SliderVolumeLevel", audioSource.volume);
        audio.play();
    }

}
