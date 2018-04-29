using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HsirballFire : MonoBehaviour {

	public GameObject target;
	public float speed;
	public float rotationSpeed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.position = Vector3.MoveTowards (transform.position, target.transform.position, speed * Time.deltaTime);
		Vector3 vectorToTarget = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
		Quaternion qt = Quaternion.AngleAxis (angle, Vector3.forward);
		transform.rotation = Quaternion.RotateTowards (transform.rotation, qt, Time.deltaTime * rotationSpeed);
	}
}
