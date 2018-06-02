using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour {
	public int points;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	void OnTriggerEnter2D (Collider2D col){
			//if(collider.tag =="Player"){
				//animation.AddPoints(points);
        //if (col.gameObject.CompareTag("gameover2"))
        //{
            
            //Application.LoadLevel("1");
            //print("assas");
        //};
		gameObject.SetActive(false);
		col.GetComponent<Playerninja>().counter++;
	}
       
	}
		
		
