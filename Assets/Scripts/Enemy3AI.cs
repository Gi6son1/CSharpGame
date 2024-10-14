using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;

public class Enemy3AI : MonoBehaviour
{
    Transform target; //will hold the transform component of thw player
    public float movementSpeed; //movement speed is set to 8
    public Animator animator;

    private void Start()
    {
        movementSpeed = Random.Range(5.0f, 8.3f);
        target = GameObject.Find("Skin1").GetComponent<Transform>(); //finds player in scene and gets transform component
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), movementSpeed * Time.deltaTime);
    }   //the enemy moves towards the player's x position at the specified movement speed
    private void OnBecameInvisible()
    {
        animator.enabled = false;
    }
    private void OnBecameVisible()
    {
        animator.enabled = true;
    }
}
