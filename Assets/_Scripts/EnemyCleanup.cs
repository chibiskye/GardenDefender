using UnityEngine;
using System.Collections;

public class EnemyCleanup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (GameOverManager.gameOver)
        {
            Destroy(gameObject);
            return;
        }

        if (gameObject)
        {
            Destroy(gameObject, 20f);
        }
	}
}
