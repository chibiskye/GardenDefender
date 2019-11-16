using UnityEngine;
using System.Collections;

public class SensorDoors : MonoBehaviour {

    Animation anim;
    AudioSource aud;

	public AnimationClip clipOpen; // the open animation
	public AnimationClip clipClose; // the close animation

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animation>();
        aud = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
	
	// open the gates
	void OnTriggerEnter (Collider defender) {
	   if (defender.gameObject.CompareTag("Player")) {
	      anim.Play(clipOpen.name);
		  aud.Play(); // play the clip loaded in the audio component	
	   }
	}

	// close the gates
	void OnTriggerExit (Collider defender) {
	   if (defender.gameObject.CompareTag("Player")) {
	      anim.Play(clipClose.name);
		  aud.Play(); // play the clip loaded in the audio component
	   }
	}

}
