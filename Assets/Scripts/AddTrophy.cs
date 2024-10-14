using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class AddTrophy : MonoBehaviour
{
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    public string newTrophy; //this will hold the number of the unlocked trophy (can be changed in editor so i can apply this script in the survival mode)

    void Start()
    {
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        if (!fileContents[1].Contains(newTrophy)) //if the number of the trophy isnt already in the line containing the unlocked trophies
            fileContents[1] = fileContents[1] + newTrophy; //the line is updated with the unlocked trophy
        File.WriteAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt", fileContents); //file is updated with updated contents
    }
}
