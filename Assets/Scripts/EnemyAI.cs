using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding; //allows me to use commands and functions for the pathfinding scripts

public class EnemyAI : MonoBehaviour
{
    Transform target; //calls the transform element of the enemy's target (thr player sprite)
    public float movementSpeed; // creates a variable that controls speed of enemy. It is not pre-set so that i can reuse the script for other enemies.
    public float nextWaypointDistance = 3f; //creates a variable that defines the distance between each waypoint in the enemies path.
    public Animator animator; //calls the animator component

    Path path; //creates a path called path
    int currentWaypoint = 0; //the current waypoint number is set to 0
    bool reachedEndOfPath = false; //a bool is created that says that the enemy has not reached the end of the path

    Seeker seeker; //creates a seeker component called seeker
    Rigidbody2D rb; //creates the rigidbody component called rb

    void Start() //function called before first frame update
    {
        Physics2D.IgnoreLayerCollision(9, 9); //stops enemies from colliding with eachother
        seeker = GetComponent<Seeker>(); //seeker script is retrived from enemy components
        rb = GetComponent<Rigidbody2D>(); //rigidbody component retrieved from enemy components
        InvokeRepeating("UpdatePath", 0f, 0.5f); //sets it so that the path is updated every half second
        target = GameObject.Find("Skin1").GetComponent<Transform>();
    }

    void UpdatePath() //script that updates path
    {
        if (seeker.IsDone()) //if bool from seeker script (path has been created)
        {
            seeker.StartPath(rb.position, target.position, OnPathComplete); //create a new path (updating path)
        }
    }

    void OnPathComplete(Path p)
    {
        if (!p.error) //if no error is found
        {
            path = p;
            currentWaypoint = 0; //waypoint is reset
        }
    }
    void FixedUpdate() //updates a fixed amount per second
    {
        if (path == null) //if there is no path
        {
            return; //returns out of function
        }
        if (currentWaypoint >= path.vectorPath.Count) //if current waypoint number is greater/equal to the number of waypoints created in the path
        {
            reachedEndOfPath = true; //the enemy has reached end of path
            return;
        }
        else
        {
            reachedEndOfPath = false; //if not, the enemy has not reached end of path
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized; //vector is created, which sets direction from enemy to next waypoint in path
        Vector2 force = direction * movementSpeed * Time.deltaTime; //force variable is created from the movement speed and direction
        rb.AddForce(force); //force is applied to enemy sprite
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]); //distance variable is created from enemy to next waypoint in path
        if (distance < nextWaypointDistance) //if the distance is is less than the next waypoint distance
        {
            currentWaypoint++; //current waypoint increases by 1
        }
        if (rb.velocity.x >= 0.01f) // if enemy is travelling left
        {
            transform.localScale = new Vector3(-1.75f, 1.75f, 1f); //enemy flipped to face left
        }
        if (rb.velocity.x <= -0.01f) //if enemy is travelling right
        {
            transform.localScale = new Vector3(1.75f, 1.75f, 1f); //enemy flipped to face right
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); //sets speed variable to the positive version of the enemy velocity
    }
    private void OnBecameInvisible()
    {
        animator.enabled = false;
    }
    private void OnBecameVisible()
    {
        animator.enabled = true;
    }
}

