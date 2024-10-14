using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ResetGameData : MonoBehaviour
{
    // Start is called before the first frame update
    public void Reset()
    {
        if (Directory.Exists(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts")) // if accounts folder exists
            Directory.Delete(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Accounts", true); //delets folder and contents
        if (File.Exists(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Leaderboard.txt")) //if leaderboard file exists
            File.Delete(GameObject.Find("FlashLetter").GetComponent<Text>().text + "\\Computing Project Program\\Game Files\\Leaderboard.txt"); //deletes file
        Application.Quit(); //closes game
    }
}
