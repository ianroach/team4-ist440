using System.Collections;

using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class PlayerCarMovement : MonoBehaviour
{
    
    public GameObject SplatAnimate;
    public GameObject ExplosionAnimate;
    public GameObject CatExplosionAnimate;
	public GameObject Bullet;

    public AudioSource coinSoundEffect;
	public AudioSource ManScreamSound;
	public AudioSource CarNoise;
	public AudioSource Pickupsound;

    public float power = 3;
    public float maxspeed = 5;
    public float turnpower = 2;
    public float friction = 3;
    public Vector2 curspeed;
    
    public Text CoinPlus;
    public Vector3 StartPosition;
    public Quaternion RotatePosition;

    

    new Rigidbody2D rigidbody2D;
    private ScoreManager scores;
	private bool invincible = false;


    // Use this for initialization
    void Start()
    {
     
     
        rigidbody2D = GetComponent<Rigidbody2D>();
        StartPosition = transform.position;
        RotatePosition = transform.rotation;
        
        CoinPlus.text = "";
        scores = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();

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
			CarNoise.Play ();
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
		if (!invincible) {
			if ((collision.tag == "Car") || (collision.tag == "Alien") || (collision.tag == "MonsterTruck")) {
				if (HealthControl.health <= 5) {
					if (collision.tag == "Car") {
						Destroy (collision.gameObject);
					}
					playExplosion ();
					HealthControl.health -= 1;
					invincible = true;
					Invoke ("resetInvulnerability", 2);

					Reset ();

				}
			} else if (collision.tag == "Ped") {
				if (HealthControl.health <= 5) {
					ManScreamSound.Play ();
					Destroy (collision.gameObject);
					playSplat ();
					HealthControl.health -= 1;
					invincible = true;
					Invoke ("resetInvulnerability", 2);

					Reset ();
				}
			} else if (collision.tag == "Cat") {
				if (HealthControl.health <= 5) {
					catPlayExplosion ();
					HealthControl.health -= 1;
					invincible = true;
					Invoke ("resetInvulnerability", 2);

					Reset ();
				}
			}
		}
        
		if (collision.tag == "Gsol") {
			scores.count += 100;
         
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); // Loads the next scene in next sequential order //  

			StartCoroutine (ShowMessage ("+100", 1));
		} else if (collision.gameObject.tag == "PickUp") {
			coinSoundEffect.Play ();
			Destroy (collision.gameObject);
			scores.count += 50;
			StartCoroutine (ShowMessage ("+50", 2)); 
		} else if (collision.gameObject.tag == "Stop") 
		{
			Pickupsound.Play ();
			Destroy (collision.gameObject);
			bullet ();
		}
	
    }

        IEnumerator ShowMessage (string message, float delay)
        {
            CoinPlus.text = message;
            CoinPlus.enabled = true;
        
            yield return new WaitForSeconds(delay);
            CoinPlus.enabled = false;
        }
    
  
    

    private void Reset()
    {
        transform.position = StartPosition;
        transform.rotation = RotatePosition;

	
		

    }
	void resetInvulnerability()
	{
		invincible = false;
	}
    
    private void playExplosion ()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimate);
        explosion.transform.position = transform.position;

    }
    private void catPlayExplosion()
    {
        GameObject Catexplosion = (GameObject)Instantiate(CatExplosionAnimate);
        Catexplosion.transform.position = transform.position;
    }
    private void playSplat ()
        
    {
        GameObject splat = (GameObject)Instantiate(SplatAnimate);
        splat.transform.position = transform.position;
	
    }
	private void bullet ()
	{
		GameObject bullet = (GameObject)Instantiate(Bullet);
		bullet.transform.position = transform.position;
	}
}