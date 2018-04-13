using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlienMovement : MonoBehaviour {

    public AudioSource AlienSoundEffect;
    public AudioSource ManScreamEffect;

    public GameObject SplatAnimate;
	public GameObject ExplosionAnimate;
	public GameObject target;
	public float moveSpeed;
	public float rotationSpeed;

	public Transform SwitchCheck;
	public float SwithRadius;
	public LayerMask WhatIsSwitch;
	private bool hittingSwitch;
	public bool stopMove;
	// Use this for initialization
	void Start () {
      
		AlienSoundEffect.Play();
	}

	// Update is called once per frame
	void Update () {
        

		hittingSwitch = Physics2D.OverlapCircle (SwitchCheck.position, SwithRadius, WhatIsSwitch);
		if (hittingSwitch)
			stopMove = !stopMove;
		if (stopMove) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, -moveSpeed * Time.deltaTime);
           
        } else {
           
            transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed * Time.deltaTime);
			Vector3 vectorToTarget = target.transform.position - transform.position;
			float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
			Quaternion qt = Quaternion.AngleAxis (angle, Vector3.forward);
			transform.rotation = Quaternion.RotateTowards (transform.rotation, qt, Time.deltaTime * rotationSpeed);

		}
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Car")
		{
			Destroy(collision.gameObject);
			playExplosion ();
		
		}
        else if (collision.tag == "Ped")
        {
            ManScreamEffect.Play();
            Destroy(collision.gameObject);
            playSplat();
        }
	}

	private void playExplosion ()
	{
		GameObject explosion = (GameObject)Instantiate(ExplosionAnimate);
		explosion.transform.position = transform.position;
	}
    private void playSplat()

    {
        GameObject splat = (GameObject)Instantiate(SplatAnimate);
        splat.transform.position = transform.position;
    }

}