using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerninja : MonoBehaviour {

	private Rigidbody2D myRigidBody ;

	[SerializeField]
	private float movementSpeed;
	private bool facingRight;
	private Animator myAnimator;
	private bool slide;
	private bool attack;
	[SerializeField]
	private Transform[] groundPonits;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private LayerMask whatIsGround;
	private bool isGrounded;
	private bool jump;
	[SerializeField]
	private float jumpforce;
	[SerializeField]
	private bool airControl;
	// Use this for initialization
	Animator anim;
	public float speed = 0.2f;
	public float timee = 1000f;
	public int counter; 
	void Start () {
		facingRight = true;
		myRigidBody = GetComponent<Rigidbody2D> ();
		myAnimator = GetComponent<Animator> ();
	}

	void Update(){
		timee -= 1f;
		if(timee==0)
		{
//			Time.timeScale = 0;
//			timee = 0;
			SceneManager.LoadScene ("gameover");
		}

		if (counter == 2) {
			SceneManager.LoadScene("WIN");
		}



	


		HandleInput();
	}
	// Update is called once per frame
	void FixedUpdate () {
		float horizontal = Input.GetAxis("Horizontal");
		isGrounded=IsGrounded ();
		Debug.Log (horizontal);
		HandleMovement (horizontal);
		Flip(horizontal);
		HandleAttacks ();
		ResetValues ();

	}
	private void HandleMovement(float horizontal)
	{
		if (!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag("Attack") && (isGrounded || airControl)){
			myRigidBody.velocity = new Vector2(horizontal * movementSpeed,myRigidBody.velocity.y);  //x=-1 y=0
		}
		if (isGrounded && jump) {
			isGrounded = false;
			myRigidBody.AddForce (new Vector2 (0, jumpforce));
			myAnimator.SetTrigger ("jump");
		}

		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) {
			myAnimator.SetBool ("slide", true);
		}
		else if (!this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Slide")) {
			myAnimator.SetBool ("slide", false);
		}

		myAnimator.SetFloat("speed",Mathf.Abs(horizontal));


	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
	private void HandleAttacks()
	{
//		if (attack && isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsTag ("Attack")) {
		if (attack){
			myAnimator.SetTrigger ("attack");
			myRigidBody.velocity = Vector2.zero;
		}
	}
	private void HandleInput(){
		if (Input.GetKeyDown (KeyCode.Space)) {
			jump = true;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			attack = true;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			slide = true;
		}

	}

	private void ResetValues(){
		attack = false;
		slide = false;
		jump = false;
	}
	private bool IsGrounded(){
		if (myRigidBody.velocity.y <= 0) {
			foreach (Transform point in groundPonits) {
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
				for (int i = 0; i < colliders.Length; i++) {
					if (colliders [i].gameObject != gameObject) {
						myAnimator.ResetTrigger ("jump");
						myAnimator.SetBool ("land", false);
						return true;
					}
				}
			}
		}
		return false;
	}
	private void OnGUI()
	{
		GUI.Label(new Rect(20, 20, 100, 20), "Time: " + timee);
	}

//	void OnTriggerEnter(Collider col){
//		if (col.gameObject.tag == "win") {
//			SceneManager.LoadScene ("WIN");
//		}





}
