using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class NewSave : MonoBehaviour
{
    string[] fileContents;  //this array will hold the contents of the player's account file
    GameObject selectedAccount; //this is creating a gameobject variable that will hold the selected account gameobject
    string accountUsername; //this string will hold the player's account name
    int SaveFileLineNumber; //this will hold the line number of the new save file

    // Start is called before the first frame update
    public void newSave()
    {
        selectedAccount = GameObject.Find("Selected Account"); //selected account gameobject is found
        accountUsername = selectedAccount.GetComponent<Text>().text; //account username is retrieved from game object
        fileContents = File.ReadAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //account file contents are read
        if (fileContents[4] == "N/A") //if there is no previous save file
        {
            fileContents[4] = "1"; //the "N/A" line is changed to 1 (level 1), updating the contents array
            File.WriteAllLines(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt", fileContents); //file is updated with updated contents
            SaveFileLineNumber = 4; //set to 4
            level1(SaveFileLineNumber); //function called with save file number
        }
        else if (fileContents[4] != "N/A") //if the first save file line is not N/A (if there is at least one save file)
        {
            StreamWriter userFile = File.AppendText(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts\\" + (accountUsername) + ".txt"); //file is opened in append mode
            userFile.WriteLine("1"); //a new line is written to the file
            userFile.Close(); //file is saved
            SaveFileLineNumber = fileContents.GetLength(0); //the save file number is set to the length of the filecontents array
            level1(SaveFileLineNumber); //function called with save file level
        }
    }
    void level1(int SaveFileLineNumber) //this function uses the save file level and is used to load level 1
    {
        DontDestroyOnLoad(selectedAccount); //selected account game object will not be destroyed when next scene loaded
        new GameObject("SaveFileLine").AddComponent<Text>().text = (SaveFileLineNumber.ToString()); //save file line gameobject is made and a text component added with the save file line number
        DontDestroyOnLoad(GameObject.Find("SaveFileLine")); //save file line object will not be destroyed on load
        DontDestroyOnLoad(GameObject.Find("Selected Account"));
        DontDestroyOnLoad(GameObject.Find("FlashLetter"));
        DontDestroyOnLoad(GameObject.Find("Music"));
        DontDestroyOnLoad(GameObject.Find("SoundFX"));
        SceneManager.LoadScene(7); //scene 7 loaded (level 1)
    }
}
