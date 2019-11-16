using UnityEngine;
using System.Collections;

public class GnomeController : MonoBehaviour {

    Vector3 movement;
    Animator anim;
    Rigidbody rb;
    AudioSource aud;
    int floorMask;
    float camRayLength = 50f;

    public float speed;
    public AudioClip gnomeIdle;
    public AudioClip gnomeMove;

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        aud = GetComponent<AudioSource>();
        floorMask = LayerMask.GetMask("Floor");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (GameOverManager.gameOver)
        {
            aud.enabled = false;
            anim.enabled = false;
            return;
        }

        float h = Input.GetAxisRaw("Horizontal1");
        float v = Input.GetAxisRaw("Vertical1");

        Move(h, v);
        Turn();
        Animate(h, v);
        SoundEffects(h, v);
	}

    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Turn ()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rb.MoveRotation(newRotation);
        }
    }

    void Animate (float h, float v)
    {
        bool moving = h != 0 || v != 0;
        anim.SetBool("IsWalking", moving);
    }

    void SoundEffects (float h, float v)
    {
        if (h != 0 || v != 0)
        {
            aud.clip = gnomeMove;
            aud.Play();
        }
        else
        {
            aud.clip = gnomeIdle;
            aud.Play();
        }
    }
}
