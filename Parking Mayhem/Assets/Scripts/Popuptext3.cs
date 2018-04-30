using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popuptext3 : MonoBehaviour {

	public Text text;

	// Use this for initialization
	void Start () {
		StartCoroutine (ShowMessage ("Player2", 4));
	}

	IEnumerator ShowMessage (string message, float delay)
	{
		text.text = message;
		text.enabled = true;

		yield return new WaitForSeconds(delay);
		text.enabled = false;
	}
}
