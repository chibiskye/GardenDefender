using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    Vector3 offset;

    public Transform target;
    public float smoothing;

	// Use this for initialization
	void Start () {
        offset = transform.position - target.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetCamPos = target.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, Time.deltaTime * smoothing);
	}
}
