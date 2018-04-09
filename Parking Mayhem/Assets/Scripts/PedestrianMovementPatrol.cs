using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovementPatrol : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;

	public Transform SwitchCheck;
	public float SwithRadius;
	public LayerMask WhatIsSwitch;
	private bool hittingSwitch;

	void Start () {
	
	}

	void Update () {
		hittingSwitch = Physics2D.OverlapCircle (SwitchCheck.position, SwithRadius, WhatIsSwitch);
		if (hittingSwitch)
			moveRight = !moveRight;
		if (moveRight) {
			
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 270f));
			GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		} else {
			
			transform.rotation = Quaternion.Euler (new Vector3 (0, 0, 90f));
			GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed,  GetComponent<Rigidbody2D>().velocity.y);
	}
}
}