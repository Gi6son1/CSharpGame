using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class CheckForSavefiles : MonoBehaviour
{
    public GameObject newButton; //calls the new save button so i can modify it
    public GameObject loadButton; //calls the load save button so i can modify it
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name

    // Start is called before the first frame update
    void Start()
    {
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        if (fileContents[4] != "N/A") //if the first save file line is not N/A (if there is at least one save file)
            loadButton.SetActive(true); //load button is made visible (player can load a save)
        if (fileContents.GetLength(0) < 7) //if the length of all lines in the file is less than 7 (if there is no 3rd save file)
            newButton.SetActive(true); //new save button is made visible (player can create a new save)
    }
}
