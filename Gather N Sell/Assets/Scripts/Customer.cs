using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour {
	public string resource = "";
	public int amount = 0;


	void Awake () {
		
		// Initializes the resource type and amount for the given customer
		this.amount = Random.Range (1, 4); // Amount of the given resource
		int resourceNum = Random.Range (1, 4); // Type of the resource

		/**
		 * Assigns the resource type according to the randomly selected number
		 * above, resourceNum
		 */
		switch (resourceNum)
		{
		// Resource 1 = wood
		case 1:
			//Debug.Log ("wood");
			resource = "wood";
			break;
		// Resource 2 = berries
		case 2:
			//Debug.Log ("berries");
			this.resource = "berries";
			break;
		// Resource 3 = coal
		default:
			//Debug.Log ("coal");
			this.resource = "coal";
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Request(){
		Debug.Log ("resource: " + this.resource + ", amount: " + this.amount);
	}
}
