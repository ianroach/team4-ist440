using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPowerUp : MonoBehaviour {

	public GameObject ExplosionAnimate;
	public float speed = 5;
	public float rotatingSpeed = 200;
	public GameObject target;

	Rigidbody2D rb;

	void Start ()
	{
		target = GameObject.FindGameObjectWithTag ("Alien");

		rb = GetComponent<Rigidbody2D> ();

	}

	void FixedUpdate()
	{
		//Allows the object to move to the other objects position
		Vector2 point2Target = (Vector2)transform.position - (Vector2)target.transform.position;
		point2Target.Normalize ();

		float value = Vector3.Cross (point2Target, transform.right).z;

		rb.angularVelocity = rotatingSpeed * value;
		rb.velocity = transform.right * speed;
	}
		void OnTriggerEnter2D(Collider2D other)
		{
		if (other.tag == "Alien")
		{
			playExplosion ();
			Destroy (other.gameObject);
			Destroy (this.gameObject);

		}
	}
	private void playExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate(ExplosionAnimate);
		explosion.transform.position = transform.position;

	}
}
