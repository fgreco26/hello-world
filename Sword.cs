using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {

	private float swingDuration = 0.5f;
	private float swingSpeed = 0.22f;

	private float swingTimer = 0f;
	private bool swinging = false;
	private Vector3 startRot;

	void Start () {
		startRot = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) && !swinging) {
			swinging = true;
		}	

		if (swinging) {
			swingTimer += Time.deltaTime;

			if (swingTimer < (swingDuration / 2)) {
				transform.eulerAngles = Vector3.Lerp(startRot, new Vector3(0, 0, 1), swingSpeed);
			}

			if (swingTimer > (swingDuration / 2)) {
				transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, startRot, swingSpeed);
			}

			if (swingTimer > swingDuration) {
				swingTimer = 0f;
				swinging = false;
			}
		}
	}
}