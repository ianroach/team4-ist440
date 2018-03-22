using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	public Text Clock;
	float gameTimer = 0f;

	void Update () {
		gameTimer += Time.deltaTime;

		int seconds = (int)(gameTimer % 60);
		int minutes = (int)(gameTimer / 60) % 60;

		string timerString = string.Format ("{0:00}:{1:00}", minutes, seconds);

		Clock.text = timerString;

	
}
}