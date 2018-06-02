using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class death : MonoBehaviour {

	// Use this for initialization

	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		print ("finish" + col.name);
		Time.timeScale = 0;
	}
}