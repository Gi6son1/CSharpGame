using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveScore : MonoBehaviour
{
    public GameObject scoreText; //this will hold the text gameobject on the panel
    public SurvivalTimer survivalTimer; //this will hold the survival timer script
    string score; //will hold the score as a string
    public GameObject addTrophy; //holds the addtrophy game object
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    // Start is called before the first frame update
    void Start()
    {
        score = ((int)survivalTimer.milliseconds).ToString(); //the integer version of the score is held then turned into a string
        scoreText.GetComponent<Text>().text = score; //the text component of the text gameobject is set to the string
        if ((int)survivalTimer.milliseconds > 10000) //if score is over 10000
            addTrophy.SetActive(true); //activate game object
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        if (fileContents[3] == "N/A" || int.Parse(score) > int.Parse(fileContents[3])) //if highscore line is n/a or greater than the survival score
        {
            fileContents[3] = score; //the line is changed to the score
            File.WriteAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt", fileContents); //file is updated with updated contents
        }

    }
}
