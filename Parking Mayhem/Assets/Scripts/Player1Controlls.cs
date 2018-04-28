using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controlls : MonoBehaviour
{


    public GameObject projectile1;

    new Rigidbody2D rigidbody2D;

    public Multlvlhealth1 health;

    public float power = 3;
    public float maxspeed = 5;
    public float turnpower = 2;
    public float friction = 3;
    public Vector2 curspeed;

    public Transform target;
    public float fireForce;

    public float timeBetweenShots = 0.3333f;
    private float timestamp;

    public Vector3 StartPosition;
    public Quaternion RotatePosition;

    public GameObject LittleExplositionAnimate;


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

        if (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(transform.up * power);
            rigidbody2D.drag = friction;

        }
        if (Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.AddForce(-(transform.up) * (power / 2));
            rigidbody2D.drag = friction;

        }
        if (Input.GetAxis("Horizontal") == -1 || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetAxis("Horizontal") == 1 || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -turnpower);
        }

        if (Time.time >= timestamp && (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.P)))
        {
            Attack();
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
        timestamp = Time.time + timeBetweenShots;
        Vector3 targetDir1 = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir1.y, targetDir1.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);


        GameObject newFire1 = Instantiate(projectile1, transform.position, transform.rotation);
        newFire1.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, fireForce));




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

    }
    public void Reset()
    {

        transform.position = StartPosition;
        transform.rotation = RotatePosition;

    }
    private void LittleExplosion()
    {
        GameObject Smallexplode = (GameObject)Instantiate(LittleExplositionAnimate);
        Smallexplode.transform.position = transform.position;
    }
}
