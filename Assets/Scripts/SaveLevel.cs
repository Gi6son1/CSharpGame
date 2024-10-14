using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveLevel : MonoBehaviour
{
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    int SaveFileLineNumber; //this will hold the line number of the new save file
    GameObject saveFileLine; //this will hold the saveFileLine gameobject
    public string newLevel; //this will hold the number of the next level (can be changed in editor so no new scripts need to be made if i want to add more levels)

    public void Save()
    {
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        saveFileLine = GameObject.Find("SaveFileLine"); //save file line gameobject is found
        SaveFileLineNumber = int.Parse(saveFileLine.GetComponent<Text>().text);  //save file line number is retrieved and turned into an integer
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        fileContents[SaveFileLineNumber] = (newLevel); //the save file line is updated with the number of the next level
        File.WriteAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt", fileContents); //file is updated with updated contents
    }
}
