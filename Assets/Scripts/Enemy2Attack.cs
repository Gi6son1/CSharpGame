using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Attack : MonoBehaviour
{
    bool canAttack; //will determine whether enemy can deal damage to the player or not
    Collider2D attackCollider; //this will hold the collider component of the attackskin gameobject
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true; //set to true
        attackCollider = GetComponent<Collider2D>(); //component is taken from attackskin
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack) //if enemy is able to attack
            attackCollider.enabled = true; //collider is enabled
        if (!canAttack) //if enemy is unable to attack
            attackCollider.enabled = false; //collider is disabled
    }
    private void OnTriggerEnter2D(Collider2D collision) //function that occurs when any object enters the collider
    {
        if (collision.gameObject.tag.Equals("Player")) //if object is the player
        {
            canAttack = false; //set to false  
            StartCoroutine(Wait()); //wait function is called
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f); //wait for one second
        canAttack = true; //set back to true (this means that the damage can be dealt only once per second, rather than every frame and breaking the game)
    }
}
