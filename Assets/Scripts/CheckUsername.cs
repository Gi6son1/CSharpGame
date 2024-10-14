using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO; //enabling this part allows me to access the program files

public class CheckUsername : MonoBehaviour
{
    bool badUsername; //will determine if username is taken
    int accountFiles; //holds number of account files in folder
    string[] files; //will hold all the paths to the files
    string[] fileContents; //will hold the contents of each file
    public InputField InputField; //calls the Input field object so i can refer to it
    public Text WarningText; //calls the "red" text in the create account window so i can modify it
    public GameObject AccountCreatedPanel; //calls the panel so i can modify it
    public GameObject CreateAccountPanel; //calls the panel so i can modify it

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void check()
    {
        badUsername = false; //sets to false
        files = Directory.GetFiles(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts");
        foreach (string filename in files)
        {
            accountFiles++;
        }
        foreach (string filename in files) //for each file in the string
        {
            fileContents = File.ReadAllLines(filename); //reads the contents of each file
            if (fileContents[0] != InputField.text) //if the entered username doesn't match the one in the file 
            {
                badUsername = false; //it is set to false
            }
            if (fileContents[0] == InputField.text) //if it does
            {
                badUsername = true;//it is set to true
                WarningText.gameObject.SetActive(true); //the red text shows up
                break; //the loop terminates
            }
        }

        if (!badUsername)//if it is not taken
        {
            var UserFile = File.CreateText(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (InputField.text) + ".txt"); //a text file is created in the accounts folder
            UserFile.WriteLine(InputField.text); //the username is written to the first line
            UserFile.WriteLine("1"); //the base skin number is written to the second line
            UserFile.WriteLine("1"); //recent skin is set to base skin (third line)
            UserFile.WriteLine("N/A"); //the highscore (none) is written to the fourth line
            UserFile.WriteLine("N/A"); //the save level (none) is written to the fifth line
            UserFile.Close(); //closes the file, and saves the modifications
            CreateAccountPanel.gameObject.SetActive(false); //the create account panel disappears
            AccountCreatedPanel.gameObject.SetActive(true); //the account created panel appears
            if (GameObject.Find("Selected Account") == null)
                new GameObject("Selected Account").AddComponent<Text>();
            GameObject.Find("Selected Account").GetComponent<Text>().text = InputField.text; //makes the selected account name the new account name
        }

    }
}
