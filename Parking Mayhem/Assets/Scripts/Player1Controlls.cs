using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controlls : MonoBehaviour
{


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

    new Rigidbody2D rigidbody2D;

    public Multlvlhealth1 health;

    public float power = 3;
    public float maxspeed = 5;
    public float turnpower = 2;
    public float friction = 3;
    public Vector2 curspeed;

	public Transform target;

    public float fireForce;
	public float fireForce2;
	public float fireForce3;
	public float fireForce4;

    public float timeBetweenShots = 0.3333f;
	public float timeBetweenShots2 = 0.50f;
	public float timeBetweenShots3 = 5f;
	public float timeBetweenShots4 = 5f;
    private float timestamp;

    public Vector3 StartPosition;
    public Quaternion RotatePosition;

    public GameObject LittleExplositionAnimate;

	public int typeshot = 1;

    // Use this for initialization
    void Start()
    {
        Multlvlhealth1 health1 = GetComponent<Multlvlhealth1>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
        RotatePosition = transform.rotation;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

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



    void Attack()
    {
		shoot.Play ();
        timestamp = Time.time + timeBetweenShots;
        Vector3 targetDir1 = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir1.y, targetDir1.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);


        GameObject newFire1 = Instantiate(projectile1, transform.position, transform.rotation);
        newFire1.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, fireForce));





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
        health = GetComponent<Multlvlhealth1>();

        if (collision.tag == "Player2")
        {
            LittleExplosion();
            health.DealDamage(5);
            Destroy(collision.gameObject);

        }

		if (collision.tag == "ExtraDamage2") 
		{
			LittleExplosion ();
			health.DealDamage (15);
			Destroy (collision.gameObject);
		}
		if (collision.tag == "DestroyDamage2")
		{
			health.DealDamage (50);
			Destroy (collision.gameObject);
		}
		if (collision.tag == "RapidDamage2") 
		{
			LittleExplosion ();
			health.DealDamage (10);
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
