using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowTrophies : MonoBehaviour
{
    public GameObject Feat2; //this will hold the trophy 2 text object
    public GameObject Feat3; //this will hold the trophy 3 text object
    public GameObject Trophy2Skin; //this will hold the trophy 2 skin image
    public GameObject Trophy3Skin;  //this will hold the trophy 3 skin image
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    public Button Trophy2Button; //this will hold the trophy 2 button
    public Button Trophy3Button;  //this will hold the trophy 3 button

    // Start is called before the first frame update
    void Start()
    {
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        if (fileContents[1].Contains("2")) //if the file contains 2 (trophy2 unlocked)
        {
            Trophy2Skin.SetActive(true); //skin is shown
            Feat2.SetActive(false); //feat message disappears
            Trophy2Button.interactable = true; //button becomes clickable
        }
        if (fileContents[1].Contains("3")) //if the file contains 3 (trophy2 unlocked)
        {
            Trophy3Skin.SetActive(true); //skin is shown
            Feat3.SetActive(false); //feat message disappears
            Trophy3Button.interactable = true; //button becomes clickable
        }
    }

}
