using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Attack : MonoBehaviour
{
    public GameObject BulletEmitter; //calls the bullet emitter game object
    public GameObject EnemyBullet; //calls the enemy bullet game object
    GameObject player;
    float BulletForwardForce = 500f; //this variable dictates how fast the bullet travels
    int direction = 1;
    bool facingUp = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Skin1");
        InvokeRepeating("ShootRaycast", 0f, 1f); //carries out the function once per second
    }

    // Update is called once per frame
    void Update()
    {
        var localdistance = player.transform.InverseTransformPoint(transform.position); //finds distance between enemy and player
        if (localdistance.y < -3f && !facingUp)
        {
            Vector3 theScale = transform.parent.localScale; //player sprite scale is defined
            theScale.y *= -1f; //the x-axis scale is reversed
            transform.parent.localScale = theScale; //the new scale is set to the player
            direction = 1; //set to -1
            facingUp = true;
        }
        if (localdistance.y > 3f && facingUp)
        {
            Vector3 theScale = transform.parent.localScale; //player sprite scale is defined
            theScale.y *= -1f; //the x-axis scale is reversed
            transform.parent.localScale = theScale; //the new scale is set to the player
            direction = -1; //set to -1
            facingUp = false;
        }
    }
    void ShootRaycast() //function for shooting
    {         //here i shoot a raycast upwards so that if the player is above, the message is sent
              //the ray also only operates on the player layer, so that other objects do not get in the way and block the ray
        RaycastHit2D hitInfoUp = Physics2D.Raycast(transform.position, Vector2.up, Mathf.Infinity, 1 << LayerMask.NameToLayer("Player"));
        RaycastHit2D hitInfoDown = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, 1 << LayerMask.NameToLayer("Player"));
        if (hitInfoUp || hitInfoDown) //if any of the rays hit the player
        {
            GameObject TemporaryBulletHandler; //creates a game object that will act as the bullet     /*/ this spawns the object as a bullet at the bullet emitter location/*/
            TemporaryBulletHandler = Instantiate(EnemyBullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject;
            TemporaryBulletHandler.transform.Rotate(0f, 0f, -90f); //rotates bullet 90 degrees to make it come out straight
            Rigidbody2D TemporaryRigidBody; //creates a rigidbody variable that will control the physics for the bullet
            TemporaryRigidBody = TemporaryBulletHandler.GetComponent<Rigidbody2D>(); //calls the rigidbody2D component of the bullet
            TemporaryRigidBody.AddForce(transform.up * BulletForwardForce * direction); //fires the bullet upwards at the bulletforce that was set at the start
            Destroy(TemporaryBulletHandler, 8.0f); //destroys the bullet after 8 seconds, this means the computer won't be slowed down due to lots of objects in the game
        }
    }
}
