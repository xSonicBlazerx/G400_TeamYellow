using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	//Day Variables
	public static int customersLeft = 15;
	float dayTimer = 180;
	float timeLeft;


	// Use this for initialization
	void Start () {
		this.timeLeft = dayTimer;
	}
	
	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;
		GameEnd ();
	}

	/**
	 * Checks whether the player is either out of time or customers.
	 * If so, then the day is over
	 * (NOTE: Still need to set up transition between day and night)
	 */
	void GameEnd(){
		if (customersLeft == 0 || this.timeLeft <= 0) {
			Debug.Log ("Game Over!!!");
			UnityEditor.EditorApplication.isPlaying = false;
		}
	}
}
