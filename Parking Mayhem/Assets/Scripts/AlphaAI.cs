using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaAI : MonoBehaviour {

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoint;
    int currentPatrolIndex;

    public Transform target;
    public float chaseRange;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;

    public GameObject projectile;
    public float fireForce;

    public float awarenessRange;
    public float distanceToTarget;

	// Use this for initialization
	void Start () {
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints[currentPatrolIndex];
	}
	
	// Update is called once per frame
	void Update () {
        //Check the distaance to the player
        distanceToTarget = Vector3.Distance(transform.position, target.position);

        //Check to see if the enemy is aware of the player else it patrols the area
        if (distanceToTarget > awarenessRange)
        {
            patrol();
        }
        if (distanceToTarget < awarenessRange && distanceToTarget > attackRange)
        {
            Chase();
        }
        if (distanceToTarget < attackRange)
        {
            Attack();
        }
	}

    void patrol()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
        //Check to see if AI reached a patrol point

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 15f)
        {
            // Reached the patrol point and goes the the next one
            //CHeck to see if we have anymore patrol point, if not returns to first point
          if (currentPatrolIndex * 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            } else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoint = patrolPoints[currentPatrolIndex];
        }
        //Turn to face the current patrol point
        //Finding the direction Vector that points to the patrolpoint
        Vector3 patrolPoinDir = currentPatrolPoint.position - transform.position;
        //Figure out the rotation in degrees that we need to turn towards
        float angle = Mathf.Atan2(patrolPoinDir.y, patrolPoinDir.x) * Mathf.Rad2Deg - 90f;
        //Made the rotation that we need to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Apply the rotation to our transform
        transform.rotation = Quaternion.RotateTowards (transform.rotation, q, 360f);

    }

    void Chase()
    {
        //Chases Player
        //Get the distance to the target and check to see if it is close enough to chase

        Vector3 patrolPointDir = currentPatrolPoint.position - transform.position;
        float angle = Mathf.Atan2(patrolPointDir.y, patrolPointDir.x) * Mathf.Rad2Deg - 90f;
        //Made the rotation that we need to face
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        //Apply the rotation to out transform
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 360f);
        transform.Translate(Vector3.up * Time.deltaTime * speed);

    }
   void Attack ()
    {
        Vector3 targetDir = target.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

        //Check to see if it's time to attack
        if (Time.time > lastAttackTime + attackDelay)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);
            // fire projectile
            GameObject newFire = Instantiate(projectile, transform.position, transform.rotation);
            newFire.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, fireForce));
            lastAttackTime = Time.time;
        }

    }
}

