﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour {

	private Rigidbody2D myRigidBody;
	private Animator myAnimator;
	private float jumpForce;
	public bool isAlive;


	// Use this for initialization
	void Start () {

		isAlive = true;

		myRigidBody = gameObject.GetComponent<Rigidbody2D> ();
		myAnimator = gameObject.GetComponent<Animator> ();

		jumpForce = 10f;
		myRigidBody.gravityScale = 5f;



	}
	
	// Update is called once per frame
	void Update () {

		if (isAlive) {
			if (Input.GetMouseButton (0)) {

				Flap ();
			}

		}
	}

	void Flap(){

		myRigidBody.velocity = new Vector2 (0, jumpForce);

		myAnimator.SetTrigger ("Flap");

		CheckIfDragonVisibleOnScreen ();
	}

	void onCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "Obstacles") {
			isAlive = false;
			Time.timeScale = 0f;
		}

		}


	void CheckIfDragonVisibleOnScreen(){
		if( Mathf.Abs (gameObject.transform.position.y) > 5.3f )
		{
			isAlive = false;
			Time.timeScale = 0f;
		}

	}

}

