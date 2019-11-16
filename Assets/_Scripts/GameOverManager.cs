using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOverManager : MonoBehaviour {

    Animator anim;
    Text displayText;
    int score;
    float restartTimer;

    public static bool gameOver;

    public float restartDelay;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        displayText = GetComponentInChildren<Text>();
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        score = ScoreManager.score;

        ChangeText(displayText, score);

        anim.SetInteger("ScoreValue", score);

        if (score < -200 || score > 200)
        {
            gameOver = true;

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay && Input.GetButton("Restart"))
            {
                SceneManager.LoadScene("GardenDefenderLv1");
            }
        }
    }

    void ChangeText (Text display, int scoreValue)
    {
        if (scoreValue < -200)
        {
            display.text = "Game Over!";
        }
        else if (scoreValue > 200)
        {
            display.text = "You Win!";
        }
    }
}
