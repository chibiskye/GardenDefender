using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    Text scoreText;

    public static int score;

	// Use this for initialization
	void Awake () {
        scoreText = GetComponent<Text>();
        score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score: " + score;
	}
}
