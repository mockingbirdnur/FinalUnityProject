using System.Collections;
using UnityEngine;

public class walktodestination : MonoBehaviour {

	public Transform cube;

	// Use this for initialization
	void Start () {

		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
		agent.destination = cube.position;
		
	}
}
