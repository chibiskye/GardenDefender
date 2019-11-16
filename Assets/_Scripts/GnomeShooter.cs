using UnityEngine;
using System.Collections;

public class GnomeShooter : MonoBehaviour {

    AudioSource aud;
    float timer;

    public GameObject projectile;
    public float fireRate = 0.5f;
    public float range;

    // Use this for initialization
    void Awake () {
        aud = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameOverManager.gameOver)
        {
            aud.enabled = false;
            return;
        }

        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= fireRate)
        {
            Shoot();
            aud.Play();
            timer = 0f;
        }
	}

    void Shoot()
    {
        GameObject enemyIns = (GameObject)Instantiate(projectile, transform.position, transform.rotation);

        Rigidbody rb = enemyIns.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * range;
    }
}
