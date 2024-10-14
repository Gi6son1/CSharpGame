using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Dodge : MonoBehaviour
{
    public float dodgeForce; //will control what direction and how fast each dodge it
    public Rigidbody2D Enemy4; //takes the rigidbody component of enemy
    public Collider2D dodgeUp1; //these are all the dodge collider components of the enemy
    public Collider2D dodgeLeft1;
    public Collider2D dodgeRight1;
    public Collider2D dodgeUp2;
    public Collider2D dodgeLeft2;
    public Collider2D dodgeRight2;
 
    private void OnTriggerEnter2D(Collider2D collision) //if object enters a dodge collider
    {
        if ((collision.transform.gameObject.tag.Equals("PlayerMelee")) || (collision.transform.gameObject.tag.Equals("PlayerBullet"))) //if object is an player attack
        {
            if ((gameObject.name == "DodgeLeft") || (gameObject.name == "DodgeRight")) //if collider is dodge right/left collider
            {
                dodgeUp1.enabled = false; //disables all the dodge colliders
                dodgeRight1.enabled = false;
                dodgeLeft1.enabled = false;
                dodgeUp2.enabled = false;
                dodgeRight2.enabled = false;
                dodgeLeft2.enabled = false;
                StartCoroutine(Wait()); //calls wait function
                Enemy4.AddForce(-Vector2.right * dodgeForce); //add left/right dodge force
            }
            if (gameObject.name == "DodgeUp") //if collider is dodge up collider
            {
                dodgeUp1.enabled = false; //disables all dodge colliders
                dodgeRight1.enabled = false;
                dodgeLeft1.enabled = false;
                dodgeUp2.enabled = false;
                dodgeRight2.enabled = false;
                dodgeLeft2.enabled = false;
                StartCoroutine(Wait()); //calls wait function
                Enemy4.AddForce(Vector2.up * dodgeForce); //add upwards dodge force
            }
        }
    }
    IEnumerator Wait() //wait function
    {
        yield return new WaitForSeconds(5f); //wait for 5 seconds
        dodgeUp1.enabled = true; //enables all the dodge colliders (limiting the colliders means the enemy cannot continously dodge attacks and never be hit)
        dodgeRight1.enabled = true;
        dodgeLeft1.enabled = true;
        dodgeUp2.enabled = true;
        dodgeRight2.enabled = true;
        dodgeLeft2.enabled = true; 
    }
}
