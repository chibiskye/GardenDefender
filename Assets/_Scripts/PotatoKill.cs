using UnityEngine;
using System.Collections;

public class PotatoKill : MonoBehaviour {

    public GameObject explosion;
    public float explosionTime;
    public int enemyValue;

	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 2f);
	}

    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            GameObject exploIns = (GameObject) Instantiate(explosion, other.transform.position, other.transform.rotation);
            Destroy(exploIns, explosionTime);

            ScoreManager.score += enemyValue;
        }
    }
}
