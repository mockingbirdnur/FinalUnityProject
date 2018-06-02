using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class followme : MonoBehaviour {
	NavMeshAgent nav;
	public GameObject mainPlayer;
	// Use this for initialization
	void Start () {
		nav = this.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nav.SetDestination(mainPlayer.transform.position);
	}
}
