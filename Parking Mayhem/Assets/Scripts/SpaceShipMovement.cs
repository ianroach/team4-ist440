using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipMovement : MonoBehaviour {

    public float speed;             //Floating point variable to store the player's movement speed.
    public float turnpower = 2;
    public float timeBetweenShots = 0.3333f;
    private float timestamp;
    public GameObject Bullet;
    public GameObject BulletPosition_1;
    public GameObject BulletPosition_2;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.


    // Use this for initialization
    void Start () {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();

    }
	
	//FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis ("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis ("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce (movement * speed);

        if (Time.time >= timestamp && (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.UpArrow)))
        {
            GameObject bullet_1 = (GameObject)Instantiate(Bullet);
            bullet_1.transform.position = BulletPosition_1.transform.position;

            GameObject bullet_2 = (GameObject)Instantiate(Bullet);
            bullet_2.transform.position = BulletPosition_2.transform.position;
            timestamp = Time.time + timeBetweenShots;
        }
    }
}
