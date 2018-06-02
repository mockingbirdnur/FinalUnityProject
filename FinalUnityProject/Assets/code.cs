using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class code : MonoBehaviour {

	Animator anim;
	public float speed = 0.2f;
    public float timee = 1000f;
    public int counter; 
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
        timee -= 1f;
        if(timee<0)
        {
            Time.timeScale = 0;
            timee = 0;
        }
		if (Input.GetKey(KeyCode.D)) {
			this.transform.position = new Vector3 (
				this.transform.position.x + speed,
				this.transform.position.y,
				this.transform.position.z);

			anim.SetBool ("fight", true);
		}
		this.transform.rotation = new Quaternion (
			this.transform.rotation.x,
			180,
			this.transform.rotation.x,
			1
		);


		if(Input.GetKeyUp(KeyCode.D)){

			anim.SetBool ("fight", false);

		}

		if (Input.GetKey (KeyCode.A)) {
			this.transform.position = new Vector3 (
				this.transform.position.x - speed,
				this.transform.position.y,
				this.transform.position.z
			);
			this.transform.rotation = new Quaternion (
				this.transform.rotation.x,
				180,
				this.transform.rotation.x,
				1
			);

		}
		if (Input.GetKeyUp (KeyCode.A)) {
			anim.SetBool ("fight", false);
		}
		if(Input.GetKeyDown(KeyCode.S)) {

			anim.SetBool ("fall", true);

		}
		if(Input.GetKeyUp(KeyCode.S)) {

			anim.SetBool ("fall", false);

		}
		if(Input.GetKeyDown(KeyCode.Space)) {

			anim.SetBool ("bang1", true);

		}
		if(Input.GetKeyUp(KeyCode.Space)) {

			anim.SetBool ("bang1", false);

		}
		if(Input.GetKeyDown(KeyCode.W)) {

			anim.SetBool ("bang2", true);

		}
		if(Input.GetKeyUp(KeyCode.W)) {

			anim.SetBool ("bang2", false);

		}

        if (counter == 6) {
            SceneManager.LoadScene("WIN");
        }

	}
	private void OnGUI()
	{
        GUI.Label(new Rect(20, 20, 100, 20), "Time: " + timee);
	}
   
}