using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    int playerHealth; //will hold the player's health
    // Update is called once per frame
    void Update()
    {
        playerHealth = GameObject.Find("Skin1").transform.GetChild(3).GetComponent<PlayerGeneral>().health; //health number is retrieved from the player's health script
        if (playerHealth < 0) //if the health is less than 0
            playerHealth = 0; //the health becomes 0
        gameObject.GetComponent<Text>().text = "HP: " + playerHealth; //the UI text is changed to show the current health
    }
}
