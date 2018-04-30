using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popuptext2 : MonoBehaviour {
	public Text text;

	// Use this for initialization
	void Start () {
		StartCoroutine (ShowMessage ("Player1", 4));
	}

	IEnumerator ShowMessage (string message, float delay)
	{
		text.text = message;
		text.enabled = true;

		yield return new WaitForSeconds(delay);
		text.enabled = false;
	}
}
