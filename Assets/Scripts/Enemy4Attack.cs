using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Attack : MonoBehaviour
{
    float BulletForwardForce = 20f;  //this will hold the bullet forward force
    Transform player; //will hold the transform component of the player
    public GameObject EnemyBullet; //will call the enemy bullet gameobject
    Vector2 direction; //will hold the direction from enemy to player
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1f, 0.75f); //calls shoot function every 0.75 seconds, starting 1 second after being loaded in
        player = GameObject.Find("Skin1").GetComponent<Transform>(); //gets the transform component of player
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToTarget = player.position - transform.position; //finds vector from enemy to player
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg; //calculates the angle
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward); //creates the rotation needed
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 50); //rotates the bullet emitter towards player
    }
    void Shoot()
    {

        direction = (player.position - transform.position).normalized * BulletForwardForce; //direction is calculated, then bullet speed is added
        GameObject TemporaryBulletHandler; //creates a game object that will act as the bullet     /*/ this spawns the object as a bullet at the bullet emitter location/*/
        TemporaryBulletHandler = Instantiate(EnemyBullet, transform.position, transform.rotation) as GameObject;
        Rigidbody2D TemporaryRigidBody; //creates a rigidbody variable that will control the physics for the bullet
        TemporaryRigidBody = TemporaryBulletHandler.GetComponent<Rigidbody2D>(); //calls the rigidbody2D component of the bullet
        TemporaryRigidBody.velocity = new Vector2(direction.x, direction.y); //uses the direction variable to add velocity to the bullet
        Destroy(TemporaryBulletHandler, 4.0f); //destroys the bullet after 4 seconds, this means the computer won't be slowed down due to lots of objects in the game
    }
}
