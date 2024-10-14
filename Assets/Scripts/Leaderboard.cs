using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public SurvivalTimer survivalTimer; //this will hold the survival timer script
    int score; //will hold the score as a string
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    int numberExamined1; //will hold one of the scores to be examined for its position in the file
    int numberExamined2; //will hold another one of the scores to be examined for its position in the file
    string usernameExamined1; //will hold username relating to numberexamined1
    string usernameExamined2; //will hold username relating to numberexamined2
    public Text first; //this will hold the 1st text
    public Text second; //this will hold the 2nd text
    public Text third; //this will hold the 3rd text

    // Start is called before the first frame update
    void Start()
    {
        if (!File.Exists(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Leaderboard.txt")) //if leader board file doesnt exist
        {
            fileContents = new string[] { "0", "N/A", "0", "N/A", "0", "N/A" }; //the soon-to-be file contents are defined
            File.WriteAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Leaderboard.txt", fileContents); //create file and update with file contents
        }
        score = (int)survivalTimer.milliseconds; //the integer version of the score is held then turned into a string
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Leaderboard.txt"); //account file contents are read
        if (score > int.Parse(fileContents[4])) //if score is bigger than the lowest score
        {
            numberExamined1 = score; //the first number to be examined is the score
            usernameExamined1 = accountUsername; //the username to go with the score is defined
            for (int i = 0; i < 3; i++) //repeat 3 times
            {
                if (numberExamined1 > int.Parse(fileContents[i * 2])) //if the number to be examined is bigger than the file score
                {
                    numberExamined2 = int.Parse(fileContents[i * 2]); //the file score becomes numberexamined2
                    usernameExamined2 = fileContents[i * 2 + 1]; //the username that goes with number examined2 is the username that went with the file score
                    fileContents[i * 2] = numberExamined1.ToString(); //the number to be examined is writen to the filescore line 
                    fileContents[i * 2 + 1] = usernameExamined1; //the username related to the number to be examined is added below it
                    numberExamined1 = numberExamined2; //the filescore becomes the number to be examined
                    usernameExamined1 = usernameExamined2; //the username relating to the filescore becomes username to be examined
                }
            }
            File.WriteAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Leaderboard.txt", fileContents); //update with file contents
        }
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Leaderboard.txt"); //updated account file contents are read
        first.text = "1st:\n" + fileContents[1] + "     " + fileContents[0]; //the first text is changed to the relevant leaderboard info
        second.text = "2nd:\n" + fileContents[3] + "     " + fileContents[2]; //same for second
        third.text = "3rd:\n" + fileContents[5] + "     " + fileContents[4]; //same for third
    }
}
