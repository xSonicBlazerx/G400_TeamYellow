using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherManager : MonoBehaviour {
	public float gatherTimer = 5f;
	bool nearResource = false;

	public AudioManager audioManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (nearResource == true) {
			if (Input.GetButton ("Gather")) {
				gatherTimer -= Time.deltaTime;
				Debug.Log (gatherTimer);
			}
		}
		if (gatherTimer < 0) {
			//Destroy (gameObject);
			GameObject player = GameObject.Find ("Player");
			var playerScript = player.GetComponent<Player>();
			if (this.gameObject.CompareTag ("Tree")) {
				Debug.Log (playerScript.LumberSupply);
				playerScript.LumberSupply++;
				Debug.Log (playerScript.LumberSupply);
				//audioManager.WoodCollectSuccess ();
			} else if (this.gameObject.CompareTag ("Berry")) {
				Debug.Log (playerScript.BerrySupply);
				playerScript.BerrySupply++;
				Debug.Log (playerScript.BerrySupply);
				//audioManager.BerriesCollectSuccess ();
			} else if (this.gameObject.CompareTag ("Coal")) {
				Debug.Log (playerScript.CoalSupply);
				playerScript.CoalSupply++;
				Debug.Log (playerScript.CoalSupply);
				//audioManager.CoalCollectSuccess ();
			}
			Destroy (gameObject);
			Debug.Log ("Item Gathered!");
			nearResource = false;
		}
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("It's the player!");
			nearResource = true;
		}
	}
	void OnTriggerExit2D (Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Player Left");
			nearResource = false;
		}
	}
}
