using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {
	public Animator anim;
	private float inputH;
	private float inputV;
	public Rigidbody rbody;
    public int coins;
    public GameObject objToDestroy;
    void OnGUI()
    {
        // This line feeds "This is the tooltip" into GUI.tooltip
        GUI.Button(new Rect(10, 10, 130, 30), new GUIContent("You collected : " + coins));

    }
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown ("1")) {
			anim.Play ("WAIT01", -1, 0f);
		}
		if (Input.GetKeyDown ("2")) {
			anim.Play ("WAIT02", -1, 0f);
		}
		if (Input.GetKeyDown ("3")) {
			anim.Play ("WAIT03", -1, 0f);
		}
		if (Input.GetKeyDown ("4")) {
			anim.Play ("WAIT04", -1, 0f);
		}
		if(Input.GetMouseButtonDown(0))
		{
			anim.Play ("DAMAGED00", -1, 0f);
	}
		inputH = Input.GetAxis ("Horizontal");
		inputV = Input.GetAxis ("Vertical");
		anim.SetFloat ("inputH", inputH);
		anim.SetFloat ("inputV", inputV);

		float moveX = inputH * 50f * Time.deltaTime;
		float moveZ = inputV * 100f * Time.deltaTime;

		if (moveZ <= 0f) {
			moveX = 0f;
		}
		rbody.velocity = new Vector3 (moveX, 0f, moveZ);
}
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            coins++;
        }
        if (coins == 11)
        {
            Destroy(objToDestroy);
        }
//		if (coins != 11)
//		{
//			SceneManager.LoadScene ("gameover");
//		}
        if (other.gameObject.CompareTag("opendoor"))
        {
			SceneManager.LoadScene (2);
        }
        if (other.gameObject.CompareTag("gameover2"))
        {
			SceneManager.LoadScene (4);
        }
    }
    public void nextLevel(){

		SceneManager.LoadScene (3);
    }

}