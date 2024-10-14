using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDeathLeaderboard : MonoBehaviour
{
    public GameObject leaderBoard; //will hold the leaderboard panel
    public GameObject healthUI; //will hold health ui gameobject
    GameObject[] enemies; //gameobject array will hold list of enemies

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Skin1") == null) //if player is dead
        {
            StartCoroutine(Wait()); //start wait function
        }
    }
    IEnumerator Wait() //wait function
    {
        yield return new WaitForSeconds(1f); //wait for one second
        enemies = GameObject.FindGameObjectsWithTag("enemy"); //finds all enemies in scene
        for (int i = 0; i < enemies.GetLength(0); i++) //repeat for every enemy
            Destroy(enemies[i]); //delete enemy (deletes all enemies)
        healthUI.SetActive(false); //make health UI disappear
        leaderBoard.SetActive(true); //make leaderboard appear
    }
}
