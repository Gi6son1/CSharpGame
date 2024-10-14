using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthBar : MonoBehaviour
{
    float originalHealth; //will hold the boss' original health
    float currentHealth; //will hold the current health
    float healthPercentage; //will hold the percentage of health the boss has left
    public Transform bar; //will hold the transform component of the bar gameobject
    // Start is called before the first frame update
    void Start()
    {
        originalHealth = GameObject.Find("BossBody").GetComponent<EnemyHealth>().health; //original health is found at the start
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = GameObject.Find("BossBody").GetComponent<EnemyHealth>().health; //current health is found
        healthPercentage = currentHealth / originalHealth; //health percentage is calculated (% of health left)
        Vector3 scale = bar.localScale; //bar sprite scale variable is defined
        scale.x = healthPercentage; //the x scale becomes the health percentage
        transform.localScale = scale; //the bar is then scaled to the health percentage
    }
}
