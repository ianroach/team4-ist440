using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class CarMovement : MonoBehaviour
{

    public float power = 3;
    public float maxspeed = 5;
    public float turnpower = 2;
    public float friction = 3;
    public int maxHealth = 4;
    public Vector2 curspeed;
    public Text ScoreText;
    public Text CoinPlus;
    public Vector3 StartPosition;
    public Quaternion RotatePosition;

    

    new Rigidbody2D rigidbody2D;
    private int count;
    

    // Use this for initialization
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
        RotatePosition = transform.rotation;
        count = 0;
        CoinPlus.text = "";
        SetScoreText();
        

    }


    void FixedUpdate()
    {
        curspeed = new Vector2(rigidbody2D.velocity.x, rigidbody2D.velocity.y);

        if (curspeed.magnitude > maxspeed)
        {
            curspeed = curspeed.normalized;
            curspeed *= maxspeed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rigidbody2D.AddForce(transform.up * power);
            rigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rigidbody2D.AddForce(-(transform.up) * (power / 2));
            rigidbody2D.drag = friction;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * turnpower);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * -turnpower);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Car")
        {
            HealthControl.health -= 1;
            Reset();
            
        }
        else if (collision.tag == "Gsol")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (collision.gameObject.tag == "PickUp")
        {
            Destroy(collision.gameObject);
            count += 50;
            SetScoreText();
          
            
        }
    }
    void SetScoreText()
       
    {
        ScoreText.text = "Tokens: " + count.ToString();
    }
    private void Reset()
    {
        transform.position = StartPosition;
        transform.rotation = RotatePosition;
    }
}