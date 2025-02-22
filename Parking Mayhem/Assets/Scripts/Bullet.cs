﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    float speed;
    public GameObject ExplosionAnimate;


    // Use this for initialization
    void Start () {
        speed = 200f;
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 position = transform.position;

        position = new Vector2(position.x, position.y + speed * Time.deltaTime);

        transform.position = position;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Meteor"))
        {
            if (collision.tag == "Meteor")
            {
                Destroy(collision.gameObject);
            }
            playExplosion();
        }
    }

    private void playExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionAnimate);
        explosion.transform.position = transform.position;
    }
}