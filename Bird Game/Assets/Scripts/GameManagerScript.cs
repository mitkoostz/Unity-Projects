﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour {

	public int myScore;
	public Text myScoreGUI;

	public Transform bottomObstacle, topObstacle;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		myScore = 0;

		myScoreGUI = GameObject.Find ("Text")
			.GetComponent<Text> ();

		InvokeRepeating ("ObstacleSpawner", .5f, 1.5f);

		audioSource = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GmAddScore(){
		this.myScore++;

		myScoreGUI.text = myScore.ToString ();

		audioSource.Play ();

	}

	void ObstacleSpawner(){
		int rand = Random.Range (0, 2);

		float
		topObstacleMinY = 2f,
		topObstacleMaxY = 6f,
		bottomObstacleMinY = -6f,
		bottomObstacleMaxY = -2;

		switch (rand) {
		case 0:

			Instantiate (
				bottomObstacle,
				new Vector2 (
					9f,
					Random.Range (bottomObstacleMinY, bottomObstacleMaxY)
				),
				Quaternion.identity);
			break;

		case 1:
			Instantiate (
				bottomObstacle,
				new Vector2 (
					9f,
					Random.Range (topObstacleMinY, topObstacleMaxY)
				),
				Quaternion.identity);
			break;

		}

	}

}
