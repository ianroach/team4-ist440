using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor_Destroy : MonoBehaviour {


    public GameObject ExplosionAnimate;

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
