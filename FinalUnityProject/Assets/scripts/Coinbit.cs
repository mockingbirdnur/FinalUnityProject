using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinbit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		print (Time.realtimeSinceStartup);
	}
	void OnTriggerEnter(Collider col){
//		print ("test");
//		Time.timeScale = 0;
		if (col.gameObject.tag == "Coin") {
		}
	

	}
}
