using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1bullet : MonoBehaviour {

	public GameObject play2;

	private void OnTriggerEnter2D(Collider2D collision){

		if (collision.tag == "Player2") {
			Destroy (this.gameObject);
		}
		if (collision.tag == "walls") {
			Destroy (this.gameObject);
		}
			
}

}