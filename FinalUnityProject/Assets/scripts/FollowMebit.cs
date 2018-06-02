using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FollowMebit : MonoBehaviour {
	NavMeshAgent nav;
	public GameObject mainPlayer;

	public Animator anim;

	void Start () {
		nav = this.GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		nav.SetDestination(mainPlayer.transform.position);
		//GetComponent<GUIText>().text = Time.time.ToString("0.0");

	}
//	void OnTriggerEnter(Collider col){
//		if (col.gameObject.tag == "Player") {
//			Time.timeScale = 0;
//		}
//
//	}
	void OnGUI(){

//		GUILayout.Label(Application.realTimeSinceStartup.ToString());

	}

}
