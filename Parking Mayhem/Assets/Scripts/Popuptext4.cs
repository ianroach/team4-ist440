using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popuptext4 : MonoBehaviour {

    public Text text;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(ShowMessage("LAND ON EARTH WHEN YOU SEE IT", 6));
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        text.text = message;
        text.enabled = true;

        yield return new WaitForSeconds(delay);
        text.enabled = false;
    }
}
