using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpaceShipMovement : MonoBehaviour
{

    public float speed;             //Floating point variable to store the player's movement speed.
    public float turnpower = 2;
    public float timeBetweenShots = 0.3333f;
    private float timestamp;
    public GameObject Bullet;
    public GameObject BulletPosition_1;
    public GameObject BulletPosition_2;
    public GameObject ExplosionAnimate;
    public Vector3 StartPosition;
    private bool invincible = false;
    public Quaternion RotatePosition;
    private ScoreManager scores;
    public AudioSource coinSoundEffect;
    public AudioSource Pickupsound;

    public Text CoinPlus;

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    new Rigidbody2D rigidbody2D;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-2050.0f, -369f, 0.0f);
        scores = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

        rigidbody2D = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
        RotatePosition = transform.rotation;

        CoinPlus.text = "";
        scores = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        if (Time.time >= timestamp && (Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.UpArrow)))
        {
            GameObject bullet_1 = (GameObject)Instantiate(Bullet);
            bullet_1.transform.position = BulletPosition_1.transform.position;

            GameObject bullet_2 = (GameObject)Instantiate(Bullet);
            bullet_2.transform.position = BulletPosition_2.transform.position;
            timestamp = Time.time + timeBetweenShots;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Meteor"))
        {
            if (HealthControl.health <= 5)
            {
                if (collision.tag == "Meteor")
                {
                    Destroy(collision.gameObject);
                }
                playExplosion();
                HealthControl.health -= 1;
                invincible = true;
                Invoke("resetInvulnerability", 1);
                Reset();
            }

            if (collision.tag == "earth")
            {
                scores.count += 100;

                SceneManager.LoadScene(11);

                StartCoroutine(ShowMessage("+100", 1));
            }
            else if (collision.gameObject.tag == "PickUp")
            {
                coinSoundEffect.Play();
                Destroy(collision.gameObject);
                scores.count += 50;
                StartCoroutine(ShowMessage("+50", 2));
            }
            else if (collision.gameObject.tag == "Stop")
            {
                Pickupsound.Play();
                Destroy(collision.gameObject);
            }
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        CoinPlus.text = message;
        CoinPlus.enabled = true;

        yield return new WaitForSeconds(delay);
        CoinPlus.enabled = false;
    }

    private void Reset()
    {
        transform.position = StartPosition;
    }
    void resetInvulnerability()
    {
        invincible = false;
    }

    private void playExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimate);
        explosion.transform.position = transform.position;
    }
}
