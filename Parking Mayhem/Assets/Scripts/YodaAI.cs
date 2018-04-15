using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YodaAI : MonoBehaviour {

	public GameObject projectile;
	public GameObject target;

	public float speedFactor;
	public float delay;
	public float moveSpeed;
	public float rotationSpeed;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


		fire ();
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, moveSpeed * Time.deltaTime);
		Vector3 vectorToTarget = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
		Quaternion qt = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, qt, Time.deltaTime * rotationSpeed);
			
	
}
	IEnumerator fire()
	{
		while (true) {

			GameObject clone = (GameObject)Instantiate (projectile, transform.position, Quaternion.identity);
			clone.GetComponent <Rigidbody2D> ().velocity = transform.up * speedFactor;
			yield return new WaitForSeconds(delay);
		}
	}
}

