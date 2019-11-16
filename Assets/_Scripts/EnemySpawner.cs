using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    Animator anim;

    public GameObject enemy;
    public float spawnTime;
    public Transform[] spawnPoints;

	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
	}
	
	void Spawn () {
        if (GameOverManager.gameOver)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Quaternion randRotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);

        GameObject obj = (GameObject) Instantiate(enemy, spawnPoints[spawnPointIndex].position, randRotation);

        int rand = Random.Range(0, 2);
        Action(obj, rand);
	}

    void Action (GameObject enemyIns, int spd)
    {
        anim = enemyIns.GetComponent<Animator>();
        if (anim == null)
        {
            return;
        }

        if (spd == 0)
        {
            anim.speed = Random.Range(3, 5);
        }
        else if (spd == 1)
        {
            anim.enabled = false;
        }
    }
}
