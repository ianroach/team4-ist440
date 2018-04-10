using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

	// Use this for initialization
	void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints [currentPatrolIndex];
	}

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //Check to see if we have reached the patrol point
        if (Vector3.Distance(transform.position,currentPatrolPoint.position)  < 20f)
        //We have reached the patrol point - get the next one
        //Check to see if we have anymore patrol points - if not go bback to the begining
        {
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
        //Turn to face the current patrol point
        //Figure out the rotation in degrees that we need to turn towards
        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg -90f;
        //Made the rotation that we need to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Apply the rotation to out transform
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 360f);
    }
    }


