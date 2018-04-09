using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianMovement : MonoBehaviour {

	public Rigidbody2D rb;
	public float minSpeed = 8f;
	public float maxSpeed = 12f;

	float speed = 1f;

	void Start()
	{
		speed = Random.Range (minSpeed, maxSpeed);
	}

	void FixedUpdate () {

		Vector2 forward = new Vector2 (transform.up.x, transform.up.y);
		rb.MovePosition (rb.position + forward * Time.fixedDeltaTime * speed);
	}
}

