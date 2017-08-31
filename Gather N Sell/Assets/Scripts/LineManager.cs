using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour {
	public GameObject customer;
	public GameObject[] line;
	private int customersLeft;
	public Player Player;
	public UIManager costs;
	public GameObject AudioManager;

	// Use this for initialization
	void Start () {
		this.customersLeft = GameManager.customersLeft;
		this.line = new GameObject[customersLeft];
		Debug.Log (customersLeft);
		for (int i = 0; i < customersLeft; i++) {
			line [i] = Instantiate (customer,
									new Vector3 (this.transform.position.x - (i * 1),
												 this.transform.position.y),
									this.transform.rotation);
		}
		//Makes first customer state their request
		line [0].GetComponent<Customer> ().Request ();
	}

	//Deals with variables once a customer has been served
	public void CustomerServed(){
		Destroy (line [0]);
		//Shifts all customers down the line after the lead customer is served
		for (int i = 0; i < customersLeft; i++) {
			//If on the last customer on the list, sets it to null
			if (i == customersLeft - 1) {
				line [i] = null;
				this.customersLeft--;

			//Otherwise, move the customer up one place in the line
			} else if (line [i] != null) {
				line [i] = line [i + 1];
				line [i].transform.position = new Vector3 (line [i].transform.position.x + 1,
															line [i].transform.position.y,
															line [i].transform.position.z);
			}
		}
		//Removes one from the remaining customer count
		GameManager.customersLeft--;

		//Has the next customer at the head state their request
		if(GameManager.customersLeft > 0)
			line [0].GetComponent<Customer> ().Request ();
	}

	public void TransAccept(){
		int amount = line [0].GetComponent<Customer> ().amount;
		int max = line [0].GetComponent<Customer> ().maxVal;
		switch (line [0].GetComponent<Customer> ().resource) {
		case "wood":
			if (Player.LumberSupply >= amount && costs.wCost <= max) {
				Player.LumberSupply -= amount;
				Player.MoneySupply += costs.wCost * amount;
				AudioManager.GetComponent<AudioManager> ().AcceptSale ();
			} else {
				AudioManager.GetComponent<AudioManager> ().DeclineSale ();
				Debug.Log ("The customer leaves in a rage, ranting about your lack of stock at a reasonable price...");
			}
			break;
		case "berries":
			if (Player.BerrySupply >= amount && costs.bCost <= max) {
				Player.BerrySupply -= amount;
				Player.MoneySupply += costs.bCost * amount;
				AudioManager.GetComponent<AudioManager> ().AcceptSale ();
			} else {	
				AudioManager.GetComponent<AudioManager> ().DeclineSale ();
				Debug.Log ("The customer leaves in a rage, ranting about your lack of stock at a reasonable price...");
			}
			break;
		default:
			if (Player.CoalSupply >= amount && costs.cCost <= max) {
				Player.CoalSupply -= amount;
				Player.MoneySupply += costs.cCost * amount;
				AudioManager.GetComponent<AudioManager> ().AcceptSale ();
			} else {
				AudioManager.GetComponent<AudioManager> ().DeclineSale ();
				Debug.Log ("The customer leaves in a rage, ranting about your lack of stock at a reasonable price...");
			}
			break;
		}
		CustomerServed ();
	}

	public void TransDecline(){
		Debug.Log ("Declined");
		AudioManager.GetComponent<AudioManager> ().DeclineSale ();
		CustomerServed ();
	}

	// Update is called once per frame
	void Update () {
//		//If the space key is pressed, then a customer is served
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			Debug.Log ("Key Pressed!");
//			CustomerServed ();
//		}
	}
}
