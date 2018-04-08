using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

	public int count;
    public int finalScore;

	public Text ScoreText;
	public Text hiScoreText;

	void Start()
	{

		hiScoreText.text = PlayerPrefs.GetInt ("", 0).ToString();
       
    }
	// Update is called once per frame
	void Update () {

		ScoreText.text = "Score: " + count.ToString();
		if(count > PlayerPrefs.GetInt("", 0))
		{
			PlayerPrefs.SetInt ("", count);
			hiScoreText.text = count.ToString ();
            PlayerPrefs.SetInt("finalScore", finalScore);
        }
	}
}
