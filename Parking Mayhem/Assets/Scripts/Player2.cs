using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

	public Vector3 StartPosition;
	public Quaternion RotatePosition;
	public GameObject projectile2;


	new Rigidbody2D rigidbody2D;

	public Transform target;
	public float fireForce;

	public float timeBetweenShots = 0.3333f;
	private float timestamp;

	public float power = 3;
	public float maxspeed = 5;
	public float turnpower = 2;
	public float friction = 3;
	public Vector2 curspeed;
	// Use this for initialization
	void Start () {
		
		rigidbody2D = GetComponent<Rigidbody2D>();
		StartPosition = transform.position;
		RotatePosition = transform.rotation;

	}

	void FixedUpdate () {

	curspeed = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);

	if (curspeed.magnitude > maxspeed)
	{
		curspeed = curspeed.normalized;
		curspeed *= maxspeed;
	}

		if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.W))
	{

		rigidbody2D.AddForce(transform.up * power);
		rigidbody2D.drag = friction;


	}
	if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.S))
	{
		rigidbody2D.AddForce(-(transform.up) * (power / 2));
		rigidbody2D.drag = friction;

	}
	if (Input.GetAxis("Horizontal") == -1 || Input.GetKey(KeyCode.A))
	{
		transform.Rotate(Vector3.forward * turnpower);
	}
	if (Input.GetAxis("Horizontal") == 1 || Input.GetKey(KeyCode.D))
	{
		transform.Rotate(Vector3.forward * -turnpower);
	}
		if (Time.time >= timestamp && (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.Space)))
	{
		Attack ();
	}

	noGas();

}

void noGas()
{
	bool gas;
	if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
	{
		gas = true;
	}
	else
	{
		gas = false;
	}

	if (!gas)
	{
		rigidbody2D.drag = friction * 2;
	}
}

	void Attack ()
	{
		timestamp = Time.time + timeBetweenShots;
		Vector3 targetDir2 = target.position - transform.position;
		float angle = Mathf.Atan2(targetDir2.y, targetDir2.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);


		GameObject newFire2 = Instantiate (projectile2, transform.position, transform.rotation);
		newFire2.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0f, fireForce));






	}
}
