using UnityEngine;
using System.Collections;

public class PlantEatten : MonoBehaviour {

    Animator anim;
    AudioSource aud;

    public int scoreValue;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            anim.enabled = true;
            aud.Play();
            Destroy(gameObject, 2f);
            ScoreManager.score -= scoreValue;
        }
    }
}
