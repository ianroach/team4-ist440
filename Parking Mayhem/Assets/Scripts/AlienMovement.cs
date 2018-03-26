using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour {

	public GameObject ExplosionAnimate;
	public GameObject target;
	public float moveSpeed;
	public float rotationSpeed;

	public Transform SwitchCheck;
	public float SwithRadius;
	public LayerMask WhatIsSwitch;
	private bool hittingSwitch;
	public bool stopMove;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		hittingSwitch = Physics2D.OverlapCircle (SwitchCheck.position, SwithRadius, WhatIsSwitch);
		if (hittingSwitch)
			stopMove = !stopMove;
		if (stopMove) {
			transform.position = new Vector3 (0f, 0f, 0f);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed * Time.deltaTime);
			Vector3 vectorToTarget = target.transform.position - transform.position;
			float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
			Quaternion qt = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, qt, Time.deltaTime * rotationSpeed);
		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Car")
		{
			Destroy(collision.gameObject);
			playExplosion ();
		
		}

	}

	private void playExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate(ExplosionAnimate);
		explosion.transform.position = transform.position;
	}
}