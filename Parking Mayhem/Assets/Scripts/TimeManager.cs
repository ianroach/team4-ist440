using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour {
	public Text Clock;

	public float startTime;
	public float ellapsedTime;
	public bool startCounter;

	public int minutes;
	public int seconds;
	// Use this for initialization
	void Start () {
		startCounter = false;
		Clock = GetComponent<Text> ();
	}

	public void startTimeCounter()
	{
		startTime = Time.time;
		startCounter = true;
	}

	public void stopTimeCounter()
	{
		startCounter = false;
	}

	void Update ()
	{
		if(startCounter)
		{
			ellapsedTime = Time.time - startTime;

			minutes = (int)ellapsedTime / 60;
			seconds = (int)ellapsedTime % 60;

			Clock.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
	}
	}
}