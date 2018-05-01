using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class blinkingtext : MonoBehaviour {

    public Text text;
	// Use this for initialization
	void Start () {
        GetComponent<Text>();
        StartBlinking();
	}

	IEnumerator Blink()
    {
        while (true)
        {
            switch(text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
                    yield return new WaitForSeconds(1.5f);
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
                    yield return new WaitForSeconds(1.5f);
                    break;
            }
        }
    }
	void StartBlinking () {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
	}
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
}
