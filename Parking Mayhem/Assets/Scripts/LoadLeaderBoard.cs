using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLeaderBoard : MonoBehaviour {

	public void LeaderBoard()
	{
		SceneManager.LoadScene ("ShowLeaderboard");
	}
}
