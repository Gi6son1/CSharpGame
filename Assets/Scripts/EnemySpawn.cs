using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public SurvivalTimer survivalTimer; //this will hold the survival timer script
    int score; //this will hold the integer version of the millisecond score
    int spawnChance; //this will hold the end number from the random number generator
    int enemyTypeNumber; //this will hold the enemy type number to be spawned
    int addedHealth; //this will hold the health added to the enemy if the score exceeds 7500 
    bool canSpawn; //this will determine if enemy is able to spawn
    bool eligiblePlatform; //will determine if platform is eligible to spawn on
    public GameObject spawnLocations; //will hold the spawn positions gameobject
    GameObject spawnPlatform; //will hold spawnlocation game object
    GameObject spawnedEnemy; //will hold the enemy to be spawned
    public GameObject enemy1; //holds the enemy1 game object
    public GameObject enemy2; //holds enemy2 game object
    public GameObject enemy3; //holds enemy3 game object
    public GameObject enemy4; //holds enemy4 game object

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = false; //set to false
        StartCoroutine(Wait()); //starts wait function
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("Skin1") != null) && canSpawn) //if player is not dead and canspawn set to true
        {
            canSpawn = false; //set to false
            StartCoroutine(Wait()); //starts wait function
            score = (int)survivalTimer.milliseconds; //the integer version of the score is held
            EnemyDifficulty(score); //the enemy difficulty function is called 
        }
    }
    IEnumerator Wait() //wait function
    {
        yield return new WaitForSeconds(2f); //wait two seconds
        canSpawn = true; //set to true (enemy can spawn again)
    }

    void EnemyDifficulty(int score) //this is the function that determines what enemy spawns
    {
        addedHealth = 0; //set to 0
        spawnChance = Random.Range(1, (score + 1)); //random number chosen between 1 and player score (+1 because then a number is chosen between 1 and score INCLUSIVELY)
        if (spawnChance <= 1000) //if the number is less than or equal to 1000
            spawnedEnemy = enemy1; //the enemy type is enemy1
        if (spawnChance > 1000 && spawnChance <= 4500)  //if between 1000 and 4500
        {
            enemyTypeNumber = Random.Range(2, 4); //there is a 50/50 chance that it will be enemy2 or enemy3 ((2, 4) means either 2 or 3)
            if (enemyTypeNumber == 2) //if the number is 2
                spawnedEnemy = enemy2; //set to enemy2
            else //if not 2
                spawnedEnemy = enemy3; //set to enemy3
        }
        if (spawnChance > 4500) //if greater than 4500
            spawnedEnemy = enemy4; //the enemy is enemy4
        if (score >= 7500) //if the score is bigger than 7500
        {
            addedHealth = score / 200; //the added health is the score divided by 2
        }
        SpawnEnemy(spawnedEnemy, addedHealth); //calls function with the added health and the enemy to be spawned
    }
    void SpawnEnemy(GameObject spawnedEnemy, int addedHealth) //this function spawns the enemy in to the correct location
    {
        eligiblePlatform = false; //set to false
        while (!eligiblePlatform) //while false
        {
            spawnPlatform = spawnLocations.transform.GetChild(Random.Range(0, 14)).gameObject; //choose a random spawn location
            if (spawnPlatform.GetComponent<VisibilityCheck>().offscreen) //if it is offscreen
            {
                eligiblePlatform = true; //set to true
            }
        }
        GameObject temporaryEnemy; //creates a game object variable  (doing this means when adding health, it isnt added to the prefab which can cause errors)
        temporaryEnemy = Instantiate(spawnedEnemy, spawnPlatform.transform.position, Quaternion.identity) as GameObject; //spawn enemy in spawn location as the variable
        if (spawnedEnemy == enemy4) //if enemy is enemy4
            temporaryEnemy.transform.GetChild(3).GetComponent<EnemyHealth>().health += addedHealth; //add the added health to the child object containing the script 
        else
        {
            temporaryEnemy.GetComponent<EnemyHealth>().health += addedHealth; // add the added health to the enemy 
        }
    }
}
