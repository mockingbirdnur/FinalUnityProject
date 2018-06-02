 using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class sourcecode : MonoBehaviour {
	public GameObject player;
	public float speed = 0.2f;
	public int coin=0;
	// Use this for initialization
	void Start () {

	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "gameover") {
			SceneManager.LoadScene (4);
		}
		if (col.gameObject.tag == "Coin") {
			SceneManager.LoadScene (3);
		}
	}



	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.UpArrow)) {
			player.transform.position = new Vector3 (
				player.transform.position.x,
				player.transform.position.y,  
				player.transform.position.z+speed);
		}
		if (Input.GetKey (KeyCode.DownArrow)) {
			player.transform.position = new Vector3 (
				player.transform.position.x,
				player.transform.position.y,  
				player.transform.position.z-speed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			player.transform.position = new Vector3 (
				player.transform.position.x-speed,
				player.transform.position.y,  
				player.transform.position.z);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			player.transform.position = new Vector3 (
				player.transform.position.x+speed,
				player.transform.position.y,  
				player.transform.position.z);
		}
	}

}