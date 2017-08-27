using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public int LumberSupply = 0;
	public int BerrySupply = 0;
	public int CoalSupply = 0;
	public int MoneySupply = 0;
	public int TimeRemaining;
	public float hForce = 200f;
	public float maxSpeed = 2f;

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

		if (h * rb2d.velocity.x < maxSpeed) {
			rb2d.AddForce (Vector2.right * h * hForce);
		}

		if (Mathf.Abs (rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
		}
	}
}
