using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyJumpToPlatform : MonoBehaviour
{
    public float jumpPower; //creates a float that will hold how high enemy will jump to reach platform
    public float forwardForce; //creates a float that will hold how much force enemy will move along x-axis to reach platform
    Transform player; //holds the location of the player
    public float heightNeeded = -3f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Skin1").GetComponent<Transform>(); //transform component found for player in scene
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision) //if object enters circle collider
    {
        if (collision.transform.gameObject.tag.Equals("enemy")) //if object is an enemy
        {
            var localdistance = player.transform.InverseTransformPoint(collision.transform.position); //finds distance between enemy and player
            if ((localdistance.y < heightNeeded) && (Math.Sign(forwardForce) == Math.Sign(collision.GetComponent<Rigidbody2D>().velocity.x))) //if player is above enemy
            {
                collision.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPower); //add jump force
                collision.GetComponent<Rigidbody2D>().AddForce(Vector2.right * forwardForce); //add forward force
            }
        }
    }
}
