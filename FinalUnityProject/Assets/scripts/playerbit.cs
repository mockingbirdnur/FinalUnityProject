using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerbit : MonoBehaviour {
	public Animator anim;
	private float inputH;
	private float inputV;
	public Rigidbody rbody;
	private bool run;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.A)) {
			anim.Play ("WAIT01", -1, 0f);
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			anim.Play ("WAIT02", -1, 0f);
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			anim.Play ("WAIT03", -1, 0f);
		}
		if (Input.GetKeyDown (KeyCode.F)) {
			anim.Play ("WAIT04", -1, 0f);
		}
		if (Input.GetMouseButtonDown(0)) {
			int n = Random.Range (0, 2);
			if (n == 0) {
				anim.Play ("DAMAGED00", -1, 0f);
			} else {
				anim.Play ("DAMAGED01", -1, 0f);
			}


	//}
		if (Input.GetKey (KeyCode.Q)) {
			run = true;
		} else {
			run = false;
		}

//		if (Input.GetKey (KeyCode.Space)) {
//			anim.SetBool ("jump", true);
//
//		} else {
//			anim.SetBool ("jump", false);
//		}



			
		inputH = Input.GetAxis("Horizontal");
		inputV = Input.GetAxis("Vertical");
		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);
		anim.SetBool ("run", run);
		float moveX = inputH * 50f * Time.deltaTime;
		float moveZ = inputV * 50f * Time.deltaTime;

		if (moveZ <= 0f) {
			moveX = 0f;
		} else if (run) {
			moveX*=3f;
			moveZ*=3f;
		}

			
		rbody.velocity = new Vector3 (moveX,0f,moveZ);
	}

}
}
