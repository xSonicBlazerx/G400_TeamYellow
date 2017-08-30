using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int LumberSupply = 0;
	public int BerrySupply = 0;
	public int CoalSupply = 0;
	public int MoneySupply = 0;
	public int TimeRemaining;
	public float hForce = 100f;
	public float maxSpeed = 3f;

	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		//Debug.Log (h);
		rb2d.velocity = new Vector2 (h * maxSpeed, rb2d.velocity.y);

	}
}
