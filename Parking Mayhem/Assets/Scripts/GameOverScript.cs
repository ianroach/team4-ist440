using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{


    private ScoreManager score;

    public Text ScoreUIText;

    // Use this for initialization
    void Start()
    {

        score = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        ScoreUIText.text = "" + score.count.ToString();
    }

}
