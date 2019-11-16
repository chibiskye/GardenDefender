using UnityEngine;
using System.Collections;

public class ScarecrowController : MonoBehaviour {

    Animator anim;
    Rigidbody rb;

    public float speed;
    public float delayTime;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}

    void Start()
    {
        StartCoroutine(WaitAndRun(delayTime));
    }

    IEnumerator WaitAndRun (float delay)
    {
        while (GameOverManager.gameOver == false)
        {
            yield return new WaitForSeconds(delay * Time.deltaTime);

            float v = Random.Range(-1f, 1f);
            float h = Random.Range(-1f, 1f);

            anim.SetFloat("InputV", v);

            Quaternion direction = Quaternion.identity;
            direction.SetLookRotation(new Vector3(h, 0f, 0f));

            if (h != 0)
            {
                rb.rotation = Quaternion.Lerp(transform.rotation, direction, Time.deltaTime * speed);
            }

            if (GameOverManager.gameOver)
            {
                rb.freezeRotation = true;
                anim.SetFloat("InputV", 0f);
                anim.SetTrigger("GameOver");
            }
        }
    }
}
