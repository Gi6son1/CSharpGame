using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class CustomisePlayer : MonoBehaviour
{
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    public GameObject Trophy1Highlight; //this will hold the first trophy highlight box
    public GameObject Trophy2Highlight; //this will hold the second trophy highlight box
    public GameObject Trophy3Highlight;  //this will hold the third trophy highlight box
    public GameObject CurrentSkin1; //this will hold the first skin game object in the current skin box
    public GameObject CurrentSkin2; //this will hold the second skin game object in the current skin box
    public GameObject CurrentSkin3; //this will hold the third skin game object in the current skin box

    // Start is called before the first frame update
    void Start()
    {
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
    }

    // Update is called once per frame
    void Update()
    {
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        if (fileContents[2].Contains("1")) //if the recent skin is skin1
        {
            Trophy1Highlight.SetActive(true); //skin 1 highlight box appears
            Trophy2Highlight.SetActive(false); //other highlight boxes disappear
            Trophy3Highlight.SetActive(false);
            CurrentSkin1.SetActive(true); //current skin appears as skin1
            CurrentSkin2.SetActive(false); 
            CurrentSkin3.SetActive(false);
        }
        if (fileContents[2].Contains("2")) //if recent skin is skin2
        {
            Trophy2Highlight.SetActive(true); //skin 2 highlight box appears
            Trophy3Highlight.SetActive(false); //other highlight boxes disappear
            Trophy1Highlight.SetActive(false);
            CurrentSkin1.SetActive(false); //current skin appears as skin2
            CurrentSkin2.SetActive(true);
            CurrentSkin3.SetActive(false);
        }
        if (fileContents[2].Contains("3")) //if recent skin is skin2
        {
            Trophy3Highlight.SetActive(true); //skin 3 highlight box appears
            Trophy2Highlight.SetActive(false); //other highlight boxes disappear
            Trophy1Highlight.SetActive(false);
            CurrentSkin1.SetActive(false); //current skin appears as skin3
            CurrentSkin2.SetActive(false);
            CurrentSkin3.SetActive(true);
        }
    }

    public void Customise(string skin) //function used to change the current skin using skin number defined in onClick() function
    {
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        fileContents[2] = skin.ToString(); //the file line with the recent skin changes to the defined skin number
        File.WriteAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt", fileContents); //file is updated with updated contents
    }
}
