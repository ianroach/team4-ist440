using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

	public static float score = 0;

	public static Text ScoreText;

	public string scoreTextName = "ScoreText";

	// Update is called once per frame
	void Update () {

		DontDestroyOnLoad (gameObject);
		ScoreText = GameObject.Find (scoreTextName).GetComponent<Text> ();
		calculateScoreText ();
	}

	public static float getScore()
	{
		return score;
	}

	public static void addScore(float count)
	{
		score += count;
		calculateScoreText ();
	}

	public static void resetScore ()
	{
		score = 0;
	}

	public static void calculateScoreText ()
	{
		if (ScoreText != null)
		{
			ScoreText.text = "Score:" + score.ToString ();
		}
			
	}


}
