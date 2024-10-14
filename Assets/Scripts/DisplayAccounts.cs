using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DisplayAccounts : MonoBehaviour
{
    public GameObject box1; //here i am calling the account boxes and text boxes so that i can modify them
    public GameObject box2;
    public GameObject box3;
    public GameObject box4;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    string[] fileContents; 
    string[] files;
    int accountFiles;
    string userName; //will hold the username of the account being read
    string highScore; //will hold the highscore of the account being read
    string saveFileLevel; //will hold the save file level of the account being read
    string[] boxData; //will hold the information of the account that will be put in the text box
    public GameObject currentAccountText; //calls the current account text object so i can modify it

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.Find("Selected Account") == null) //if there is no selected account game object
        {
            new GameObject("Selected Account").AddComponent<Text>(); //make one and add a text component to it
        }

    }

    // Update is called once per frame
    void Update()
    {
     
    }
    public void display()
    {
        accountFiles = 0; //number of account files are reset
        files = Directory.GetFiles(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts"); //get all the path of the files in the folder
        foreach (string filename in files) //increases the accountfiles variable by one for every path in the string
        {
            accountFiles++; //increases by one
            boxData = new string[5]; //the length of the array is defined so that it can hold all of the account values for all the accounts
            fileContents = File.ReadAllLines(filename); //reads the contents of each file
            userName = fileContents[0]; //the username is taken from the first line
            highScore = fileContents[3]; //the highscore is taken from the fourth line
            saveFileLevel = fileContents[4]; //the save file level is taken from the fifth line
            boxData[accountFiles] = userName + "\n\nHighscore: " + highScore + "\nSave File Level: " + saveFileLevel; //the information for the text box
            if (accountFiles == 1) //if the account is the first file seen, the first box appears with the account info
            {
                box1.SetActive(true);
                text1.GetComponent<Text>().text = boxData[accountFiles]; //the text is the information from the file
            }
            if (accountFiles == 2) //same for second file
            {
                box2.SetActive(true);
                text2.GetComponent<Text>().text = boxData[accountFiles];
            }
            if (accountFiles == 3) //same for third file
            {
                box3.SetActive(true);
                text3.GetComponent<Text>().text = boxData[accountFiles];
            }
            if (accountFiles == 4) //same for fourth file
            {
                box4.SetActive(true);
                text4.GetComponent<Text>().text = boxData[accountFiles];
            }
        }
        currentAccountText.GetComponent<Text>().text = "Current Account: " + GameObject.Find("Selected Account").GetComponent<Text>().text;
        //this changes the text in the current account text to show the account that is currently being used
    }


}
