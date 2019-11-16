using UnityEngine;
using System.Collections;

public class BGMManager : MonoBehaviour {

    AudioSource aud;

	// Use this for initialization
	void Awake () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (GameOverManager.gameOver)
        {
            aud.Stop();
        }
	}
}
