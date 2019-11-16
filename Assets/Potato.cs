using UnityEngine;
using System.Collections;

public class Potato : MonoBehaviour {

    public GameObject projectile;
    public float speed = 20f;

	void Start () {
	}
	
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            ShootProjectile();
        }
	}

    void ShootProjectile()
    {
        GameObject potato = (GameObject)Instantiate(projectile, transform.position, transform.rotation);
        //potato.GetComponent<Rigidbody>().transform = transform.TransformDirection(new Vector3(0, 0, speed));
        potato.GetComponent<Rigidbody>().transform.position = transform.TransformDirection(new Vector3(0, 0, speed));

    }


}
