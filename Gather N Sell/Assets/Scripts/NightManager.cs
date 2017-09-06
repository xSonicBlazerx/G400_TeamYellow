using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightManager : MonoBehaviour {

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void CompleteSceneNight(){
		Player.LumberSupply.ToString ();
		Player.BerrySupply.ToString ();
		Player.CoalSupply.ToString ();
		Player.LumberSold.ToString ();
		Player.BerrySold.ToString ();
		Player.CoalSold.ToString ();
		while (true) {
			if (Input.GetKeyDown (KeyCode.Space))
				break;
		}
		gameManager.ManagerNight ();
	}
		
}
