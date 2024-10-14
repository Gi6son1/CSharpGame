using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Attack : MonoBehaviour
{
    public Rigidbody2D rb; //holds the rigidbody component of the enemy to find its direction
    int direction; //holds the direction that the enemy is facing
    public GameObject BulletEmitter; //calls the bullet emitter game object
    public GameObject EnemyBullet; //calls the enemy bullet game object
    float BulletForwardForce = 500f; //this variable dictates how fast the bullet travels
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootRaycast", 1f, 1f); //carries out the function once per second
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x >= 0.01f) // if enemy is travelling left
            direction = -1; //set to -1
        if (rb.velocity.x <= -0.01f) //if enemy is travelling right
            direction = 1; //set to -1
    }
    void ShootRaycast() //function for shooting
    {         //here i shoot raycasts both sides of the enemy so that if the player is on either side, the message is sent without the enemy body blocking the ray
                //the rays also only operate on the player layer, so that other objects do not get in the way and block the ray
        RaycastHit2D hitInfoLeft = Physics2D.Raycast(transform.position, -Vector2.right, Mathf.Infinity, 1 << LayerMask.NameToLayer("Player")); //shoots left
        RaycastHit2D hitInfoRight = Physics2D.Raycast(transform.position, Vector2.right, Mathf.Infinity, 1 << LayerMask.NameToLayer("Player"));  //shoots right
        if (hitInfoLeft || hitInfoRight) //if any of the rays hit the player
        {
            GameObject TemporaryBulletHandler; //creates a game object that will act as the bullet     /*/ this spawns the object as a bullet at the bullet emitter location/*/
            TemporaryBulletHandler = Instantiate(EnemyBullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
            Rigidbody2D TemporaryRigidBody; //creates a rigidbody variable that will control the physics for the bullet
            TemporaryRigidBody = TemporaryBulletHandler.GetComponent<Rigidbody2D>(); //calls the rigidbody2D component of the bullet
            TemporaryRigidBody.AddForce(-transform.right * BulletForwardForce * direction); //fires the bullet outwards at the bulletforce that was set at the start
            Destroy(TemporaryBulletHandler, 8.0f); //destroys the bullet after 8 seconds, this means the computer won't be slowed down due to lots of objects in the game
        }
    }
}
