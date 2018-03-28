using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCarMovement : MonoBehaviour
{
    public GameObject SplatAnimate;
    public GameObject ExplosionAnimate;
    public AudioSource coinSoundEffect;

    public float power = 3;
    public float maxspeed = 5;
    public float turnpower = 2;
    public float friction = 3;
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
        GetComponent<AudioSource>();
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
        if ((collision.tag == "Car") || (collision.tag == "Alien"))
        {
            if (HealthControl.health <= 5)
            {
                if (collision.tag == "Car")
                {
                    Destroy(collision.gameObject);
                }
                playExplosion();
                HealthControl.health -= 1;
                Reset();

            }
        }
        if (collision.tag == "Ped")
            {
            if (HealthControl.health <= 5)
            {
                Destroy(collision.gameObject);
                playSplat();
                HealthControl.health -= 2;
                Reset();
            }
            }

        
        else if (collision.tag == "Gsol")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads the next scene in next sequential order //
        }
        else if (collision.gameObject.tag == "PickUp")
        {
            coinSoundEffect.Play();
            Destroy(collision.gameObject);
            count += 50;
            StartCoroutine(ShowMessage("+50", 2));
             SetScoreText();



            

        }
    }

        IEnumerator ShowMessage (string message, float delay)
        {
            CoinPlus.text = message;
            CoinPlus.enabled = true;
        
            yield return new WaitForSeconds(delay);
            CoinPlus.enabled = false;
        }
    
    void SetScoreText()
       
    {
        ScoreText.text = "Coins: " + count.ToString();
    }
    

    private void Reset()
    {
        transform.position = StartPosition;
        transform.rotation = RotatePosition;
    }
    
    private void playExplosion ()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimate);
        explosion.transform.position = transform.position;
    }
    private void playSplat ()
        
    {
        GameObject splat = (GameObject)Instantiate(SplatAnimate);
        splat.transform.position = transform.position;
    }
}