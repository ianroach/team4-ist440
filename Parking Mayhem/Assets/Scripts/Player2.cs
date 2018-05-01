using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

	public Vector3 StartPosition;
	public Quaternion RotatePosition;

	public GameObject projectile1;
	public GameObject projectile2;
	public GameObject projectile3;
	public GameObject projectile4;


	public AudioSource pickup1;
	public AudioSource pickup2;
	public AudioSource pickup3;


	public AudioSource shoot;
	public AudioSource shoot2;
	public AudioSource shoot3;
	public AudioSource shoot4;


	public int typeshot = 1;

    public Multlvlhealth2 health;
    public GameObject LittleExplositionAnimate;
    new Rigidbody2D rigidbody2D;

	public Transform target;

	public float timeBetweenShots = 0.3333f;
	public float timeBetweenShots2 = 0.50f;
	public float timeBetweenShots3 = 5f;
	public float timeBetweenShots4 = 5f;

	public float fireForce;
	public float fireForce2;
	public float fireForce3;
	public float fireForce4;

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

		if (Input.GetKey(KeyCode.Joystick1Button0) || Input.GetKey(KeyCode.UpArrow))
	{

		rigidbody2D.AddForce(transform.up * power);
		rigidbody2D.drag = friction;


	}
		if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.DownArrow))
	{
		rigidbody2D.AddForce(-(transform.up) * (power / 2));
		rigidbody2D.drag = friction;

	}
		if (Input.GetAxis("HorizontalMP1") == -1 || Input.GetKey(KeyCode.LeftArrow))
	{
		transform.Rotate(Vector3.forward * turnpower);
	}
		if (Input.GetAxis("HorizontalMP1") == 1 || Input.GetKey(KeyCode.RightArrow))
	{
		transform.Rotate(Vector3.forward * -turnpower);
	}
		if (Time.time >= timestamp && (Input.GetKey(KeyCode.Joystick1Button4) || Input.GetKey(KeyCode.RightShift)))
	{
			switch (typeshot){
			case 1:
				Attack ();
				break;
			case 2:
			default:

				SpecialAttack ();
				break;
			case 3:
				RapidAttack ();

				break;

			case 4:
				MegaAttack ();
				break;
			}

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
		shoot.Play ();
		timestamp = Time.time + timeBetweenShots;
		Vector3 targetDir2 = target.position - transform.position;
		float angle = Mathf.Atan2(targetDir2.y, targetDir2.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);


		GameObject newFire2 = Instantiate (projectile1, transform.position, transform.rotation);
		newFire2.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0f, fireForce));

	}

	void SpecialAttack()
	{
		shoot2.Play ();
		timestamp = Time.time + timeBetweenShots2;


		Vector3 targetDir1 = target.position - transform.position;
		float angle = Mathf.Atan2 (targetDir1.y, targetDir1.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90 * Time.deltaTime);



		GameObject newFire2 = Instantiate (projectile2, transform.position, transform.rotation);
		newFire2.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0f, fireForce2));
	}

	void MegaAttack()
	{
		shoot3.Play ();
		timestamp = Time.time + timeBetweenShots3;


		Vector3 targetDir1 = target.position - transform.position;
		float angle = Mathf.Atan2 (targetDir1.y, targetDir1.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 270);



		GameObject newFire2 = Instantiate (projectile3, transform.position, transform.rotation);
		newFire2.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0f, fireForce3));
	}
	void RapidAttack()
	{
		shoot4.Play ();
		timestamp = Time.time + timeBetweenShots4;


		Vector3 targetDir1 = target.position - transform.position;
		float angle = Mathf.Atan2 (targetDir1.y, targetDir1.x) * Mathf.Rad2Deg - 90f;
		Quaternion q = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 90 * Time.deltaTime);



		GameObject newFire2 = Instantiate (projectile4, transform.position, transform.rotation);
		newFire2.GetComponent<Rigidbody2D> ().AddRelativeForce (new Vector2 (0f, fireForce4));
	}	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        health = GetComponent<Multlvlhealth2>();

		if (collision.tag == "Player") {
			LittleExplosion ();
			health.DealDamage (5);
			Destroy (collision.gameObject);

		} 
		if (collision.tag == "ExtraDamage") 
		{
			LittleExplosion ();
			health.DealDamage (20);
			Destroy (collision.gameObject);
		}
		if (collision.tag == "DestroyDamage")
		{
			
			health.DealDamage (100);
			Destroy (collision.gameObject);
		}
		if (collision.tag == "RapidDamage") 
		{
			LittleExplosion ();
			health.DealDamage (5);
			Destroy (collision.gameObject);
		}
		if (collision.tag == "blaster")
		{
			pickup1.Play ();
			typeshot = 2;
			Destroy (collision.gameObject);
		}
		if (collision.tag == "beam")
		{
			pickup2.Play ();
			typeshot = 4;
			Destroy (collision.gameObject);
		}
		if (collision.tag == "rapid") 
		{
			pickup3.Play ();
			typeshot = 3;
			Destroy (collision.gameObject);
		}

    }
    public void Reset()
    {
		typeshot = 1;
        transform.position = StartPosition;
        transform.rotation = RotatePosition;
	
    }
    private void LittleExplosion()
    {
        GameObject Smallexplode = (GameObject)Instantiate(LittleExplositionAnimate);
        Smallexplode.transform.position = transform.position;
    }
}
