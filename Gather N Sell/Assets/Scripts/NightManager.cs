using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightManager : MonoBehaviour {

	public GameManager gameManager;

	public GameObject fading;
	public GameObject night;

	bool atPause = false;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (atPause && Input.GetKeyDown (KeyCode.Space))
			gameManager.ManagerDay ();
	}

	public void CompleteSceneNight(){
		fading.SetActive (true);
		night.SetActive (true);
		Player.LumberSupply.ToString ();
		Player.BerrySupply.ToString ();
		Player.CoalSupply.ToString ();
		Player.LumberSold.ToString ();
		Player.BerrySold.ToString ();
		Player.CoalSold.ToString ();
		atPause = true;
	}
		
}
