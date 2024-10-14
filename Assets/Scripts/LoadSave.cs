using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class LoadSave : MonoBehaviour
{
    public GameObject box1; //here i am calling the savefile boxes and text boxes so that i can modify them
    public GameObject box2;
    public GameObject box3;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    string[] fileContents; //this array will hold the contents of each file
    string accountUsername; //will hold account username
    GameObject selectedAccount; //creates gameobject variable for selected account
    int numberOfSaves; //will hold the number of savefiles
    int saveBoxNumber; //will hold the current savebox needed to put data in
    string boxInfo; //will hold the save number to go in the box

    public void DisplaySaves() //function used to display the save files
    {
        saveBoxNumber = 0; //set to 0
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        numberOfSaves = fileContents.GetLength(0) - 4; //the number of save files are found by subtracting the number of irrelevant lines from the amount of lines in the array
        for (int i = 0; i < numberOfSaves; i++) //repeats for every save file
        {
            saveBoxNumber++; //increases by 1
            boxInfo = fileContents[(i + 4)]; //the contents is the save level from the save file line
            if (saveBoxNumber == 1) //if the number is 1
            {
                box1.SetActive(true); //box1 is visible
                text1.GetComponent<Text>().text = boxInfo; //the text is the information from the file
            }
            if (saveBoxNumber == 2)
            {
                box2.SetActive(true);  //same for box2
                text2.GetComponent<Text>().text = boxInfo;
            }
            if (saveBoxNumber == 3)
            {
                box3.SetActive(true);   //same for box3
                text3.GetComponent<Text>().text = boxInfo;
            }
        }
    }
}
